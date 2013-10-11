<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSettings
    Inherits System.Windows.Forms.Form

    'Форма переопределяет dispose для очистки списка компонентов.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Является обязательной для конструктора форм Windows Forms
    Private components As System.ComponentModel.IContainer

    'Примечание: следующая процедура является обязательной для конструктора форм Windows Forms
    'Для ее изменения используйте конструктор форм Windows Form.  
    'Не изменяйте ее в редакторе исходного кода.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmSettings))
        Me.cmdCancel = New System.Windows.Forms.Button()
        Me.cmdOK = New System.Windows.Forms.Button()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.gbTorFilesToTorClnt = New System.Windows.Forms.GroupBox()
        Me.Label39 = New System.Windows.Forms.Label()
        Me.RadioButton4 = New System.Windows.Forms.RadioButton()
        Me.RadioButton3 = New System.Windows.Forms.RadioButton()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.TextBox10 = New System.Windows.Forms.TextBox()
        Me.TextBox7 = New System.Windows.Forms.TextBox()
        Me.gbSaveTorrentFiles = New System.Windows.Forms.GroupBox()
        Me.TextBox3 = New System.Windows.Forms.TextBox()
        Me.SaveTorrFiles_obSaveLinkToFile = New System.Windows.Forms.RadioButton()
        Me.SaveTorrFiles_DownloadByAnotherUser = New System.Windows.Forms.CheckBox()
        Me.SaveTorrFiles_btnSelectPath = New System.Windows.Forms.Button()
        Me.SaveTorrFiles_txtSaveInPath = New System.Windows.Forms.TextBox()
        Me.SaveTorrFiles_obSaveInPath = New System.Windows.Forms.RadioButton()
        Me.SaveTorrFiles_obRequestPath = New System.Windows.Forms.RadioButton()
        Me.SaveTorrFiles_gbDownloadByAnotherUser = New System.Windows.Forms.GroupBox()
        Me.TextBox12 = New System.Windows.Forms.TextBox()
        Me.Label38 = New System.Windows.Forms.Label()
        Me.SaveTorrFiles_DownloadByAnotherUser_Password = New System.Windows.Forms.TextBox()
        Me.SaveTorrFiles_DownloadByAnotherUser_Username = New System.Windows.Forms.TextBox()
        Me.Label37 = New System.Windows.Forms.Label()
        Me.cbExtendedLog = New System.Windows.Forms.CheckBox()
        Me.cmdVerifySettings = New System.Windows.Forms.Button()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.TabPage4 = New System.Windows.Forms.TabPage()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.GroupBox15 = New System.Windows.Forms.GroupBox()
        Me.sf_SubForumsListColl = New System.Windows.Forms.ComboBox()
        Me.sf_btnMoveDown = New System.Windows.Forms.Button()
        Me.sf_btnSubForumsListColl_SaveAs = New System.Windows.Forms.Button()
        Me.sf_btnMoveUp = New System.Windows.Forms.Button()
        Me.sf_btnSubForumsListColl_Edit = New System.Windows.Forms.Button()
        Me.sf_SubforumsList = New System.Windows.Forms.CheckedListBox()
        Me.sf_btnEditSubforum = New System.Windows.Forms.Button()
        Me.sf_btnSubForumsListColl_Delete = New System.Windows.Forms.Button()
        Me.sf_btnDeleteSubforum = New System.Windows.Forms.Button()
        Me.sf_btnAddSubforum = New System.Windows.Forms.Button()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.gb_InnerList = New System.Windows.Forms.GroupBox()
        Me.InnerList_cbProcessParent = New System.Windows.Forms.CheckBox()
        Me.InnerList_llSelectInnerSubf = New System.Windows.Forms.LinkLabel()
        Me.InnerList_obInnerSubfReport = New System.Windows.Forms.RadioButton()
        Me.InnerList_obSelectedSubfReport = New System.Windows.Forms.RadioButton()
        Me.sf_AD_cbDownloadIfSeedsNotMore = New System.Windows.Forms.CheckBox()
        Me.AutoStartStop = New System.Windows.Forms.CheckBox()
        Me.gb_AutoStartStop = New System.Windows.Forms.GroupBox()
        Me.AutoStartStop_StartForced = New System.Windows.Forms.CheckBox()
        Me.AutoStartStop_NumberOfSeedsNotMore = New System.Windows.Forms.ComboBox()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.sf_txtSubforumFullPath = New System.Windows.Forms.TextBox()
        Me.Label29 = New System.Windows.Forms.Label()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.sf_txtSubForumNumber = New System.Windows.Forms.TextBox()
        Me.sf_ChangeLabelOfTorrent = New System.Windows.Forms.CheckBox()
        Me.gb_AutodownloadTorrents = New System.Windows.Forms.GroupBox()
        Me.sf_AD_cbNumberOfSeeds = New System.Windows.Forms.ComboBox()
        Me.RadioButton2 = New System.Windows.Forms.RadioButton()
        Me.GroupBox5 = New System.Windows.Forms.GroupBox()
        Me.LinkLabel1 = New System.Windows.Forms.LinkLabel()
        Me.sf_AD_txtNameOfTorrentPathTemplate = New System.Windows.Forms.TextBox()
        Me.RadioButton1 = New System.Windows.Forms.RadioButton()
        Me.sf_AD_gbWhereTorClientMustSaveTorrentFile = New System.Windows.Forms.GroupBox()
        Me.sf_AD_WhereTorClientMustSaveTorrentFile_btnCustomPath = New System.Windows.Forms.Button()
        Me.sf_AD_WhereTorClientMustSaveTorrentFile_txtCustomPath = New System.Windows.Forms.TextBox()
        Me.sf_AD_WhereTorClientMustSaveTorrentFile_rbCustomPath = New System.Windows.Forms.RadioButton()
        Me.TextBox11 = New System.Windows.Forms.TextBox()
        Me.sf_AD_WhereTorClientMustSaveTorrentFile_rbDefaultPath = New System.Windows.Forms.RadioButton()
        Me.TextBox4 = New System.Windows.Forms.TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.sf_AD_btnSelectDownloadFolder = New System.Windows.Forms.Button()
        Me.sf_AD_txtDownloadFilesToFolder = New System.Windows.Forms.TextBox()
        Me.gb_ChangeLabel = New System.Windows.Forms.GroupBox()
        Me.sf_ChangeLabelOfTorrent_AnotherName = New System.Windows.Forms.ComboBox()
        Me.sf_ChangeLabelOfTorrent_AnotherName_EditList = New System.Windows.Forms.Button()
        Me.sf_ChangeLabelOfTorrent_OnlyIfLabelIsEmpty = New System.Windows.Forms.CheckBox()
        Me.sf_ChangeLabelOfTorrent_ToAnotherName = New System.Windows.Forms.RadioButton()
        Me.sf_ChangeLabelOfTorrent_ToNameSubforum = New System.Windows.Forms.RadioButton()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.RadioButton6 = New System.Windows.Forms.RadioButton()
        Me.GroupBox7 = New System.Windows.Forms.GroupBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txttorrentClientPassword = New System.Windows.Forms.TextBox()
        Me.txttorrentClientUsername = New System.Windows.Forms.TextBox()
        Me.txttorrentClientIncomingPort = New System.Windows.Forms.TextBox()
        Me.RadioButton5 = New System.Windows.Forms.RadioButton()
        Me.GroupBoxUtorrentSettings = New System.Windows.Forms.GroupBox()
        Me.TextBox16 = New System.Windows.Forms.TextBox()
        Me.GroupBox6 = New System.Windows.Forms.GroupBox()
        Me.txtTorrentsPath = New System.Windows.Forms.TextBox()
        Me.btnSelectFolder = New System.Windows.Forms.Button()
        Me.TextBox2 = New System.Windows.Forms.TextBox()
        Me.cbRefreshInfoFromTorFilesAlways = New System.Windows.Forms.CheckBox()
        Me.cbTorrentClientName = New System.Windows.Forms.ComboBox()
        Me.Label40 = New System.Windows.Forms.Label()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtSite_Username = New System.Windows.Forms.TextBox()
        Me.txtSite_Password = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.btntorrentClientAnswerFile = New System.Windows.Forms.Button()
        Me.txttorrentClientAnswerFile = New System.Windows.Forms.TextBox()
        Me.rbDontQueryTorrentClient = New System.Windows.Forms.RadioButton()
        Me.mtxtTorrentClientIPAddress = New System.Windows.Forms.MaskedTextBox()
        Me.TextBox8 = New System.Windows.Forms.TextBox()
        Me.rbTorrentClientOnAnotherComputer = New System.Windows.Forms.RadioButton()
        Me.rbTorrentClientOnThisComputer = New System.Windows.Forms.RadioButton()
        Me.TabPage3 = New System.Windows.Forms.TabPage()
        Me.ReportSeeding_ShowOnlySeedsNotMoreThanValue = New System.Windows.Forms.NumericUpDown()
        Me.ReportSeeding_ShowOnlySeedsNotMoreThanIs = New System.Windows.Forms.CheckBox()
        Me.GroupBox14 = New System.Windows.Forms.GroupBox()
        Me.TextBox17 = New System.Windows.Forms.TextBox()
        Me.ReportAddTextAfterReport = New System.Windows.Forms.TextBox()
        Me.Label25 = New System.Windows.Forms.Label()
        Me.ReportAddTextAfterReportMoreThanXBytesTxt = New System.Windows.Forms.TextBox()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.ReportAddTextAfterReportMoreThanXBytesValue = New System.Windows.Forms.NumericUpDown()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.ReportAddTextAfterEveryXTorrentsTxt = New System.Windows.Forms.TextBox()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.ReportAddTextAfterEveryXTorrentsValue = New System.Windows.Forms.NumericUpDown()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.ReportAddTextBeforeReportTxt = New System.Windows.Forms.TextBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.btn_ReportTemplate = New System.Windows.Forms.Button()
        Me.GroupBox13 = New System.Windows.Forms.GroupBox()
        Me.TextBox9 = New System.Windows.Forms.TextBox()
        Me.rtb_ReportTemplate = New System.Windows.Forms.RichTextBox()
        Me.GroupBox12 = New System.Windows.Forms.GroupBox()
        Me.prog_Report_NameLinkClick_btnAltBrowserSelectAddress = New System.Windows.Forms.Button()
        Me.prog_Report_NameLinkClick_txtAltBrowserAddress = New System.Windows.Forms.TextBox()
        Me.prog_Report_NameLinkClick_obAltBrowser = New System.Windows.Forms.RadioButton()
        Me.prog_Report_NameLinkClick_obDefBrowser = New System.Windows.Forms.RadioButton()
        Me.GroupBox11 = New System.Windows.Forms.GroupBox()
        Me.cbDontAutoShowReports = New System.Windows.Forms.CheckBox()
        Me.TextBox14 = New System.Windows.Forms.TextBox()
        Me.WebFindDateTorRegCb = New System.Windows.Forms.CheckBox()
        Me.WebFindDateTorRegGb = New System.Windows.Forms.GroupBox()
        Me.TextBox15 = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.WebFindDateTorRegForNotMoreSeeds = New System.Windows.Forms.NumericUpDown()
        Me.StatRepcbIsSendStatRep = New System.Windows.Forms.CheckBox()
        Me.gbStatReport = New System.Windows.Forms.GroupBox()
        Me.StatReptxtWatchmenPass = New System.Windows.Forms.TextBox()
        Me.Label41 = New System.Windows.Forms.Label()
        Me.cb_prog_DiscountGenreInSort = New System.Windows.Forms.CheckBox()
        Me.TabPage5 = New System.Windows.Forms.TabPage()
        Me.Label24 = New System.Windows.Forms.Label()
        Me.Panel5 = New System.Windows.Forms.Panel()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.gbUseProxy = New System.Windows.Forms.GroupBox()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.rbProxyAuthorizationManual = New System.Windows.Forms.RadioButton()
        Me.txtProxyAuthorizationDomain = New System.Windows.Forms.TextBox()
        Me.rbProxyAuthorizationUseDefaultCredentials = New System.Windows.Forms.RadioButton()
        Me.txtProxyAuthorizationName = New System.Windows.Forms.TextBox()
        Me.rbProxyAuthorizationNotRequired = New System.Windows.Forms.RadioButton()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.txtProxyAuthorizationPassword = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.rbProxyManual = New System.Windows.Forms.RadioButton()
        Me.txtProxyIPAddress = New System.Windows.Forms.TextBox()
        Me.rbProxyGetSystemWebProxy = New System.Windows.Forms.RadioButton()
        Me.txtProxyPort = New System.Windows.Forms.TextBox()
        Me.rbProxyNotRequired = New System.Windows.Forms.RadioButton()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.TabPage6 = New System.Windows.Forms.TabPage()
        Me.TextBox13 = New System.Windows.Forms.TextBox()
        Me.GroupBox10 = New System.Windows.Forms.GroupBox()
        Me.NUDHours = New System.Windows.Forms.NumericUpDown()
        Me.Label28 = New System.Windows.Forms.Label()
        Me.Label27 = New System.Windows.Forms.Label()
        Me.Label26 = New System.Windows.Forms.Label()
        Me.NUDMinutes = New System.Windows.Forms.NumericUpDown()
        Me.NUDSeconds = New System.Windows.Forms.NumericUpDown()
        Me.GroupBox9 = New System.Windows.Forms.GroupBox()
        Me.TextBox6 = New System.Windows.Forms.TextBox()
        Me.Label36 = New System.Windows.Forms.Label()
        Me.NUDPauseBeforeDownloadWebPageWithCookie = New System.Windows.Forms.NumericUpDown()
        Me.Label35 = New System.Windows.Forms.Label()
        Me.GroupBox8 = New System.Windows.Forms.GroupBox()
        Me.Label32 = New System.Windows.Forms.Label()
        Me.Label34 = New System.Windows.Forms.Label()
        Me.NUDPauseAfterSendCommandToTorrentClient = New System.Windows.Forms.NumericUpDown()
        Me.Label33 = New System.Windows.Forms.Label()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.TextBox5 = New System.Windows.Forms.TextBox()
        Me.LimitSpeedDownloadIs = New System.Windows.Forms.CheckBox()
        Me.Label31 = New System.Windows.Forms.Label()
        Me.LimitSpeedDownloadValue = New System.Windows.Forms.NumericUpDown()
        Me.LimitSpeedUploadValue = New System.Windows.Forms.NumericUpDown()
        Me.Label30 = New System.Windows.Forms.Label()
        Me.LimitSpeedUploadIs = New System.Windows.Forms.CheckBox()
        Me.TabPage7 = New System.Windows.Forms.TabPage()
        Me.Interface_cbCloseToTray = New System.Windows.Forms.CheckBox()
        Me.Interface_cbMinimizeToTray = New System.Windows.Forms.CheckBox()
        Me.Interface_cbRequestOnExit = New System.Windows.Forms.CheckBox()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.Panel1.SuspendLayout()
        Me.gbTorFilesToTorClnt.SuspendLayout()
        Me.gbSaveTorrentFiles.SuspendLayout()
        Me.SaveTorrFiles_gbDownloadByAnotherUser.SuspendLayout()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.TabPage4.SuspendLayout()
        Me.Panel4.SuspendLayout()
        Me.GroupBox15.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.gb_InnerList.SuspendLayout()
        Me.gb_AutoStartStop.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.gb_AutodownloadTorrents.SuspendLayout()
        Me.GroupBox5.SuspendLayout()
        Me.sf_AD_gbWhereTorClientMustSaveTorrentFile.SuspendLayout()
        Me.gb_ChangeLabel.SuspendLayout()
        Me.TabPage2.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.GroupBox7.SuspendLayout()
        Me.GroupBoxUtorrentSettings.SuspendLayout()
        Me.GroupBox6.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.TabPage3.SuspendLayout()
        CType(Me.ReportSeeding_ShowOnlySeedsNotMoreThanValue, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox14.SuspendLayout()
        CType(Me.ReportAddTextAfterReportMoreThanXBytesValue, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ReportAddTextAfterEveryXTorrentsValue, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox13.SuspendLayout()
        Me.GroupBox12.SuspendLayout()
        Me.GroupBox11.SuspendLayout()
        Me.WebFindDateTorRegGb.SuspendLayout()
        CType(Me.WebFindDateTorRegForNotMoreSeeds, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbStatReport.SuspendLayout()
        Me.TabPage5.SuspendLayout()
        Me.Panel5.SuspendLayout()
        Me.gbUseProxy.SuspendLayout()
        Me.TabPage6.SuspendLayout()
        Me.GroupBox10.SuspendLayout()
        CType(Me.NUDHours, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NUDMinutes, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NUDSeconds, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox9.SuspendLayout()
        CType(Me.NUDPauseBeforeDownloadWebPageWithCookie, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox8.SuspendLayout()
        CType(Me.NUDPauseAfterSendCommandToTorrentClient, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox3.SuspendLayout()
        CType(Me.LimitSpeedDownloadValue, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LimitSpeedUploadValue, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage7.SuspendLayout()
        Me.SuspendLayout()
        '
        'cmdCancel
        '
        Me.cmdCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cmdCancel.Location = New System.Drawing.Point(744, 581)
        Me.cmdCancel.Name = "cmdCancel"
        Me.cmdCancel.Size = New System.Drawing.Size(75, 23)
        Me.cmdCancel.TabIndex = 12
        Me.cmdCancel.Text = "Отмена"
        Me.cmdCancel.UseVisualStyleBackColor = True
        '
        'cmdOK
        '
        Me.cmdOK.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdOK.BackColor = System.Drawing.SystemColors.Control
        Me.cmdOK.Location = New System.Drawing.Point(663, 581)
        Me.cmdOK.Name = "cmdOK"
        Me.cmdOK.Size = New System.Drawing.Size(75, 23)
        Me.cmdOK.TabIndex = 11
        Me.cmdOK.Text = "OK"
        Me.cmdOK.UseVisualStyleBackColor = False
        '
        'Panel1
        '
        Me.Panel1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel1.AutoScroll = True
        Me.Panel1.Controls.Add(Me.gbTorFilesToTorClnt)
        Me.Panel1.Controls.Add(Me.gbSaveTorrentFiles)
        Me.Panel1.Controls.Add(Me.cbExtendedLog)
        Me.Panel1.Location = New System.Drawing.Point(6, 6)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(795, 531)
        Me.Panel1.TabIndex = 11
        '
        'gbTorFilesToTorClnt
        '
        Me.gbTorFilesToTorClnt.Controls.Add(Me.Label39)
        Me.gbTorFilesToTorClnt.Controls.Add(Me.RadioButton4)
        Me.gbTorFilesToTorClnt.Controls.Add(Me.RadioButton3)
        Me.gbTorFilesToTorClnt.Controls.Add(Me.Button1)
        Me.gbTorFilesToTorClnt.Controls.Add(Me.TextBox10)
        Me.gbTorFilesToTorClnt.Controls.Add(Me.TextBox7)
        Me.gbTorFilesToTorClnt.Location = New System.Drawing.Point(7, 298)
        Me.gbTorFilesToTorClnt.Name = "gbTorFilesToTorClnt"
        Me.gbTorFilesToTorClnt.Size = New System.Drawing.Size(764, 154)
        Me.gbTorFilesToTorClnt.TabIndex = 29
        Me.gbTorFilesToTorClnt.TabStop = False
        Me.gbTorFilesToTorClnt.Text = "Передача в торрент-клиент (щелчок по значку BitTorrent в Отчёте)"
        '
        'Label39
        '
        Me.Label39.AutoSize = True
        Me.Label39.Location = New System.Drawing.Point(6, 20)
        Me.Label39.Name = "Label39"
        Me.Label39.Size = New System.Drawing.Size(441, 13)
        Me.Label39.TabIndex = 6
        Me.Label39.Text = "В какой папке торрент-клиент должен сохранять передаваемые ему торрент-файлы:"
        '
        'RadioButton4
        '
        Me.RadioButton4.AutoSize = True
        Me.RadioButton4.Location = New System.Drawing.Point(9, 59)
        Me.RadioButton4.Name = "RadioButton4"
        Me.RadioButton4.Size = New System.Drawing.Size(128, 17)
        Me.RadioButton4.TabIndex = 5
        Me.RadioButton4.TabStop = True
        Me.RadioButton4.Text = "в следующей папке:"
        Me.RadioButton4.UseVisualStyleBackColor = True
        '
        'RadioButton3
        '
        Me.RadioButton3.AutoSize = True
        Me.RadioButton3.Location = New System.Drawing.Point(9, 36)
        Me.RadioButton3.Name = "RadioButton3"
        Me.RadioButton3.Size = New System.Drawing.Size(104, 17)
        Me.RadioButton3.TabIndex = 4
        Me.RadioButton3.TabStop = True
        Me.RadioButton3.Text = "не настраивать"
        Me.RadioButton3.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Button1.Location = New System.Drawing.Point(727, 55)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(31, 23)
        Me.Button1.TabIndex = 3
        Me.Button1.Text = "..."
        Me.Button1.UseVisualStyleBackColor = True
        '
        'TextBox10
        '
        Me.TextBox10.Location = New System.Drawing.Point(143, 58)
        Me.TextBox10.Name = "TextBox10"
        Me.TextBox10.ReadOnly = True
        Me.TextBox10.Size = New System.Drawing.Size(578, 20)
        Me.TextBox10.TabIndex = 2
        '
        'TextBox7
        '
        Me.TextBox7.BackColor = System.Drawing.SystemColors.Control
        Me.TextBox7.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TextBox7.Location = New System.Drawing.Point(9, 84)
        Me.TextBox7.Multiline = True
        Me.TextBox7.Name = "TextBox7"
        Me.TextBox7.Size = New System.Drawing.Size(681, 68)
        Me.TextBox7.TabIndex = 0
        Me.TextBox7.Text = resources.GetString("TextBox7.Text")
        '
        'gbSaveTorrentFiles
        '
        Me.gbSaveTorrentFiles.Controls.Add(Me.TextBox3)
        Me.gbSaveTorrentFiles.Controls.Add(Me.SaveTorrFiles_obSaveLinkToFile)
        Me.gbSaveTorrentFiles.Controls.Add(Me.SaveTorrFiles_DownloadByAnotherUser)
        Me.gbSaveTorrentFiles.Controls.Add(Me.SaveTorrFiles_btnSelectPath)
        Me.gbSaveTorrentFiles.Controls.Add(Me.SaveTorrFiles_txtSaveInPath)
        Me.gbSaveTorrentFiles.Controls.Add(Me.SaveTorrFiles_obSaveInPath)
        Me.gbSaveTorrentFiles.Controls.Add(Me.SaveTorrFiles_obRequestPath)
        Me.gbSaveTorrentFiles.Controls.Add(Me.SaveTorrFiles_gbDownloadByAnotherUser)
        Me.gbSaveTorrentFiles.Location = New System.Drawing.Point(7, 34)
        Me.gbSaveTorrentFiles.Name = "gbSaveTorrentFiles"
        Me.gbSaveTorrentFiles.Size = New System.Drawing.Size(764, 258)
        Me.gbSaveTorrentFiles.TabIndex = 28
        Me.gbSaveTorrentFiles.TabStop = False
        Me.gbSaveTorrentFiles.Text = "Что делать при щелчке по значку дискеты в Отчёте:"
        '
        'TextBox3
        '
        Me.TextBox3.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TextBox3.Location = New System.Drawing.Point(35, 228)
        Me.TextBox3.Multiline = True
        Me.TextBox3.Name = "TextBox3"
        Me.TextBox3.ReadOnly = True
        Me.TextBox3.Size = New System.Drawing.Size(708, 14)
        Me.TextBox3.TabIndex = 7
        Me.TextBox3.Text = "Возможности связанных функций перечислены в меню ""Запуск"" - ""Скачивание торрент-ф" & _
            "айлов по списку и работа с пасскеями"""
        '
        'SaveTorrFiles_obSaveLinkToFile
        '
        Me.SaveTorrFiles_obSaveLinkToFile.AutoSize = True
        Me.SaveTorrFiles_obSaveLinkToFile.Location = New System.Drawing.Point(6, 207)
        Me.SaveTorrFiles_obSaveLinkToFile.Name = "SaveTorrFiles_obSaveLinkToFile"
        Me.SaveTorrFiles_obSaveLinkToFile.Size = New System.Drawing.Size(665, 17)
        Me.SaveTorrFiles_obSaveLinkToFile.TabIndex = 6
        Me.SaveTorrFiles_obSaveLinkToFile.TabStop = True
        Me.SaveTorrFiles_obSaveLinkToFile.Text = "Добавлять ссылку в текстовый файл links.txt в папке с программой. Если файл с так" & _
            "им именем не найден - он будет создан."
        Me.SaveTorrFiles_obSaveLinkToFile.UseVisualStyleBackColor = True
        '
        'SaveTorrFiles_DownloadByAnotherUser
        '
        Me.SaveTorrFiles_DownloadByAnotherUser.AutoSize = True
        Me.SaveTorrFiles_DownloadByAnotherUser.Location = New System.Drawing.Point(40, 67)
        Me.SaveTorrFiles_DownloadByAnotherUser.Name = "SaveTorrFiles_DownloadByAnotherUser"
        Me.SaveTorrFiles_DownloadByAnotherUser.Size = New System.Drawing.Size(610, 17)
        Me.SaveTorrFiles_DownloadByAnotherUser.TabIndex = 4
        Me.SaveTorrFiles_DownloadByAnotherUser.Text = "Скачивать от имени другого пользователя. Эта настройка дейстаует на оба варианта " & _
            "скачивания торрент-файлов"
        Me.SaveTorrFiles_DownloadByAnotherUser.UseVisualStyleBackColor = True
        '
        'SaveTorrFiles_btnSelectPath
        '
        Me.SaveTorrFiles_btnSelectPath.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.SaveTorrFiles_btnSelectPath.Location = New System.Drawing.Point(727, 38)
        Me.SaveTorrFiles_btnSelectPath.Name = "SaveTorrFiles_btnSelectPath"
        Me.SaveTorrFiles_btnSelectPath.Size = New System.Drawing.Size(31, 23)
        Me.SaveTorrFiles_btnSelectPath.TabIndex = 3
        Me.SaveTorrFiles_btnSelectPath.Text = "..."
        Me.SaveTorrFiles_btnSelectPath.UseVisualStyleBackColor = True
        '
        'SaveTorrFiles_txtSaveInPath
        '
        Me.SaveTorrFiles_txtSaveInPath.Location = New System.Drawing.Point(214, 41)
        Me.SaveTorrFiles_txtSaveInPath.Name = "SaveTorrFiles_txtSaveInPath"
        Me.SaveTorrFiles_txtSaveInPath.ReadOnly = True
        Me.SaveTorrFiles_txtSaveInPath.Size = New System.Drawing.Size(507, 20)
        Me.SaveTorrFiles_txtSaveInPath.TabIndex = 2
        '
        'SaveTorrFiles_obSaveInPath
        '
        Me.SaveTorrFiles_obSaveInPath.AutoSize = True
        Me.SaveTorrFiles_obSaveInPath.Location = New System.Drawing.Point(6, 42)
        Me.SaveTorrFiles_obSaveInPath.Name = "SaveTorrFiles_obSaveInPath"
        Me.SaveTorrFiles_obSaveInPath.Size = New System.Drawing.Size(202, 17)
        Me.SaveTorrFiles_obSaveInPath.TabIndex = 1
        Me.SaveTorrFiles_obSaveInPath.TabStop = True
        Me.SaveTorrFiles_obSaveInPath.Text = "Сохранять торрент-файлы в папку:"
        Me.SaveTorrFiles_obSaveInPath.UseVisualStyleBackColor = True
        '
        'SaveTorrFiles_obRequestPath
        '
        Me.SaveTorrFiles_obRequestPath.AutoSize = True
        Me.SaveTorrFiles_obRequestPath.Location = New System.Drawing.Point(6, 19)
        Me.SaveTorrFiles_obRequestPath.Name = "SaveTorrFiles_obRequestPath"
        Me.SaveTorrFiles_obRequestPath.Size = New System.Drawing.Size(307, 17)
        Me.SaveTorrFiles_obRequestPath.TabIndex = 0
        Me.SaveTorrFiles_obRequestPath.TabStop = True
        Me.SaveTorrFiles_obRequestPath.Text = "Каждый раз спрашивать, куда сохранять торрент-файл"
        Me.SaveTorrFiles_obRequestPath.UseVisualStyleBackColor = True
        '
        'SaveTorrFiles_gbDownloadByAnotherUser
        '
        Me.SaveTorrFiles_gbDownloadByAnotherUser.Controls.Add(Me.TextBox12)
        Me.SaveTorrFiles_gbDownloadByAnotherUser.Controls.Add(Me.Label38)
        Me.SaveTorrFiles_gbDownloadByAnotherUser.Controls.Add(Me.SaveTorrFiles_DownloadByAnotherUser_Password)
        Me.SaveTorrFiles_gbDownloadByAnotherUser.Controls.Add(Me.SaveTorrFiles_DownloadByAnotherUser_Username)
        Me.SaveTorrFiles_gbDownloadByAnotherUser.Controls.Add(Me.Label37)
        Me.SaveTorrFiles_gbDownloadByAnotherUser.Location = New System.Drawing.Point(31, 67)
        Me.SaveTorrFiles_gbDownloadByAnotherUser.Name = "SaveTorrFiles_gbDownloadByAnotherUser"
        Me.SaveTorrFiles_gbDownloadByAnotherUser.Size = New System.Drawing.Size(706, 131)
        Me.SaveTorrFiles_gbDownloadByAnotherUser.TabIndex = 5
        Me.SaveTorrFiles_gbDownloadByAnotherUser.TabStop = False
        '
        'TextBox12
        '
        Me.TextBox12.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TextBox12.Location = New System.Drawing.Point(6, 75)
        Me.TextBox12.Multiline = True
        Me.TextBox12.Name = "TextBox12"
        Me.TextBox12.ReadOnly = True
        Me.TextBox12.Size = New System.Drawing.Size(696, 54)
        Me.TextBox12.TabIndex = 6
        Me.TextBox12.Text = resources.GetString("TextBox12.Text")
        '
        'Label38
        '
        Me.Label38.AutoSize = True
        Me.Label38.Location = New System.Drawing.Point(64, 52)
        Me.Label38.Name = "Label38"
        Me.Label38.Size = New System.Drawing.Size(48, 13)
        Me.Label38.TabIndex = 3
        Me.Label38.Text = "Пароль:"
        '
        'SaveTorrFiles_DownloadByAnotherUser_Password
        '
        Me.SaveTorrFiles_DownloadByAnotherUser_Password.Location = New System.Drawing.Point(118, 49)
        Me.SaveTorrFiles_DownloadByAnotherUser_Password.Name = "SaveTorrFiles_DownloadByAnotherUser_Password"
        Me.SaveTorrFiles_DownloadByAnotherUser_Password.Size = New System.Drawing.Size(235, 20)
        Me.SaveTorrFiles_DownloadByAnotherUser_Password.TabIndex = 2
        '
        'SaveTorrFiles_DownloadByAnotherUser_Username
        '
        Me.SaveTorrFiles_DownloadByAnotherUser_Username.Location = New System.Drawing.Point(118, 23)
        Me.SaveTorrFiles_DownloadByAnotherUser_Username.Name = "SaveTorrFiles_DownloadByAnotherUser_Username"
        Me.SaveTorrFiles_DownloadByAnotherUser_Username.Size = New System.Drawing.Size(235, 20)
        Me.SaveTorrFiles_DownloadByAnotherUser_Username.TabIndex = 1
        '
        'Label37
        '
        Me.Label37.AutoSize = True
        Me.Label37.Location = New System.Drawing.Point(6, 27)
        Me.Label37.Name = "Label37"
        Me.Label37.Size = New System.Drawing.Size(106, 13)
        Me.Label37.TabIndex = 0
        Me.Label37.Text = "Имя пользователя:"
        '
        'cbExtendedLog
        '
        Me.cbExtendedLog.AutoSize = True
        Me.cbExtendedLog.Location = New System.Drawing.Point(13, 11)
        Me.cbExtendedLog.Name = "cbExtendedLog"
        Me.cbExtendedLog.Size = New System.Drawing.Size(337, 17)
        Me.cbExtendedLog.TabIndex = 27
        Me.cbExtendedLog.Text = "Записывать расширенный лог работы в папку с программой"
        Me.cbExtendedLog.UseVisualStyleBackColor = True
        '
        'cmdVerifySettings
        '
        Me.cmdVerifySettings.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdVerifySettings.Location = New System.Drawing.Point(501, 581)
        Me.cmdVerifySettings.Name = "cmdVerifySettings"
        Me.cmdVerifySettings.Size = New System.Drawing.Size(158, 23)
        Me.cmdVerifySettings.TabIndex = 10
        Me.cmdVerifySettings.Text = "Протестировать настройки"
        Me.cmdVerifySettings.UseVisualStyleBackColor = True
        '
        'TabControl1
        '
        Me.TabControl1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage4)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Controls.Add(Me.TabPage3)
        Me.TabControl1.Controls.Add(Me.TabPage5)
        Me.TabControl1.Controls.Add(Me.TabPage6)
        Me.TabControl1.Controls.Add(Me.TabPage7)
        Me.TabControl1.Location = New System.Drawing.Point(18, 12)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(809, 563)
        Me.TabControl1.TabIndex = 13
        '
        'TabPage1
        '
        Me.TabPage1.BackColor = System.Drawing.SystemColors.Control
        Me.TabPage1.Controls.Add(Me.Panel1)
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(801, 537)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Папки"
        '
        'TabPage4
        '
        Me.TabPage4.BackColor = System.Drawing.SystemColors.Control
        Me.TabPage4.Controls.Add(Me.Panel4)
        Me.TabPage4.Controls.Add(Me.Panel3)
        Me.TabPage4.Location = New System.Drawing.Point(4, 22)
        Me.TabPage4.Name = "TabPage4"
        Me.TabPage4.Size = New System.Drawing.Size(801, 537)
        Me.TabPage4.TabIndex = 3
        Me.TabPage4.Text = "Обрабатываемые подразделы форума"
        '
        'Panel4
        '
        Me.Panel4.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Panel4.Controls.Add(Me.GroupBox15)
        Me.Panel4.Location = New System.Drawing.Point(3, 3)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(315, 531)
        Me.Panel4.TabIndex = 42
        '
        'GroupBox15
        '
        Me.GroupBox15.Controls.Add(Me.sf_SubForumsListColl)
        Me.GroupBox15.Controls.Add(Me.sf_btnMoveDown)
        Me.GroupBox15.Controls.Add(Me.sf_btnSubForumsListColl_SaveAs)
        Me.GroupBox15.Controls.Add(Me.sf_btnMoveUp)
        Me.GroupBox15.Controls.Add(Me.sf_btnSubForumsListColl_Edit)
        Me.GroupBox15.Controls.Add(Me.sf_SubforumsList)
        Me.GroupBox15.Controls.Add(Me.sf_btnEditSubforum)
        Me.GroupBox15.Controls.Add(Me.sf_btnSubForumsListColl_Delete)
        Me.GroupBox15.Controls.Add(Me.sf_btnDeleteSubforum)
        Me.GroupBox15.Controls.Add(Me.sf_btnAddSubforum)
        Me.GroupBox15.Location = New System.Drawing.Point(0, 0)
        Me.GroupBox15.Name = "GroupBox15"
        Me.GroupBox15.Size = New System.Drawing.Size(315, 531)
        Me.GroupBox15.TabIndex = 40
        Me.GroupBox15.TabStop = False
        Me.GroupBox15.Text = "Выберите из коллекции список подразделов:"
        '
        'sf_SubForumsListColl
        '
        Me.sf_SubForumsListColl.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.sf_SubForumsListColl.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource
        Me.sf_SubForumsListColl.FormattingEnabled = True
        Me.sf_SubForumsListColl.Location = New System.Drawing.Point(6, 19)
        Me.sf_SubForumsListColl.Name = "sf_SubForumsListColl"
        Me.sf_SubForumsListColl.Size = New System.Drawing.Size(303, 21)
        Me.sf_SubForumsListColl.TabIndex = 32
        '
        'sf_btnMoveDown
        '
        Me.sf_btnMoveDown.Image = Global.WindowsApplication1.My.Resources.Resources.ArrowDown
        Me.sf_btnMoveDown.ImageAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.sf_btnMoveDown.Location = New System.Drawing.Point(279, 119)
        Me.sf_btnMoveDown.Name = "sf_btnMoveDown"
        Me.sf_btnMoveDown.Size = New System.Drawing.Size(30, 30)
        Me.sf_btnMoveDown.TabIndex = 39
        Me.ToolTip1.SetToolTip(Me.sf_btnMoveDown, "Переместить выбранный подраздел вниз")
        Me.sf_btnMoveDown.UseVisualStyleBackColor = True
        '
        'sf_btnSubForumsListColl_SaveAs
        '
        Me.sf_btnSubForumsListColl_SaveAs.Location = New System.Drawing.Point(6, 46)
        Me.sf_btnSubForumsListColl_SaveAs.Name = "sf_btnSubForumsListColl_SaveAs"
        Me.sf_btnSubForumsListColl_SaveAs.Size = New System.Drawing.Size(69, 23)
        Me.sf_btnSubForumsListColl_SaveAs.TabIndex = 34
        Me.sf_btnSubForumsListColl_SaveAs.Text = "Сохранить"
        Me.sf_btnSubForumsListColl_SaveAs.UseVisualStyleBackColor = True
        '
        'sf_btnMoveUp
        '
        Me.sf_btnMoveUp.Image = Global.WindowsApplication1.My.Resources.Resources.ArrowUp
        Me.sf_btnMoveUp.Location = New System.Drawing.Point(279, 78)
        Me.sf_btnMoveUp.Name = "sf_btnMoveUp"
        Me.sf_btnMoveUp.Size = New System.Drawing.Size(30, 30)
        Me.sf_btnMoveUp.TabIndex = 38
        Me.ToolTip1.SetToolTip(Me.sf_btnMoveUp, "Переместить выбранный подраздел вверх")
        Me.sf_btnMoveUp.UseVisualStyleBackColor = True
        '
        'sf_btnSubForumsListColl_Edit
        '
        Me.sf_btnSubForumsListColl_Edit.Location = New System.Drawing.Point(206, 46)
        Me.sf_btnSubForumsListColl_Edit.Name = "sf_btnSubForumsListColl_Edit"
        Me.sf_btnSubForumsListColl_Edit.Size = New System.Drawing.Size(103, 23)
        Me.sf_btnSubForumsListColl_Edit.TabIndex = 35
        Me.sf_btnSubForumsListColl_Edit.Text = "Правка списка..."
        Me.sf_btnSubForumsListColl_Edit.UseVisualStyleBackColor = True
        Me.sf_btnSubForumsListColl_Edit.Visible = False
        '
        'sf_SubforumsList
        '
        Me.sf_SubforumsList.FormattingEnabled = True
        Me.sf_SubforumsList.Location = New System.Drawing.Point(6, 78)
        Me.sf_SubforumsList.Name = "sf_SubforumsList"
        Me.sf_SubforumsList.Size = New System.Drawing.Size(268, 409)
        Me.sf_SubforumsList.TabIndex = 37
        '
        'sf_btnEditSubforum
        '
        Me.sf_btnEditSubforum.Location = New System.Drawing.Point(114, 497)
        Me.sf_btnEditSubforum.Name = "sf_btnEditSubforum"
        Me.sf_btnEditSubforum.Size = New System.Drawing.Size(86, 23)
        Me.sf_btnEditSubforum.TabIndex = 30
        Me.sf_btnEditSubforum.Text = "Изменить"
        Me.sf_btnEditSubforum.UseVisualStyleBackColor = True
        '
        'sf_btnSubForumsListColl_Delete
        '
        Me.sf_btnSubForumsListColl_Delete.Location = New System.Drawing.Point(102, 46)
        Me.sf_btnSubForumsListColl_Delete.Name = "sf_btnSubForumsListColl_Delete"
        Me.sf_btnSubForumsListColl_Delete.Size = New System.Drawing.Size(75, 23)
        Me.sf_btnSubForumsListColl_Delete.TabIndex = 36
        Me.sf_btnSubForumsListColl_Delete.Text = "Удалить"
        Me.sf_btnSubForumsListColl_Delete.UseVisualStyleBackColor = True
        '
        'sf_btnDeleteSubforum
        '
        Me.sf_btnDeleteSubforum.Location = New System.Drawing.Point(223, 497)
        Me.sf_btnDeleteSubforum.Name = "sf_btnDeleteSubforum"
        Me.sf_btnDeleteSubforum.Size = New System.Drawing.Size(86, 23)
        Me.sf_btnDeleteSubforum.TabIndex = 27
        Me.sf_btnDeleteSubforum.Text = "Удалить"
        Me.sf_btnDeleteSubforum.UseVisualStyleBackColor = True
        '
        'sf_btnAddSubforum
        '
        Me.sf_btnAddSubforum.Location = New System.Drawing.Point(6, 497)
        Me.sf_btnAddSubforum.Name = "sf_btnAddSubforum"
        Me.sf_btnAddSubforum.Size = New System.Drawing.Size(86, 23)
        Me.sf_btnAddSubforum.TabIndex = 26
        Me.sf_btnAddSubforum.Text = "Добавить"
        Me.sf_btnAddSubforum.UseVisualStyleBackColor = True
        '
        'Panel3
        '
        Me.Panel3.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel3.AutoScroll = True
        Me.Panel3.Controls.Add(Me.gb_InnerList)
        Me.Panel3.Controls.Add(Me.sf_AD_cbDownloadIfSeedsNotMore)
        Me.Panel3.Controls.Add(Me.AutoStartStop)
        Me.Panel3.Controls.Add(Me.gb_AutoStartStop)
        Me.Panel3.Controls.Add(Me.GroupBox4)
        Me.Panel3.Controls.Add(Me.sf_ChangeLabelOfTorrent)
        Me.Panel3.Controls.Add(Me.gb_AutodownloadTorrents)
        Me.Panel3.Controls.Add(Me.gb_ChangeLabel)
        Me.Panel3.Location = New System.Drawing.Point(324, 3)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(474, 531)
        Me.Panel3.TabIndex = 41
        '
        'gb_InnerList
        '
        Me.gb_InnerList.Controls.Add(Me.InnerList_cbProcessParent)
        Me.gb_InnerList.Controls.Add(Me.InnerList_llSelectInnerSubf)
        Me.gb_InnerList.Controls.Add(Me.InnerList_obInnerSubfReport)
        Me.gb_InnerList.Controls.Add(Me.InnerList_obSelectedSubfReport)
        Me.gb_InnerList.Location = New System.Drawing.Point(3, 324)
        Me.gb_InnerList.Name = "gb_InnerList"
        Me.gb_InnerList.Size = New System.Drawing.Size(452, 87)
        Me.gb_InnerList.TabIndex = 45
        Me.gb_InnerList.TabStop = False
        Me.gb_InnerList.Text = "Тип отчёта"
        '
        'InnerList_cbProcessParent
        '
        Me.InnerList_cbProcessParent.AutoSize = True
        Me.InnerList_cbProcessParent.Location = New System.Drawing.Point(26, 65)
        Me.InnerList_cbProcessParent.Name = "InnerList_cbProcessParent"
        Me.InnerList_cbProcessParent.Size = New System.Drawing.Size(336, 17)
        Me.InnerList_cbProcessParent.TabIndex = 3
        Me.InnerList_cbProcessParent.Text = "Обрабатывать вместе со вложенными и текущий подраздел"
        Me.InnerList_cbProcessParent.UseVisualStyleBackColor = True
        '
        'InnerList_llSelectInnerSubf
        '
        Me.InnerList_llSelectInnerSubf.AutoSize = True
        Me.InnerList_llSelectInnerSubf.Location = New System.Drawing.Point(292, 44)
        Me.InnerList_llSelectInnerSubf.Name = "InnerList_llSelectInnerSubf"
        Me.InnerList_llSelectInnerSubf.Size = New System.Drawing.Size(145, 13)
        Me.InnerList_llSelectInnerSubf.TabIndex = 2
        Me.InnerList_llSelectInnerSubf.TabStop = True
        Me.InnerList_llSelectInnerSubf.Text = "Выбрано 0 из 0 вложенных"
        '
        'InnerList_obInnerSubfReport
        '
        Me.InnerList_obInnerSubfReport.AutoSize = True
        Me.InnerList_obInnerSubfReport.Location = New System.Drawing.Point(6, 42)
        Me.InnerList_obInnerSubfReport.Name = "InnerList_obInnerSubfReport"
        Me.InnerList_obInnerSubfReport.Size = New System.Drawing.Size(281, 17)
        Me.InnerList_obInnerSubfReport.TabIndex = 1
        Me.InnerList_obInnerSubfReport.TabStop = True
        Me.InnerList_obInnerSubfReport.Text = "Объединённый отчёт по вложенным подразделам"
        Me.InnerList_obInnerSubfReport.UseVisualStyleBackColor = True
        '
        'InnerList_obSelectedSubfReport
        '
        Me.InnerList_obSelectedSubfReport.AutoSize = True
        Me.InnerList_obSelectedSubfReport.Location = New System.Drawing.Point(6, 19)
        Me.InnerList_obSelectedSubfReport.Name = "InnerList_obSelectedSubfReport"
        Me.InnerList_obSelectedSubfReport.Size = New System.Drawing.Size(301, 17)
        Me.InnerList_obSelectedSubfReport.TabIndex = 0
        Me.InnerList_obSelectedSubfReport.TabStop = True
        Me.InnerList_obSelectedSubfReport.Text = "Отчёт по выбранному подразделу (т.е. обычный отчёт)"
        Me.InnerList_obSelectedSubfReport.UseVisualStyleBackColor = True
        '
        'sf_AD_cbDownloadIfSeedsNotMore
        '
        Me.sf_AD_cbDownloadIfSeedsNotMore.AutoSize = True
        Me.sf_AD_cbDownloadIfSeedsNotMore.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.sf_AD_cbDownloadIfSeedsNotMore.Location = New System.Drawing.Point(9, 419)
        Me.sf_AD_cbDownloadIfSeedsNotMore.Name = "sf_AD_cbDownloadIfSeedsNotMore"
        Me.sf_AD_cbDownloadIfSeedsNotMore.Size = New System.Drawing.Size(366, 17)
        Me.sf_AD_cbDownloadIfSeedsNotMore.TabIndex = 2
        Me.sf_AD_cbDownloadIfSeedsNotMore.Text = "Автоматически скачивать раздачи при количестве сидов не более"
        Me.sf_AD_cbDownloadIfSeedsNotMore.UseVisualStyleBackColor = True
        '
        'AutoStartStop
        '
        Me.AutoStartStop.AutoSize = True
        Me.AutoStartStop.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.AutoStartStop.Location = New System.Drawing.Point(9, 236)
        Me.AutoStartStop.Name = "AutoStartStop"
        Me.AutoStartStop.Size = New System.Drawing.Size(360, 17)
        Me.AutoStartStop.TabIndex = 44
        Me.AutoStartStop.Text = "Автоматически запускать и останавливать сидируемые раздачи:"
        Me.AutoStartStop.UseVisualStyleBackColor = True
        '
        'gb_AutoStartStop
        '
        Me.gb_AutoStartStop.Controls.Add(Me.AutoStartStop_StartForced)
        Me.gb_AutoStartStop.Controls.Add(Me.AutoStartStop_NumberOfSeedsNotMore)
        Me.gb_AutoStartStop.Controls.Add(Me.Label19)
        Me.gb_AutoStartStop.Controls.Add(Me.Label17)
        Me.gb_AutoStartStop.Location = New System.Drawing.Point(3, 238)
        Me.gb_AutoStartStop.Name = "gb_AutoStartStop"
        Me.gb_AutoStartStop.Size = New System.Drawing.Size(452, 80)
        Me.gb_AutoStartStop.TabIndex = 43
        Me.gb_AutoStartStop.TabStop = False
        '
        'AutoStartStop_StartForced
        '
        Me.AutoStartStop_StartForced.AutoSize = True
        Me.AutoStartStop_StartForced.Location = New System.Drawing.Point(26, 58)
        Me.AutoStartStop_StartForced.Name = "AutoStartStop_StartForced"
        Me.AutoStartStop_StartForced.Size = New System.Drawing.Size(158, 17)
        Me.AutoStartStop_StartForced.TabIndex = 3
        Me.AutoStartStop_StartForced.Text = "Запускать принудительно"
        Me.AutoStartStop_StartForced.UseVisualStyleBackColor = True
        '
        'AutoStartStop_NumberOfSeedsNotMore
        '
        Me.AutoStartStop_NumberOfSeedsNotMore.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.AutoStartStop_NumberOfSeedsNotMore.FormattingEnabled = True
        Me.AutoStartStop_NumberOfSeedsNotMore.Items.AddRange(New Object() {"0", "1", "2", "3", "4", "5", "6", "7", "8", "9", "10"})
        Me.AutoStartStop_NumberOfSeedsNotMore.Location = New System.Drawing.Point(231, 18)
        Me.AutoStartStop_NumberOfSeedsNotMore.Name = "AutoStartStop_NumberOfSeedsNotMore"
        Me.AutoStartStop_NumberOfSeedsNotMore.Size = New System.Drawing.Size(38, 21)
        Me.AutoStartStop_NumberOfSeedsNotMore.TabIndex = 2
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Location = New System.Drawing.Point(23, 42)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(406, 13)
        Me.Label19.TabIndex = 1
        Me.Label19.Text = "Остановка происходит при кол-ве сидов больше этого числа на два и больше."
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Location = New System.Drawing.Point(3, 21)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(222, 13)
        Me.Label17.TabIndex = 0
        Me.Label17.Text = "Запускать раздачу, если сидов не больше"
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.sf_txtSubforumFullPath)
        Me.GroupBox4.Controls.Add(Me.Label29)
        Me.GroupBox4.Controls.Add(Me.Label16)
        Me.GroupBox4.Controls.Add(Me.sf_txtSubForumNumber)
        Me.GroupBox4.Location = New System.Drawing.Point(3, 3)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(452, 109)
        Me.GroupBox4.TabIndex = 37
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "Данные о выбраном подразделе"
        '
        'sf_txtSubforumFullPath
        '
        Me.sf_txtSubforumFullPath.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.sf_txtSubforumFullPath.Location = New System.Drawing.Point(6, 55)
        Me.sf_txtSubforumFullPath.Multiline = True
        Me.sf_txtSubforumFullPath.Name = "sf_txtSubforumFullPath"
        Me.sf_txtSubforumFullPath.ReadOnly = True
        Me.sf_txtSubforumFullPath.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.sf_txtSubforumFullPath.Size = New System.Drawing.Size(440, 48)
        Me.sf_txtSubforumFullPath.TabIndex = 32
        '
        'Label29
        '
        Me.Label29.AutoSize = True
        Me.Label29.Location = New System.Drawing.Point(6, 39)
        Me.Label29.Name = "Label29"
        Me.Label29.Size = New System.Drawing.Size(146, 13)
        Me.Label29.TabIndex = 41
        Me.Label29.Text = "Полный путь к подразделу:"
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(6, 19)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(84, 13)
        Me.Label16.TabIndex = 41
        Me.Label16.Text = "№ подраздела:"
        '
        'sf_txtSubForumNumber
        '
        Me.sf_txtSubForumNumber.Location = New System.Drawing.Point(96, 16)
        Me.sf_txtSubForumNumber.Name = "sf_txtSubForumNumber"
        Me.sf_txtSubForumNumber.ReadOnly = True
        Me.sf_txtSubForumNumber.Size = New System.Drawing.Size(95, 20)
        Me.sf_txtSubForumNumber.TabIndex = 42
        '
        'sf_ChangeLabelOfTorrent
        '
        Me.sf_ChangeLabelOfTorrent.AutoSize = True
        Me.sf_ChangeLabelOfTorrent.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.sf_ChangeLabelOfTorrent.Location = New System.Drawing.Point(9, 115)
        Me.sf_ChangeLabelOfTorrent.Name = "sf_ChangeLabelOfTorrent"
        Me.sf_ChangeLabelOfTorrent.Size = New System.Drawing.Size(350, 17)
        Me.sf_ChangeLabelOfTorrent.TabIndex = 36
        Me.sf_ChangeLabelOfTorrent.Text = "В торрент-клиентах изменять метку для раздач подраздела на:"
        Me.sf_ChangeLabelOfTorrent.UseVisualStyleBackColor = True
        '
        'gb_AutodownloadTorrents
        '
        Me.gb_AutodownloadTorrents.BackColor = System.Drawing.SystemColors.Control
        Me.gb_AutodownloadTorrents.Controls.Add(Me.sf_AD_cbNumberOfSeeds)
        Me.gb_AutodownloadTorrents.Controls.Add(Me.RadioButton2)
        Me.gb_AutodownloadTorrents.Controls.Add(Me.GroupBox5)
        Me.gb_AutodownloadTorrents.Controls.Add(Me.RadioButton1)
        Me.gb_AutodownloadTorrents.Controls.Add(Me.sf_AD_gbWhereTorClientMustSaveTorrentFile)
        Me.gb_AutodownloadTorrents.Controls.Add(Me.TextBox4)
        Me.gb_AutodownloadTorrents.Controls.Add(Me.Label11)
        Me.gb_AutodownloadTorrents.Controls.Add(Me.sf_AD_btnSelectDownloadFolder)
        Me.gb_AutodownloadTorrents.Controls.Add(Me.sf_AD_txtDownloadFilesToFolder)
        Me.gb_AutodownloadTorrents.Location = New System.Drawing.Point(3, 417)
        Me.gb_AutodownloadTorrents.Name = "gb_AutodownloadTorrents"
        Me.gb_AutodownloadTorrents.Size = New System.Drawing.Size(452, 319)
        Me.gb_AutodownloadTorrents.TabIndex = 40
        Me.gb_AutodownloadTorrents.TabStop = False
        '
        'sf_AD_cbNumberOfSeeds
        '
        Me.sf_AD_cbNumberOfSeeds.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.sf_AD_cbNumberOfSeeds.FormattingEnabled = True
        Me.sf_AD_cbNumberOfSeeds.Items.AddRange(New Object() {"0", "1", "2", "3", "4", "5", "6", "7", "8", "9", "10"})
        Me.sf_AD_cbNumberOfSeeds.Location = New System.Drawing.Point(372, 0)
        Me.sf_AD_cbNumberOfSeeds.Name = "sf_AD_cbNumberOfSeeds"
        Me.sf_AD_cbNumberOfSeeds.Size = New System.Drawing.Size(38, 21)
        Me.sf_AD_cbNumberOfSeeds.TabIndex = 3
        '
        'RadioButton2
        '
        Me.RadioButton2.AutoSize = True
        Me.RadioButton2.Location = New System.Drawing.Point(12, 110)
        Me.RadioButton2.Name = "RadioButton2"
        Me.RadioButton2.Size = New System.Drawing.Size(135, 17)
        Me.RadioButton2.TabIndex = 15
        Me.RadioButton2.TabStop = True
        Me.RadioButton2.Text = "собрать название из:"
        Me.RadioButton2.UseVisualStyleBackColor = True
        '
        'GroupBox5
        '
        Me.GroupBox5.Controls.Add(Me.LinkLabel1)
        Me.GroupBox5.Controls.Add(Me.sf_AD_txtNameOfTorrentPathTemplate)
        Me.GroupBox5.Location = New System.Drawing.Point(6, 113)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Size = New System.Drawing.Size(440, 64)
        Me.GroupBox5.TabIndex = 16
        Me.GroupBox5.TabStop = False
        '
        'LinkLabel1
        '
        Me.LinkLabel1.AutoSize = True
        Me.LinkLabel1.Location = New System.Drawing.Point(189, 43)
        Me.LinkLabel1.Name = "LinkLabel1"
        Me.LinkLabel1.Size = New System.Drawing.Size(242, 13)
        Me.LinkLabel1.TabIndex = 13
        Me.LinkLabel1.TabStop = True
        Me.LinkLabel1.Text = "Справка по разрешённым здесь переменным"
        '
        'sf_AD_txtNameOfTorrentPathTemplate
        '
        Me.sf_AD_txtNameOfTorrentPathTemplate.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.sf_AD_txtNameOfTorrentPathTemplate.Location = New System.Drawing.Point(6, 20)
        Me.sf_AD_txtNameOfTorrentPathTemplate.Name = "sf_AD_txtNameOfTorrentPathTemplate"
        Me.sf_AD_txtNameOfTorrentPathTemplate.Size = New System.Drawing.Size(425, 20)
        Me.sf_AD_txtNameOfTorrentPathTemplate.TabIndex = 12
        '
        'RadioButton1
        '
        Me.RadioButton1.AutoSize = True
        Me.RadioButton1.Location = New System.Drawing.Point(12, 87)
        Me.RadioButton1.Name = "RadioButton1"
        Me.RadioButton1.Size = New System.Drawing.Size(226, 17)
        Me.RadioButton1.TabIndex = 14
        Me.RadioButton1.TabStop = True
        Me.RadioButton1.Text = "скопировать название раздачи с сайта"
        Me.RadioButton1.UseVisualStyleBackColor = True
        '
        'sf_AD_gbWhereTorClientMustSaveTorrentFile
        '
        Me.sf_AD_gbWhereTorClientMustSaveTorrentFile.Controls.Add(Me.sf_AD_WhereTorClientMustSaveTorrentFile_btnCustomPath)
        Me.sf_AD_gbWhereTorClientMustSaveTorrentFile.Controls.Add(Me.sf_AD_WhereTorClientMustSaveTorrentFile_txtCustomPath)
        Me.sf_AD_gbWhereTorClientMustSaveTorrentFile.Controls.Add(Me.sf_AD_WhereTorClientMustSaveTorrentFile_rbCustomPath)
        Me.sf_AD_gbWhereTorClientMustSaveTorrentFile.Controls.Add(Me.TextBox11)
        Me.sf_AD_gbWhereTorClientMustSaveTorrentFile.Controls.Add(Me.sf_AD_WhereTorClientMustSaveTorrentFile_rbDefaultPath)
        Me.sf_AD_gbWhereTorClientMustSaveTorrentFile.Location = New System.Drawing.Point(6, 183)
        Me.sf_AD_gbWhereTorClientMustSaveTorrentFile.Name = "sf_AD_gbWhereTorClientMustSaveTorrentFile"
        Me.sf_AD_gbWhereTorClientMustSaveTorrentFile.Size = New System.Drawing.Size(440, 128)
        Me.sf_AD_gbWhereTorClientMustSaveTorrentFile.TabIndex = 13
        Me.sf_AD_gbWhereTorClientMustSaveTorrentFile.TabStop = False
        Me.sf_AD_gbWhereTorClientMustSaveTorrentFile.Text = "В какой папке торрент-клиент должен сохранять торрент-файлы подраздела:"
        '
        'sf_AD_WhereTorClientMustSaveTorrentFile_btnCustomPath
        '
        Me.sf_AD_WhereTorClientMustSaveTorrentFile_btnCustomPath.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.sf_AD_WhereTorClientMustSaveTorrentFile_btnCustomPath.Location = New System.Drawing.Point(402, 96)
        Me.sf_AD_WhereTorClientMustSaveTorrentFile_btnCustomPath.Name = "sf_AD_WhereTorClientMustSaveTorrentFile_btnCustomPath"
        Me.sf_AD_WhereTorClientMustSaveTorrentFile_btnCustomPath.Size = New System.Drawing.Size(29, 23)
        Me.sf_AD_WhereTorClientMustSaveTorrentFile_btnCustomPath.TabIndex = 4
        Me.sf_AD_WhereTorClientMustSaveTorrentFile_btnCustomPath.Text = "..."
        Me.sf_AD_WhereTorClientMustSaveTorrentFile_btnCustomPath.UseVisualStyleBackColor = True
        '
        'sf_AD_WhereTorClientMustSaveTorrentFile_txtCustomPath
        '
        Me.sf_AD_WhereTorClientMustSaveTorrentFile_txtCustomPath.Location = New System.Drawing.Point(17, 99)
        Me.sf_AD_WhereTorClientMustSaveTorrentFile_txtCustomPath.Name = "sf_AD_WhereTorClientMustSaveTorrentFile_txtCustomPath"
        Me.sf_AD_WhereTorClientMustSaveTorrentFile_txtCustomPath.ReadOnly = True
        Me.sf_AD_WhereTorClientMustSaveTorrentFile_txtCustomPath.Size = New System.Drawing.Size(379, 20)
        Me.sf_AD_WhereTorClientMustSaveTorrentFile_txtCustomPath.TabIndex = 3
        '
        'sf_AD_WhereTorClientMustSaveTorrentFile_rbCustomPath
        '
        Me.sf_AD_WhereTorClientMustSaveTorrentFile_rbCustomPath.AutoSize = True
        Me.sf_AD_WhereTorClientMustSaveTorrentFile_rbCustomPath.Location = New System.Drawing.Point(6, 76)
        Me.sf_AD_WhereTorClientMustSaveTorrentFile_rbCustomPath.Name = "sf_AD_WhereTorClientMustSaveTorrentFile_rbCustomPath"
        Me.sf_AD_WhereTorClientMustSaveTorrentFile_rbCustomPath.Size = New System.Drawing.Size(149, 17)
        Me.sf_AD_WhereTorClientMustSaveTorrentFile_rbCustomPath.TabIndex = 2
        Me.sf_AD_WhereTorClientMustSaveTorrentFile_rbCustomPath.TabStop = True
        Me.sf_AD_WhereTorClientMustSaveTorrentFile_rbCustomPath.Text = "в нижеуказанной папке:"
        Me.sf_AD_WhereTorClientMustSaveTorrentFile_rbCustomPath.UseVisualStyleBackColor = True
        '
        'TextBox11
        '
        Me.TextBox11.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TextBox11.Location = New System.Drawing.Point(20, 42)
        Me.TextBox11.Multiline = True
        Me.TextBox11.Name = "TextBox11"
        Me.TextBox11.ReadOnly = True
        Me.TextBox11.Size = New System.Drawing.Size(346, 28)
        Me.TextBox11.TabIndex = 1
        Me.TextBox11.Text = "В этом случае папка берётся из: вкладка ""Папки"" - раздел ""Передача скачанных торр" & _
            "ент-файлов в торрент-клиент"""
        '
        'sf_AD_WhereTorClientMustSaveTorrentFile_rbDefaultPath
        '
        Me.sf_AD_WhereTorClientMustSaveTorrentFile_rbDefaultPath.AutoSize = True
        Me.sf_AD_WhereTorClientMustSaveTorrentFile_rbDefaultPath.Location = New System.Drawing.Point(6, 19)
        Me.sf_AD_WhereTorClientMustSaveTorrentFile_rbDefaultPath.Name = "sf_AD_WhereTorClientMustSaveTorrentFile_rbDefaultPath"
        Me.sf_AD_WhereTorClientMustSaveTorrentFile_rbDefaultPath.Size = New System.Drawing.Size(138, 17)
        Me.sf_AD_WhereTorClientMustSaveTorrentFile_rbDefaultPath.TabIndex = 0
        Me.sf_AD_WhereTorClientMustSaveTorrentFile_rbDefaultPath.TabStop = True
        Me.sf_AD_WhereTorClientMustSaveTorrentFile_rbDefaultPath.Text = "в папке по умолчанию"
        Me.sf_AD_WhereTorClientMustSaveTorrentFile_rbDefaultPath.UseVisualStyleBackColor = True
        '
        'TextBox4
        '
        Me.TextBox4.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TextBox4.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TextBox4.Location = New System.Drawing.Point(6, 64)
        Me.TextBox4.Multiline = True
        Me.TextBox4.Name = "TextBox4"
        Me.TextBox4.ReadOnly = True
        Me.TextBox4.Size = New System.Drawing.Size(440, 17)
        Me.TextBox4.TabIndex = 5
        Me.TextBox4.Text = "Для скачиваемой раздачи в этой папке будет создаваться подпапка с названием:"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(6, 20)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(48, 13)
        Me.Label11.TabIndex = 4
        Me.Label11.Text = "в папку:"
        '
        'sf_AD_btnSelectDownloadFolder
        '
        Me.sf_AD_btnSelectDownloadFolder.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.sf_AD_btnSelectDownloadFolder.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.sf_AD_btnSelectDownloadFolder.Location = New System.Drawing.Point(417, 35)
        Me.sf_AD_btnSelectDownloadFolder.Name = "sf_AD_btnSelectDownloadFolder"
        Me.sf_AD_btnSelectDownloadFolder.Size = New System.Drawing.Size(29, 23)
        Me.sf_AD_btnSelectDownloadFolder.TabIndex = 1
        Me.sf_AD_btnSelectDownloadFolder.Text = "..."
        Me.sf_AD_btnSelectDownloadFolder.UseVisualStyleBackColor = True
        '
        'sf_AD_txtDownloadFilesToFolder
        '
        Me.sf_AD_txtDownloadFilesToFolder.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.sf_AD_txtDownloadFilesToFolder.Location = New System.Drawing.Point(6, 38)
        Me.sf_AD_txtDownloadFilesToFolder.Name = "sf_AD_txtDownloadFilesToFolder"
        Me.sf_AD_txtDownloadFilesToFolder.ReadOnly = True
        Me.sf_AD_txtDownloadFilesToFolder.Size = New System.Drawing.Size(405, 20)
        Me.sf_AD_txtDownloadFilesToFolder.TabIndex = 0
        '
        'gb_ChangeLabel
        '
        Me.gb_ChangeLabel.BackColor = System.Drawing.SystemColors.Control
        Me.gb_ChangeLabel.Controls.Add(Me.sf_ChangeLabelOfTorrent_AnotherName)
        Me.gb_ChangeLabel.Controls.Add(Me.sf_ChangeLabelOfTorrent_AnotherName_EditList)
        Me.gb_ChangeLabel.Controls.Add(Me.sf_ChangeLabelOfTorrent_OnlyIfLabelIsEmpty)
        Me.gb_ChangeLabel.Controls.Add(Me.sf_ChangeLabelOfTorrent_ToAnotherName)
        Me.gb_ChangeLabel.Controls.Add(Me.sf_ChangeLabelOfTorrent_ToNameSubforum)
        Me.gb_ChangeLabel.Location = New System.Drawing.Point(3, 118)
        Me.gb_ChangeLabel.Name = "gb_ChangeLabel"
        Me.gb_ChangeLabel.Size = New System.Drawing.Size(452, 114)
        Me.gb_ChangeLabel.TabIndex = 39
        Me.gb_ChangeLabel.TabStop = False
        Me.gb_ChangeLabel.Text = "GroupBox6"
        '
        'sf_ChangeLabelOfTorrent_AnotherName
        '
        Me.sf_ChangeLabelOfTorrent_AnotherName.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.sf_ChangeLabelOfTorrent_AnotherName.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource
        Me.sf_ChangeLabelOfTorrent_AnotherName.FormattingEnabled = True
        Me.sf_ChangeLabelOfTorrent_AnotherName.Location = New System.Drawing.Point(26, 65)
        Me.sf_ChangeLabelOfTorrent_AnotherName.Name = "sf_ChangeLabelOfTorrent_AnotherName"
        Me.sf_ChangeLabelOfTorrent_AnotherName.Size = New System.Drawing.Size(420, 21)
        Me.sf_ChangeLabelOfTorrent_AnotherName.TabIndex = 42
        '
        'sf_ChangeLabelOfTorrent_AnotherName_EditList
        '
        Me.sf_ChangeLabelOfTorrent_AnotherName_EditList.Location = New System.Drawing.Point(320, 37)
        Me.sf_ChangeLabelOfTorrent_AnotherName_EditList.Name = "sf_ChangeLabelOfTorrent_AnotherName_EditList"
        Me.sf_ChangeLabelOfTorrent_AnotherName_EditList.Size = New System.Drawing.Size(107, 22)
        Me.sf_ChangeLabelOfTorrent_AnotherName_EditList.TabIndex = 41
        Me.sf_ChangeLabelOfTorrent_AnotherName_EditList.Text = "Правка списка..."
        Me.sf_ChangeLabelOfTorrent_AnotherName_EditList.UseVisualStyleBackColor = True
        Me.sf_ChangeLabelOfTorrent_AnotherName_EditList.Visible = False
        '
        'sf_ChangeLabelOfTorrent_OnlyIfLabelIsEmpty
        '
        Me.sf_ChangeLabelOfTorrent_OnlyIfLabelIsEmpty.AutoSize = True
        Me.sf_ChangeLabelOfTorrent_OnlyIfLabelIsEmpty.Location = New System.Drawing.Point(26, 91)
        Me.sf_ChangeLabelOfTorrent_OnlyIfLabelIsEmpty.Name = "sf_ChangeLabelOfTorrent_OnlyIfLabelIsEmpty"
        Me.sf_ChangeLabelOfTorrent_OnlyIfLabelIsEmpty.Size = New System.Drawing.Size(206, 17)
        Me.sf_ChangeLabelOfTorrent_OnlyIfLabelIsEmpty.TabIndex = 40
        Me.sf_ChangeLabelOfTorrent_OnlyIfLabelIsEmpty.Text = "Менять, только если метка пустая."
        Me.sf_ChangeLabelOfTorrent_OnlyIfLabelIsEmpty.UseVisualStyleBackColor = True
        '
        'sf_ChangeLabelOfTorrent_ToAnotherName
        '
        Me.sf_ChangeLabelOfTorrent_ToAnotherName.AutoSize = True
        Me.sf_ChangeLabelOfTorrent_ToAnotherName.Location = New System.Drawing.Point(26, 42)
        Me.sf_ChangeLabelOfTorrent_ToAnotherName.Name = "sf_ChangeLabelOfTorrent_ToAnotherName"
        Me.sf_ChangeLabelOfTorrent_ToAnotherName.Size = New System.Drawing.Size(113, 17)
        Me.sf_ChangeLabelOfTorrent_ToAnotherName.TabIndex = 39
        Me.sf_ChangeLabelOfTorrent_ToAnotherName.TabStop = True
        Me.sf_ChangeLabelOfTorrent_ToAnotherName.Text = "другое название:"
        Me.sf_ChangeLabelOfTorrent_ToAnotherName.UseVisualStyleBackColor = True
        '
        'sf_ChangeLabelOfTorrent_ToNameSubforum
        '
        Me.sf_ChangeLabelOfTorrent_ToNameSubforum.AutoSize = True
        Me.sf_ChangeLabelOfTorrent_ToNameSubforum.Location = New System.Drawing.Point(26, 19)
        Me.sf_ChangeLabelOfTorrent_ToNameSubforum.Name = "sf_ChangeLabelOfTorrent_ToNameSubforum"
        Me.sf_ChangeLabelOfTorrent_ToNameSubforum.Size = New System.Drawing.Size(139, 17)
        Me.sf_ChangeLabelOfTorrent_ToNameSubforum.TabIndex = 38
        Me.sf_ChangeLabelOfTorrent_ToNameSubforum.TabStop = True
        Me.sf_ChangeLabelOfTorrent_ToNameSubforum.Text = "название подраздела."
        Me.sf_ChangeLabelOfTorrent_ToNameSubforum.UseVisualStyleBackColor = True
        '
        'TabPage2
        '
        Me.TabPage2.BackColor = System.Drawing.SystemColors.Control
        Me.TabPage2.Controls.Add(Me.Panel2)
        Me.TabPage2.Location = New System.Drawing.Point(4, 22)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(801, 537)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Торрент-клиент и аккаунты"
        '
        'Panel2
        '
        Me.Panel2.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel2.AutoScroll = True
        Me.Panel2.Controls.Add(Me.RadioButton6)
        Me.Panel2.Controls.Add(Me.GroupBox7)
        Me.Panel2.Controls.Add(Me.RadioButton5)
        Me.Panel2.Controls.Add(Me.GroupBoxUtorrentSettings)
        Me.Panel2.Controls.Add(Me.cbTorrentClientName)
        Me.Panel2.Controls.Add(Me.Label40)
        Me.Panel2.Controls.Add(Me.GroupBox2)
        Me.Panel2.Controls.Add(Me.GroupBox1)
        Me.Panel2.Location = New System.Drawing.Point(6, 6)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(789, 525)
        Me.Panel2.TabIndex = 0
        '
        'RadioButton6
        '
        Me.RadioButton6.AutoSize = True
        Me.RadioButton6.Location = New System.Drawing.Point(479, 238)
        Me.RadioButton6.Name = "RadioButton6"
        Me.RadioButton6.Size = New System.Drawing.Size(112, 17)
        Me.RadioButton6.TabIndex = 56
        Me.RadioButton6.TabStop = True
        Me.RadioButton6.Text = "указать вручную:"
        Me.RadioButton6.UseVisualStyleBackColor = True
        Me.RadioButton6.Visible = False
        '
        'GroupBox7
        '
        Me.GroupBox7.Controls.Add(Me.Label1)
        Me.GroupBox7.Controls.Add(Me.Label2)
        Me.GroupBox7.Controls.Add(Me.Label3)
        Me.GroupBox7.Controls.Add(Me.txttorrentClientPassword)
        Me.GroupBox7.Controls.Add(Me.txttorrentClientUsername)
        Me.GroupBox7.Controls.Add(Me.txttorrentClientIncomingPort)
        Me.GroupBox7.Location = New System.Drawing.Point(6, 265)
        Me.GroupBox7.Name = "GroupBox7"
        Me.GroupBox7.Size = New System.Drawing.Size(625, 99)
        Me.GroupBox7.TabIndex = 48
        Me.GroupBox7.TabStop = False
        Me.GroupBox7.Text = "Порт, имя, пароль доступа к торрент-клиенту - берём данные из торрент-клиента"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(6, 16)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(237, 13)
        Me.Label1.TabIndex = 36
        Me.Label1.Text = "Порт входящих соединений торрент-клиента:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(6, 44)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(278, 13)
        Me.Label2.TabIndex = 21
        Me.Label2.Text = "Имя учетной записи подключения к торрент-клиенту:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(6, 75)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(294, 13)
        Me.Label3.TabIndex = 22
        Me.Label3.Text = "Пароль учетной записи подключения к торрент-клиенту:"
        '
        'txttorrentClientPassword
        '
        Me.txttorrentClientPassword.Location = New System.Drawing.Point(304, 72)
        Me.txttorrentClientPassword.Name = "txttorrentClientPassword"
        Me.txttorrentClientPassword.Size = New System.Drawing.Size(315, 20)
        Me.txttorrentClientPassword.TabIndex = 2
        '
        'txttorrentClientUsername
        '
        Me.txttorrentClientUsername.Location = New System.Drawing.Point(304, 41)
        Me.txttorrentClientUsername.Name = "txttorrentClientUsername"
        Me.txttorrentClientUsername.Size = New System.Drawing.Size(315, 20)
        Me.txttorrentClientUsername.TabIndex = 1
        '
        'txttorrentClientIncomingPort
        '
        Me.txttorrentClientIncomingPort.Location = New System.Drawing.Point(249, 13)
        Me.txttorrentClientIncomingPort.Name = "txttorrentClientIncomingPort"
        Me.txttorrentClientIncomingPort.Size = New System.Drawing.Size(70, 20)
        Me.txttorrentClientIncomingPort.TabIndex = 0
        '
        'RadioButton5
        '
        Me.RadioButton5.AutoSize = True
        Me.RadioButton5.Location = New System.Drawing.Point(479, 215)
        Me.RadioButton5.Name = "RadioButton5"
        Me.RadioButton5.Size = New System.Drawing.Size(188, 17)
        Me.RadioButton5.TabIndex = 55
        Me.RadioButton5.TabStop = True
        Me.RadioButton5.Text = "автоматически брать из utorrent"
        Me.RadioButton5.UseVisualStyleBackColor = True
        Me.RadioButton5.Visible = False
        '
        'GroupBoxUtorrentSettings
        '
        Me.GroupBoxUtorrentSettings.Controls.Add(Me.TextBox16)
        Me.GroupBoxUtorrentSettings.Controls.Add(Me.GroupBox6)
        Me.GroupBoxUtorrentSettings.Controls.Add(Me.cbRefreshInfoFromTorFilesAlways)
        Me.GroupBoxUtorrentSettings.Location = New System.Drawing.Point(6, 31)
        Me.GroupBoxUtorrentSettings.Name = "GroupBoxUtorrentSettings"
        Me.GroupBoxUtorrentSettings.Size = New System.Drawing.Size(757, 156)
        Me.GroupBoxUtorrentSettings.TabIndex = 47
        Me.GroupBoxUtorrentSettings.TabStop = False
        Me.GroupBoxUtorrentSettings.Text = "Дополнительные настройки, если используется торрент-клиент utorrent"
        '
        'TextBox16
        '
        Me.TextBox16.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TextBox16.Location = New System.Drawing.Point(37, 132)
        Me.TextBox16.Multiline = True
        Me.TextBox16.Name = "TextBox16"
        Me.TextBox16.ReadOnly = True
        Me.TextBox16.Size = New System.Drawing.Size(695, 21)
        Me.TextBox16.TabIndex = 58
        Me.TextBox16.Text = "При изменении количества и(или) названия торрент-файлов в папке автоматически буд" & _
            "ет обновлена информация из них."
        '
        'GroupBox6
        '
        Me.GroupBox6.Controls.Add(Me.txtTorrentsPath)
        Me.GroupBox6.Controls.Add(Me.btnSelectFolder)
        Me.GroupBox6.Controls.Add(Me.TextBox2)
        Me.GroupBox6.Location = New System.Drawing.Point(9, 19)
        Me.GroupBox6.Name = "GroupBox6"
        Me.GroupBox6.Size = New System.Drawing.Size(738, 82)
        Me.GroupBox6.TabIndex = 57
        Me.GroupBox6.TabStop = False
        Me.GroupBox6.Text = "Папка, в которой находятся torrent-файлы"
        '
        'txtTorrentsPath
        '
        Me.txtTorrentsPath.BackColor = System.Drawing.SystemColors.Control
        Me.txtTorrentsPath.Location = New System.Drawing.Point(6, 24)
        Me.txtTorrentsPath.Name = "txtTorrentsPath"
        Me.txtTorrentsPath.ReadOnly = True
        Me.txtTorrentsPath.Size = New System.Drawing.Size(689, 20)
        Me.txtTorrentsPath.TabIndex = 51
        '
        'btnSelectFolder
        '
        Me.btnSelectFolder.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.btnSelectFolder.Location = New System.Drawing.Point(701, 22)
        Me.btnSelectFolder.Name = "btnSelectFolder"
        Me.btnSelectFolder.Size = New System.Drawing.Size(31, 23)
        Me.btnSelectFolder.TabIndex = 0
        Me.btnSelectFolder.Text = "..."
        Me.btnSelectFolder.UseVisualStyleBackColor = True
        '
        'TextBox2
        '
        Me.TextBox2.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TextBox2.Location = New System.Drawing.Point(6, 50)
        Me.TextBox2.Multiline = True
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.ReadOnly = True
        Me.TextBox2.Size = New System.Drawing.Size(465, 28)
        Me.TextBox2.TabIndex = 53
        Me.TextBox2.Text = "Во вложенных папках torrent-файлы тоже ищутся. Если папку не указать, или указать" & _
            " неправильно, то информация о скачанных раздачах, их статусах не будет собрана."
        '
        'cbRefreshInfoFromTorFilesAlways
        '
        Me.cbRefreshInfoFromTorFilesAlways.AutoSize = True
        Me.cbRefreshInfoFromTorFilesAlways.Location = New System.Drawing.Point(9, 113)
        Me.cbRefreshInfoFromTorFilesAlways.Name = "cbRefreshInfoFromTorFilesAlways"
        Me.cbRefreshInfoFromTorFilesAlways.Size = New System.Drawing.Size(359, 17)
        Me.cbRefreshInfoFromTorFilesAlways.TabIndex = 54
        Me.cbRefreshInfoFromTorFilesAlways.Text = "Получать информацию из торрент-файлов при каждой обработке"
        Me.cbRefreshInfoFromTorFilesAlways.UseVisualStyleBackColor = True
        '
        'cbTorrentClientName
        '
        Me.cbTorrentClientName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbTorrentClientName.FormattingEnabled = True
        Me.cbTorrentClientName.Items.AddRange(New Object() {"utorrent", "Transmission"})
        Me.cbTorrentClientName.Location = New System.Drawing.Point(180, 4)
        Me.cbTorrentClientName.Name = "cbTorrentClientName"
        Me.cbTorrentClientName.Size = New System.Drawing.Size(121, 21)
        Me.cbTorrentClientName.TabIndex = 0
        '
        'Label40
        '
        Me.Label40.AutoSize = True
        Me.Label40.Location = New System.Drawing.Point(3, 7)
        Me.Label40.Name = "Label40"
        Me.Label40.Size = New System.Drawing.Size(165, 13)
        Me.Label40.TabIndex = 39
        Me.Label40.Text = "Выберите Ваш торрент-клиент:"
        '
        'GroupBox2
        '
        Me.GroupBox2.BackColor = System.Drawing.SystemColors.Control
        Me.GroupBox2.Controls.Add(Me.Label4)
        Me.GroupBox2.Controls.Add(Me.txtSite_Username)
        Me.GroupBox2.Controls.Add(Me.txtSite_Password)
        Me.GroupBox2.Controls.Add(Me.Label5)
        Me.GroupBox2.Controls.Add(Me.TextBox1)
        Me.GroupBox2.Location = New System.Drawing.Point(6, 370)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(757, 150)
        Me.GroupBox2.TabIndex = 38
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Параметры доступа на сайт rutracker.org"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(6, 16)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(216, 13)
        Me.Label4.TabIndex = 30
        Me.Label4.Text = "Имя пользователя на сайте rutracker.org:"
        '
        'txtSite_Username
        '
        Me.txtSite_Username.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtSite_Username.Location = New System.Drawing.Point(240, 13)
        Me.txtSite_Username.Name = "txtSite_Username"
        Me.txtSite_Username.Size = New System.Drawing.Size(511, 20)
        Me.txtSite_Username.TabIndex = 0
        '
        'txtSite_Password
        '
        Me.txtSite_Password.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtSite_Password.Location = New System.Drawing.Point(240, 39)
        Me.txtSite_Password.Name = "txtSite_Password"
        Me.txtSite_Password.Size = New System.Drawing.Size(511, 20)
        Me.txtSite_Password.TabIndex = 1
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(2, 42)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(232, 13)
        Me.Label5.TabIndex = 31
        Me.Label5.Text = "Пароль пользователя на сайте rutracker.org:"
        '
        'TextBox1
        '
        Me.TextBox1.BackColor = System.Drawing.SystemColors.Control
        Me.TextBox1.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TextBox1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.TextBox1.Location = New System.Drawing.Point(5, 65)
        Me.TextBox1.Multiline = True
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.ReadOnly = True
        Me.TextBox1.Size = New System.Drawing.Size(745, 78)
        Me.TextBox1.TabIndex = 32
        Me.TextBox1.TabStop = False
        Me.TextBox1.Text = resources.GetString("TextBox1.Text")
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.btntorrentClientAnswerFile)
        Me.GroupBox1.Controls.Add(Me.txttorrentClientAnswerFile)
        Me.GroupBox1.Controls.Add(Me.rbDontQueryTorrentClient)
        Me.GroupBox1.Controls.Add(Me.mtxtTorrentClientIPAddress)
        Me.GroupBox1.Controls.Add(Me.TextBox8)
        Me.GroupBox1.Controls.Add(Me.rbTorrentClientOnAnotherComputer)
        Me.GroupBox1.Controls.Add(Me.rbTorrentClientOnThisComputer)
        Me.GroupBox1.Location = New System.Drawing.Point(6, 193)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(321, 66)
        Me.GroupBox1.TabIndex = 2
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Торрент-клиент находится:"
        '
        'btntorrentClientAnswerFile
        '
        Me.btntorrentClientAnswerFile.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btntorrentClientAnswerFile.Enabled = False
        Me.btntorrentClientAnswerFile.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.btntorrentClientAnswerFile.Location = New System.Drawing.Point(287, 85)
        Me.btntorrentClientAnswerFile.Name = "btntorrentClientAnswerFile"
        Me.btntorrentClientAnswerFile.Size = New System.Drawing.Size(28, 23)
        Me.btntorrentClientAnswerFile.TabIndex = 4
        Me.btntorrentClientAnswerFile.Text = "..."
        Me.btntorrentClientAnswerFile.UseVisualStyleBackColor = True
        Me.btntorrentClientAnswerFile.Visible = False
        '
        'txttorrentClientAnswerFile
        '
        Me.txttorrentClientAnswerFile.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txttorrentClientAnswerFile.BackColor = System.Drawing.SystemColors.Control
        Me.txttorrentClientAnswerFile.Enabled = False
        Me.txttorrentClientAnswerFile.Location = New System.Drawing.Point(40, 88)
        Me.txttorrentClientAnswerFile.Name = "txttorrentClientAnswerFile"
        Me.txttorrentClientAnswerFile.ReadOnly = True
        Me.txttorrentClientAnswerFile.Size = New System.Drawing.Size(241, 20)
        Me.txttorrentClientAnswerFile.TabIndex = 38
        Me.txttorrentClientAnswerFile.TabStop = False
        Me.txttorrentClientAnswerFile.Visible = False
        '
        'rbDontQueryTorrentClient
        '
        Me.rbDontQueryTorrentClient.AutoSize = True
        Me.rbDontQueryTorrentClient.Enabled = False
        Me.rbDontQueryTorrentClient.Location = New System.Drawing.Point(6, 65)
        Me.rbDontQueryTorrentClient.Name = "rbDontQueryTorrentClient"
        Me.rbDontQueryTorrentClient.Size = New System.Drawing.Size(391, 17)
        Me.rbDontQueryTorrentClient.TabIndex = 3
        Me.rbDontQueryTorrentClient.TabStop = True
        Me.rbDontQueryTorrentClient.Text = "Не опрашивать торрент-клиент. Получить данные из текстового файла:"
        Me.rbDontQueryTorrentClient.UseVisualStyleBackColor = True
        Me.rbDontQueryTorrentClient.Visible = False
        '
        'mtxtTorrentClientIPAddress
        '
        Me.mtxtTorrentClientIPAddress.Location = New System.Drawing.Point(226, 41)
        Me.mtxtTorrentClientIPAddress.Name = "mtxtTorrentClientIPAddress"
        Me.mtxtTorrentClientIPAddress.Size = New System.Drawing.Size(90, 20)
        Me.mtxtTorrentClientIPAddress.TabIndex = 0
        '
        'TextBox8
        '
        Me.TextBox8.BackColor = System.Drawing.SystemColors.Control
        Me.TextBox8.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TextBox8.Enabled = False
        Me.TextBox8.ForeColor = System.Drawing.SystemColors.ControlText
        Me.TextBox8.Location = New System.Drawing.Point(40, 114)
        Me.TextBox8.Multiline = True
        Me.TextBox8.Name = "TextBox8"
        Me.TextBox8.ReadOnly = True
        Me.TextBox8.Size = New System.Drawing.Size(655, 66)
        Me.TextBox8.TabIndex = 32
        Me.TextBox8.TabStop = False
        Me.TextBox8.Text = resources.GetString("TextBox8.Text")
        Me.TextBox8.Visible = False
        '
        'rbTorrentClientOnAnotherComputer
        '
        Me.rbTorrentClientOnAnotherComputer.AutoSize = True
        Me.rbTorrentClientOnAnotherComputer.Location = New System.Drawing.Point(6, 42)
        Me.rbTorrentClientOnAnotherComputer.Name = "rbTorrentClientOnAnotherComputer"
        Me.rbTorrentClientOnAnotherComputer.Size = New System.Drawing.Size(214, 17)
        Me.rbTorrentClientOnAnotherComputer.TabIndex = 1
        Me.rbTorrentClientOnAnotherComputer.TabStop = True
        Me.rbTorrentClientOnAnotherComputer.Text = "на другом компьютере, его IP-адрес:"
        Me.rbTorrentClientOnAnotherComputer.UseVisualStyleBackColor = True
        '
        'rbTorrentClientOnThisComputer
        '
        Me.rbTorrentClientOnThisComputer.AutoSize = True
        Me.rbTorrentClientOnThisComputer.Location = New System.Drawing.Point(6, 19)
        Me.rbTorrentClientOnThisComputer.Name = "rbTorrentClientOnThisComputer"
        Me.rbTorrentClientOnThisComputer.Size = New System.Drawing.Size(148, 17)
        Me.rbTorrentClientOnThisComputer.TabIndex = 0
        Me.rbTorrentClientOnThisComputer.TabStop = True
        Me.rbTorrentClientOnThisComputer.Text = "на этом же компьютере"
        Me.rbTorrentClientOnThisComputer.UseVisualStyleBackColor = True
        '
        'TabPage3
        '
        Me.TabPage3.AutoScroll = True
        Me.TabPage3.BackColor = System.Drawing.SystemColors.Control
        Me.TabPage3.Controls.Add(Me.ReportSeeding_ShowOnlySeedsNotMoreThanValue)
        Me.TabPage3.Controls.Add(Me.ReportSeeding_ShowOnlySeedsNotMoreThanIs)
        Me.TabPage3.Controls.Add(Me.GroupBox14)
        Me.TabPage3.Controls.Add(Me.btn_ReportTemplate)
        Me.TabPage3.Controls.Add(Me.GroupBox13)
        Me.TabPage3.Controls.Add(Me.GroupBox12)
        Me.TabPage3.Controls.Add(Me.GroupBox11)
        Me.TabPage3.Controls.Add(Me.WebFindDateTorRegCb)
        Me.TabPage3.Controls.Add(Me.WebFindDateTorRegGb)
        Me.TabPage3.Controls.Add(Me.StatRepcbIsSendStatRep)
        Me.TabPage3.Controls.Add(Me.gbStatReport)
        Me.TabPage3.Controls.Add(Me.cb_prog_DiscountGenreInSort)
        Me.TabPage3.Location = New System.Drawing.Point(4, 22)
        Me.TabPage3.Name = "TabPage3"
        Me.TabPage3.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage3.Size = New System.Drawing.Size(801, 537)
        Me.TabPage3.TabIndex = 4
        Me.TabPage3.Text = "Отчёты"
        '
        'ReportSeeding_ShowOnlySeedsNotMoreThanValue
        '
        Me.ReportSeeding_ShowOnlySeedsNotMoreThanValue.Location = New System.Drawing.Point(547, 147)
        Me.ReportSeeding_ShowOnlySeedsNotMoreThanValue.Maximum = New Decimal(New Integer() {1000, 0, 0, 0})
        Me.ReportSeeding_ShowOnlySeedsNotMoreThanValue.Name = "ReportSeeding_ShowOnlySeedsNotMoreThanValue"
        Me.ReportSeeding_ShowOnlySeedsNotMoreThanValue.Size = New System.Drawing.Size(47, 20)
        Me.ReportSeeding_ShowOnlySeedsNotMoreThanValue.TabIndex = 2
        Me.ReportSeeding_ShowOnlySeedsNotMoreThanValue.Value = New Decimal(New Integer() {1000, 0, 0, 0})
        '
        'ReportSeeding_ShowOnlySeedsNotMoreThanIs
        '
        Me.ReportSeeding_ShowOnlySeedsNotMoreThanIs.AutoSize = True
        Me.ReportSeeding_ShowOnlySeedsNotMoreThanIs.Location = New System.Drawing.Point(6, 148)
        Me.ReportSeeding_ShowOnlySeedsNotMoreThanIs.Name = "ReportSeeding_ShowOnlySeedsNotMoreThanIs"
        Me.ReportSeeding_ShowOnlySeedsNotMoreThanIs.Size = New System.Drawing.Size(543, 17)
        Me.ReportSeeding_ShowOnlySeedsNotMoreThanIs.TabIndex = 42
        Me.ReportSeeding_ShowOnlySeedsNotMoreThanIs.Text = "В Отчёте в форум о сидируемых раздачах отображать только раздачи с количеством си" & _
            "дов не более"
        Me.ReportSeeding_ShowOnlySeedsNotMoreThanIs.UseVisualStyleBackColor = True
        '
        'GroupBox14
        '
        Me.GroupBox14.Controls.Add(Me.TextBox17)
        Me.GroupBox14.Controls.Add(Me.ReportAddTextAfterReport)
        Me.GroupBox14.Controls.Add(Me.Label25)
        Me.GroupBox14.Controls.Add(Me.ReportAddTextAfterReportMoreThanXBytesTxt)
        Me.GroupBox14.Controls.Add(Me.Label22)
        Me.GroupBox14.Controls.Add(Me.ReportAddTextAfterReportMoreThanXBytesValue)
        Me.GroupBox14.Controls.Add(Me.Label21)
        Me.GroupBox14.Controls.Add(Me.ReportAddTextAfterEveryXTorrentsTxt)
        Me.GroupBox14.Controls.Add(Me.Label18)
        Me.GroupBox14.Controls.Add(Me.ReportAddTextAfterEveryXTorrentsValue)
        Me.GroupBox14.Controls.Add(Me.Label14)
        Me.GroupBox14.Controls.Add(Me.ReportAddTextBeforeReportTxt)
        Me.GroupBox14.Controls.Add(Me.Label13)
        Me.GroupBox14.Location = New System.Drawing.Point(6, 668)
        Me.GroupBox14.Name = "GroupBox14"
        Me.GroupBox14.Size = New System.Drawing.Size(741, 482)
        Me.GroupBox14.TabIndex = 40
        Me.GroupBox14.TabStop = False
        Me.GroupBox14.Text = "Общие части в отчёте в форум"
        '
        'TextBox17
        '
        Me.TextBox17.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TextBox17.Location = New System.Drawing.Point(25, 247)
        Me.TextBox17.Multiline = True
        Me.TextBox17.Name = "TextBox17"
        Me.TextBox17.ReadOnly = True
        Me.TextBox17.Size = New System.Drawing.Size(665, 52)
        Me.TextBox17.TabIndex = 12
        Me.TextBox17.Text = resources.GetString("TextBox17.Text")
        '
        'ReportAddTextAfterReport
        '
        Me.ReportAddTextAfterReport.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.ReportAddTextAfterReport.Location = New System.Drawing.Point(25, 399)
        Me.ReportAddTextAfterReport.Multiline = True
        Me.ReportAddTextAfterReport.Name = "ReportAddTextAfterReport"
        Me.ReportAddTextAfterReport.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.ReportAddTextAfterReport.Size = New System.Drawing.Size(710, 75)
        Me.ReportAddTextAfterReport.TabIndex = 11
        Me.ReportAddTextAfterReport.WordWrap = False
        '
        'Label25
        '
        Me.Label25.AutoSize = True
        Me.Label25.Location = New System.Drawing.Point(6, 383)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(234, 13)
        Me.Label25.TabIndex = 10
        Me.Label25.Text = "В конце отчета добавлять следующий текст:"
        '
        'ReportAddTextAfterReportMoreThanXBytesTxt
        '
        Me.ReportAddTextAfterReportMoreThanXBytesTxt.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.ReportAddTextAfterReportMoreThanXBytesTxt.Location = New System.Drawing.Point(25, 305)
        Me.ReportAddTextAfterReportMoreThanXBytesTxt.Multiline = True
        Me.ReportAddTextAfterReportMoreThanXBytesTxt.Name = "ReportAddTextAfterReportMoreThanXBytesTxt"
        Me.ReportAddTextAfterReportMoreThanXBytesTxt.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.ReportAddTextAfterReportMoreThanXBytesTxt.Size = New System.Drawing.Size(710, 75)
        Me.ReportAddTextAfterReportMoreThanXBytesTxt.TabIndex = 9
        Me.ReportAddTextAfterReportMoreThanXBytesTxt.WordWrap = False
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.Location = New System.Drawing.Point(384, 223)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(181, 13)
        Me.Label22.TabIndex = 8
        Me.Label22.Text = "байт добавлять следующий текст:"
        '
        'ReportAddTextAfterReportMoreThanXBytesValue
        '
        Me.ReportAddTextAfterReportMoreThanXBytesValue.Location = New System.Drawing.Point(303, 221)
        Me.ReportAddTextAfterReportMoreThanXBytesValue.Maximum = New Decimal(New Integer() {1000000, 0, 0, 0})
        Me.ReportAddTextAfterReportMoreThanXBytesValue.Minimum = New Decimal(New Integer() {10000, 0, 0, 0})
        Me.ReportAddTextAfterReportMoreThanXBytesValue.Name = "ReportAddTextAfterReportMoreThanXBytesValue"
        Me.ReportAddTextAfterReportMoreThanXBytesValue.Size = New System.Drawing.Size(75, 20)
        Me.ReportAddTextAfterReportMoreThanXBytesValue.TabIndex = 7
        Me.ReportAddTextAfterReportMoreThanXBytesValue.Value = New Decimal(New Integer() {100000, 0, 0, 0})
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Location = New System.Drawing.Point(6, 223)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(291, 13)
        Me.Label21.TabIndex = 6
        Me.Label21.Text = "Каждый раз по достижении отчётом размера, кратного"
        '
        'ReportAddTextAfterEveryXTorrentsTxt
        '
        Me.ReportAddTextAfterEveryXTorrentsTxt.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.ReportAddTextAfterEveryXTorrentsTxt.Location = New System.Drawing.Point(25, 140)
        Me.ReportAddTextAfterEveryXTorrentsTxt.Multiline = True
        Me.ReportAddTextAfterEveryXTorrentsTxt.Name = "ReportAddTextAfterEveryXTorrentsTxt"
        Me.ReportAddTextAfterEveryXTorrentsTxt.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.ReportAddTextAfterEveryXTorrentsTxt.Size = New System.Drawing.Size(710, 75)
        Me.ReportAddTextAfterEveryXTorrentsTxt.TabIndex = 5
        Me.ReportAddTextAfterEveryXTorrentsTxt.WordWrap = False
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Location = New System.Drawing.Point(159, 116)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(193, 13)
        Me.Label18.TabIndex = 4
        Me.Label18.Text = "раздач добавлять следующий текст:"
        '
        'ReportAddTextAfterEveryXTorrentsValue
        '
        Me.ReportAddTextAfterEveryXTorrentsValue.Location = New System.Drawing.Point(93, 114)
        Me.ReportAddTextAfterEveryXTorrentsValue.Maximum = New Decimal(New Integer() {1000, 0, 0, 0})
        Me.ReportAddTextAfterEveryXTorrentsValue.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.ReportAddTextAfterEveryXTorrentsValue.Name = "ReportAddTextAfterEveryXTorrentsValue"
        Me.ReportAddTextAfterEveryXTorrentsValue.Size = New System.Drawing.Size(60, 20)
        Me.ReportAddTextAfterEveryXTorrentsValue.TabIndex = 3
        Me.ReportAddTextAfterEveryXTorrentsValue.Value = New Decimal(New Integer() {10, 0, 0, 0})
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(6, 116)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(81, 13)
        Me.Label14.TabIndex = 2
        Me.Label14.Text = "После каждых"
        '
        'ReportAddTextBeforeReportTxt
        '
        Me.ReportAddTextBeforeReportTxt.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.ReportAddTextBeforeReportTxt.Location = New System.Drawing.Point(25, 32)
        Me.ReportAddTextBeforeReportTxt.Multiline = True
        Me.ReportAddTextBeforeReportTxt.Name = "ReportAddTextBeforeReportTxt"
        Me.ReportAddTextBeforeReportTxt.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.ReportAddTextBeforeReportTxt.Size = New System.Drawing.Size(710, 75)
        Me.ReportAddTextBeforeReportTxt.TabIndex = 1
        Me.ReportAddTextBeforeReportTxt.WordWrap = False
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(6, 16)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(317, 13)
        Me.Label13.TabIndex = 0
        Me.Label13.Text = "Перед началом отчёта в форум добавлять следующий текст:"
        '
        'btn_ReportTemplate
        '
        Me.btn_ReportTemplate.Location = New System.Drawing.Point(746, 324)
        Me.btn_ReportTemplate.Name = "btn_ReportTemplate"
        Me.btn_ReportTemplate.Size = New System.Drawing.Size(32, 23)
        Me.btn_ReportTemplate.TabIndex = 3
        Me.btn_ReportTemplate.Text = "Найденные переменные подсветить зелёным цветом"
        Me.btn_ReportTemplate.UseVisualStyleBackColor = True
        '
        'GroupBox13
        '
        Me.GroupBox13.Controls.Add(Me.TextBox9)
        Me.GroupBox13.Controls.Add(Me.rtb_ReportTemplate)
        Me.GroupBox13.Location = New System.Drawing.Point(6, 249)
        Me.GroupBox13.Name = "GroupBox13"
        Me.GroupBox13.Size = New System.Drawing.Size(741, 413)
        Me.GroupBox13.TabIndex = 39
        Me.GroupBox13.TabStop = False
        Me.GroupBox13.Text = "Формат отображения информации о каждой раздаче в отчете в форум:"
        '
        'TextBox9
        '
        Me.TextBox9.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TextBox9.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.TextBox9.Location = New System.Drawing.Point(6, 100)
        Me.TextBox9.Multiline = True
        Me.TextBox9.Name = "TextBox9"
        Me.TextBox9.ReadOnly = True
        Me.TextBox9.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.TextBox9.Size = New System.Drawing.Size(729, 305)
        Me.TextBox9.TabIndex = 2
        Me.TextBox9.Text = resources.GetString("TextBox9.Text")
        '
        'rtb_ReportTemplate
        '
        Me.rtb_ReportTemplate.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.rtb_ReportTemplate.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.rtb_ReportTemplate.Location = New System.Drawing.Point(6, 19)
        Me.rtb_ReportTemplate.Name = "rtb_ReportTemplate"
        Me.rtb_ReportTemplate.Size = New System.Drawing.Size(729, 75)
        Me.rtb_ReportTemplate.TabIndex = 0
        Me.rtb_ReportTemplate.Text = ""
        '
        'GroupBox12
        '
        Me.GroupBox12.Controls.Add(Me.prog_Report_NameLinkClick_btnAltBrowserSelectAddress)
        Me.GroupBox12.Controls.Add(Me.prog_Report_NameLinkClick_txtAltBrowserAddress)
        Me.GroupBox12.Controls.Add(Me.prog_Report_NameLinkClick_obAltBrowser)
        Me.GroupBox12.Controls.Add(Me.prog_Report_NameLinkClick_obDefBrowser)
        Me.GroupBox12.Location = New System.Drawing.Point(6, 173)
        Me.GroupBox12.Name = "GroupBox12"
        Me.GroupBox12.Size = New System.Drawing.Size(741, 70)
        Me.GroupBox12.TabIndex = 38
        Me.GroupBox12.TabStop = False
        Me.GroupBox12.Text = "При щелчке по названию раздачи в отчёте открывать веб-страницу раздачи"
        '
        'prog_Report_NameLinkClick_btnAltBrowserSelectAddress
        '
        Me.prog_Report_NameLinkClick_btnAltBrowserSelectAddress.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.prog_Report_NameLinkClick_btnAltBrowserSelectAddress.Location = New System.Drawing.Point(704, 38)
        Me.prog_Report_NameLinkClick_btnAltBrowserSelectAddress.Name = "prog_Report_NameLinkClick_btnAltBrowserSelectAddress"
        Me.prog_Report_NameLinkClick_btnAltBrowserSelectAddress.Size = New System.Drawing.Size(31, 23)
        Me.prog_Report_NameLinkClick_btnAltBrowserSelectAddress.TabIndex = 3
        Me.prog_Report_NameLinkClick_btnAltBrowserSelectAddress.Text = "..."
        Me.prog_Report_NameLinkClick_btnAltBrowserSelectAddress.UseVisualStyleBackColor = True
        '
        'prog_Report_NameLinkClick_txtAltBrowserAddress
        '
        Me.prog_Report_NameLinkClick_txtAltBrowserAddress.Location = New System.Drawing.Point(132, 41)
        Me.prog_Report_NameLinkClick_txtAltBrowserAddress.Name = "prog_Report_NameLinkClick_txtAltBrowserAddress"
        Me.prog_Report_NameLinkClick_txtAltBrowserAddress.ReadOnly = True
        Me.prog_Report_NameLinkClick_txtAltBrowserAddress.Size = New System.Drawing.Size(566, 20)
        Me.prog_Report_NameLinkClick_txtAltBrowserAddress.TabIndex = 2
        '
        'prog_Report_NameLinkClick_obAltBrowser
        '
        Me.prog_Report_NameLinkClick_obAltBrowser.AutoSize = True
        Me.prog_Report_NameLinkClick_obAltBrowser.Location = New System.Drawing.Point(6, 42)
        Me.prog_Report_NameLinkClick_obAltBrowser.Name = "prog_Report_NameLinkClick_obAltBrowser"
        Me.prog_Report_NameLinkClick_obAltBrowser.Size = New System.Drawing.Size(120, 17)
        Me.prog_Report_NameLinkClick_obAltBrowser.TabIndex = 1
        Me.prog_Report_NameLinkClick_obAltBrowser.TabStop = True
        Me.prog_Report_NameLinkClick_obAltBrowser.Text = "в другом браузере"
        Me.prog_Report_NameLinkClick_obAltBrowser.UseVisualStyleBackColor = True
        '
        'prog_Report_NameLinkClick_obDefBrowser
        '
        Me.prog_Report_NameLinkClick_obDefBrowser.AutoSize = True
        Me.prog_Report_NameLinkClick_obDefBrowser.Location = New System.Drawing.Point(6, 19)
        Me.prog_Report_NameLinkClick_obDefBrowser.Name = "prog_Report_NameLinkClick_obDefBrowser"
        Me.prog_Report_NameLinkClick_obDefBrowser.Size = New System.Drawing.Size(155, 17)
        Me.prog_Report_NameLinkClick_obDefBrowser.TabIndex = 0
        Me.prog_Report_NameLinkClick_obDefBrowser.TabStop = True
        Me.prog_Report_NameLinkClick_obDefBrowser.Text = "в браузере по умолчанию"
        Me.prog_Report_NameLinkClick_obDefBrowser.UseVisualStyleBackColor = True
        '
        'GroupBox11
        '
        Me.GroupBox11.Controls.Add(Me.cbDontAutoShowReports)
        Me.GroupBox11.Controls.Add(Me.TextBox14)
        Me.GroupBox11.Location = New System.Drawing.Point(393, 59)
        Me.GroupBox11.Name = "GroupBox11"
        Me.GroupBox11.Size = New System.Drawing.Size(307, 82)
        Me.GroupBox11.TabIndex = 37
        Me.GroupBox11.TabStop = False
        Me.GroupBox11.Text = "GroupBox11"
        '
        'cbDontAutoShowReports
        '
        Me.cbDontAutoShowReports.AutoSize = True
        Me.cbDontAutoShowReports.Location = New System.Drawing.Point(6, 0)
        Me.cbDontAutoShowReports.Name = "cbDontAutoShowReports"
        Me.cbDontAutoShowReports.Size = New System.Drawing.Size(215, 17)
        Me.cbDontAutoShowReports.TabIndex = 35
        Me.cbDontAutoShowReports.Text = "НЕ создавать отчёты автоматически"
        Me.cbDontAutoShowReports.UseVisualStyleBackColor = True
        '
        'TextBox14
        '
        Me.TextBox14.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TextBox14.Location = New System.Drawing.Point(6, 23)
        Me.TextBox14.Multiline = True
        Me.TextBox14.Name = "TextBox14"
        Me.TextBox14.ReadOnly = True
        Me.TextBox14.Size = New System.Drawing.Size(295, 55)
        Me.TextBox14.TabIndex = 36
        Me.TextBox14.Text = "Полезно, если у Вас программа работает по таймеру, и Вам эти отчёты не нужны кажд" & _
            "ый раз. Если же они Вам понадобятся, то в меню ""Запуск"" щелкните ""Показать отчёт" & _
            "ы"". Они будут сформированы и показаны."
        '
        'WebFindDateTorRegCb
        '
        Me.WebFindDateTorRegCb.AutoSize = True
        Me.WebFindDateTorRegCb.Location = New System.Drawing.Point(15, 33)
        Me.WebFindDateTorRegCb.Name = "WebFindDateTorRegCb"
        Me.WebFindDateTorRegCb.Size = New System.Drawing.Size(314, 17)
        Me.WebFindDateTorRegCb.TabIndex = 34
        Me.WebFindDateTorRegCb.Text = "Выяснять даты регистрации торрент-файлов на трекере"
        Me.WebFindDateTorRegCb.UseVisualStyleBackColor = True
        '
        'WebFindDateTorRegGb
        '
        Me.WebFindDateTorRegGb.Controls.Add(Me.TextBox15)
        Me.WebFindDateTorRegGb.Controls.Add(Me.Label7)
        Me.WebFindDateTorRegGb.Controls.Add(Me.WebFindDateTorRegForNotMoreSeeds)
        Me.WebFindDateTorRegGb.Location = New System.Drawing.Point(6, 35)
        Me.WebFindDateTorRegGb.Name = "WebFindDateTorRegGb"
        Me.WebFindDateTorRegGb.Size = New System.Drawing.Size(342, 90)
        Me.WebFindDateTorRegGb.TabIndex = 33
        Me.WebFindDateTorRegGb.TabStop = False
        '
        'TextBox15
        '
        Me.TextBox15.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TextBox15.Location = New System.Drawing.Point(20, 43)
        Me.TextBox15.Multiline = True
        Me.TextBox15.Name = "TextBox15"
        Me.TextBox15.ReadOnly = True
        Me.TextBox15.Size = New System.Drawing.Size(316, 41)
        Me.TextBox15.TabIndex = 36
        Me.TextBox15.Text = "Снимите галочку, если Вам не нужны даты регистрации нескачанных торрент-файлов.На" & _
            "пример, если вам просто нужны отчёты о сидируемых раздачах."
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(6, 22)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(170, 13)
        Me.Label7.TabIndex = 32
        Me.Label7.Text = "Для количества сидов не более"
        '
        'WebFindDateTorRegForNotMoreSeeds
        '
        Me.WebFindDateTorRegForNotMoreSeeds.Location = New System.Drawing.Point(182, 20)
        Me.WebFindDateTorRegForNotMoreSeeds.Maximum = New Decimal(New Integer() {10, 0, 0, 0})
        Me.WebFindDateTorRegForNotMoreSeeds.Name = "WebFindDateTorRegForNotMoreSeeds"
        Me.WebFindDateTorRegForNotMoreSeeds.Size = New System.Drawing.Size(39, 20)
        Me.WebFindDateTorRegForNotMoreSeeds.TabIndex = 31
        '
        'StatRepcbIsSendStatRep
        '
        Me.StatRepcbIsSendStatRep.AutoSize = True
        Me.StatRepcbIsSendStatRep.Location = New System.Drawing.Point(402, 6)
        Me.StatRepcbIsSendStatRep.Name = "StatRepcbIsSendStatRep"
        Me.StatRepcbIsSendStatRep.Size = New System.Drawing.Size(199, 17)
        Me.StatRepcbIsSendStatRep.TabIndex = 29
        Me.StatRepcbIsSendStatRep.Text = "Отправлять статистический отчет"
        Me.StatRepcbIsSendStatRep.UseVisualStyleBackColor = True
        '
        'gbStatReport
        '
        Me.gbStatReport.Controls.Add(Me.StatReptxtWatchmenPass)
        Me.gbStatReport.Controls.Add(Me.Label41)
        Me.gbStatReport.Location = New System.Drawing.Point(393, 9)
        Me.gbStatReport.Name = "gbStatReport"
        Me.gbStatReport.Size = New System.Drawing.Size(230, 44)
        Me.gbStatReport.TabIndex = 27
        Me.gbStatReport.TabStop = False
        '
        'StatReptxtWatchmenPass
        '
        Me.StatReptxtWatchmenPass.Location = New System.Drawing.Point(84, 17)
        Me.StatReptxtWatchmenPass.Name = "StatReptxtWatchmenPass"
        Me.StatReptxtWatchmenPass.Size = New System.Drawing.Size(113, 20)
        Me.StatReptxtWatchmenPass.TabIndex = 7
        '
        'Label41
        '
        Me.Label41.AutoSize = True
        Me.Label41.Location = New System.Drawing.Point(6, 20)
        Me.Label41.Name = "Label41"
        Me.Label41.Size = New System.Drawing.Size(72, 13)
        Me.Label41.TabIndex = 6
        Me.Label41.Text = "Ключ отчёта:"
        '
        'cb_prog_DiscountGenreInSort
        '
        Me.cb_prog_DiscountGenreInSort.AutoSize = True
        Me.cb_prog_DiscountGenreInSort.Location = New System.Drawing.Point(6, 6)
        Me.cb_prog_DiscountGenreInSort.Name = "cb_prog_DiscountGenreInSort"
        Me.cb_prog_DiscountGenreInSort.Size = New System.Drawing.Size(361, 17)
        Me.cb_prog_DiscountGenreInSort.TabIndex = 26
        Me.cb_prog_DiscountGenreInSort.Text = "В отчете для вставки в форум не учитывать жанр при сортировке"
        Me.cb_prog_DiscountGenreInSort.UseVisualStyleBackColor = True
        '
        'TabPage5
        '
        Me.TabPage5.BackColor = System.Drawing.SystemColors.Control
        Me.TabPage5.Controls.Add(Me.Label24)
        Me.TabPage5.Controls.Add(Me.Panel5)
        Me.TabPage5.Location = New System.Drawing.Point(4, 22)
        Me.TabPage5.Name = "TabPage5"
        Me.TabPage5.Size = New System.Drawing.Size(801, 537)
        Me.TabPage5.TabIndex = 5
        Me.TabPage5.Text = "Прокси-сервер"
        '
        'Label24
        '
        Me.Label24.AutoSize = True
        Me.Label24.Location = New System.Drawing.Point(13, 16)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(388, 13)
        Me.Label24.TabIndex = 34
        Me.Label24.Text = "Пока заблокировал, ибо нет времени, да и кое-какие моменты непонятны"
        '
        'Panel5
        '
        Me.Panel5.Controls.Add(Me.Label23)
        Me.Panel5.Controls.Add(Me.gbUseProxy)
        Me.Panel5.Controls.Add(Me.rbProxyManual)
        Me.Panel5.Controls.Add(Me.txtProxyIPAddress)
        Me.Panel5.Controls.Add(Me.rbProxyGetSystemWebProxy)
        Me.Panel5.Controls.Add(Me.txtProxyPort)
        Me.Panel5.Controls.Add(Me.rbProxyNotRequired)
        Me.Panel5.Controls.Add(Me.Label8)
        Me.Panel5.Controls.Add(Me.Label6)
        Me.Panel5.Enabled = False
        Me.Panel5.Location = New System.Drawing.Point(16, 44)
        Me.Panel5.Name = "Panel5"
        Me.Panel5.Size = New System.Drawing.Size(491, 325)
        Me.Panel5.TabIndex = 33
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.Location = New System.Drawing.Point(30, 57)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(423, 13)
        Me.Label23.TabIndex = 32
        Me.Label23.Text = "(т.е. считываются параметры прокси Internet Explorer (IE) текущего пользователя)"
        '
        'gbUseProxy
        '
        Me.gbUseProxy.Controls.Add(Me.Label20)
        Me.gbUseProxy.Controls.Add(Me.rbProxyAuthorizationManual)
        Me.gbUseProxy.Controls.Add(Me.txtProxyAuthorizationDomain)
        Me.gbUseProxy.Controls.Add(Me.rbProxyAuthorizationUseDefaultCredentials)
        Me.gbUseProxy.Controls.Add(Me.txtProxyAuthorizationName)
        Me.gbUseProxy.Controls.Add(Me.rbProxyAuthorizationNotRequired)
        Me.gbUseProxy.Controls.Add(Me.Label10)
        Me.gbUseProxy.Controls.Add(Me.txtProxyAuthorizationPassword)
        Me.gbUseProxy.Controls.Add(Me.Label9)
        Me.gbUseProxy.Location = New System.Drawing.Point(14, 142)
        Me.gbUseProxy.Name = "gbUseProxy"
        Me.gbUseProxy.Size = New System.Drawing.Size(458, 166)
        Me.gbUseProxy.TabIndex = 28
        Me.gbUseProxy.TabStop = False
        Me.gbUseProxy.Text = "Авторизация на прокси-сервере"
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Location = New System.Drawing.Point(29, 137)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(45, 13)
        Me.Label20.TabIndex = 11
        Me.Label20.Text = "Домен:"
        '
        'rbProxyAuthorizationManual
        '
        Me.rbProxyAuthorizationManual.AutoSize = True
        Me.rbProxyAuthorizationManual.Location = New System.Drawing.Point(6, 65)
        Me.rbProxyAuthorizationManual.Name = "rbProxyAuthorizationManual"
        Me.rbProxyAuthorizationManual.Size = New System.Drawing.Size(283, 17)
        Me.rbProxyAuthorizationManual.TabIndex = 13
        Me.rbProxyAuthorizationManual.TabStop = True
        Me.rbProxyAuthorizationManual.Text = "Ручная настройка авторизации на прокси-сервере"
        Me.rbProxyAuthorizationManual.UseVisualStyleBackColor = True
        '
        'txtProxyAuthorizationDomain
        '
        Me.txtProxyAuthorizationDomain.Location = New System.Drawing.Point(80, 134)
        Me.txtProxyAuthorizationDomain.Name = "txtProxyAuthorizationDomain"
        Me.txtProxyAuthorizationDomain.Size = New System.Drawing.Size(132, 20)
        Me.txtProxyAuthorizationDomain.TabIndex = 10
        '
        'rbProxyAuthorizationUseDefaultCredentials
        '
        Me.rbProxyAuthorizationUseDefaultCredentials.AutoSize = True
        Me.rbProxyAuthorizationUseDefaultCredentials.Location = New System.Drawing.Point(6, 42)
        Me.rbProxyAuthorizationUseDefaultCredentials.Name = "rbProxyAuthorizationUseDefaultCredentials"
        Me.rbProxyAuthorizationUseDefaultCredentials.Size = New System.Drawing.Size(446, 17)
        Me.rbProxyAuthorizationUseDefaultCredentials.TabIndex = 12
        Me.rbProxyAuthorizationUseDefaultCredentials.TabStop = True
        Me.rbProxyAuthorizationUseDefaultCredentials.Text = "Использовать настройки авторизации на прокси-сервере текущего пользователя"
        Me.rbProxyAuthorizationUseDefaultCredentials.UseVisualStyleBackColor = True
        '
        'txtProxyAuthorizationName
        '
        Me.txtProxyAuthorizationName.Location = New System.Drawing.Point(80, 82)
        Me.txtProxyAuthorizationName.Name = "txtProxyAuthorizationName"
        Me.txtProxyAuthorizationName.Size = New System.Drawing.Size(132, 20)
        Me.txtProxyAuthorizationName.TabIndex = 6
        '
        'rbProxyAuthorizationNotRequired
        '
        Me.rbProxyAuthorizationNotRequired.AutoSize = True
        Me.rbProxyAuthorizationNotRequired.Location = New System.Drawing.Point(6, 19)
        Me.rbProxyAuthorizationNotRequired.Name = "rbProxyAuthorizationNotRequired"
        Me.rbProxyAuthorizationNotRequired.Size = New System.Drawing.Size(227, 17)
        Me.rbProxyAuthorizationNotRequired.TabIndex = 11
        Me.rbProxyAuthorizationNotRequired.TabStop = True
        Me.rbProxyAuthorizationNotRequired.Text = "Прокси сервер не требует авторизации"
        Me.rbProxyAuthorizationNotRequired.UseVisualStyleBackColor = True
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(26, 111)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(48, 13)
        Me.Label10.TabIndex = 9
        Me.Label10.Text = "Пароль:"
        '
        'txtProxyAuthorizationPassword
        '
        Me.txtProxyAuthorizationPassword.Location = New System.Drawing.Point(80, 108)
        Me.txtProxyAuthorizationPassword.Name = "txtProxyAuthorizationPassword"
        Me.txtProxyAuthorizationPassword.Size = New System.Drawing.Size(132, 20)
        Me.txtProxyAuthorizationPassword.TabIndex = 7
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(42, 85)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(32, 13)
        Me.Label9.TabIndex = 8
        Me.Label9.Text = "Имя:"
        '
        'rbProxyManual
        '
        Me.rbProxyManual.AutoSize = True
        Me.rbProxyManual.Location = New System.Drawing.Point(14, 73)
        Me.rbProxyManual.Name = "rbProxyManual"
        Me.rbProxyManual.Size = New System.Drawing.Size(200, 17)
        Me.rbProxyManual.TabIndex = 31
        Me.rbProxyManual.Text = "Ручная настройка прокси-сервера"
        Me.rbProxyManual.UseVisualStyleBackColor = True
        '
        'txtProxyIPAddress
        '
        Me.txtProxyIPAddress.Location = New System.Drawing.Point(86, 90)
        Me.txtProxyIPAddress.Name = "txtProxyIPAddress"
        Me.txtProxyIPAddress.Size = New System.Drawing.Size(100, 20)
        Me.txtProxyIPAddress.TabIndex = 2
        '
        'rbProxyGetSystemWebProxy
        '
        Me.rbProxyGetSystemWebProxy.AutoSize = True
        Me.rbProxyGetSystemWebProxy.Location = New System.Drawing.Point(14, 37)
        Me.rbProxyGetSystemWebProxy.Name = "rbProxyGetSystemWebProxy"
        Me.rbProxyGetSystemWebProxy.Size = New System.Drawing.Size(378, 17)
        Me.rbProxyGetSystemWebProxy.TabIndex = 30
        Me.rbProxyGetSystemWebProxy.Text = "Автоматически определять настройки прокси-сервера для этой сети"
        Me.rbProxyGetSystemWebProxy.UseVisualStyleBackColor = True
        '
        'txtProxyPort
        '
        Me.txtProxyPort.Location = New System.Drawing.Point(86, 116)
        Me.txtProxyPort.Name = "txtProxyPort"
        Me.txtProxyPort.Size = New System.Drawing.Size(100, 20)
        Me.txtProxyPort.TabIndex = 3
        '
        'rbProxyNotRequired
        '
        Me.rbProxyNotRequired.AutoSize = True
        Me.rbProxyNotRequired.Checked = True
        Me.rbProxyNotRequired.Location = New System.Drawing.Point(14, 14)
        Me.rbProxyNotRequired.Name = "rbProxyNotRequired"
        Me.rbProxyNotRequired.Size = New System.Drawing.Size(128, 17)
        Me.rbProxyNotRequired.TabIndex = 29
        Me.rbProxyNotRequired.TabStop = True
        Me.rbProxyNotRequired.Text = "Без прокси-сервера"
        Me.rbProxyNotRequired.UseVisualStyleBackColor = True
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(48, 119)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(35, 13)
        Me.Label8.TabIndex = 4
        Me.Label8.Text = "Порт:"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(30, 93)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(53, 13)
        Me.Label6.TabIndex = 1
        Me.Label6.Text = "IP-адрес:"
        '
        'TabPage6
        '
        Me.TabPage6.BackColor = System.Drawing.SystemColors.Control
        Me.TabPage6.Controls.Add(Me.TextBox13)
        Me.TabPage6.Controls.Add(Me.GroupBox10)
        Me.TabPage6.Controls.Add(Me.GroupBox9)
        Me.TabPage6.Controls.Add(Me.GroupBox8)
        Me.TabPage6.Controls.Add(Me.GroupBox3)
        Me.TabPage6.Location = New System.Drawing.Point(4, 22)
        Me.TabPage6.Name = "TabPage6"
        Me.TabPage6.Size = New System.Drawing.Size(801, 537)
        Me.TabPage6.TabIndex = 6
        Me.TabPage6.Text = "Таймер"
        '
        'TextBox13
        '
        Me.TextBox13.Location = New System.Drawing.Point(647, 66)
        Me.TextBox13.Multiline = True
        Me.TextBox13.Name = "TextBox13"
        Me.TextBox13.ReadOnly = True
        Me.TextBox13.Size = New System.Drawing.Size(132, 160)
        Me.TextBox13.TabIndex = 23
        Me.TextBox13.Text = " Уточнение! Программа НЕ будет ограничивать скорость, если во вкладке ""Аккаунты"" " & _
            "настройка ""Торрент-клиент находится"" стоит в положении ""Не опрашивать торрент кл" & _
            "иент...""."
        Me.TextBox13.Visible = False
        '
        'GroupBox10
        '
        Me.GroupBox10.Controls.Add(Me.NUDHours)
        Me.GroupBox10.Controls.Add(Me.Label28)
        Me.GroupBox10.Controls.Add(Me.Label27)
        Me.GroupBox10.Controls.Add(Me.Label26)
        Me.GroupBox10.Controls.Add(Me.NUDMinutes)
        Me.GroupBox10.Controls.Add(Me.NUDSeconds)
        Me.GroupBox10.Location = New System.Drawing.Point(8, 8)
        Me.GroupBox10.Name = "GroupBox10"
        Me.GroupBox10.Size = New System.Drawing.Size(608, 50)
        Me.GroupBox10.TabIndex = 22
        Me.GroupBox10.TabStop = False
        Me.GroupBox10.Text = "Таймер срабатывает, запуская в меню ""Запуск"" пункт ""Обработать подраздел(ы)"", раз" & _
            " в нижеуказанный период:"
        '
        'NUDHours
        '
        Me.NUDHours.Location = New System.Drawing.Point(9, 19)
        Me.NUDHours.Name = "NUDHours"
        Me.NUDHours.Size = New System.Drawing.Size(45, 20)
        Me.NUDHours.TabIndex = 1
        '
        'Label28
        '
        Me.Label28.AutoSize = True
        Me.Label28.Location = New System.Drawing.Point(215, 21)
        Me.Label28.Name = "Label28"
        Me.Label28.Size = New System.Drawing.Size(28, 13)
        Me.Label28.TabIndex = 6
        Me.Label28.Text = "сек."
        '
        'Label27
        '
        Me.Label27.AutoSize = True
        Me.Label27.Location = New System.Drawing.Point(134, 21)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(30, 13)
        Me.Label27.TabIndex = 4
        Me.Label27.Text = "мин."
        '
        'Label26
        '
        Me.Label26.AutoSize = True
        Me.Label26.Location = New System.Drawing.Point(55, 21)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(12, 13)
        Me.Label26.TabIndex = 2
        Me.Label26.Text = "ч"
        '
        'NUDMinutes
        '
        Me.NUDMinutes.Location = New System.Drawing.Point(89, 19)
        Me.NUDMinutes.Maximum = New Decimal(New Integer() {59, 0, 0, 0})
        Me.NUDMinutes.Name = "NUDMinutes"
        Me.NUDMinutes.Size = New System.Drawing.Size(45, 20)
        Me.NUDMinutes.TabIndex = 3
        Me.NUDMinutes.Value = New Decimal(New Integer() {5, 0, 0, 0})
        '
        'NUDSeconds
        '
        Me.NUDSeconds.Location = New System.Drawing.Point(169, 19)
        Me.NUDSeconds.Maximum = New Decimal(New Integer() {59, 0, 0, 0})
        Me.NUDSeconds.Name = "NUDSeconds"
        Me.NUDSeconds.Size = New System.Drawing.Size(45, 20)
        Me.NUDSeconds.TabIndex = 5
        '
        'GroupBox9
        '
        Me.GroupBox9.Controls.Add(Me.TextBox6)
        Me.GroupBox9.Controls.Add(Me.Label36)
        Me.GroupBox9.Controls.Add(Me.NUDPauseBeforeDownloadWebPageWithCookie)
        Me.GroupBox9.Controls.Add(Me.Label35)
        Me.GroupBox9.Location = New System.Drawing.Point(8, 197)
        Me.GroupBox9.Name = "GroupBox9"
        Me.GroupBox9.Size = New System.Drawing.Size(608, 85)
        Me.GroupBox9.TabIndex = 21
        Me.GroupBox9.TabStop = False
        Me.GroupBox9.Text = "Пауза перед попыткой закачки веб-страницы"
        '
        'TextBox6
        '
        Me.TextBox6.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TextBox6.Location = New System.Drawing.Point(6, 40)
        Me.TextBox6.Multiline = True
        Me.TextBox6.Name = "TextBox6"
        Me.TextBox6.ReadOnly = True
        Me.TextBox6.Size = New System.Drawing.Size(560, 41)
        Me.TextBox6.TabIndex = 14
        Me.TextBox6.Text = resources.GetString("TextBox6.Text")
        '
        'Label36
        '
        Me.Label36.AutoSize = True
        Me.Label36.Location = New System.Drawing.Point(410, 16)
        Me.Label36.Name = "Label36"
        Me.Label36.Size = New System.Drawing.Size(33, 13)
        Me.Label36.TabIndex = 2
        Me.Label36.Text = "мсек"
        '
        'NUDPauseBeforeDownloadWebPageWithCookie
        '
        Me.NUDPauseBeforeDownloadWebPageWithCookie.Location = New System.Drawing.Point(354, 14)
        Me.NUDPauseBeforeDownloadWebPageWithCookie.Maximum = New Decimal(New Integer() {5000, 0, 0, 0})
        Me.NUDPauseBeforeDownloadWebPageWithCookie.Minimum = New Decimal(New Integer() {50, 0, 0, 0})
        Me.NUDPauseBeforeDownloadWebPageWithCookie.Name = "NUDPauseBeforeDownloadWebPageWithCookie"
        Me.NUDPauseBeforeDownloadWebPageWithCookie.Size = New System.Drawing.Size(50, 20)
        Me.NUDPauseBeforeDownloadWebPageWithCookie.TabIndex = 1
        Me.NUDPauseBeforeDownloadWebPageWithCookie.Value = New Decimal(New Integer() {111, 0, 0, 0})
        '
        'Label35
        '
        Me.Label35.AutoSize = True
        Me.Label35.Location = New System.Drawing.Point(6, 16)
        Me.Label35.Name = "Label35"
        Me.Label35.Size = New System.Drawing.Size(342, 13)
        Me.Label35.TabIndex = 0
        Me.Label35.Text = "Величина паузы перед ПЕРВОЙ попыткой закачки веб-страницы:"
        '
        'GroupBox8
        '
        Me.GroupBox8.Controls.Add(Me.Label32)
        Me.GroupBox8.Controls.Add(Me.Label34)
        Me.GroupBox8.Controls.Add(Me.NUDPauseAfterSendCommandToTorrentClient)
        Me.GroupBox8.Controls.Add(Me.Label33)
        Me.GroupBox8.Location = New System.Drawing.Point(8, 288)
        Me.GroupBox8.Name = "GroupBox8"
        Me.GroupBox8.Size = New System.Drawing.Size(608, 69)
        Me.GroupBox8.TabIndex = 20
        Me.GroupBox8.TabStop = False
        Me.GroupBox8.Text = "Пауза после отправки пакетной команды торрент-клиенту"
        '
        'Label32
        '
        Me.Label32.AutoSize = True
        Me.Label32.Location = New System.Drawing.Point(6, 20)
        Me.Label32.Name = "Label32"
        Me.Label32.Size = New System.Drawing.Size(92, 13)
        Me.Label32.TabIndex = 16
        Me.Label32.Text = "Величина паузы:"
        '
        'Label34
        '
        Me.Label34.AutoSize = True
        Me.Label34.Location = New System.Drawing.Point(6, 45)
        Me.Label34.Name = "Label34"
        Me.Label34.Size = New System.Drawing.Size(274, 13)
        Me.Label34.TabIndex = 19
        Me.Label34.Text = "Напоминание: 1 секунда = 1000 мсек (миллисекунд)"
        '
        'NUDPauseAfterSendCommandToTorrentClient
        '
        Me.NUDPauseAfterSendCommandToTorrentClient.Location = New System.Drawing.Point(104, 18)
        Me.NUDPauseAfterSendCommandToTorrentClient.Maximum = New Decimal(New Integer() {1000, 0, 0, 0})
        Me.NUDPauseAfterSendCommandToTorrentClient.Minimum = New Decimal(New Integer() {5, 0, 0, 0})
        Me.NUDPauseAfterSendCommandToTorrentClient.Name = "NUDPauseAfterSendCommandToTorrentClient"
        Me.NUDPauseAfterSendCommandToTorrentClient.Size = New System.Drawing.Size(47, 20)
        Me.NUDPauseAfterSendCommandToTorrentClient.TabIndex = 17
        Me.NUDPauseAfterSendCommandToTorrentClient.Value = New Decimal(New Integer() {88, 0, 0, 0})
        '
        'Label33
        '
        Me.Label33.AutoSize = True
        Me.Label33.Location = New System.Drawing.Point(157, 20)
        Me.Label33.Name = "Label33"
        Me.Label33.Size = New System.Drawing.Size(33, 13)
        Me.Label33.TabIndex = 18
        Me.Label33.Text = "мсек"
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.TextBox5)
        Me.GroupBox3.Controls.Add(Me.LimitSpeedDownloadIs)
        Me.GroupBox3.Controls.Add(Me.Label31)
        Me.GroupBox3.Controls.Add(Me.LimitSpeedDownloadValue)
        Me.GroupBox3.Controls.Add(Me.LimitSpeedUploadValue)
        Me.GroupBox3.Controls.Add(Me.Label30)
        Me.GroupBox3.Controls.Add(Me.LimitSpeedUploadIs)
        Me.GroupBox3.Location = New System.Drawing.Point(8, 64)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(608, 127)
        Me.GroupBox3.TabIndex = 15
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Регулировка скорости закачки и раздачи во время обработки"
        '
        'TextBox5
        '
        Me.TextBox5.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TextBox5.Location = New System.Drawing.Point(6, 68)
        Me.TextBox5.Multiline = True
        Me.TextBox5.Name = "TextBox5"
        Me.TextBox5.ReadOnly = True
        Me.TextBox5.Size = New System.Drawing.Size(596, 54)
        Me.TextBox5.TabIndex = 14
        Me.TextBox5.Text = resources.GetString("TextBox5.Text")
        '
        'LimitSpeedDownloadIs
        '
        Me.LimitSpeedDownloadIs.AutoSize = True
        Me.LimitSpeedDownloadIs.Location = New System.Drawing.Point(6, 19)
        Me.LimitSpeedDownloadIs.Name = "LimitSpeedDownloadIs"
        Me.LimitSpeedDownloadIs.Size = New System.Drawing.Size(283, 17)
        Me.LimitSpeedDownloadIs.TabIndex = 8
        Me.LimitSpeedDownloadIs.Text = "При обработке ограничивать скорость закачки до"
        Me.LimitSpeedDownloadIs.UseVisualStyleBackColor = True
        '
        'Label31
        '
        Me.Label31.AutoSize = True
        Me.Label31.Location = New System.Drawing.Point(376, 46)
        Me.Label31.Name = "Label31"
        Me.Label31.Size = New System.Drawing.Size(61, 13)
        Me.Label31.TabIndex = 13
        Me.Label31.Text = "КБайт/сек"
        '
        'LimitSpeedDownloadValue
        '
        Me.LimitSpeedDownloadValue.Location = New System.Drawing.Point(295, 18)
        Me.LimitSpeedDownloadValue.Maximum = New Decimal(New Integer() {100000, 0, 0, 0})
        Me.LimitSpeedDownloadValue.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.LimitSpeedDownloadValue.Name = "LimitSpeedDownloadValue"
        Me.LimitSpeedDownloadValue.Size = New System.Drawing.Size(75, 20)
        Me.LimitSpeedDownloadValue.TabIndex = 9
        Me.LimitSpeedDownloadValue.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'LimitSpeedUploadValue
        '
        Me.LimitSpeedUploadValue.Location = New System.Drawing.Point(295, 44)
        Me.LimitSpeedUploadValue.Maximum = New Decimal(New Integer() {100000, 0, 0, 0})
        Me.LimitSpeedUploadValue.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.LimitSpeedUploadValue.Name = "LimitSpeedUploadValue"
        Me.LimitSpeedUploadValue.Size = New System.Drawing.Size(75, 20)
        Me.LimitSpeedUploadValue.TabIndex = 12
        Me.LimitSpeedUploadValue.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'Label30
        '
        Me.Label30.AutoSize = True
        Me.Label30.Location = New System.Drawing.Point(376, 20)
        Me.Label30.Name = "Label30"
        Me.Label30.Size = New System.Drawing.Size(61, 13)
        Me.Label30.TabIndex = 10
        Me.Label30.Text = "КБайт/сек"
        '
        'LimitSpeedUploadIs
        '
        Me.LimitSpeedUploadIs.AutoSize = True
        Me.LimitSpeedUploadIs.Location = New System.Drawing.Point(6, 45)
        Me.LimitSpeedUploadIs.Name = "LimitSpeedUploadIs"
        Me.LimitSpeedUploadIs.Size = New System.Drawing.Size(276, 17)
        Me.LimitSpeedUploadIs.TabIndex = 11
        Me.LimitSpeedUploadIs.Text = "При обработке ограничивать скорость отдачи до"
        Me.LimitSpeedUploadIs.UseVisualStyleBackColor = True
        '
        'TabPage7
        '
        Me.TabPage7.BackColor = System.Drawing.SystemColors.Control
        Me.TabPage7.Controls.Add(Me.Interface_cbCloseToTray)
        Me.TabPage7.Controls.Add(Me.Interface_cbMinimizeToTray)
        Me.TabPage7.Controls.Add(Me.Interface_cbRequestOnExit)
        Me.TabPage7.Location = New System.Drawing.Point(4, 22)
        Me.TabPage7.Name = "TabPage7"
        Me.TabPage7.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage7.Size = New System.Drawing.Size(801, 537)
        Me.TabPage7.TabIndex = 7
        Me.TabPage7.Text = "Интерфейс"
        '
        'Interface_cbCloseToTray
        '
        Me.Interface_cbCloseToTray.AutoSize = True
        Me.Interface_cbCloseToTray.Location = New System.Drawing.Point(16, 66)
        Me.Interface_cbCloseToTray.Name = "Interface_cbCloseToTray"
        Me.Interface_cbCloseToTray.Size = New System.Drawing.Size(123, 17)
        Me.Interface_cbCloseToTray.TabIndex = 2
        Me.Interface_cbCloseToTray.Text = "Закрывать в лоток"
        Me.Interface_cbCloseToTray.UseVisualStyleBackColor = True
        '
        'Interface_cbMinimizeToTray
        '
        Me.Interface_cbMinimizeToTray.AutoSize = True
        Me.Interface_cbMinimizeToTray.Location = New System.Drawing.Point(16, 43)
        Me.Interface_cbMinimizeToTray.Name = "Interface_cbMinimizeToTray"
        Me.Interface_cbMinimizeToTray.Size = New System.Drawing.Size(132, 17)
        Me.Interface_cbMinimizeToTray.TabIndex = 1
        Me.Interface_cbMinimizeToTray.Text = "Сворачивать в лоток"
        Me.Interface_cbMinimizeToTray.UseVisualStyleBackColor = True
        '
        'Interface_cbRequestOnExit
        '
        Me.Interface_cbRequestOnExit.AutoSize = True
        Me.Interface_cbRequestOnExit.Location = New System.Drawing.Point(16, 20)
        Me.Interface_cbRequestOnExit.Name = "Interface_cbRequestOnExit"
        Me.Interface_cbRequestOnExit.Size = New System.Drawing.Size(189, 17)
        Me.Interface_cbRequestOnExit.TabIndex = 0
        Me.Interface_cbRequestOnExit.Text = "Запрос на выход из программы"
        Me.Interface_cbRequestOnExit.UseVisualStyleBackColor = True
        '
        'ToolTip1
        '
        Me.ToolTip1.AutomaticDelay = 200
        Me.ToolTip1.AutoPopDelay = 20000
        Me.ToolTip1.InitialDelay = 100
        Me.ToolTip1.ReshowDelay = 40
        '
        'frmSettings
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(839, 618)
        Me.Controls.Add(Me.TabControl1)
        Me.Controls.Add(Me.cmdVerifySettings)
        Me.Controls.Add(Me.cmdOK)
        Me.Controls.Add(Me.cmdCancel)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.MinimumSize = New System.Drawing.Size(780, 580)
        Me.Name = "frmSettings"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Настройки"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.gbTorFilesToTorClnt.ResumeLayout(False)
        Me.gbTorFilesToTorClnt.PerformLayout()
        Me.gbSaveTorrentFiles.ResumeLayout(False)
        Me.gbSaveTorrentFiles.PerformLayout()
        Me.SaveTorrFiles_gbDownloadByAnotherUser.ResumeLayout(False)
        Me.SaveTorrFiles_gbDownloadByAnotherUser.PerformLayout()
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage4.ResumeLayout(False)
        Me.Panel4.ResumeLayout(False)
        Me.GroupBox15.ResumeLayout(False)
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        Me.gb_InnerList.ResumeLayout(False)
        Me.gb_InnerList.PerformLayout()
        Me.gb_AutoStartStop.ResumeLayout(False)
        Me.gb_AutoStartStop.PerformLayout()
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        Me.gb_AutodownloadTorrents.ResumeLayout(False)
        Me.gb_AutodownloadTorrents.PerformLayout()
        Me.GroupBox5.ResumeLayout(False)
        Me.GroupBox5.PerformLayout()
        Me.sf_AD_gbWhereTorClientMustSaveTorrentFile.ResumeLayout(False)
        Me.sf_AD_gbWhereTorClientMustSaveTorrentFile.PerformLayout()
        Me.gb_ChangeLabel.ResumeLayout(False)
        Me.gb_ChangeLabel.PerformLayout()
        Me.TabPage2.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.GroupBox7.ResumeLayout(False)
        Me.GroupBox7.PerformLayout()
        Me.GroupBoxUtorrentSettings.ResumeLayout(False)
        Me.GroupBoxUtorrentSettings.PerformLayout()
        Me.GroupBox6.ResumeLayout(False)
        Me.GroupBox6.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.TabPage3.ResumeLayout(False)
        Me.TabPage3.PerformLayout()
        CType(Me.ReportSeeding_ShowOnlySeedsNotMoreThanValue, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox14.ResumeLayout(False)
        Me.GroupBox14.PerformLayout()
        CType(Me.ReportAddTextAfterReportMoreThanXBytesValue, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ReportAddTextAfterEveryXTorrentsValue, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox13.ResumeLayout(False)
        Me.GroupBox13.PerformLayout()
        Me.GroupBox12.ResumeLayout(False)
        Me.GroupBox12.PerformLayout()
        Me.GroupBox11.ResumeLayout(False)
        Me.GroupBox11.PerformLayout()
        Me.WebFindDateTorRegGb.ResumeLayout(False)
        Me.WebFindDateTorRegGb.PerformLayout()
        CType(Me.WebFindDateTorRegForNotMoreSeeds, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbStatReport.ResumeLayout(False)
        Me.gbStatReport.PerformLayout()
        Me.TabPage5.ResumeLayout(False)
        Me.TabPage5.PerformLayout()
        Me.Panel5.ResumeLayout(False)
        Me.Panel5.PerformLayout()
        Me.gbUseProxy.ResumeLayout(False)
        Me.gbUseProxy.PerformLayout()
        Me.TabPage6.ResumeLayout(False)
        Me.TabPage6.PerformLayout()
        Me.GroupBox10.ResumeLayout(False)
        Me.GroupBox10.PerformLayout()
        CType(Me.NUDHours, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NUDMinutes, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NUDSeconds, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox9.ResumeLayout(False)
        Me.GroupBox9.PerformLayout()
        CType(Me.NUDPauseBeforeDownloadWebPageWithCookie, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox8.ResumeLayout(False)
        Me.GroupBox8.PerformLayout()
        CType(Me.NUDPauseAfterSendCommandToTorrentClient, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        CType(Me.LimitSpeedDownloadValue, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LimitSpeedUploadValue, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage7.ResumeLayout(False)
        Me.TabPage7.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents cmdCancel As System.Windows.Forms.Button
    Friend WithEvents cmdOK As System.Windows.Forms.Button
    Friend WithEvents cmdVerifySettings As System.Windows.Forms.Button
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtSite_Password As System.Windows.Forms.TextBox
    Friend WithEvents txttorrentClientUsername As System.Windows.Forms.TextBox
    Friend WithEvents txtSite_Username As System.Windows.Forms.TextBox
    Friend WithEvents txttorrentClientPassword As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents mtxtTorrentClientIPAddress As System.Windows.Forms.MaskedTextBox
    Friend WithEvents rbTorrentClientOnAnotherComputer As System.Windows.Forms.RadioButton
    Friend WithEvents rbTorrentClientOnThisComputer As System.Windows.Forms.RadioButton
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txttorrentClientIncomingPort As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents TabPage4 As System.Windows.Forms.TabPage
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents sf_txtSubforumFullPath As System.Windows.Forms.TextBox
    Friend WithEvents gb_AutodownloadTorrents As System.Windows.Forms.GroupBox
    Friend WithEvents sf_AD_txtNameOfTorrentPathTemplate As System.Windows.Forms.TextBox
    Friend WithEvents TextBox4 As System.Windows.Forms.TextBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents sf_AD_cbNumberOfSeeds As System.Windows.Forms.ComboBox
    Friend WithEvents sf_AD_cbDownloadIfSeedsNotMore As System.Windows.Forms.CheckBox
    Friend WithEvents sf_AD_btnSelectDownloadFolder As System.Windows.Forms.Button
    Friend WithEvents sf_AD_txtDownloadFilesToFolder As System.Windows.Forms.TextBox
    Friend WithEvents gb_ChangeLabel As System.Windows.Forms.GroupBox
    Friend WithEvents sf_ChangeLabelOfTorrent_OnlyIfLabelIsEmpty As System.Windows.Forms.CheckBox
    Friend WithEvents sf_ChangeLabelOfTorrent_ToAnotherName As System.Windows.Forms.RadioButton
    Friend WithEvents sf_ChangeLabelOfTorrent_ToNameSubforum As System.Windows.Forms.RadioButton
    Friend WithEvents sf_ChangeLabelOfTorrent As System.Windows.Forms.CheckBox
    Friend WithEvents sf_btnDeleteSubforum As System.Windows.Forms.Button
    Friend WithEvents sf_btnAddSubforum As System.Windows.Forms.Button
    Friend WithEvents btntorrentClientAnswerFile As System.Windows.Forms.Button
    Friend WithEvents txttorrentClientAnswerFile As System.Windows.Forms.TextBox
    Friend WithEvents rbDontQueryTorrentClient As System.Windows.Forms.RadioButton
    Friend WithEvents TextBox8 As System.Windows.Forms.TextBox
    Friend WithEvents TabPage3 As System.Windows.Forms.TabPage
    Friend WithEvents rtb_ReportTemplate As System.Windows.Forms.RichTextBox
    Friend WithEvents btn_ReportTemplate As System.Windows.Forms.Button
    Friend WithEvents TextBox9 As System.Windows.Forms.TextBox
    Friend WithEvents cbExtendedLog As System.Windows.Forms.CheckBox
    Friend WithEvents Panel4 As System.Windows.Forms.Panel
    Friend WithEvents sf_btnEditSubforum As System.Windows.Forms.Button
    Friend WithEvents sf_txtSubForumNumber As System.Windows.Forms.TextBox
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents cb_prog_DiscountGenreInSort As System.Windows.Forms.CheckBox
    Friend WithEvents gb_AutoStartStop As System.Windows.Forms.GroupBox
    Friend WithEvents AutoStartStop_StartForced As System.Windows.Forms.CheckBox
    Friend WithEvents AutoStartStop_NumberOfSeedsNotMore As System.Windows.Forms.ComboBox
    Friend WithEvents AutoStartStop As System.Windows.Forms.CheckBox
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents TabPage5 As System.Windows.Forms.TabPage
    Friend WithEvents rbProxyManual As System.Windows.Forms.RadioButton
    Friend WithEvents rbProxyGetSystemWebProxy As System.Windows.Forms.RadioButton
    Friend WithEvents rbProxyNotRequired As System.Windows.Forms.RadioButton
    Friend WithEvents gbUseProxy As System.Windows.Forms.GroupBox
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents rbProxyAuthorizationManual As System.Windows.Forms.RadioButton
    Friend WithEvents txtProxyAuthorizationDomain As System.Windows.Forms.TextBox
    Friend WithEvents rbProxyAuthorizationUseDefaultCredentials As System.Windows.Forms.RadioButton
    Friend WithEvents txtProxyAuthorizationName As System.Windows.Forms.TextBox
    Friend WithEvents rbProxyAuthorizationNotRequired As System.Windows.Forms.RadioButton
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents txtProxyAuthorizationPassword As System.Windows.Forms.TextBox
    Friend WithEvents txtProxyIPAddress As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtProxyPort As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents Panel5 As System.Windows.Forms.Panel
    Friend WithEvents Label24 As System.Windows.Forms.Label
    Friend WithEvents TabPage6 As System.Windows.Forms.TabPage
    Friend WithEvents Label28 As System.Windows.Forms.Label
    Friend WithEvents NUDSeconds As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label27 As System.Windows.Forms.Label
    Friend WithEvents NUDMinutes As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label26 As System.Windows.Forms.Label
    Friend WithEvents NUDHours As System.Windows.Forms.NumericUpDown
    Friend WithEvents sf_ChangeLabelOfTorrent_AnotherName_EditList As System.Windows.Forms.Button
    Friend WithEvents sf_SubForumsListColl As System.Windows.Forms.ComboBox
    Friend WithEvents sf_btnSubForumsListColl_Edit As System.Windows.Forms.Button
    Friend WithEvents sf_btnSubForumsListColl_SaveAs As System.Windows.Forms.Button
    Friend WithEvents sf_ChangeLabelOfTorrent_AnotherName As System.Windows.Forms.ComboBox
    Friend WithEvents sf_btnSubForumsListColl_Delete As System.Windows.Forms.Button
    Friend WithEvents Label31 As System.Windows.Forms.Label
    Friend WithEvents LimitSpeedUploadValue As System.Windows.Forms.NumericUpDown
    Friend WithEvents LimitSpeedUploadIs As System.Windows.Forms.CheckBox
    Friend WithEvents Label30 As System.Windows.Forms.Label
    Friend WithEvents LimitSpeedDownloadValue As System.Windows.Forms.NumericUpDown
    Friend WithEvents LimitSpeedDownloadIs As System.Windows.Forms.CheckBox
    Friend WithEvents TextBox5 As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents Label34 As System.Windows.Forms.Label
    Friend WithEvents Label33 As System.Windows.Forms.Label
    Friend WithEvents NUDPauseAfterSendCommandToTorrentClient As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label32 As System.Windows.Forms.Label
    Friend WithEvents GroupBox8 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox9 As System.Windows.Forms.GroupBox
    Friend WithEvents Label36 As System.Windows.Forms.Label
    Friend WithEvents NUDPauseBeforeDownloadWebPageWithCookie As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label35 As System.Windows.Forms.Label
    Friend WithEvents TextBox6 As System.Windows.Forms.TextBox
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents gbStatReport As System.Windows.Forms.GroupBox
    Friend WithEvents StatReptxtWatchmenPass As System.Windows.Forms.TextBox
    Friend WithEvents Label41 As System.Windows.Forms.Label
    Friend WithEvents StatRepcbIsSendStatRep As System.Windows.Forms.CheckBox
    Friend WithEvents TabPage7 As System.Windows.Forms.TabPage
    Friend WithEvents Interface_cbCloseToTray As System.Windows.Forms.CheckBox
    Friend WithEvents Interface_cbMinimizeToTray As System.Windows.Forms.CheckBox
    Friend WithEvents Interface_cbRequestOnExit As System.Windows.Forms.CheckBox
    Friend WithEvents gbSaveTorrentFiles As System.Windows.Forms.GroupBox
    Friend WithEvents SaveTorrFiles_btnSelectPath As System.Windows.Forms.Button
    Friend WithEvents SaveTorrFiles_txtSaveInPath As System.Windows.Forms.TextBox
    Friend WithEvents SaveTorrFiles_obSaveInPath As System.Windows.Forms.RadioButton
    Friend WithEvents SaveTorrFiles_obRequestPath As System.Windows.Forms.RadioButton
    Friend WithEvents gbTorFilesToTorClnt As System.Windows.Forms.GroupBox
    Friend WithEvents SaveTorrFiles_DownloadByAnotherUser As System.Windows.Forms.CheckBox
    Friend WithEvents SaveTorrFiles_gbDownloadByAnotherUser As System.Windows.Forms.GroupBox
    Friend WithEvents Label38 As System.Windows.Forms.Label
    Friend WithEvents SaveTorrFiles_DownloadByAnotherUser_Password As System.Windows.Forms.TextBox
    Friend WithEvents SaveTorrFiles_DownloadByAnotherUser_Username As System.Windows.Forms.TextBox
    Friend WithEvents Label37 As System.Windows.Forms.Label
    Friend WithEvents TextBox7 As System.Windows.Forms.TextBox
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents TextBox10 As System.Windows.Forms.TextBox
    Friend WithEvents sf_AD_gbWhereTorClientMustSaveTorrentFile As System.Windows.Forms.GroupBox
    Friend WithEvents sf_AD_WhereTorClientMustSaveTorrentFile_btnCustomPath As System.Windows.Forms.Button
    Friend WithEvents sf_AD_WhereTorClientMustSaveTorrentFile_txtCustomPath As System.Windows.Forms.TextBox
    Friend WithEvents sf_AD_WhereTorClientMustSaveTorrentFile_rbCustomPath As System.Windows.Forms.RadioButton
    Friend WithEvents TextBox11 As System.Windows.Forms.TextBox
    Friend WithEvents sf_AD_WhereTorClientMustSaveTorrentFile_rbDefaultPath As System.Windows.Forms.RadioButton
    Friend WithEvents RadioButton2 As System.Windows.Forms.RadioButton
    Friend WithEvents GroupBox5 As System.Windows.Forms.GroupBox
    Friend WithEvents RadioButton1 As System.Windows.Forms.RadioButton
    Friend WithEvents RadioButton4 As System.Windows.Forms.RadioButton
    Friend WithEvents RadioButton3 As System.Windows.Forms.RadioButton
    Friend WithEvents TextBox12 As System.Windows.Forms.TextBox
    Friend WithEvents Label39 As System.Windows.Forms.Label
    Friend WithEvents cbTorrentClientName As System.Windows.Forms.ComboBox
    Friend WithEvents Label40 As System.Windows.Forms.Label
    Friend WithEvents GroupBoxUtorrentSettings As System.Windows.Forms.GroupBox
    Friend WithEvents TextBox2 As System.Windows.Forms.TextBox
    Friend WithEvents btnSelectFolder As System.Windows.Forms.Button
    Friend WithEvents txtTorrentsPath As System.Windows.Forms.TextBox
    Friend WithEvents cbRefreshInfoFromTorFilesAlways As System.Windows.Forms.CheckBox
    Friend WithEvents WebFindDateTorRegForNotMoreSeeds As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents GroupBox6 As System.Windows.Forms.GroupBox
    Friend WithEvents RadioButton6 As System.Windows.Forms.RadioButton
    Friend WithEvents RadioButton5 As System.Windows.Forms.RadioButton
    Friend WithEvents GroupBox7 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox10 As System.Windows.Forms.GroupBox
    Friend WithEvents TextBox13 As System.Windows.Forms.TextBox
    Friend WithEvents WebFindDateTorRegCb As System.Windows.Forms.CheckBox
    Friend WithEvents WebFindDateTorRegGb As System.Windows.Forms.GroupBox
    Friend WithEvents cbDontAutoShowReports As System.Windows.Forms.CheckBox
    Friend WithEvents TextBox14 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox15 As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox11 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox12 As System.Windows.Forms.GroupBox
    Friend WithEvents prog_Report_NameLinkClick_btnAltBrowserSelectAddress As System.Windows.Forms.Button
    Friend WithEvents prog_Report_NameLinkClick_txtAltBrowserAddress As System.Windows.Forms.TextBox
    Friend WithEvents prog_Report_NameLinkClick_obAltBrowser As System.Windows.Forms.RadioButton
    Friend WithEvents prog_Report_NameLinkClick_obDefBrowser As System.Windows.Forms.RadioButton
    Friend WithEvents TextBox16 As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox13 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox14 As System.Windows.Forms.GroupBox
    Friend WithEvents ReportAddTextAfterReport As System.Windows.Forms.TextBox
    Friend WithEvents Label25 As System.Windows.Forms.Label
    Friend WithEvents ReportAddTextAfterReportMoreThanXBytesTxt As System.Windows.Forms.TextBox
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents ReportAddTextAfterReportMoreThanXBytesValue As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents ReportAddTextAfterEveryXTorrentsTxt As System.Windows.Forms.TextBox
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents ReportAddTextAfterEveryXTorrentsValue As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents ReportAddTextBeforeReportTxt As System.Windows.Forms.TextBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents TextBox17 As System.Windows.Forms.TextBox
    Friend WithEvents sf_SubforumsList As System.Windows.Forms.CheckedListBox
    Friend WithEvents sf_btnMoveDown As System.Windows.Forms.Button
    Friend WithEvents sf_btnMoveUp As System.Windows.Forms.Button
    Friend WithEvents GroupBox15 As System.Windows.Forms.GroupBox
    Friend WithEvents Label29 As System.Windows.Forms.Label
    Friend WithEvents LinkLabel1 As System.Windows.Forms.LinkLabel
    Friend WithEvents gb_InnerList As System.Windows.Forms.GroupBox
    Friend WithEvents InnerList_llSelectInnerSubf As System.Windows.Forms.LinkLabel
    Friend WithEvents InnerList_obInnerSubfReport As System.Windows.Forms.RadioButton
    Friend WithEvents InnerList_obSelectedSubfReport As System.Windows.Forms.RadioButton
    Friend WithEvents InnerList_cbProcessParent As System.Windows.Forms.CheckBox
    Friend WithEvents SaveTorrFiles_obSaveLinkToFile As System.Windows.Forms.RadioButton
    Friend WithEvents TextBox3 As System.Windows.Forms.TextBox
    Friend WithEvents ReportSeeding_ShowOnlySeedsNotMoreThanValue As System.Windows.Forms.NumericUpDown
    Friend WithEvents ReportSeeding_ShowOnlySeedsNotMoreThanIs As System.Windows.Forms.CheckBox
End Class
