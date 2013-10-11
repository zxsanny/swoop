Imports System.Text
Public Class frmSaveRestoreTorrentsLabels
    Dim mySave As New SaveFileDialog
    ''' <summary>
    ''' Сюда собираем инфу для сохранения в файл и сюда же подгружаем из файла
    ''' </summary>
    ''' <remarks></remarks>
    Dim SavedInfo As New StringBuilder
    Dim RestoredInfo As String
    Dim torC As New List(Of torrentInfo)
    Dim StatusOfChangingLabels As String = ""
    Private Sub frmSaveRestoreTorrentsLabels_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Icon = WindowsApplication1.My.Resources.Keepers
        rbSaveLabelsToFile.Checked = True
        rbSaveLabelsToFile_CheckedChanged(sender, e)
    End Sub

    Private Sub rbSaveLabelsToFile_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbSaveLabelsToFile.CheckedChanged
        If rbSaveLabelsToFile.Checked = True Then
            TSSLbl.Text = "Щелкните кнопку ""Выполнить"" для сохранения хэшей и меток в файл"
            btnExecute.Enabled = True
        End If

    End Sub

    Private Sub rbRestoreLabelsFromFile_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbRestoreLabelsFromFile.CheckedChanged
        If rbRestoreLabelsFromFile.Checked = True Then
            gbRestoreLabelsFromFile.Enabled = True
            CheckFile()
        Else
            gbRestoreLabelsFromFile.Enabled = False
        End If
    End Sub

    Private Sub btnSelectFile_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSelectFile.Click
        Call frmSettings.SelOpenFile("Выберите файл с сохранёнными хэшами и метками", "Файл хэшей-меток (*.wlolbl)|*.wlolbl|Все файлы (*.*)|*.*", My.Application.Info.DirectoryPath)
        If myOpenFile.ShowDialog = DialogResult.OK Then txtFileName.Text = myOpenFile.FileName
        CheckFile()
    End Sub

    Private Sub CheckFile()
        If My.Computer.FileSystem.FileExists(txtFileName.Text) = True Then
            btnExecute.Enabled = True
            TSSLbl.Text = "Файл с хэшами и метками выбран. Можно запускать восстановление."
        Else
            btnExecute.Enabled = False
            TSSLbl.Text = "Выберите файл с хэшами и метками."
        End If
    End Sub

    Private Sub btnExecute_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExecute.Click
        If rbSaveLabelsToFile.Checked = True Then
            SavedInfo = CollectSavedInfo(SavedInfo)
            mySave.Title = "Сохранить как"
            mySave.Filter = "Файл хэшей-меток (*.wlolbl)|*.wlolbl|Все файлы (*.*)|*.*"
            mySave.InitialDirectory = My.Application.Info.DirectoryPath
            If mySave.ShowDialog = DialogResult.OK Then
                Try
                    My.Computer.FileSystem.WriteAllText(mySave.FileName, SavedInfo.ToString, False, System.Text.Encoding.UTF8)
                    MessageBox.Show(Me, "Данные успешно сохранены", "Сообщение", vbOKOnly, MessageBoxIcon.Information)
                Catch ex As Exception
                    MessageBox.Show(Me, "Данные не удалось сохранить", "Ошибка", vbOKOnly, MessageBoxIcon.Error)
                End Try
            End If
        ElseIf rbRestoreLabelsFromFile.Checked = True Then
            If My.Computer.FileSystem.FileExists(txtFileName.Text) = True Then
                Try
                    RestoredInfo = My.Computer.FileSystem.ReadAllText(myOpenFile.FileName, System.Text.Encoding.UTF8)
                    'Сначала получим данные из торрент-клиента и проверим, сколько раздач в торрент-клиенте
                    torC.Clear()
                    frmMain.OprosTorrentClienta(torC)
                    If torC.Count < 1 Then
                        MessageBox.Show(Me, "Сейчас в торрент-клиенте нет ни одной раздачи, нечего и восстанавливать", "Информация", vbOKOnly, MessageBoxIcon.Exclamation)
                        Exit Sub
                    End If
                    btnExecute.Enabled = False
                    BgrndWorker.RunWorkerAsync()
                Catch ex As Exception
                    MessageBox.Show(Me, "Данные не удалось восстановить", "Ошибка", vbOKOnly, MessageBoxIcon.Error)
                End Try
            Else
                MessageBox.Show(Me, "Файл не найден", "Ошибка", vbOKOnly, MessageBoxIcon.Error)
            End If
        End If
    End Sub
    Friend Function CollectSavedInfo(ByRef textInfile As StringBuilder) As StringBuilder
        TC.ReceiveTorClientSessionToken()
        frmMain.OprosTorrentClienta(torrentsInfoOnlyFromTorClientInfrmSaveLoad)
        textInfile.Length = 0
        textInfile.Capacity = torrentsInfoOnlyFromTorClientInfrmSaveLoad.Count + 20
        For i2 As Integer = 0 To torrentsInfoOnlyFromTorClientInfrmSaveLoad.Count - 1
            textInfile.AppendLine(torrentsInfoOnlyFromTorClientInfrmSaveLoad.Item(i2).Hash & "=" & torrentsInfoOnlyFromTorClientInfrmSaveLoad.Item(i2).Label)
        Next
        Return textInfile
    End Function

    Private Sub BgrndWorker_DoWork(ByVal sender As System.Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles BgrndWorker.DoWork
        RestoreSavedInfo()
    End Sub

    Private Sub BgrndWorker_ProgressChanged(ByVal sender As Object, ByVal e As System.ComponentModel.ProgressChangedEventArgs) Handles BgrndWorker.ProgressChanged
        TSSLbl.Text = StatusOfChangingLabels
    End Sub

    Private Sub BgrndWorker_RunWorkerCompleted(ByVal sender As Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles BgrndWorker.RunWorkerCompleted
        MessageBox.Show(Me, "Данные успешно восстановлены", "Сообщение", vbOKOnly, MessageBoxIcon.Information)
        btnExecute.Enabled = True
    End Sub

    ''' <summary>
    ''' Вбрасываем в торрент-клиент информацию из параметра
    ''' </summary>
    ''' <remarks></remarks>
    Friend Sub RestoreSavedInfo()
        'Теперь начинаем сравнивать хэши, и при совпадении сравниваем ярлыки. Если НЕ совпадают - добавляем в лист обработки
        Dim sTextSpld() As String = RestoredInfo.Split(vbLf)
        Dim mHash As String = ""
        Dim mLabel As String = ""
        Dim AllCom As String = ""
        Dim CountOfAdded As Integer = 0
        Dim IsFinal As Boolean = False
        StatusOfChangingLabels = "Начали изменение ярлыков раздач" : If BgrndWorker.IsBusy = True Then BgrndWorker.ReportProgress(0)
        For i As Integer = 0 To sTextSpld.Length - 1 'Пошли по строкам списка хэшей-ярлыков
            If sTextSpld(i).Length > 40 Then 'Проверяем длину строки
                mHash = Mid(sTextSpld(i), 1, 40) 'Получаем хэш
                mLabel = (Mid(sTextSpld(i), 42, sTextSpld(i).Length - 42)) 'Получаем ярлык
                For j As Integer = 0 To torC.Count - 1 'Идём по коллекции из торрент-клиента
                    If torC.Item(j).Hash = mHash And torC.Item(j).Label <> mLabel Then 'Нашли совпадающий хэш
                        TC.TorrentChangeLabel(mHash, mLabel, AllCom, CountOfAdded, False)
                        Exit For
                    End If
                Next
            End If
            If i / 100 = i \ 100 Or i = sTextSpld.Length - 1 Then
                StatusOfChangingLabels = "Обработано " & i.ToString & " / " & (sTextSpld.Length - 1).ToString & " ярлыков"
                If BgrndWorker.IsBusy = True Then BgrndWorker.ReportProgress(0)
            End If
            'При последнем проходе коллекции выполняем все неотправленные команды
            If i = sTextSpld.Length - 1 Then TC.AddAndSendCom("", "", AllCom, CountOfAdded, True)
        Next
    End Sub

End Class