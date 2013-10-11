<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmLinksListsAndTorFiles
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmLinksListsAndTorFiles))
        Me.gbDownload = New System.Windows.Forms.GroupBox()
        Me.cbChangePasskeyToGuest = New System.Windows.Forms.CheckBox()
        Me.TextBox2 = New System.Windows.Forms.TextBox()
        Me.btnDownloadTorFiles = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btnSelectTorrentFilesLinksList = New System.Windows.Forms.Button()
        Me.txtTorrentFilesLinksList = New System.Windows.Forms.TextBox()
        Me.gbInsertPasskey = New System.Windows.Forms.GroupBox()
        Me.btnInsertNewPasskey = New System.Windows.Forms.Button()
        Me.TextBox5 = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.btnSelectPathWithTorrFiles = New System.Windows.Forms.Button()
        Me.txtSelectPathWithTorrFiles = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtNewPasskey = New System.Windows.Forms.TextBox()
        Me.BWorker = New System.ComponentModel.BackgroundWorker()
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.TSSLabel1 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.TextBox6 = New System.Windows.Forms.TextBox()
        Me.gbDownload.SuspendLayout()
        Me.gbInsertPasskey.SuspendLayout()
        Me.StatusStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'gbDownload
        '
        Me.gbDownload.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.gbDownload.Controls.Add(Me.cbChangePasskeyToGuest)
        Me.gbDownload.Controls.Add(Me.TextBox2)
        Me.gbDownload.Controls.Add(Me.btnDownloadTorFiles)
        Me.gbDownload.Controls.Add(Me.Label1)
        Me.gbDownload.Controls.Add(Me.btnSelectTorrentFilesLinksList)
        Me.gbDownload.Controls.Add(Me.txtTorrentFilesLinksList)
        Me.gbDownload.Location = New System.Drawing.Point(12, 12)
        Me.gbDownload.Name = "gbDownload"
        Me.gbDownload.Size = New System.Drawing.Size(517, 169)
        Me.gbDownload.TabIndex = 0
        Me.gbDownload.TabStop = False
        Me.gbDownload.Text = "Скачивание торрент-файлов по списку"
        '
        'cbChangePasskeyToGuest
        '
        Me.cbChangePasskeyToGuest.AutoSize = True
        Me.cbChangePasskeyToGuest.Location = New System.Drawing.Point(6, 63)
        Me.cbChangePasskeyToGuest.Name = "cbChangePasskeyToGuest"
        Me.cbChangePasskeyToGuest.Size = New System.Drawing.Size(504, 17)
        Me.cbChangePasskeyToGuest.TabIndex = 5
        Me.cbChangePasskeyToGuest.Text = "Менять пасскей на гостевой (guestguest) - полезно, если торрент-файлы НЕ для себя" & _
            " качаете"
        Me.cbChangePasskeyToGuest.UseVisualStyleBackColor = True
        '
        'TextBox2
        '
        Me.TextBox2.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TextBox2.Location = New System.Drawing.Point(6, 85)
        Me.TextBox2.Multiline = True
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.ReadOnly = True
        Me.TextBox2.Size = New System.Drawing.Size(425, 81)
        Me.TextBox2.TabIndex = 4
        Me.TextBox2.Text = resources.GetString("TextBox2.Text")
        '
        'btnDownloadTorFiles
        '
        Me.btnDownloadTorFiles.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnDownloadTorFiles.Location = New System.Drawing.Point(436, 86)
        Me.btnDownloadTorFiles.Name = "btnDownloadTorFiles"
        Me.btnDownloadTorFiles.Size = New System.Drawing.Size(75, 23)
        Me.btnDownloadTorFiles.TabIndex = 3
        Me.btnDownloadTorFiles.Text = "Скачать"
        Me.btnDownloadTorFiles.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(6, 21)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(341, 13)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Выберите текстовый файл со списком ссылок на торрент-файлы"
        '
        'btnSelectTorrentFilesLinksList
        '
        Me.btnSelectTorrentFilesLinksList.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnSelectTorrentFilesLinksList.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.btnSelectTorrentFilesLinksList.Location = New System.Drawing.Point(484, 34)
        Me.btnSelectTorrentFilesLinksList.Name = "btnSelectTorrentFilesLinksList"
        Me.btnSelectTorrentFilesLinksList.Size = New System.Drawing.Size(27, 23)
        Me.btnSelectTorrentFilesLinksList.TabIndex = 1
        Me.btnSelectTorrentFilesLinksList.Text = "..."
        Me.btnSelectTorrentFilesLinksList.UseVisualStyleBackColor = True
        '
        'txtTorrentFilesLinksList
        '
        Me.txtTorrentFilesLinksList.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtTorrentFilesLinksList.Location = New System.Drawing.Point(6, 37)
        Me.txtTorrentFilesLinksList.Name = "txtTorrentFilesLinksList"
        Me.txtTorrentFilesLinksList.ReadOnly = True
        Me.txtTorrentFilesLinksList.Size = New System.Drawing.Size(472, 20)
        Me.txtTorrentFilesLinksList.TabIndex = 0
        '
        'gbInsertPasskey
        '
        Me.gbInsertPasskey.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.gbInsertPasskey.Controls.Add(Me.btnInsertNewPasskey)
        Me.gbInsertPasskey.Controls.Add(Me.TextBox6)
        Me.gbInsertPasskey.Controls.Add(Me.TextBox5)
        Me.gbInsertPasskey.Controls.Add(Me.Label3)
        Me.gbInsertPasskey.Controls.Add(Me.btnSelectPathWithTorrFiles)
        Me.gbInsertPasskey.Controls.Add(Me.txtSelectPathWithTorrFiles)
        Me.gbInsertPasskey.Controls.Add(Me.Label2)
        Me.gbInsertPasskey.Controls.Add(Me.txtNewPasskey)
        Me.gbInsertPasskey.Location = New System.Drawing.Point(12, 187)
        Me.gbInsertPasskey.Name = "gbInsertPasskey"
        Me.gbInsertPasskey.Size = New System.Drawing.Size(517, 252)
        Me.gbInsertPasskey.TabIndex = 1
        Me.gbInsertPasskey.TabStop = False
        Me.gbInsertPasskey.Text = "Вставить в торрент-файлы другой пасскей"
        '
        'btnInsertNewPasskey
        '
        Me.btnInsertNewPasskey.Location = New System.Drawing.Point(436, 142)
        Me.btnInsertNewPasskey.Name = "btnInsertNewPasskey"
        Me.btnInsertNewPasskey.Size = New System.Drawing.Size(75, 23)
        Me.btnInsertNewPasskey.TabIndex = 7
        Me.btnInsertNewPasskey.Text = "Обработать"
        Me.btnInsertNewPasskey.UseVisualStyleBackColor = True
        '
        'TextBox5
        '
        Me.TextBox5.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TextBox5.Location = New System.Drawing.Point(245, 18)
        Me.TextBox5.Multiline = True
        Me.TextBox5.Name = "TextBox5"
        Me.TextBox5.ReadOnly = True
        Me.TextBox5.Size = New System.Drawing.Size(260, 65)
        Me.TextBox5.TabIndex = 5
        Me.TextBox5.Text = "Чтобы увидеть Ваш пасскей, на сайте rutracker.org щелкните ссылку ""Профиль"" (на в" & _
            "еб-странице справа вверху) и затем ссылку ""Passkey"". Пасскей программа не запоми" & _
            "нает, так что будьте спокойны."
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(6, 93)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(290, 13)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "Выберите папку с обрабатываемыми торрент-файлами"
        '
        'btnSelectPathWithTorrFiles
        '
        Me.btnSelectPathWithTorrFiles.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnSelectPathWithTorrFiles.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.btnSelectPathWithTorrFiles.Location = New System.Drawing.Point(484, 109)
        Me.btnSelectPathWithTorrFiles.Name = "btnSelectPathWithTorrFiles"
        Me.btnSelectPathWithTorrFiles.Size = New System.Drawing.Size(27, 23)
        Me.btnSelectPathWithTorrFiles.TabIndex = 3
        Me.btnSelectPathWithTorrFiles.Text = "..."
        Me.btnSelectPathWithTorrFiles.UseVisualStyleBackColor = True
        '
        'txtSelectPathWithTorrFiles
        '
        Me.txtSelectPathWithTorrFiles.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtSelectPathWithTorrFiles.Location = New System.Drawing.Point(9, 112)
        Me.txtSelectPathWithTorrFiles.Name = "txtSelectPathWithTorrFiles"
        Me.txtSelectPathWithTorrFiles.ReadOnly = True
        Me.txtSelectPathWithTorrFiles.Size = New System.Drawing.Size(469, 20)
        Me.txtSelectPathWithTorrFiles.TabIndex = 2
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(6, 23)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(89, 13)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Новый пасскей:"
        '
        'txtNewPasskey
        '
        Me.txtNewPasskey.Location = New System.Drawing.Point(98, 20)
        Me.txtNewPasskey.Name = "txtNewPasskey"
        Me.txtNewPasskey.Size = New System.Drawing.Size(142, 20)
        Me.txtNewPasskey.TabIndex = 0
        '
        'BWorker
        '
        Me.BWorker.WorkerReportsProgress = True
        Me.BWorker.WorkerSupportsCancellation = True
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.TSSLabel1})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 452)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(541, 22)
        Me.StatusStrip1.SizingGrip = False
        Me.StatusStrip1.TabIndex = 2
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'TSSLabel1
        '
        Me.TSSLabel1.Name = "TSSLabel1"
        Me.TSSLabel1.Size = New System.Drawing.Size(121, 17)
        Me.TSSLabel1.Text = "ToolStripStatusLabel1"
        '
        'TextBox6
        '
        Me.TextBox6.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TextBox6.Location = New System.Drawing.Point(6, 142)
        Me.TextBox6.Multiline = True
        Me.TextBox6.Name = "TextBox6"
        Me.TextBox6.ReadOnly = True
        Me.TextBox6.Size = New System.Drawing.Size(413, 105)
        Me.TextBox6.TabIndex = 6
        Me.TextBox6.Text = resources.GetString("TextBox6.Text")
        '
        'frmLinksListsAndTorFiles
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(541, 474)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.gbInsertPasskey)
        Me.Controls.Add(Me.gbDownload)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmLinksListsAndTorFiles"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Обработка списков ссылок и торрент-файлов"
        Me.gbDownload.ResumeLayout(False)
        Me.gbDownload.PerformLayout()
        Me.gbInsertPasskey.ResumeLayout(False)
        Me.gbInsertPasskey.PerformLayout()
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents gbDownload As System.Windows.Forms.GroupBox
    Friend WithEvents btnSelectTorrentFilesLinksList As System.Windows.Forms.Button
    Friend WithEvents txtTorrentFilesLinksList As System.Windows.Forms.TextBox
    Friend WithEvents TextBox2 As System.Windows.Forms.TextBox
    Friend WithEvents btnDownloadTorFiles As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents gbInsertPasskey As System.Windows.Forms.GroupBox
    Friend WithEvents cbChangePasskeyToGuest As System.Windows.Forms.CheckBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtNewPasskey As System.Windows.Forms.TextBox
    Friend WithEvents btnSelectPathWithTorrFiles As System.Windows.Forms.Button
    Friend WithEvents txtSelectPathWithTorrFiles As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents TextBox5 As System.Windows.Forms.TextBox
    Friend WithEvents BWorker As System.ComponentModel.BackgroundWorker
    Friend WithEvents btnInsertNewPasskey As System.Windows.Forms.Button
    Friend WithEvents StatusStrip1 As System.Windows.Forms.StatusStrip
    Friend WithEvents TSSLabel1 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents TextBox6 As System.Windows.Forms.TextBox
End Class
