Imports System.IO
Imports System.Runtime.Serialization.Formatters.Binary
Imports System.Collections.ObjectModel 'Для объявления torrList
Public Class frmSettings
    Dim tempName1 As String
    Private Sub cmdOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdOK.Click

        '1 вкладка: Папки
        'SavI.torrentTorrentsPathTemp = txtTorrentsPathTemp.Text
        SavI.ExtLogEnabled = cbExtendedLog.Checked
        If SaveTorrFiles_obRequestPath.Checked = True Then SavI.prog_SavingTorrFiles = 0
        If SaveTorrFiles_obSaveInPath.Checked = True Then SavI.prog_SavingTorrFiles = 1
        If SaveTorrFiles_obSaveLinkToFile.Checked = True Then SavI.prog_SavingTorrFiles = 2
        SavI.prog_SaveTorrFilesToPath = SaveTorrFiles_txtSaveInPath.Text
        SavI.prog_SaveTorrFiles_DownloadByAnotherUser = SaveTorrFiles_DownloadByAnotherUser.Checked
        SavI.prog_SaveTorrFiles_DownloadByAnotherUser_Username = SaveTorrFiles_DownloadByAnotherUser_Username.Text
        SavI.prog_SaveTorrFiles_DownloadByAnotherUser_Password = SaveTorrFiles_DownloadByAnotherUser_Password.Text

        '2 вкладка: Обрабатываемые подразделы форума
        SubForumsList.Clear()
        For Each element As Class_Subforum In SubForumsListTemp
            'Добавляем строку в коллекцию подстановки
            If element.ChangeLabelOfTorrent_AnotherNamesList.Contains(element.ChangeLabelOfTorrent_AnotherName) = False Then
                element.ChangeLabelOfTorrent_AnotherNamesList.Add(element.ChangeLabelOfTorrent_AnotherName)
            End If
            'Добавляем клон элемента в сохраняемую коллекцию
            SubForumsList.Add(CType(element.Clone, Class_Subforum))
        Next

        '3 вкладка: Торрент-клиенты и аккаунты
        SavI.torrentClientName = cbTorrentClientName.SelectedIndex + 1
        SavI.torrentTorrentsPath = txtTorrentsPath.Text
        SavI.torrentRefreshInfoFromTorFilesAlways = cbRefreshInfoFromTorFilesAlways.Checked
        If rbTorrentClientOnThisComputer.Checked Then
            SavI.torrentClientWhere = 0
        ElseIf rbTorrentClientOnAnotherComputer.Checked Then
            SavI.torrentClientWhere = 1
        ElseIf rbDontQueryTorrentClient.Checked Then
            SavI.torrentClientWhere = 2
        End If
        SavI.torrentClientAnswerFile = txttorrentClientAnswerFile.Text
        SavI.torrentClientIPAddress = Trim(mtxtTorrentClientIPAddress.Text)
        SavI.torrentClientIncomingPort = Trim(Val(txttorrentClientIncomingPort.Text))
        SavI.torrentClientUsername = Trim(txttorrentClientUsername.Text)
        SavI.torrentClientPassword = Trim(txttorrentClientPassword.Text)
        SavI.Site_Password = Trim(txtSite_Password.Text)
        SavI.Site_Username = Trim(txtSite_Username.Text)

        '4 Вкладка: Отчет в форум
        SavI.prog_DiscountGenreInSort = cb_prog_DiscountGenreInSort.Checked
        SavI.WebFindDateTorRegForNotMoreSeeds = WebFindDateTorRegForNotMoreSeeds.Value
        SavI.WebFindDateTorRegIs = WebFindDateTorRegCb.Checked
        SavI.StatRepIsSendStatRep = StatRepcbIsSendStatRep.Checked
        SavI.StatRepWatchmenPass = StatReptxtWatchmenPass.Text
        ''SavI.StatRepNumOfTorInRep = StatRepNUDNumOfTorInRep.Value
        ''SavI.StatRepSendRepOnlyAboutStoredTorrents = StatRepcbSendRepOnlyAboutStoredTorrents.Checked
        ''SavI.StatRepPauseAfterEverySendReport = StatRepNUDPauseAfterEverySendReport.Value
        ''SavI.StatRepDelimiterBetweenLineElements = StatReptxtDelimiterBetweenLineElements.Text
        SavI.DontAutoShowReports = cbDontAutoShowReports.Checked

        SavI.prog_ReportSeeding_ShowOnlySeedsNotMoreThanIs = ReportSeeding_ShowOnlySeedsNotMoreThanIs.Checked
        SavI.prog_ReportSeeding_ShowOnlySeedsNotMoreThanValue = ReportSeeding_ShowOnlySeedsNotMoreThanValue.Value
        
        If prog_Report_NameLinkClick_obDefBrowser.Checked Then
            SavI.prog_Report_NameLinkClick = 0
        ElseIf prog_Report_NameLinkClick_obAltBrowser.Checked Then
            SavI.prog_Report_NameLinkClick = 1
        End If
        SavI.prog_Report_NameLinkClick_AltBrowserAddress = prog_Report_NameLinkClick_txtAltBrowserAddress.Text
        If SavI.prog_Report_NameLinkClick = 1 And My.Computer.FileSystem.FileExists(SavI.prog_Report_NameLinkClick_AltBrowserAddress) = False Then
            MessageBox.Show(Me, "Во вкладке ""Отчеты"" неправильно указан браузер для открытия ссылок из отчёта." & Environment.NewLine & _
                             "Пожалуйста, укажите правильный браузер или выберите опцию ""в браузере по умолчанию""", "Предупреждение", vbOKOnly, MessageBoxIcon.Warning)
            Exit Sub
        End If

        SavI.prog_ReportTemplate = rtb_ReportTemplate.Text
        frmMain.ReportTemplateParse()
        SavI.Report.ReportAddTextBeforeReport = ReportAddTextBeforeReportTxt.Text
        SavI.Report.ReportAddTextAfterEveryXTorrentsValue = ReportAddTextAfterEveryXTorrentsValue.Value
        SavI.Report.ReportAddTextAfterEveryXTorrentsTxt = ReportAddTextAfterEveryXTorrentsTxt.Text
        SavI.Report.ReportAddTextAfterReportMoreThanXBytesValue = ReportAddTextAfterReportMoreThanXBytesValue.Value
        SavI.Report.ReportAddTextAfterReportMoreThanXBytesTxt = ReportAddTextAfterReportMoreThanXBytesTxt.Text
        SavI.Report.ReportAddTextAfterReport = ReportAddTextAfterReport.Text

        '5 Вкладка: Прокси-сервер
        If rbProxyNotRequired.Checked Then
            SavI.Proxy = 0
        ElseIf rbProxyGetSystemWebProxy.Checked Then
            SavI.Proxy = 1
        ElseIf rbProxyManual.Checked Then
            SavI.Proxy = 2
        End If
        SavI.ProxyIPAddress = Trim(txtProxyIPAddress.Text)
        SavI.ProxyPort = Val(Trim(txtProxyPort.Text))
        If rbProxyAuthorizationNotRequired.Checked Then
            SavI.ProxyAuthorization = 0
        ElseIf rbProxyAuthorizationUseDefaultCredentials.Checked Then
            SavI.ProxyAuthorization = 1
        ElseIf rbProxyAuthorizationManual.Checked Then
            SavI.ProxyAuthorization = 2
        End If
        SavI.ProxyAuthorizationName = Trim(txtProxyAuthorizationName.Text)
        SavI.ProxyAuthorizationPassword = Trim(txtProxyAuthorizationPassword.Text)
        SavI.ProxyAuthorizationDomain = Trim(txtProxyAuthorizationDomain.Text)
        frmMain.ProxyBuilder()

        '6 Вкладка: Таймер
        Dim newTimerInterval As Decimal = NUDHours.Value * 3600 + NUDMinutes.Value * 60 + NUDSeconds.Value
        If frmMain.Timer.Enabled = True Then
            If newTimerInterval <> SavI.prog_TimerStart Then
                Call frmMain.TimerStartOFFToolStripMenuItem_Click(sender, e) 'frmMain.Timer.Enabled = False
                SavI.prog_TimerStart = NUDHours.Value * 3600 + NUDMinutes.Value * 60 + NUDSeconds.Value
                frmMain.Timer.Interval = SavI.prog_TimerStart * 1000
                Call frmMain.TimerStartONToolStripMenuItem_Click(sender, e) 'frmMain.Timer.Enabled = True
            End If
        Else
            SavI.prog_TimerStart = NUDHours.Value * 3600 + NUDMinutes.Value * 60 + NUDSeconds.Value
            frmMain.Timer.Interval = SavI.prog_TimerStart * 1000
        End If
        SavI.LimitSpeedDownloadIs = LimitSpeedDownloadIs.Checked
        SavI.LimitSpeedDownloadValue = LimitSpeedDownloadValue.Value
        SavI.LimitSpeedUploadIs = LimitSpeedUploadIs.Checked
        SavI.LimitSpeedUploadValue = LimitSpeedUploadValue.Value
        SavI.prog_PauseBeforeDownloadWebPageWithCookie = CInt(NUDPauseBeforeDownloadWebPageWithCookie.Value)
        SavI.prog_PauseAfterSendCommandToTorrentClient = CInt(NUDPauseAfterSendCommandToTorrentClient.Value)

        '7 вкладка: Интерфейс
        SavI.Interface_RequestOnExit = Interface_cbRequestOnExit.Checked
        SavI.Interface_MinimizeToTray = Interface_cbMinimizeToTray.Checked
        SavI.Interface_CloseToTray = Interface_cbCloseToTray.Checked


        'Настройки собраны, сохраняем их в файл
        Call frmMain.SaveSettingsToFile()
        'Подсчитываем количество подразделов с установленным флагом "Обрабатывать подраздел" => выставляем доступность кнопки таймера
        frmMain.TimerToolStripDropDownButton1.Enabled = False
        For Each ssf As Class_Subforum In SubForumsList
            If ssf.IsProcessSubforum = True Then frmMain.TimerToolStripDropDownButton1.Enabled = True : Exit For
        Next
        'Если не ни одного выбранного подраздела - останавливаем таймер
        If frmMain.TimerToolStripDropDownButton1.Enabled = False And frmMain.Timer.Enabled = True Then Call frmMain.TimerStartOFFToolStripMenuItem_Click(sender, e)

        Me.Dispose()
    End Sub

    Private Sub cmdCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCancel.Click
        Me.Dispose()
    End Sub

    Private Sub cmdVerifySettings_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdVerifySettings.Click
        MsgBox(VerifySettings, vbOKOnly, "Информация")
    End Sub
    Private Sub frmSettings_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
