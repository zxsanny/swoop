Imports System.IO
Imports System.Collections.ObjectModel
Public Class frmLinksListsAndTorFiles
    Dim int1 As Integer
    Dim str1 As String
    Dim torrList As ReadOnlyCollection(Of String)
    Dim whatTOstartInBWorker As Integer
    Dim NameOfFile As String
    ''' <summary>
    ''' файл со списком ссылок на торрент-файлы
    ''' </summary>
    ''' <remarks></remarks>
    Dim TorrentFilesLinksList As String
    Dim ChangePasskeyToGuest As Boolean
    ''' <summary>
    ''' Пасскей, вставляемый в торрент-файлы
    ''' </summary>
    ''' <remarks></remarks>
    Dim NewPasskey As String
    Private Sub frmLinksListsAndTorFiles_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Icon = WindowsApplication1.My.Resources.Keepers
        cbChangePasskeyToGuest.Checked = True
        btnDownloadTorFiles.Enabled = False
        btnInsertNewPasskey.Enabled = False
        TSSLabel1.Text = ""
    End Sub

    Private Sub BWorker_DoWork(ByVal sender As System.Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles BWorker.DoWork
        Select Case whatTOstartInBWorker
            Case 1
                DownloadTorrentsFilesList()
            Case 2
                InsertInTorrFilesNewPasskey()
        End Select
    End Sub

    Private Sub BWorker_ProgressChanged(ByVal sender As Object, ByVal e As System.ComponentModel.ProgressChangedEventArgs) Handles BWorker.ProgressChanged
        TSSLabel1.Text = StageOfWork
    End Sub
    Private Sub BWorker_RunWorkerCompleted(ByVal sender As Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles BWorker.RunWorkerCompleted
        GUI("unblock")
        TSSLabel1.Text = "Готово"
    End Sub
    Private Sub GUI(ByVal input As String)
        Select Case input.ToLower
            Case "block"
                gbDownload.Enabled = False
                gbInsertPasskey.Enabled = False
            Case "unblock"
                gbDownload.Enabled = True
                gbInsertPasskey.Enabled = True
        End Select
    End Sub
    Private Sub btnDownloadTorFiles_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDownloadTorFiles.Click
        TorrentFilesLinksList = txtTorrentFilesLinksList.Text
        If My.Computer.FileSystem.FileExists(TorrentFilesLinksList) = False Then
            btnDownloadTorFiles.Enabled = False
            MsgBox("Файл со списком ссылок не найден", vbOKOnly, "Ошибка")
            Exit Sub
        End If

        whatTOstartInBWorker = 1
        ChangePasskeyToGuest = cbChangePasskeyToGuest.Checked
        'Задаём переменные
        ObrabotkaStartovala = True
        ExtendedLog = "Начинаем скачивание торрент-файлов по списку из файла " & TorrentFilesLinksList & Environment.NewLine
        NameOfFile = frmMain.NowDayTimeFull() & "_скачиваем торрент-файлы по списку.log"
        frmMain.SaveExtendedLog()

        'Проверяем: если торрент-клиент на нашем компе, то притормаживаем его на время веб-запросов
        TC.ReceiveTorClientSessionToken()
        If DownloadWebPageAnswer(0) = "0" Then
            If SavI.LimitSpeedDownloadIs = True Or SavI.LimitSpeedUploadIs = True Then TC.LimitSpeedTorrentClient("ON")
        End If
        GUI("block")
        Try
            BWorker.RunWorkerAsync()
        Catch ex As Exception
            MessageBox.Show(Me, "В данный момент обработка невозможна. Попробуйте позже.", "Сообщение", vbOKOnly, MessageBoxIcon.Information)
            Exit Sub
        End Try
    End Sub
    Private Sub DownloadTorrentsFilesList()
        Dim links() As String = My.Computer.FileSystem.ReadAllText(TorrentFilesLinksList).Split(vbCrLf)
        If links.Length < 1 Then Exit Sub

        Dim FileContent() As Byte = {} ', FileContentNew() As Byte = {}
        Dim FileName As String = ""
        'Dim BinChars() As Byte = {}
        'Dim BinCharsNew() As Byte = {103, 117, 101, 115, 116, 103, 117, 101, 115, 116} 'здесь guestguest
        Dim indexesList As New List(Of Integer)
        Dim StartIndex As Integer

        Dim Pathname As String = frmMain.NowDayTimeFull
        Pathname = IO.Path.Combine(My.Computer.FileSystem.GetParentPath(TorrentFilesLinksList), Pathname)
        Try
            ExtendedLog &= "Попытка создать каталог """ & Pathname & """ для сохранения торрент-файлов"
            If My.Computer.FileSystem.DirectoryExists(Pathname) = False Then My.Computer.FileSystem.CreateDirectory(Pathname)
            ExtendedLog &= "Каталог создан успешно (или он уже существовал)"
        Catch ex As Exception
            ExtendedLog &= "Ошибка создания каталога """ & Pathname & """"
            MsgBox("Ошибка создания каталога """ & Pathname & """", vbOKOnly, "Ошибка")
        End Try

        For i = 0 To links.Length - 1
            links(i) = Trim(links(i))
            '1 - проверяем длину адреса
            If links(i).Length < 5 Then links(i) &= " = Error" : GoTo errorDown
            '2 - скачиваем торрент-файл
            StageOfWork = links(i) & " Скачиваем файл № " & (i + 1).ToString : BWorker.ReportProgress(0)
            ExtendedLog &= StageOfWork & Environment.NewLine
            frmMain.ReceiveFile(links(i), "http://rutracker.org/forum/tracker.php", FileName, FileContent)
            '2а - проверяем, достигли ли дневного лимита текущего юзера
            If FileName = "DailyLimitExceeded" Then
                str1 = "Вы уже исчерпали суточный лимит скачиваний торрент-файлов" & Environment.NewLine & _
                       "Для продолжения скачивания торент-файлов введите другие" & Environment.NewLine & _
                       "регистрационные данные в настройках сохранения торрент-файлов." & Environment.NewLine
                ExtendedLog &= str1
                MsgBox(str1, vbOKOnly, "Предупреждение")
                Exit Sub
            End If
            '3 - если файл короткий, значит ошибка скачивания
            If FileContent.Length > 10 Then
                links(i) = links(i) & vbTab & "Торрент-файл скачан"
                ExtendedLog &= "Торрент-файл скачан успешно" & Environment.NewLine
            Else
                ExtendedLog &= "Ошибка скачивания торрент-файла" & Environment.NewLine
                links(i) = links(i) & vbTab & "Ошибка скачивания" : GoTo errorDown
            End If
            If ChangePasskeyToGuest = True Then
                '4 - находим индексы искомой последовательности
                ExtendedLog &= "Находим индексы искомой последовательности ""/ann?uk=""" & Environment.NewLine
                indexesList.Clear()
                StartIndex = 0
                Do
                    int1 = FindIndexInBinFile(FileContent, "/ann?uk=", StartIndex)
                    If int1 >= 0 Then
                        StartIndex = int1 + 1
                        indexesList.Add(int1 + "/ann?uk=".Length) 'Добавляем смещение, чтобы попасть на начало пасскея
                    End If
                Loop While int1 > 0
                '4а - если не нашли, то уходим на след. ссылку
                If indexesList.Count = 0 Then
                    links(i) = links(i) & vbTab & "Не найдена ""/ann?uk="""
                    ExtendedLog &= "Не найдена искомая последовательность ""/ann?uk=""" & Environment.NewLine
                    FileName &= "_не найдены пасскеи"
                    GoTo SaveFile
                End If
                ExtendedLog &= "Найдено " & indexesList.Count.ToString & " экз. ""/ann?uk=""" & Environment.NewLine
                links(i) = links(i) & vbTab & "Найдено " & indexesList.Count.ToString & " экз. ""/ann?uk="""
                '5 - изменяем байты по найденным адресам
                'StartIndex = 0
                For j = 0 To indexesList.Count - 1
                    SetNewValueInBinMassiv(FileContent, indexesList(j), "guestguest")
                    ''If j = 0 Then
                    ''    CopiedLenght = indexesList.Item(j)
                    ''Else
                    ''    CopiedLenght = indexesList.Item(j) - indexesList.Item(j - 1) - BinCharsNew.Length
                    ''End If
                    ''Array.ConstrainedCopy(FileContent, StartIndex, FileContentNew, StartIndex, CopiedLenght ) : StartIndex += CopiedLenght
                    ''Array.ConstrainedCopy(BinCharsNew, 0, FileContentNew, StartIndex, BinCharsNew.Length) : StartIndex += BinCharsNew.Length
                Next j
                ''Array.ConstrainedCopy(FileContent, StartIndex, FileContentNew, StartIndex, FileContent.Length - StartIndex)
            End If
SaveFile:
            '6 - Сохраняем подправленный торрент-файл
            Try
                ExtendedLog &= "Пытаемся сохранить торрент-файл" & Environment.NewLine
                Dim fstr As New System.IO.FileStream(Path.Combine(Pathname, FileName), FileMode.Create, FileAccess.Write)
                fstr.Write(FileContent, 0, FileContent.Length)
                fstr.Close()
                ExtendedLog &= "Торрент-файл успешно сохранён" & Environment.NewLine
                links(i) = links(i) & vbTab & "файл сохранен"
            Catch ex As Exception
                ExtendedLog &= "Ошибка сохранения торент-файла" & Environment.NewLine
                links(i) = links(i) & vbTab & "ошибка сохранения файла"
            End Try
errorDown:
            frmMain.SaveExtendedLog()
        Next
        FileName = ""
        For i = 0 To links.Length - 1
            FileName &= links(i)
        Next
        Try
            My.Computer.FileSystem.WriteAllText(Path.Combine(Pathname, "links-DownloadResults.txt"), FileName, False)
        Catch ex As Exception

        End Try
    End Sub
    Private Function FindIndexInBinFile(ByVal FileContent() As Byte, ByVal SearchedText As String, Optional ByVal StartIndex As Integer = 0) As Integer
        Dim j As Integer
        If SearchedText.Length < 1 Then Return -20
        If StartIndex > FileContent.Length - SearchedText.Length Or StartIndex < 0 Then Return -30
        Dim STextBin(SearchedText.Length - 1) As Byte
        For i As Integer = 0 To SearchedText.Length - 1
            STextBin.SetValue(CByte(Asc(Mid(SearchedText, i + 1, 1))), i)
        Next
        For i = StartIndex To FileContent.Length - SearchedText.Length
            For j = 0 To STextBin.Length - 1
                If FileContent(i + j) <> STextBin(j) Then Exit For
                If j = STextBin.Length - 1 Then Return i
            Next
        Next
        Return -40
    End Function
    Private Sub SetNewValueInBinMassiv(ByRef FileContent() As Byte, ByVal StartIndex As Integer, ByVal NewValue As String)
        If StartIndex < 0 Or StartIndex > FileContent.Length - NewValue.Length Then Exit Sub
        If NewValue.Length < 1 Then Exit Sub
        For j As Integer = 0 To NewValue.Length - 1
            FileContent.SetValue(CByte(Asc(Mid(NewValue, j + 1, 1))), StartIndex + j)
        Next
    End Sub
    Private Sub btnInsertNewPasskey_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnInsertNewPasskey.Click
        Dim path As String = txtSelectPathWithTorrFiles.Text
        If My.Computer.FileSystem.DirectoryExists(path) = False Then
            MsgBox("Папка не найдена", vbOKOnly, "Ошибка")
            btnInsertNewPasskey.Enabled = False
            Exit Sub
        End If

        NewPasskey = Trim(txtNewPasskey.Text)
        If NewPasskey.Length <> 10 Then
            MsgBox("Длина пасскея должна быть десять символов.", vbOKOnly, "Предупреждение")
            Exit Sub
        End If

        torrList = My.Computer.FileSystem.GetFiles(path, FileIO.SearchOption.SearchAllSubDirectories, "*.torrent")
        ExtendedLog &= "Папка с торрент-файлами: " & SavI.torrentTorrentsPath & vbNewLine
        ExtendedLog &= "Количество найденных файлов в папке и вложенных папках: " & torrList.Count & vbNewLine : frmMain.SaveExtendedLog()
        If torrList.Count < 1 Then
            MessageBox.Show("torrent-файлы не обнаружены.")
            Exit Sub
        End If

        whatTOstartInBWorker = 2

        'Задаём переменные
        ObrabotkaStartovala = True
        NameOfFile = frmMain.NowDayTimeFull() & "_заменяем пасскей.log"
        frmMain.SaveExtendedLog()
        GUI("block")
        Try
            BWorker.RunWorkerAsync()
        Catch ex As Exception
            MessageBox.Show(Me, "В данный момент обработка невозможна. Попробуйте позже.", "Сообщение", vbOKOnly, MessageBoxIcon.Information)
            Exit Sub
        End Try
    End Sub

    Private Sub InsertInTorrFilesNewPasskey()
        Dim FileContent As Byte() = {}
        Dim report As String = ""
        Dim indexesList As New List(Of Integer)
        Dim StartIndex As Integer

        For i As Integer = 0 To torrList.Count - 1
            StageOfWork = "Обрабатываем файл № " & (i + 1).ToString : BWorker.ReportProgress(0)
            ExtendedLog &= StageOfWork & Environment.NewLine
            report &= My.Computer.FileSystem.GetName(torrList(i))
            Try
                If My.Computer.FileSystem.FileExists(torrList(i)) Then FileContent = My.Computer.FileSystem.ReadAllBytes(torrList(i))
            Catch ex As Exception
                ExtendedLog &= "Ошибка чтения торрент-файла" & Environment.NewLine
                report &= vbTab & "Ошибка чтения торрент-файла" : GoTo errorDown
            End Try

            '4 - находим индексы искомой последовательности /ann?uk=
            ExtendedLog &= "Находим индексы искомой последовательности ""/ann?uk=""" & Environment.NewLine
            indexesList.Clear()
            StartIndex = 0
            Do
                int1 = FindIndexInBinFile(FileContent, "/ann?uk=", StartIndex) + "/ann?uk=".Length
                If int1 >= 0 Then
                    StartIndex = int1 + 1
                    indexesList.Add(int1)
                End If
            Loop While int1 > 0
            '4а - если не нашли, то уходим на след. ссылку
            If indexesList.Count = 0 Then
                report &= vbTab & "Не найдена ""/ann?uk="""
                ExtendedLog &= "Не найдена искомая последовательность ""/ann?uk=""" & Environment.NewLine
                GoTo errorDown
            End If
            ExtendedLog &= "Найдено " & indexesList.Count.ToString & " экз. ""/ann?uk=""" & Environment.NewLine
            report &= vbTab & "Найдено " & indexesList.Count.ToString & " экз. ""/ann?uk="""
            '5 - изменяем байты по найденным адресам
            For j = 0 To indexesList.Count - 1
                SetNewValueInBinMassiv(FileContent, indexesList(j), NewPasskey)
            Next j
            'Если в анонсе есть текст http://ix значит скачали без регистриции, и тогда делаем следующие замены:
            'http://ix -> http://bt
            'net -> org

            int1 = FindIndexInBinFile(FileContent, "http://ix")
            If int1 < indexesList(0) And int1 > -1 Then 'Если до первого пасскея, то значит меняем
                SetNewValueInBinMassiv(FileContent, int1, "http://bt")
                int1 = FindIndexInBinFile(FileContent, "net")
                If int1 < indexesList(0) And int1 > -1 Then SetNewValueInBinMassiv(FileContent, int1, "org")

                int1 = FindIndexInBinFile(FileContent, "http://ix", int1)
                If int1 < indexesList(1) And int1 > -1 Then 'Если до первого пасскея, то значит меняем
                    SetNewValueInBinMassiv(FileContent, int1, "http://bt")
                    int1 = FindIndexInBinFile(FileContent, "net", int1)
                    If int1 < indexesList(1) And int1 > -1 Then SetNewValueInBinMassiv(FileContent, int1, "org")
                End If

            End If

            '6 - Сохраняем подправленный торрент-файл
            Try
                ExtendedLog &= "Пытаемся сохранить торрент-файл" & Environment.NewLine
                Dim fstr As New FileStream(torrList(i), FileMode.Create, FileAccess.Write)
                fstr.Write(FileContent, 0, FileContent.Length)
                fstr.Close()
                ExtendedLog &= "Торрент-файл успешно сохранён" & Environment.NewLine
                report &= vbTab & "файл сохранен"
            Catch ex As Exception
                ExtendedLog &= "Ошибка сохранения торент-файла" & Environment.NewLine
                report &= vbTab & "ошибка сохранения файла"
            End Try
errorDown:
            frmMain.SaveExtendedLog()
            report &= Environment.NewLine

        Next
        Try
            My.Computer.FileSystem.WriteAllText(Path.Combine(My.Computer.FileSystem.GetParentPath(torrList(0)), "links-InsertPasskey.txt"), report, False)
        Catch ex As Exception

        End Try
    End Sub


    Private Sub btnTorrentFilesLinksList_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSelectTorrentFilesLinksList.Click
        Call frmSettings.SelOpenFile("Выберите файл со списком ссылок", "Текстовый файл (*.txt)|*.txt")
        If myOpenFile.ShowDialog = DialogResult.OK Then txtTorrentFilesLinksList.Text = myOpenFile.FileName
        btnDownloadTorFiles.Enabled = True
    End Sub

    Private Sub btnSelectPathWithTorrFiles_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSelectPathWithTorrFiles.Click
        Call frmSettings.SelectFolder("Выберите папку с торент-файлами")
        If myFolder.ShowDialog = DialogResult.OK Then txtSelectPathWithTorrFiles.Text = myFolder.SelectedPath
        btnInsertNewPasskey.Enabled = True
    End Sub
End Class