#If CONFIG = "Release" Then
        cmdVerifySettings.Visible = False
        ''gbSaveTorrentFiles.Visible = False
        ''SaveTorrFiles_DownloadByAnotherUser.Visible = False
        ''SaveTorrFiles_gbDownloadByAnotherUser.Visible = False
        gbTorFilesToTorClnt.Visible = False
        gb_AutodownloadTorrents.Visible = False
        sf_AD_cbDownloadIfSeedsNotMore.Visible = False
        'StatRepcbIsSendStatRep.Visible = False
        'gbStatReport.Visible = False
        btn_ReportTemplate.Visible = False
        For tt As Integer = 0 To TabControl1.TabPages.Count - 1
            If TabControl1.TabPages.Item(tt).Name = "TabPage5" Then TabControl1.TabPages.RemoveAt(tt) : Exit For
        Next
#End If
        Me.Icon = WindowsApplication1.My.Resources.Keepers
    End Sub
    Private Sub frmSettings_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
        '1 вкладка: Папки
        'txtTorrentsPathTemp.Text = SavI.torrentTorrentsPathTemp
        cbExtendedLog.Checked = SavI.ExtLogEnabled
        If SavI.prog_SavingTorrFiles = 0 Then SaveTorrFiles_obRequestPath.Checked = True
        If SavI.prog_SavingTorrFiles = 1 Then SaveTorrFiles_obSaveInPath.Checked = True
        If SavI.prog_SavingTorrFiles = 2 Then SaveTorrFiles_obSaveLinkToFile.Checked = True
        SaveTorrFiles_txtSaveInPath.Text = SavI.prog_SaveTorrFilesToPath
        SaveTorrFiles_DownloadByAnotherUser.Checked = SavI.prog_SaveTorrFiles_DownloadByAnotherUser
        SaveTorrFiles_gbDownloadByAnotherUser.Enabled = SaveTorrFiles_DownloadByAnotherUser.Checked
        SaveTorrFiles_DownloadByAnotherUser_Username.Text = SavI.prog_SaveTorrFiles_DownloadByAnotherUser_Username
        SaveTorrFiles_DownloadByAnotherUser_Password.Text = SavI.prog_SaveTorrFiles_DownloadByAnotherUser_Password

        '2 вкладка: Обрабатываемые подразделы форума
        Call Refresh_SubForumsListColl()

        sf_btnEditSubforum.Enabled = False
        sf_btnDeleteSubforum.Enabled = False

        SubForumsListTemp.Clear()
        For Each element As Class_Subforum In SubForumsList
            SubForumsListTemp.Add(CType(element.Clone, Class_Subforum))
        Next

        If SubForumsListTemp.Count > 0 Then
            RefreshSubforumsList(0)
        Else
            RefreshSubforumsList()
        End If

        '3 вкладка: Торрент-клиенты и аккаунты
        cbTorrentClientName.SelectedIndex = SavI.torrentClientName - 1
        txtTorrentsPath.Text = SavI.torrentTorrentsPath
        cbRefreshInfoFromTorFilesAlways.Checked = SavI.torrentRefreshInfoFromTorFilesAlways
        cbTorrentClientName_SelectedIndexChanged(sender, e)
        mtxtTorrentClientIPAddress.Text = SavI.torrentClientIPAddress
        txttorrentClientAnswerFile.Text = SavI.torrentClientAnswerFile
        txttorrentClientIncomingPort.Text = SavI.torrentClientIncomingPort
        If SavI.torrentClientWhere = 0 Then
            rbTorrentClientOnThisComputer.Checked = True
            mtxtTorrentClientIPAddress.ReadOnly = True
            btntorrentClientAnswerFile.Enabled = False
        ElseIf SavI.torrentClientWhere = 1 Then
            rbTorrentClientOnAnotherComputer.Checked = True
            mtxtTorrentClientIPAddress.ReadOnly = False
            btntorrentClientAnswerFile.Enabled = False
        ElseIf SavI.torrentClientWhere = 2 Then
            rbDontQueryTorrentClient.Checked = True
            mtxtTorrentClientIPAddress.ReadOnly = True
            btntorrentClientAnswerFile.Enabled = True
        End If
        ''If SavI.torrentClientPassword.Length > 0 Then
        ''    txttorrentClientPassword.Text = "**************"
        ''Else
        ''    txttorrentClientPassword.Text = ""
        ''End If
        txttorrentClientPassword.Text = SavI.torrentClientPassword
        txttorrentClientUsername.Text = SavI.torrentClientUsername
        'todo потом сделать показ значков вместо паролей торрент-клиента и на сайте
        ''If SavI.Site_Password.Length > 0 Then
        ''    txtSite_Password.Text = "**************"
        ''Else
        ''    txtSite_Password.Text = ""
        ''End If
        txtSite_Password.Text = SavI.Site_Password
        txtSite_Username.Text = SavI.Site_Username

        '4 Вкладка: Отчеты
        cb_prog_DiscountGenreInSort.Checked = SavI.prog_DiscountGenreInSort
        WebFindDateTorRegForNotMoreSeeds.Value = SavI.WebFindDateTorRegForNotMoreSeeds
        WebFindDateTorRegCb.Checked = SavI.WebFindDateTorRegIs
        WebFindDateTorRegCb_CheckedChanged(sender, e)

        StatRepcbIsSendStatRep.Checked = SavI.StatRepIsSendStatRep
        StatReptxtWatchmenPass.Text = SavI.StatRepWatchmenPass
        cbDontAutoShowReports.Checked = SavI.DontAutoShowReports
        gbStatReport.Enabled = StatRepcbIsSendStatRep.Checked

        ReportSeeding_ShowOnlySeedsNotMoreThanIs.Checked = SavI.prog_ReportSeeding_ShowOnlySeedsNotMoreThanIs
        ReportSeeding_ShowOnlySeedsNotMoreThanValue.Value = SavI.prog_ReportSeeding_ShowOnlySeedsNotMoreThanValue
        ReportSeeding_ShowOnlySeedsNotMoreThanValue.Enabled = SavI.prog_ReportSeeding_ShowOnlySeedsNotMoreThanIs

        If SavI.prog_Report_NameLinkClick = 0 Then
            prog_Report_NameLinkClick_obDefBrowser.Checked = True
        ElseIf SavI.prog_Report_NameLinkClick = 1 Then
            prog_Report_NameLinkClick_obAltBrowser.Checked = True
        End If
        prog_Report_NameLinkClick_txtAltBrowserAddress.Text = SavI.prog_Report_NameLinkClick_AltBrowserAddress
        prog_Report_NameLinkClick_obAltBrowser_CheckedChanged(sender, e)

        rtb_ReportTemplate.Text = SavI.prog_ReportTemplate
        ReportAddTextBeforeReportTxt.Text = SavI.Report.ReportAddTextBeforeReport
        ReportAddTextAfterEveryXTorrentsValue.Value = SavI.Report.ReportAddTextAfterEveryXTorrentsValue
        ReportAddTextAfterEveryXTorrentsTxt.Text = SavI.Report.ReportAddTextAfterEveryXTorrentsTxt
        ReportAddTextAfterReportMoreThanXBytesValue.Value = SavI.Report.ReportAddTextAfterReportMoreThanXBytesValue
        ReportAddTextAfterReportMoreThanXBytesTxt.Text = SavI.Report.ReportAddTextAfterReportMoreThanXBytesTxt
        ReportAddTextAfterReport.Text = SavI.Report.ReportAddTextAfterReport

        '5 Вкладка: Прокси-сервер
        Select Case SavI.Proxy
            Case 0 : rbProxyNotRequired.Checked = True
            Case 1 : rbProxyGetSystemWebProxy.Checked = True
            Case 2 : rbProxyManual.Checked = True
        End Select
        txtProxyIPAddress.Text = SavI.ProxyIPAddress
        txtProxyPort.Text = SavI.ProxyPort
        txtProxyIPAddress.Enabled = SavI.Proxy > 1
        txtProxyPort.Enabled = SavI.Proxy > 1
        Select Case SavI.ProxyAuthorization
            Case 0 : rbProxyAuthorizationNotRequired.Checked = True
            Case 1 : rbProxyAuthorizationUseDefaultCredentials.Checked = True
            Case 2 : rbProxyAuthorizationManual.Checked = True
        End Select
        txtProxyAuthorizationName.Text = SavI.ProxyAuthorizationName
        txtProxyAuthorizationPassword.Text = SavI.ProxyAuthorizationPassword
        txtProxyAuthorizationDomain.Text = SavI.ProxyAuthorizationDomain
        txtProxyAuthorizationName.Enabled = SavI.ProxyAuthorization > 1
        txtProxyAuthorizationPassword.Enabled = SavI.ProxyAuthorization > 1
        txtProxyAuthorizationDomain.Enabled = SavI.ProxyAuthorization > 1
        gbUseProxy.Enabled = SavI.Proxy > 0

        '6 Вкладка: Таймер
        NUDHours.Value = SavI.prog_TimerStart \ 3600
        If (SavI.prog_TimerStart - NUDHours.Value * 3600) \ 60 < NUDMinutes.Minimum Then
            NUDMinutes.Value = NUDMinutes.Minimum
        Else
            NUDMinutes.Value = (SavI.prog_TimerStart - NUDHours.Value * 3600) \ 60
        End If
        If (SavI.prog_TimerStart - NUDHours.Value * 3600 - NUDMinutes.Value * 60) >= 0 Then
            NUDSeconds.Value = SavI.prog_TimerStart - NUDHours.Value * 3600 - NUDMinutes.Value * 60
        Else
            NUDSeconds.Value = 0
        End If
        LimitSpeedDownloadIs.Checked = SavI.LimitSpeedDownloadIs
        LimitSpeedDownloadValue.Value = SavI.LimitSpeedDownloadValue
        LimitSpeedDownloadValue.Enabled = LimitSpeedDownloadIs.Checked
        LimitSpeedUploadIs.Checked = SavI.LimitSpeedUploadIs
        LimitSpeedUploadValue.Value = SavI.LimitSpeedUploadValue
        LimitSpeedUploadValue.Enabled = LimitSpeedUploadIs.Checked
        NUDPauseBeforeDownloadWebPageWithCookie.Value = CDec(SavI.prog_PauseBeforeDownloadWebPageWithCookie)
        NUDPauseAfterSendCommandToTorrentClient.Value = CDec(SavI.prog_PauseAfterSendCommandToTorrentClient)

        '7 вкладка: Интерфейс
        Interface_cbRequestOnExit.Checked = SavI.Interface_RequestOnExit
        Interface_cbMinimizeToTray.Checked = SavI.Interface_MinimizeToTray
        Interface_cbCloseToTray.Checked = SavI.Interface_CloseToTray
    End Sub

    Public Function VerifySettings() As String
        VerifySettings_NumberOfErrors = 0
        Dim ErrColor As Color = Color.FromArgb(255, 192, 192)
        Dim cntr As Color = txtTorrentsPath.BackColor
        'Здесь собираем ошибки настроек, а затем выводим в сообщение.
        Dim MsgAnswer As String = ""
        'Проверяем наличие папки с торрент-файлами
        Dim isTorrentsPathExists As Boolean = False
        If My.Computer.FileSystem.DirectoryExists(Trim(txtTorrentsPath.Text)) = True Then
            isTorrentsPathExists = True
            MsgAnswer &= "OK: папка с торрент-файлами указана верно." & vbNewLine & vbNewLine
            ToolTip1.SetToolTip(txtTorrentsPath, "OK: папка с торрент-файлами указана верно.")
            txtTorrentsPath.BackColor = Color.FromKnownColor(System.Drawing.KnownColor.Control)
        Else
            MsgAnswer &= "ОШИБКА: Указанная папка с торрент-файлами не существует." & vbNewLine & vbNewLine
            ToolTip1.SetToolTip(txtTorrentsPath, "Ошибка: Указанная папка с торрент-файлами не существует.")
            txtTorrentsPath.BackColor = ErrColor
            VerifySettings_NumberOfErrors += 1
        End If
        '============================================
        'Проверяем наличие torrent-файлов в указанной папке
        If isTorrentsPathExists = True Then
            Dim torrList As ReadOnlyCollection(Of String)
            Try
                torrList = My.Computer.FileSystem.GetFiles(Trim(txtTorrentsPath.Text), FileIO.SearchOption.SearchAllSubDirectories, "*.torrent")
            Catch
            End Try
            If torrList.Count < 1 Then
                MsgAnswer &= "ОШИБКА: В указанной папке с torrent-Файлами нет ни одного torrent-файла." & vbNewLine & vbNewLine
                ToolTip1.SetToolTip(txtTorrentsPath, "Ошибка: В указанной папке с torrent-Файлами нет ни одного torrent-файла.")
                txtTorrentsPath.BackColor = ErrColor
                VerifySettings_NumberOfErrors += 1
            Else
                MsgAnswer &= "OK: Количество torrent-файлов в указанной папке = " & CStr(torrList.Count) & vbNewLine & vbNewLine
                ToolTip1.SetToolTip(txtTorrentsPath, "OK: Количество torrent-файлов в указанной папке = " & CStr(torrList.Count))
                txtTorrentsPath.BackColor = Color.FromKnownColor(System.Drawing.KnownColor.Control)
            End If
        End If
        '=============================================
        'Проверяем, чтобы временная папка вообще существовала,
        'затем пробуем в неё записать файл-пустышку, а затем удаляем его,
        'и проверяем, чтобы путь ко временной папке состоял только из латинских букв (больших и малых), арабских цифр, бэкслешей и двоеточий
        Dim TempFolder As String = "" '= txtTorrentsPathTemp.Text
        Dim isTempFolderExists As Boolean = False
        Dim textTemp As String = ""
        Dim txtTorrentsPathTempToolTip As String = "" 'Сюда собираем текст для тултипа txtTorrentsPathTemp
        Dim txtTorrentsPathTempNumberOfErrors As Byte = 0 'Сюда собираем количество ошибок проверок временной папки TorrentsPathTemp
        Dim WeHavePermissionsToWriteInTempFolder As Boolean = False
        Dim WeHavePermissionsToEraseInTempFolder As Boolean = False
        'проверяем наличие временной папки
        If My.Computer.FileSystem.DirectoryExists(TempFolder) = True Then
            isTempFolderExists = True
            textTemp = "ОК: Временная папка существует." & vbNewLine
            MsgAnswer &= textTemp & vbNewLine
            txtTorrentsPathTempToolTip &= textTemp
        Else
            textTemp = "ОШИБКА: Временная папка не существует." & vbNewLine
            MsgAnswer &= textTemp & vbNewLine
            txtTorrentsPathTempToolTip &= textTemp
            txtTorrentsPathTempNumberOfErrors += 1
            VerifySettings_NumberOfErrors += 1
        End If
        '=========================
        'Пробуем записать во временную папку
        If isTempFolderExists = True Then
            'Пробуем записать в папку
            Try
                My.Computer.FileSystem.WriteAllText(TempFolder & "\testwrite.torrent", "test test test", False)
                WeHavePermissionsToWriteInTempFolder = True
                textTemp = "ОК: Запись во временную папку возможна." & vbNewLine
                MsgAnswer &= textTemp & vbNewLine
                txtTorrentsPathTempToolTip &= textTemp
            Catch ex As Exception
                WeHavePermissionsToWriteInTempFolder = False
                textTemp = "ОШИБКА тестовой записи во временную папку. Проверьте права создания файлов пользователем в эту папку." & vbNewLine
                MsgAnswer &= textTemp & vbNewLine
                txtTorrentsPathTempToolTip &= textTemp
                txtTorrentsPathTempNumberOfErrors += 1
                VerifySettings_NumberOfErrors += 1
            End Try
        End If
        '=========================
        'Пробуем стереть только что записанный тестовый файл из временной папки
        If WeHavePermissionsToWriteInTempFolder = True Then
            If My.Computer.FileSystem.FileExists(TempFolder & "\testwrite.torrent") Then
                Try
                    My.Computer.FileSystem.DeleteFile(TempFolder & "\testwrite.torrent")
                    WeHavePermissionsToEraseInTempFolder = True
                    textTemp = "ОК: Удаление из временной папки возможно." & vbNewLine
                    MsgAnswer &= textTemp & vbNewLine
                    txtTorrentsPathTempToolTip &= textTemp
                Catch ex As Exception
                    WeHavePermissionsToWriteInTempFolder = False
                    textTemp = "Ошибка удаления тестового файла из временной папки. Проверьте права удаления файлов пользователем из этой папки." & vbNewLine
                    MsgAnswer &= textTemp & vbNewLine
                    txtTorrentsPathTempToolTip &= textTemp
                    txtTorrentsPathTempNumberOfErrors += 1
                    VerifySettings_NumberOfErrors += 1
                End Try
            End If
        End If
        '=========================
        'проверка символов в пути ко временной папке. Asc-коды допустимых символов: A-Z=65-90; a-z=97-122; 0-9=48-57; :=58; \=92
        If isTempFolderExists = True Then
            Dim AscCode As Integer = 0
            Dim IsCorrectSymbolInTempFilder As Byte = 0
            Dim NumberOfIncorrectSymbolsInTempFolder As Integer = 0
            For i As Integer = 1 To TempFolder.Length
                AscCode = Asc(Mid(TempFolder, i, 1))
                IsCorrectSymbolInTempFilder = 0
                If AscCode >= 65 And AscCode <= 90 Then IsCorrectSymbolInTempFilder += 1
                If AscCode >= 97 And AscCode <= 122 Then IsCorrectSymbolInTempFilder += 1
                If AscCode >= 48 And AscCode <= 57 Then IsCorrectSymbolInTempFilder += 1
                If AscCode = 58 Then IsCorrectSymbolInTempFilder += 1
                If AscCode = 92 Then IsCorrectSymbolInTempFilder += 1
                'Если символ не попадает ни в один из промежутков - увеличиваем счетчик некорректных символов
                If IsCorrectSymbolInTempFilder = 0 Then NumberOfIncorrectSymbolsInTempFolder += 1
            Next
            If NumberOfIncorrectSymbolsInTempFolder > 0 Then
                textTemp = "Ошибка: В пути к временной папке есть " & Str(NumberOfIncorrectSymbolsInTempFolder) & " некорректных символов" & vbNewLine
                MsgAnswer &= textTemp & vbNewLine
                txtTorrentsPathTempToolTip &= textTemp
                txtTorrentsPathTempNumberOfErrors += 1
                VerifySettings_NumberOfErrors += 1
            Else
                textTemp = "ОК: Путь к временной папке и её название корректны." & vbNewLine
                MsgAnswer &= textTemp & vbNewLine
                txtTorrentsPathTempToolTip &= textTemp

            End If
        End If

        'И после проверок настраиваем тултип и цвет фона txtTorrentsPathTemp
        'ToolTip1.SetToolTip(txtTorrentsPathTemp, txtTorrentsPathTempToolTip)
        'If txtTorrentsPathTempNumberOfErrors > 0 Then txtTorrentsPathTemp.BackColor = ErrColor
        '=====================================
        'Проверяем правильность настроек доступа к торрент-клиенту
        If rbTorrentClientOnThisComputer.Checked Then torClientAddress = "http://127.0.0.1:" & Trim(Str(Val(txttorrentClientIncomingPort.Text))) & "/gui/?list=1"
        If rbTorrentClientOnAnotherComputer.Checked Then torClientAddress = "http://" & Trim(mtxtTorrentClientIPAddress.Text) & ":" & Trim(Str(Val(txttorrentClientIncomingPort.Text))) & "/gui/?list=1"
        'todo Сделать проверку в следующей строке
        'If rbDontQueryTorrentClient.Checked =True then 
        If rbDontQueryTorrentClient.Checked = False Then
            Dim test1 As String = frmMain.DownloadWebPageWithoutCookie(torClientAddress, System.Text.Encoding.UTF8, Trim(txttorrentClientUsername.Text), Trim(txttorrentClientPassword.Text))
            If DownloadWebPageAnswer(0) = "0" Then
                textTemp = "ОК: Настройки доступа к торрент-клиенту правильные." & vbNewLine
                MsgAnswer &= textTemp & vbNewLine
            ElseIf DownloadWebPageAnswer(0) = "Error" Then
                textTemp = "Ошибочные настройки доступа к торрент-клиенту:" & vbNewLine & DownloadWebPageAnswer(1) & vbNewLine
                MsgAnswer &= textTemp & vbNewLine
                VerifySettings_NumberOfErrors += 1
            End If
        End If

        VerifySettings = MsgAnswer
    End Function
    Public Sub SelectFolder(ByVal CaptionOfWindow As String, Optional ByVal SelectPath As String = "")
        myFolder.Description = CaptionOfWindow
        If SelectPath.Length > 1 Then myFolder.SelectedPath = SelectPath Else myFolder.SelectedPath = ""
        myFolder.ShowNewFolderButton = True
    End Sub
#Region "1 вкладка: Папки"
    Private Sub SaveTorrFiles_btnSelectPath_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SaveTorrFiles_btnSelectPath.Click
        Call SelectFolder("Укажите папку, в которую сохраняются торрент-файлы", SavI.prog_SaveTorrFilesToPath)
        If myFolder.ShowDialog = Windows.Forms.DialogResult.OK Then SaveTorrFiles_txtSaveInPath.Text = myFolder.SelectedPath
    End Sub

    Private Sub SaveTorrFiles_DownloadByAnotherUser_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SaveTorrFiles_DownloadByAnotherUser.CheckedChanged
        SaveTorrFiles_gbDownloadByAnotherUser.Enabled = SaveTorrFiles_DownloadByAnotherUser.Checked
    End Sub
#End Region

#Region "2 вкладка: Обрабатываемые подразделы форума"
    Friend Sub Refresh_SubForumsListColl(Optional ByVal index As Integer = -5)
        sf_btnSubForumsListColl_Delete.Enabled = False
        sf_btnSubForumsListColl_Edit.Enabled = SubForumsListColl.Count > 0
        sf_SubForumsListColl.Items.Clear()
        sf_SubForumsListColl.AutoCompleteCustomSource.Clear()
        If SubForumsListColl.Count > 0 Then
            For Each sflc As Class_SubforumsList In SubForumsListColl
                sf_SubForumsListColl.Items.Add(sflc.Name)
                sf_SubForumsListColl.AutoCompleteCustomSource.Add(sflc.Name)
            Next
        End If
        If index < 0 Then sf_SubForumsListColl.Text = ""
        If index > -1 And index < SubForumsListColl.Count Then sf_SubForumsListColl.SelectedIndex = index
    End Sub

    Private Sub sf_SubForumsListColl_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles sf_SubForumsListColl.SelectedIndexChanged
        'sf_btnSubForumsListColl_Edit.Enabled = subf
        sf_btnSubForumsListColl_Delete.Enabled = sf_SubForumsListColl.SelectedIndex > -1
        If sf_SubForumsListColl.SelectedIndex > -1 Then
            SubForumsListTemp.Clear()
            For Each element As Class_Subforum In SubForumsListColl.Item(sf_SubForumsListColl.SelectedIndex)
                SubForumsListTemp.Add(CType(element.Clone, Class_Subforum))
            Next
            RefreshSubforumsList(0)
        End If
    End Sub

    Private Sub sf_btnSubForumsListColl_SaveAs_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles sf_btnSubForumsListColl_SaveAs.Click
        If Trim(sf_SubForumsListColl.Text).Length < 1 Then
            MsgBox("Введите хотя бы один символ в название списка", vbOKOnly, "Запрос")
            sf_SubForumsListColl.Focus()
            Exit Sub
        End If
        Dim IsNameExists As Boolean = False
        Dim IsNameExistsIndex As Integer = -1
        If SubForumsListColl.Count > 0 Then
            For i = 0 To SubForumsListColl.Count - 1
                If sf_SubForumsListColl.Text = SubForumsListColl.Item(i).Name Then
                    IsNameExists = True
                    IsNameExistsIndex = i
                    Exit For
                End If
            Next
        End If
        If IsNameExists = True Then
            Dim ans As Microsoft.VisualBasic.MsgBoxResult = _
            MsgBox("Такое имя уже есть в списке. Хотите ли Вы сохранить НОВЫЙ список подразделов под этим именем?", vbOKCancel, "Предупреждение")
            If ans = Microsoft.VisualBasic.MsgBoxResult.Cancel Then Exit Sub
            SubForumsListColl.Item(IsNameExistsIndex).Clear()
            For Each element As Class_Subforum In SubForumsListTemp
                'Добавляем строку в коллекцию подстановки
                If element.ChangeLabelOfTorrent_AnotherNamesList.Contains(element.ChangeLabelOfTorrent_AnotherName) = False Then
                    element.ChangeLabelOfTorrent_AnotherNamesList.Add(element.ChangeLabelOfTorrent_AnotherName)
                End If
                SubForumsListColl.Item(IsNameExistsIndex).Add(CType(element.Clone, Class_Subforum))
            Next
            Refresh_SubForumsListColl(IsNameExistsIndex)
        Else
            Dim SFLColl As New Class_SubforumsList
            SFLColl.Clear()
            For Each element As Class_Subforum In SubForumsListTemp
                'Добавляем строку в коллекцию подстановки
                If element.ChangeLabelOfTorrent_AnotherNamesList.Contains(element.ChangeLabelOfTorrent_AnotherName) = False Then
                    element.ChangeLabelOfTorrent_AnotherNamesList.Add(element.ChangeLabelOfTorrent_AnotherName)
                End If
                SFLColl.Add(CType(element.Clone, Class_Subforum))
            Next
            SubForumsListColl.Add(SFLColl, Trim(sf_SubForumsListColl.Text))
            Refresh_SubForumsListColl(SubForumsListColl.Count - 1)
        End If
    End Sub

    Private Sub sf_btnSubForumsListColl_Delete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles sf_btnSubForumsListColl_Delete.Click
        If sf_SubForumsListColl.SelectedIndex > -1 Then
            Dim indx As Integer = sf_SubForumsListColl.SelectedIndex
            SubForumsListColl.RemoveAt(indx)
            If indx = SubForumsListColl.Count Then indx -= 1
            If indx > -1 Then
                Refresh_SubForumsListColl(indx)
                sf_btnSubForumsListColl_Delete.Enabled = True
            Else
                Refresh_SubForumsListColl()
                sf_btnSubForumsListColl_Delete.Enabled = False
            End If
        End If
    End Sub

    Private Sub sf_btnSubForumsListColl_Edit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles sf_btnSubForumsListColl_Edit.Click
        frmEditList.Text = "Отредактируйте коллекцию списков подразделов"
        frmEditList.ShowDialog(Me)
    End Sub


    ''Friend Function AddLabelToList(ByVal myList As System.Windows.Forms.AutoCompleteStringCollection, ByVal myLabel As String) _
    ''          As System.Windows.Forms.AutoCompleteStringCollection
    ''    Dim isHaveLabel As Boolean = False
    ''    For Each lbl As String In myList
    ''        If lbl = myLabel Then
    ''            isHaveLabel = True
    ''            Exit For
    ''        End If
    ''    Next
    ''    If isHaveLabel = True Then
    ''        Return myList
    ''    Else
    ''        myList.Add(myLabel)
    ''        Return myList
    ''    End If
    ''End Function
    Private Sub sf_SubforumsList_ItemCheck(ByVal sender As Object, ByVal e As System.Windows.Forms.ItemCheckEventArgs) Handles sf_SubforumsList.ItemCheck
        If e.NewValue = CheckState.Checked Then
            SubForumsListTemp.Item(e.Index).IsProcessSubforum = True
        Else
            SubForumsListTemp.Item(e.Index).IsProcessSubforum = False
        End If

    End Sub
    Private Sub sf_SubforumsList_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles sf_SubforumsList.SelectedIndexChanged
        sf_btnEditSubforum.Enabled = sf_SubforumsList.SelectedIndex > -1
        sf_btnDeleteSubforum.Enabled = sf_btnEditSubforum.Enabled
        sf_btnMoveUp.Enabled = sf_SubforumsList.SelectedIndex > 0
        sf_btnMoveDown.Enabled = sf_SubforumsList.SelectedIndex > -1 And sf_SubforumsList.SelectedIndex < sf_SubforumsList.Items.Count - 1
        If sf_SubforumsList.SelectedIndex > -1 Then
            'Устанавливаем значения по умолчанию
            If SubForumsListTemp.Item(sf_SubforumsList.SelectedIndex).ChangeLabelOfTorrent_AnotherNamesList Is Nothing Then
                SubForumsListTemp.Item(sf_SubforumsList.SelectedIndex).ChangeLabelOfTorrent_AnotherNamesList = New List(Of String)
                SubForumsListTemp.Item(sf_SubforumsList.SelectedIndex).ChangeLabelOfTorrent_AnotherNamesList.Clear()
            End If

            sf_txtSubForumNumber.Text = SubForumsListTemp.Item(sf_SubforumsList.SelectedIndex).Number
            sf_txtSubforumFullPath.Text = SubForumsListTemp.Item(sf_SubforumsList.SelectedIndex).SubForumFullPath

            'Блок изменения меток раздач
            sf_ChangeLabelOfTorrent.Checked = SubForumsListTemp.Item(sf_SubforumsList.SelectedIndex).ChangeLabelOfTorrent
            If SubForumsListTemp.Item(sf_SubforumsList.SelectedIndex).ChangeLabelOfTorrent_ToNameSubforum = True Then
                sf_ChangeLabelOfTorrent_ToNameSubforum.Checked = True
            Else
                sf_ChangeLabelOfTorrent_ToAnotherName.Checked = True
            End If
            sf_ChangeLabelOfTorrent_AnotherName.Text = SubForumsListTemp.Item(sf_SubforumsList.SelectedIndex).ChangeLabelOfTorrent_AnotherName
            sf_ChangeLabelOfTorrent_AnotherName.Items.Clear()
            sf_ChangeLabelOfTorrent_AnotherName.AutoCompleteCustomSource.Clear()
            If SubForumsListTemp.Item(sf_SubforumsList.SelectedIndex).ChangeLabelOfTorrent_AnotherNamesList.Count > 0 Then
                Dim AddText = Sub(xx)
                                  sf_ChangeLabelOfTorrent_AnotherName.Items.Add(xx)
                              End Sub
                SubForumsListTemp.Item(sf_SubforumsList.SelectedIndex).ChangeLabelOfTorrent_AnotherNamesList.ForEach(AddText)
                sf_ChangeLabelOfTorrent_AnotherName.AutoCompleteCustomSource.Add _
                    (SubForumsListTemp.Item(sf_SubforumsList.SelectedIndex).ChangeLabelOfTorrent_AnotherNamesList.ToString)
            End If
            sf_ChangeLabelOfTorrent_OnlyIfLabelIsEmpty.Checked = SubForumsListTemp.Item(sf_SubforumsList.SelectedIndex).ChangeLabelOfTorrent_OnlyIfLabelIsEmpty
            gb_ChangeLabel.Enabled = sf_ChangeLabelOfTorrent.Checked
            'Блок автозапуска и остановки раздач
            AutoStartStop.Checked = SubForumsListTemp.Item(sf_SubforumsList.SelectedIndex).AutoStartStop
            AutoStartStop_NumberOfSeedsNotMore.SelectedIndex = SubForumsListTemp.Item(sf_SubforumsList.SelectedIndex).AutoStartStop_NumberOfSeedsNotMore
            AutoStartStop_StartForced.Checked = SubForumsListTemp.Item(sf_SubforumsList.SelectedIndex).AutoStartStop_StartForced
            gb_AutoStartStop.Enabled = AutoStartStop.Checked
            'Блок Тип отчёта
            If SubForumsListTemp.Item(sf_SubforumsList.SelectedIndex).InnerList_IsCreate = False Then
                InnerList_obSelectedSubfReport.Checked = True
                Call InnerList_obSelectedSubfReport_CheckedChanged(sender, e)
            Else
                InnerList_obInnerSubfReport.Checked = True
                Call InnerList_obInnerSubfReport_CheckedChanged(sender, e)
            End If
            InnerList_obInnerSubfReport.Enabled = False
            If SubForumsListTemp.Item(sf_SubforumsList.SelectedIndex).InnerList IsNot Nothing Then
                If SubForumsListTemp.Item(sf_SubforumsList.SelectedIndex).InnerList.Count > 0 Then
                    InnerList_obInnerSubfReport.Enabled = True
                    Dim selCount As Integer = 0
                    For inInd As Integer = 0 To SubForumsListTemp.Item(sf_SubforumsList.SelectedIndex).InnerList.Count - 1
                        If SubForumsListTemp.Item(sf_SubforumsList.SelectedIndex).InnerList.Item(inInd).IsProcessSubforum = True Then selCount += 1
                    Next
                    InnerList_llSelectInnerSubf.Text = "Выбрано " & selCount.ToString & " из " & _
                                                       SubForumsListTemp.Item(sf_SubforumsList.SelectedIndex).InnerList.Count.ToString & " вложенных"
                Else
                    InnerList_llSelectInnerSubf.Text = "Вложенных подразделов нет"
                    InnerList_obSelectedSubfReport.Checked = True
                End If
            Else
                InnerList_llSelectInnerSubf.Text = "Вложенных подразделов нет"
                InnerList_obSelectedSubfReport.Checked = True
            End If
            InnerList_cbProcessParent.Checked = SubForumsListTemp.Item(sf_SubforumsList.SelectedIndex).InnerList_ProcessParent

            'Блок автоскачивания раздач
            sf_AD_cbDownloadIfSeedsNotMore.Checked = SubForumsListTemp.Item(sf_SubforumsList.SelectedIndex).AD_DownloadIfSeedsNotMore
            gb_AutodownloadTorrents.Enabled = sf_AD_cbDownloadIfSeedsNotMore.Checked
        End If
    End Sub

    Private Sub RefreshSubforumsList(Optional ByVal selectedIndex As Integer = -5)
        sf_btnSubForumsListColl_SaveAs.Enabled = SubForumsListTemp.Count > 0
        sf_SubforumsList.Items.Clear()
        If SubForumsListTemp.Count > 0 Then
            For indx As Integer = 0 To SubForumsListTemp.Count - 1
                tempName1 = SubForumsListTemp.Item(indx).Name
                If SubForumsListTemp.Item(indx).InnerList IsNot Nothing Then
                    If SubForumsListTemp.Item(indx).InnerList.Count > 0 Then
                        tempName1 = "(+) " & SubForumsListTemp.Item(indx).Name
                    End If
                End If
                sf_SubforumsList.Items.Add(tempName1, SubForumsListTemp.Item(indx).IsProcessSubforum)
            Next

            If selectedIndex > -1 Then
                sf_SubforumsList.SelectedIndex = selectedIndex
            End If
        End If
        If sf_SubforumsList.SelectedIndex = -1 Then SetDefaultSettingsOfElements()
        sf_btnEditSubforum.Enabled = sf_SubforumsList.SelectedIndex > -1
        sf_btnDeleteSubforum.Enabled = sf_btnEditSubforum.Enabled
        'sf_btnMoveUp.Enabled = sf_SubforumsList.SelectedIndex > 0
        'sf_btnMoveDown.Enabled = sf_SubforumsList.SelectedIndex < sf_SubforumsList.Items.Count - 1
    End Sub
    Private Sub sf_btnAddSubforum_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles sf_btnAddSubforum.Click
        If Trim(txtSite_Username.Text).Length = 0 Or Trim(txtSite_Password.Text).Length = 0 Then
            MsgBox("Перед тем, как добавлять обрабатываемые подразделы, на вкладке ""Аккаунты"" укажите имя и пароль пользователя на сайте rutracker.org", vbOKOnly, "Введите дополнительные данные")
            Exit Sub
        End If
        ToSelectSubforum = -7
        Dim SubF As New Class_Subforum
        frmSelectSubforum.ShowDialog(SubF)
        If frmSelectSubforum.DialogResult = DialogResult.OK Then
            SubForumsListTemp.Add(SubF)
            RefreshSubforumsList(SubForumsListTemp.Count - 1)
        End If
    End Sub
    Private Sub sf_btnEditSubforum_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles sf_btnEditSubforum.Click
        'todo К нижеследующей строке написать код выбора в форме выбора подраздела
        frmSelectSubforum.ShowDialog(SubForumsListTemp.Item(sf_SubforumsList.SelectedIndex))
        If frmSelectSubforum.DialogResult = DialogResult.OK Then RefreshSubforumsList(sf_SubforumsList.SelectedIndex)
    End Sub
    Private Sub sf_btnDeleteSubforum_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles sf_btnDeleteSubforum.Click
        Dim selInd As Integer = sf_SubforumsList.SelectedIndex
        Dim newSelInd As Integer = -3
        If sf_SubforumsList.SelectedIndex < (SubForumsListTemp.Count - 1) Then
            newSelInd = selInd
        Else
            newSelInd = selInd - 1
        End If
        SubForumsListTemp.RemoveAt(selInd)
        RefreshSubforumsList(newSelInd)
    End Sub
    Private Sub sf_btnMoveUp_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles sf_btnMoveUp.Click
        sf_btnMoveUp.Enabled = False
        SubForumsListTemp.MoveUp(sf_SubforumsList.SelectedIndex)
        RefreshSubforumsList(sf_SubforumsList.SelectedIndex - 1)
    End Sub

    Private Sub sf_btnMoveDown_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles sf_btnMoveDown.Click
        sf_btnMoveDown.Enabled = False
        SubForumsListTemp.MoveDown(sf_SubforumsList.SelectedIndex)
        RefreshSubforumsList(sf_SubforumsList.SelectedIndex + 1)
    End Sub

    Private Sub sf_ChangeLabelOfTorrent_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles sf_ChangeLabelOfTorrent.CheckedChanged
        If sf_SubforumsList.SelectedIndex > -1 Then
            SubForumsListTemp.Item(sf_SubforumsList.SelectedIndex).ChangeLabelOfTorrent = sf_ChangeLabelOfTorrent.Checked
        End If
        gb_ChangeLabel.Enabled = sf_ChangeLabelOfTorrent.Checked
    End Sub
    Private Sub sf_ChangeLabelOfTorrent_ToNameSubforum_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles sf_ChangeLabelOfTorrent_ToNameSubforum.CheckedChanged
        If sf_ChangeLabelOfTorrent_ToNameSubforum.Checked Then sf_ChangeLabelOfTorrent_AnotherName.Enabled = False
        If sf_SubforumsList.SelectedIndex > -1 Then
            SubForumsListTemp.Item(sf_SubforumsList.SelectedIndex).ChangeLabelOfTorrent_ToNameSubforum = True
        End If
    End Sub
    Private Sub sf_ChangeLabelOfTorrent_ToAnotherName_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles sf_ChangeLabelOfTorrent_ToAnotherName.CheckedChanged
        If sf_ChangeLabelOfTorrent_ToAnotherName.Checked Then sf_ChangeLabelOfTorrent_AnotherName.Enabled = True
        If sf_SubforumsList.SelectedIndex > -1 Then
            SubForumsListTemp.Item(sf_SubforumsList.SelectedIndex).ChangeLabelOfTorrent_ToNameSubforum = False
        End If
    End Sub
    Private Sub sf_ChangeLabelOfTorrent_AnotherName_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles sf_ChangeLabelOfTorrent_AnotherName.TextChanged
        If sf_SubforumsList.SelectedIndex > -1 Then
            SubForumsListTemp.Item(sf_SubforumsList.SelectedIndex).ChangeLabelOfTorrent_AnotherName = sf_ChangeLabelOfTorrent_AnotherName.Text
        End If
    End Sub
    Private Sub sf_ChangeLabelOfTorrent_AnotherName_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles sf_ChangeLabelOfTorrent_AnotherName.SelectedIndexChanged

    End Sub
    Private Sub sf_ChangeLabelOfTorrent_OnlyIfLabelIsEmpty_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles sf_ChangeLabelOfTorrent_OnlyIfLabelIsEmpty.CheckedChanged
        If sf_SubforumsList.SelectedIndex > -1 Then
            SubForumsListTemp.Item(sf_SubforumsList.SelectedIndex).ChangeLabelOfTorrent_OnlyIfLabelIsEmpty = sf_ChangeLabelOfTorrent_OnlyIfLabelIsEmpty.Checked
        End If
    End Sub

    Private Sub AutoStartStop_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AutoStartStop.CheckedChanged
        If sf_SubforumsList.SelectedIndex > -1 Then
            SubForumsListTemp.Item(sf_SubforumsList.SelectedIndex).AutoStartStop = AutoStartStop.Checked
        End If
        gb_AutoStartStop.Enabled = AutoStartStop.Checked
    End Sub
    Private Sub AutoStartStop_NumberOfSeedsNotMore_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AutoStartStop_NumberOfSeedsNotMore.SelectedIndexChanged
        If sf_SubforumsList.SelectedIndex > -1 Then
            SubForumsListTemp.Item(sf_SubforumsList.SelectedIndex).AutoStartStop_NumberOfSeedsNotMore = AutoStartStop_NumberOfSeedsNotMore.SelectedIndex
        End If
    End Sub
    Private Sub AutoStartStop_StartForced_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AutoStartStop_StartForced.CheckedChanged
        If sf_SubforumsList.SelectedIndex > -1 Then
            SubForumsListTemp.Item(sf_SubforumsList.SelectedIndex).AutoStartStop_StartForced = AutoStartStop_StartForced.Checked
        End If
    End Sub

    Private Sub SetDefaultSettingsOfElements()
        sf_txtSubForumNumber.Text = ""
        sf_txtSubforumFullPath.Text = ""

        sf_ChangeLabelOfTorrent.Checked = False
        sf_ChangeLabelOfTorrent_ToNameSubforum.Checked = True
        sf_ChangeLabelOfTorrent_AnotherName.Text = ""
        sf_ChangeLabelOfTorrent_OnlyIfLabelIsEmpty.Checked = False

        AutoStartStop.Checked = False
        AutoStartStop_NumberOfSeedsNotMore.SelectedIndex = 2
        AutoStartStop_StartForced.Checked = False

        sf_AD_cbDownloadIfSeedsNotMore.Checked = False
        sf_AD_cbNumberOfSeeds.SelectedIndex = -1
        sf_AD_txtDownloadFilesToFolder.Text = ""
        ' todo сделать обнуление sf_clbNameOfTorrentPath 
        sf_AD_txtNameOfTorrentPathTemplate.Text = ""
    End Sub
    Private Sub sf_ChangeLabelOfTorrent_AnotherName_EditList_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles sf_ChangeLabelOfTorrent_AnotherName_EditList.Click
        frmEditList.Text = "Отредактируйте список меток подраздела"
        frmEditList.ShowDialog(Me)
    End Sub

    Private Sub sf_AD_DownloadIfSeedsLowerThan_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles sf_AD_cbDownloadIfSeedsNotMore.CheckedChanged
        gb_AutodownloadTorrents.Enabled = sf_AD_cbDownloadIfSeedsNotMore.Checked
    End Sub

    Private Sub InnerList_obSelectedSubfReport_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles InnerList_obSelectedSubfReport.CheckedChanged
        If InnerList_obSelectedSubfReport.Checked = True Then
            InnerList_llSelectInnerSubf.Enabled = False
            InnerList_cbProcessParent.Enabled = False
            If sf_SubforumsList.SelectedIndex > -1 Then SubForumsListTemp.Item(sf_SubforumsList.SelectedIndex).InnerList_IsCreate = False
        End If
    End Sub

    Private Sub InnerList_obInnerSubfReport_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles InnerList_obInnerSubfReport.CheckedChanged
        If InnerList_obInnerSubfReport.Checked = True Then
            InnerList_llSelectInnerSubf.Enabled = True
            InnerList_cbProcessParent.Enabled = True
            If sf_SubforumsList.SelectedIndex > -1 Then
                SubForumsListTemp.Item(sf_SubforumsList.SelectedIndex).InnerList_IsCreate = True
                'sf_SubforumsList.f
            End If
        End If
    End Sub

    Private Sub InnerList_llSelectInnerSubf_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles InnerList_llSelectInnerSubf.LinkClicked
        frmSelectInnerSubforums.ShowDialog(SubForumsListTemp.Item(sf_SubforumsList.SelectedIndex).InnerList)
        If SubForumsListTemp.Item(sf_SubforumsList.SelectedIndex).InnerList IsNot Nothing Then
            If SubForumsListTemp.Item(sf_SubforumsList.SelectedIndex).InnerList.Count > 0 Then
                Dim selCount As Integer = 0
                For inInd As Integer = 0 To SubForumsListTemp.Item(sf_SubforumsList.SelectedIndex).InnerList.Count - 1
                    If SubForumsListTemp.Item(sf_SubforumsList.SelectedIndex).InnerList.Item(inInd).IsProcessSubforum = True Then selCount += 1
                Next
                InnerList_llSelectInnerSubf.Text = "Выбрано " & selCount.ToString & " из " & _
                                                   SubForumsListTemp.Item(sf_SubforumsList.SelectedIndex).InnerList.Count.ToString & " вложенных"
            Else
                InnerList_llSelectInnerSubf.Text = "Вложенных подразделов нет"
            End If
        Else
            InnerList_llSelectInnerSubf.Text = "Вложенных подразделов нет"
        End If
    End Sub

    Private Sub InnerList_cbProcessParent_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles InnerList_cbProcessParent.CheckedChanged
        SubForumsListTemp.Item(sf_SubforumsList.SelectedIndex).InnerList_ProcessParent = InnerList_cbProcessParent.Checked
    End Sub
#End Region

#Region "3 вкладка: Аккаунты"
    Private Sub cbTorrentClientName_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbTorrentClientName.SelectedIndexChanged
        GroupBoxUtorrentSettings.Enabled = cbTorrentClientName.SelectedIndex = 0
    End Sub

    Private Sub btnSelectFolder_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSelectFolder.Click
        Call SelectFolder("Укажите папку с torrent-файлами", SavI.torrentTorrentsPath)
        If myFolder.ShowDialog = Windows.Forms.DialogResult.OK Then
            txtTorrentsPath.Text = myFolder.SelectedPath
        End If
    End Sub
    Private Sub btnSelectTorrentClientAnswer_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btntorrentClientAnswerFile.Click
        Call SelOpenFile("Выберите текстовый файл с ответом торрент-клиента", "Text files (*.txt)|*.txt|All files (*.*)|*.*", Mid(SavI.torrentClientAnswerFile, 1, SavI.torrentClientAnswerFile.LastIndexOf("\")))
        If myOpenFile.ShowDialog = DialogResult.OK Then txttorrentClientAnswerFile.Text = myOpenFile.FileName
    End Sub
    Public Sub SelOpenFile(ByVal CaptionOfWindow As String, ByVal myFilter As String, Optional ByVal InitialDir As String = "")
        myOpenFile.Title = CaptionOfWindow
        myOpenFile.Multiselect = False
        myOpenFile.Filter = myFilter
        If InitialDir.Length > 2 Then myOpenFile.InitialDirectory = InitialDir
    End Sub
    Public Sub SelSaveFile(ByVal CaptionOfWindow As String, ByVal myFilter As String, Optional ByVal DefaultFilename As String = "", Optional ByVal DefaultExt As String = "", Optional ByVal InitialDir As String = "")
        mySaveFile.Title = CaptionOfWindow
        mySaveFile.Filter = myFilter
        If DefaultFilename.Length > 0 Then mySaveFile.FileName = DefaultFilename
        If InitialDir.Length > 0 Then mySaveFile.InitialDirectory = InitialDir
        If DefaultExt.Length > 0 Then mySaveFile.DefaultExt = DefaultExt
    End Sub
    Private Sub rbTorrentClientOnThisComputer_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbTorrentClientOnThisComputer.CheckedChanged
        If rbTorrentClientOnThisComputer.Checked Then
            mtxtTorrentClientIPAddress.ReadOnly = True
            btntorrentClientAnswerFile.Enabled = False
        End If
    End Sub
    Private Sub rbTorrentClientOnAnotherComputer_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbTorrentClientOnAnotherComputer.CheckedChanged
        If rbTorrentClientOnAnotherComputer.Checked Then
            mtxtTorrentClientIPAddress.ReadOnly = False
            btntorrentClientAnswerFile.Enabled = False
        End If
    End Sub

    Private Sub rbDontQueryTorrentClient_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbDontQueryTorrentClient.CheckedChanged
        If rbDontQueryTorrentClient.Checked Then
            mtxtTorrentClientIPAddress.ReadOnly = True
            btntorrentClientAnswerFile.Enabled = True
        End If
    End Sub

#End Region

#Region "4 вкладка: Отчёты"
    Private Sub StatRepcbIsSendStatRep_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles StatRepcbIsSendStatRep.CheckedChanged
        gbStatReport.Enabled = StatRepcbIsSendStatRep.Checked
    End Sub
    Private Sub WebFindDateTorRegCb_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles WebFindDateTorRegCb.CheckedChanged
        WebFindDateTorRegGb.Enabled = WebFindDateTorRegCb.Checked
    End Sub
    Private Sub prog_Report_NameLinkClick_btnAltBrowserSelectAddress_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles prog_Report_NameLinkClick_btnAltBrowserSelectAddress.Click
        Call SelOpenFile("Выберите запускающий файл браузера", "Исполняемый файл (*.exe)|*.exe")
        If myOpenFile.ShowDialog = DialogResult.OK Then prog_Report_NameLinkClick_txtAltBrowserAddress.Text = myOpenFile.FileName
    End Sub
    Private Sub prog_Report_NameLinkClick_obAltBrowser_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles prog_Report_NameLinkClick_obAltBrowser.CheckedChanged
        prog_Report_NameLinkClick_txtAltBrowserAddress.Enabled = prog_Report_NameLinkClick_obAltBrowser.Checked
        prog_Report_NameLinkClick_btnAltBrowserSelectAddress.Enabled = prog_Report_NameLinkClick_obAltBrowser.Checked
    End Sub

#End Region

#Region "5 вкладка: Прокси-сервер"
    Private Sub rbProxyNotRequired_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbProxyNotRequired.CheckedChanged
        gbUseProxy.Enabled = Not rbProxyNotRequired.Checked
    End Sub
    Private Sub rbProxyManual_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbProxyManual.CheckedChanged
        txtProxyIPAddress.Enabled = rbProxyManual.Checked
        txtProxyPort.Enabled = rbProxyManual.Checked
    End Sub
    Private Sub rbProxyAuthorizationManual_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbProxyAuthorizationManual.CheckedChanged
        txtProxyAuthorizationName.Enabled = rbProxyAuthorizationManual.Checked
        txtProxyAuthorizationPassword.Enabled = rbProxyAuthorizationManual.Checked
        txtProxyAuthorizationDomain.Enabled = rbProxyAuthorizationManual.Checked
    End Sub

#End Region

#Region "6 вкладка: Таймер"
    Private Sub NUDMinutes_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NUDMinutes.ValueChanged
        If NUDHours.Value = 0 Then
            NUDMinutes.Minimum = 5
        Else
            NUDMinutes.Minimum = 0
        End If
    End Sub

    Private Sub NUDHours_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NUDHours.ValueChanged
        If NUDHours.Value > 0 Then
            NUDMinutes.Minimum = 0
        Else
            NUDMinutes.Minimum = 5
        End If
    End Sub

    Private Sub LimitSpeedDownloadIs_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LimitSpeedDownloadIs.CheckedChanged
        LimitSpeedDownloadValue.Enabled = LimitSpeedDownloadIs.Checked
    End Sub

    Private Sub LimitSpeedUploadIs_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LimitSpeedUploadIs.CheckedChanged
        LimitSpeedUploadValue.Enabled = LimitSpeedUploadIs.Checked
    End Sub
#End Region


    Private Sub ReportSeeding_ShowOnlySeedsNotMoreThanIs_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ReportSeeding_ShowOnlySeedsNotMoreThanIs.CheckedChanged
        ReportSeeding_ShowOnlySeedsNotMoreThanValue.Enabled = ReportSeeding_ShowOnlySeedsNotMoreThanIs.Checked
    End Sub

End Class