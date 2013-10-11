<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMain
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
        Dim DataGridViewCellStyle21 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle22 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle23 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle24 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle25 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle26 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle27 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle28 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle29 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle30 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmMain))
        Me.BWorker = New System.ComponentModel.BackgroundWorker()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.ФайлToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.НастройкиToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ВыходToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ЗапускToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ОбработатьПодразделToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ПоказатьОтчётыToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.ОбработатьВсеТоррентфайлыПодрядToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.ОтдельнаяОбработкаМетокРаздачВТоррентклиентуToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ПолучитьДанныеИзТоррентфайловToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ПроверитьПользователяНаСидированиеToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ОстановитьВсеРаздачиВТоррентклиентеToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.СкачиваниеТорентфайловПоСпискуИРаботаСПасскеямиToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ОПрограммеToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.TSSLabel1 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.TimerToolStripDropDownButton1 = New System.Windows.Forms.ToolStripDropDownButton()
        Me.TimerStartONToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.TimerStartOFFToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.TSSLabelTimer = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripStatusLabel2 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.TSSTorrFilesParsing = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripStatusLabel1 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.Timer = New System.Windows.Forms.Timer(Me.components)
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.dgv1 = New System.Windows.Forms.DataGridView()
        Me.Web_Status = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Web_SizeKMGBytes = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.NameLink = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.FullSource = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.WebTorrentRegistered = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Seeds = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Peers = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.toSave = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.toTorClnt = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.txtReport = New System.Windows.Forms.TextBox()
        Me.TabPage3 = New System.Windows.Forms.TabPage()
        Me.txtReportInForum = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cbSelectSubforum = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtSubforumFullPath = New System.Windows.Forms.TextBox()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.NotifyIcon1 = New System.Windows.Forms.NotifyIcon(Me.components)
        Me.MenuStrip1.SuspendLayout()
        Me.StatusStrip1.SuspendLayout()
        Me.TabControl1.SuspendLayout()
        Me.TabPage2.SuspendLayout()
        CType(Me.dgv1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage1.SuspendLayout()
        Me.TabPage3.SuspendLayout()
        Me.SuspendLayout()
        '
        'BWorker
        '
        Me.BWorker.WorkerReportsProgress = True
        Me.BWorker.WorkerSupportsCancellation = True
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ФайлToolStripMenuItem, Me.ЗапускToolStripMenuItem, Me.ToolStripMenuItem1})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(1004, 24)
        Me.MenuStrip1.TabIndex = 8
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'ФайлToolStripMenuItem
        '
        Me.ФайлToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.НастройкиToolStripMenuItem, Me.ВыходToolStripMenuItem})
        Me.ФайлToolStripMenuItem.Name = "ФайлToolStripMenuItem"
        Me.ФайлToolStripMenuItem.Size = New System.Drawing.Size(48, 20)
        Me.ФайлToolStripMenuItem.Text = "Файл"
        '
        'НастройкиToolStripMenuItem
        '
        Me.НастройкиToolStripMenuItem.Name = "НастройкиToolStripMenuItem"
        Me.НастройкиToolStripMenuItem.Size = New System.Drawing.Size(134, 22)
        Me.НастройкиToolStripMenuItem.Text = "Настройки"
        '
        'ВыходToolStripMenuItem
        '
        Me.ВыходToolStripMenuItem.Name = "ВыходToolStripMenuItem"
        Me.ВыходToolStripMenuItem.Size = New System.Drawing.Size(134, 22)
        Me.ВыходToolStripMenuItem.Text = "Выход"
        '
        'ЗапускToolStripMenuItem
        '
        Me.ЗапускToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ОбработатьПодразделToolStripMenuItem, Me.ПоказатьОтчётыToolStripMenuItem, Me.ToolStripSeparator1, Me.ОбработатьВсеТоррентфайлыПодрядToolStripMenuItem, Me.ToolStripSeparator2, Me.ОтдельнаяОбработкаМетокРаздачВТоррентклиентуToolStripMenuItem, Me.ПолучитьДанныеИзТоррентфайловToolStripMenuItem, Me.ПроверитьПользователяНаСидированиеToolStripMenuItem, Me.ОстановитьВсеРаздачиВТоррентклиентеToolStripMenuItem, Me.ToolStripSeparator3, Me.СкачиваниеТорентфайловПоСпискуИРаботаСПасскеямиToolStripMenuItem})
        Me.ЗапускToolStripMenuItem.Name = "ЗапускToolStripMenuItem"
        Me.ЗапускToolStripMenuItem.Size = New System.Drawing.Size(57, 20)
        Me.ЗапускToolStripMenuItem.Text = "Запуск"
        '
        'ОбработатьПодразделToolStripMenuItem
        '
        Me.ОбработатьПодразделToolStripMenuItem.Name = "ОбработатьПодразделToolStripMenuItem"
        Me.ОбработатьПодразделToolStripMenuItem.Size = New System.Drawing.Size(423, 22)
        Me.ОбработатьПодразделToolStripMenuItem.Text = "Обработать подраздел(ы)"
        '
        'ПоказатьОтчётыToolStripMenuItem
        '
        Me.ПоказатьОтчётыToolStripMenuItem.Name = "ПоказатьОтчётыToolStripMenuItem"
        Me.ПоказатьОтчётыToolStripMenuItem.Size = New System.Drawing.Size(423, 22)
        Me.ПоказатьОтчётыToolStripMenuItem.Text = "Сформировать и отобразить отчёты"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(420, 6)
        '
        'ОбработатьВсеТоррентфайлыПодрядToolStripMenuItem
        '
        Me.ОбработатьВсеТоррентфайлыПодрядToolStripMenuItem.Name = "ОбработатьВсеТоррентфайлыПодрядToolStripMenuItem"
        Me.ОбработатьВсеТоррентфайлыПодрядToolStripMenuItem.Size = New System.Drawing.Size(423, 22)
        Me.ОбработатьВсеТоррентфайлыПодрядToolStripMenuItem.Text = "Обработать все торрент-файлы подряд (старый способ)"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(420, 6)
        '
        'ОтдельнаяОбработкаМетокРаздачВТоррентклиентуToolStripMenuItem
        '
        Me.ОтдельнаяОбработкаМетокРаздачВТоррентклиентуToolStripMenuItem.Name = "ОтдельнаяОбработкаМетокРаздачВТоррентклиентуToolStripMenuItem"
        Me.ОтдельнаяОбработкаМетокРаздачВТоррентклиентуToolStripMenuItem.Size = New System.Drawing.Size(432, 22)
        Me.ОтдельнаяОбработкаМетокРаздачВТоррентклиентуToolStripMenuItem.Text = "Сохранение и восстановление меток раздач в торрент-клиенте..."
        '
        'ПолучитьДанныеИзТоррентфайловToolStripMenuItem
        '
        Me.ПолучитьДанныеИзТоррентфайловToolStripMenuItem.Name = "ПолучитьДанныеИзТоррентфайловToolStripMenuItem"
        Me.ПолучитьДанныеИзТоррентфайловToolStripMenuItem.Size = New System.Drawing.Size(423, 22)
        Me.ПолучитьДанныеИзТоррентфайловToolStripMenuItem.Text = "Получить данные из торрент-файлов"
        '
        'ПроверитьПользователяНаСидированиеToolStripMenuItem
        '
        Me.ПроверитьПользователяНаСидированиеToolStripMenuItem.Name = "ПроверитьПользователяНаСидированиеToolStripMenuItem"
        Me.ПроверитьПользователяНаСидированиеToolStripMenuItem.Size = New System.Drawing.Size(432, 22)
        Me.ПроверитьПользователяНаСидированиеToolStripMenuItem.Text = "Проверить пользователя на сидирование..."
        '
        'ОстановитьВсеРаздачиВТоррентклиентеToolStripMenuItem
        '
        Me.ОстановитьВсеРаздачиВТоррентклиентеToolStripMenuItem.Name = "ОстановитьВсеРаздачиВТоррентклиентеToolStripMenuItem"
        Me.ОстановитьВсеРаздачиВТоррентклиентеToolStripMenuItem.Size = New System.Drawing.Size(423, 22)
        Me.ОстановитьВсеРаздачиВТоррентклиентеToolStripMenuItem.Text = "Остановить все раздачи в торрент-клиенте"
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(420, 6)
        '
        'СкачиваниеТорентфайловПоСпискуИРаботаСПасскеямиToolStripMenuItem
        '
        Me.СкачиваниеТорентфайловПоСпискуИРаботаСПасскеямиToolStripMenuItem.Name = "СкачиваниеТорентфайловПоСпискуИРаботаСПасскеямиToolStripMenuItem"
        Me.СкачиваниеТорентфайловПоСпискуИРаботаСПасскеямиToolStripMenuItem.Size = New System.Drawing.Size(432, 22)
        Me.СкачиваниеТорентфайловПоСпискуИРаботаСПасскеямиToolStripMenuItem.Text = "Скачивание торрент-файлов по списку и работа с пасскеями..."
        '
        'ToolStripMenuItem1
        '
        Me.ToolStripMenuItem1.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ОПрограммеToolStripMenuItem})
        Me.ToolStripMenuItem1.Name = "ToolStripMenuItem1"
        Me.ToolStripMenuItem1.Size = New System.Drawing.Size(24, 20)
        Me.ToolStripMenuItem1.Text = "?"
        '
        'ОПрограммеToolStripMenuItem
        '
        Me.ОПрограммеToolStripMenuItem.Name = "ОПрограммеToolStripMenuItem"
        Me.ОПрограммеToolStripMenuItem.Size = New System.Drawing.Size(149, 22)
        Me.ОПрограммеToolStripMenuItem.Text = "О программе"
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.TSSLabel1, Me.TimerToolStripDropDownButton1, Me.TSSLabelTimer, Me.ToolStripStatusLabel2, Me.TSSTorrFilesParsing, Me.ToolStripStatusLabel1})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 711)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.ShowItemToolTips = True
        Me.StatusStrip1.Size = New System.Drawing.Size(1004, 22)
        Me.StatusStrip1.TabIndex = 10
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'TSSLabel1
        '
        Me.TSSLabel1.AutoSize = False
        Me.TSSLabel1.Name = "TSSLabel1"
        Me.TSSLabel1.Size = New System.Drawing.Size(650, 17)
        Me.TSSLabel1.Text = "TSSLabel1"
        Me.TSSLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'TimerToolStripDropDownButton1
        '
        Me.TimerToolStripDropDownButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.TimerToolStripDropDownButton1.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.TimerStartONToolStripMenuItem, Me.TimerStartOFFToolStripMenuItem})
        Me.TimerToolStripDropDownButton1.Image = Global.WindowsApplication1.My.Resources.Resources.stoppic
        Me.TimerToolStripDropDownButton1.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.TimerToolStripDropDownButton1.Name = "TimerToolStripDropDownButton1"
        Me.TimerToolStripDropDownButton1.Size = New System.Drawing.Size(29, 20)
        Me.TimerToolStripDropDownButton1.Text = "ToolStripDropDownButton1"
        Me.TimerToolStripDropDownButton1.ToolTipText = " "
        '
        'TimerStartONToolStripMenuItem
        '
        Me.TimerStartONToolStripMenuItem.Image = Global.WindowsApplication1.My.Resources.Resources.start
        Me.TimerStartONToolStripMenuItem.Name = "TimerStartONToolStripMenuItem"
        Me.TimerStartONToolStripMenuItem.Size = New System.Drawing.Size(181, 22)
        Me.TimerStartONToolStripMenuItem.Text = "Включить таймер"
        '
        'TimerStartOFFToolStripMenuItem
        '
        Me.TimerStartOFFToolStripMenuItem.Image = Global.WindowsApplication1.My.Resources.Resources.stoppic
        Me.TimerStartOFFToolStripMenuItem.Name = "TimerStartOFFToolStripMenuItem"
        Me.TimerStartOFFToolStripMenuItem.Size = New System.Drawing.Size(181, 22)
        Me.TimerStartOFFToolStripMenuItem.Text = "Выключить таймер"
        '
        'TSSLabelTimer
        '
        Me.TSSLabelTimer.AutoSize = False
        Me.TSSLabelTimer.Name = "TSSLabelTimer"
        Me.TSSLabelTimer.Size = New System.Drawing.Size(100, 17)
        Me.TSSLabelTimer.Text = "TSSLabelTimer"
        Me.TSSLabelTimer.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'ToolStripStatusLabel2
        '
        Me.ToolStripStatusLabel2.Name = "ToolStripStatusLabel2"
        Me.ToolStripStatusLabel2.Size = New System.Drawing.Size(10, 17)
        Me.ToolStripStatusLabel2.Text = "|"
        '
        'TSSTorrFilesParsing
        '
        Me.TSSTorrFilesParsing.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.TSSTorrFilesParsing.Image = Global.WindowsApplication1.My.Resources.Resources.OK
        Me.TSSTorrFilesParsing.Name = "TSSTorrFilesParsing"
        Me.TSSTorrFilesParsing.Size = New System.Drawing.Size(16, 17)
        Me.TSSTorrFilesParsing.Text = "ToolStripStatusLabel1"
        Me.TSSTorrFilesParsing.ToolTipText = "Здесь будут данные о прочтении торрент-файлов"
        '
        'ToolStripStatusLabel1
        '
        Me.ToolStripStatusLabel1.Name = "ToolStripStatusLabel1"
        Me.ToolStripStatusLabel1.Size = New System.Drawing.Size(10, 17)
        Me.ToolStripStatusLabel1.Text = "|"
        '
        'Timer
        '
        Me.Timer.Interval = 3600
        '
        'TabControl1
        '
        Me.TabControl1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage3)
        Me.TabControl1.Location = New System.Drawing.Point(0, 80)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(1004, 628)
        Me.TabControl1.TabIndex = 11
        '
        'TabPage2
        '
        Me.TabPage2.BackColor = System.Drawing.SystemColors.Control
        Me.TabPage2.Controls.Add(Me.dgv1)
        Me.TabPage2.Location = New System.Drawing.Point(4, 22)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(996, 602)
        Me.TabPage2.TabIndex = 3
        Me.TabPage2.Text = "Отчет по подразделу (таблица)"
        '
        'dgv1
        '
        Me.dgv1.AllowUserToAddRows = False
        DataGridViewCellStyle21.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.dgv1.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle21
        Me.dgv1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCellsExceptHeader
        Me.dgv1.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        DataGridViewCellStyle22.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle22.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle22.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        DataGridViewCellStyle22.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle22.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle22.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        Me.dgv1.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle22
        Me.dgv1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgv1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Web_Status, Me.Web_SizeKMGBytes, Me.NameLink, Me.FullSource, Me.WebTorrentRegistered, Me.Seeds, Me.Peers, Me.toSave, Me.toTorClnt})
        Me.dgv1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgv1.Location = New System.Drawing.Point(3, 3)
        Me.dgv1.Name = "dgv1"
        Me.dgv1.RowHeadersVisible = False
        Me.dgv1.RowTemplate.DefaultCellStyle.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.dgv1.Size = New System.Drawing.Size(990, 596)
        Me.dgv1.TabIndex = 0
        '
        'Web_Status
        '
        DataGridViewCellStyle23.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle23.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Web_Status.DefaultCellStyle = DataGridViewCellStyle23
        Me.Web_Status.HeaderText = "Статус"
        Me.Web_Status.MinimumWidth = 50
        Me.Web_Status.Name = "Web_Status"
        Me.Web_Status.ReadOnly = True
        Me.Web_Status.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.Web_Status.Width = 50
        '
        'Web_SizeKMGBytes
        '
        DataGridViewCellStyle24.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.Web_SizeKMGBytes.DefaultCellStyle = DataGridViewCellStyle24
        Me.Web_SizeKMGBytes.HeaderText = "Размер"
        Me.Web_SizeKMGBytes.MinimumWidth = 55
        Me.Web_SizeKMGBytes.Name = "Web_SizeKMGBytes"
        Me.Web_SizeKMGBytes.ReadOnly = True
        Me.Web_SizeKMGBytes.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.Web_SizeKMGBytes.Width = 55
        '
        'NameLink
        '
        Me.NameLink.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        DataGridViewCellStyle25.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        Me.NameLink.DefaultCellStyle = DataGridViewCellStyle25
        Me.NameLink.HeaderText = "Наименование раздачи"
        Me.NameLink.MinimumWidth = 500
        Me.NameLink.Name = "NameLink"
        Me.NameLink.ReadOnly = True
        Me.NameLink.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.NameLink.Width = 500
        '
        'FullSource
        '
        DataGridViewCellStyle26.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        Me.FullSource.DefaultCellStyle = DataGridViewCellStyle26
        Me.FullSource.HeaderText = "Полный источник"
        Me.FullSource.MinimumWidth = 110
        Me.FullSource.Name = "FullSource"
        Me.FullSource.ReadOnly = True
        Me.FullSource.Width = 110
        '
        'WebTorrentRegistered
        '
        Me.WebTorrentRegistered.HeaderText = "Торрент зарег-ван"
        Me.WebTorrentRegistered.MinimumWidth = 115
        Me.WebTorrentRegistered.Name = "WebTorrentRegistered"
        Me.WebTorrentRegistered.ReadOnly = True
        Me.WebTorrentRegistered.Width = 115
        '
        'Seeds
        '
        DataGridViewCellStyle27.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.Seeds.DefaultCellStyle = DataGridViewCellStyle27
        Me.Seeds.HeaderText = "Сиды"
        Me.Seeds.MinimumWidth = 40
        Me.Seeds.Name = "Seeds"
        Me.Seeds.ReadOnly = True
        Me.Seeds.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.Seeds.Width = 40
        '
        'Peers
        '
        DataGridViewCellStyle28.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.Peers.DefaultCellStyle = DataGridViewCellStyle28
        Me.Peers.HeaderText = "Пиры"
        Me.Peers.MinimumWidth = 45
        Me.Peers.Name = "Peers"
        Me.Peers.ReadOnly = True
        Me.Peers.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.Peers.Width = 45
        '
        'toSave
        '
        DataGridViewCellStyle29.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.toSave.DefaultCellStyle = DataGridViewCellStyle29
        Me.toSave.HeaderText = "в файл"
        Me.toSave.MinimumWidth = 50
        Me.toSave.Name = "toSave"
        Me.toSave.ReadOnly = True
        Me.toSave.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.toSave.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.toSave.Width = 50
        '
        'toTorClnt
        '
        DataGridViewCellStyle30.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.toTorClnt.DefaultCellStyle = DataGridViewCellStyle30
        Me.toTorClnt.HeaderText = "в тор. клиент"
        Me.toTorClnt.MinimumWidth = 50
        Me.toTorClnt.Name = "toTorClnt"
        Me.toTorClnt.ReadOnly = True
        Me.toTorClnt.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.toTorClnt.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.toTorClnt.Width = 50
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.txtReport)
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(996, 602)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Отчет по подразделу (список)"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'txtReport
        '
        Me.txtReport.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtReport.Location = New System.Drawing.Point(3, 3)
        Me.txtReport.Multiline = True
        Me.txtReport.Name = "txtReport"
        Me.txtReport.ReadOnly = True
        Me.txtReport.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.txtReport.Size = New System.Drawing.Size(990, 596)
        Me.txtReport.TabIndex = 0
        '
        'TabPage3
        '
        Me.TabPage3.Controls.Add(Me.txtReportInForum)
        Me.TabPage3.Location = New System.Drawing.Point(4, 22)
        Me.TabPage3.Name = "TabPage3"
        Me.TabPage3.Size = New System.Drawing.Size(996, 602)
        Me.TabPage3.TabIndex = 2
        Me.TabPage3.Text = "Отчёт в форум о сидируемых раздачах"
        Me.TabPage3.UseVisualStyleBackColor = True
        '
        'txtReportInForum
        '
        Me.txtReportInForum.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtReportInForum.Location = New System.Drawing.Point(0, 0)
        Me.txtReportInForum.Multiline = True
        Me.txtReportInForum.Name = "txtReportInForum"
        Me.txtReportInForum.ReadOnly = True
        Me.txtReportInForum.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.txtReportInForum.Size = New System.Drawing.Size(996, 602)
        Me.txtReportInForum.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 30)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(117, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Выберите подраздел:"
        '
        'cbSelectSubforum
        '
        Me.cbSelectSubforum.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbSelectSubforum.FormattingEnabled = True
        Me.cbSelectSubforum.Location = New System.Drawing.Point(135, 27)
        Me.cbSelectSubforum.Name = "cbSelectSubforum"
        Me.cbSelectSubforum.Size = New System.Drawing.Size(518, 21)
        Me.cbSelectSubforum.TabIndex = 1
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(12, 57)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(146, 13)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Полный путь к подразделу:"
        '
        'txtSubforumFullPath
        '
        Me.txtSubforumFullPath.Location = New System.Drawing.Point(164, 54)
        Me.txtSubforumFullPath.Name = "txtSubforumFullPath"
        Me.txtSubforumFullPath.ReadOnly = True
        Me.txtSubforumFullPath.Size = New System.Drawing.Size(489, 20)
        Me.txtSubforumFullPath.TabIndex = 3
        '
        'NotifyIcon1
        '
        Me.NotifyIcon1.Icon = CType(resources.GetObject("NotifyIcon1.Icon"), System.Drawing.Icon)
        Me.NotifyIcon1.Text = "NotifyIcon1"
        '
        'frmMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1004, 733)
        Me.Controls.Add(Me.txtSubforumFullPath)
        Me.Controls.Add(Me.TabControl1)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.cbSelectSubforum)
        Me.Controls.Add(Me.MenuStrip1)
        Me.Controls.Add(Me.Label1)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.MinimumSize = New System.Drawing.Size(750, 440)
        Me.Name = "frmMain"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage2.ResumeLayout(False)
        CType(Me.dgv1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage1.PerformLayout()
        Me.TabPage3.ResumeLayout(False)
        Me.TabPage3.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents BWorker As System.ComponentModel.BackgroundWorker
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents ФайлToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents НастройкиToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents StatusStrip1 As System.Windows.Forms.StatusStrip
    Friend WithEvents TSSLabel1 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ЗапускToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ОбработатьПодразделToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ОбработатьВсеТоррентфайлыПодрядToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ОПрограммеToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ВыходToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents TimerToolStripDropDownButton1 As System.Windows.Forms.ToolStripDropDownButton
    Friend WithEvents TimerStartOFFToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents TimerStartONToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Timer As System.Windows.Forms.Timer
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cbSelectSubforum As System.Windows.Forms.ComboBox
    Friend WithEvents txtSubforumFullPath As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents TabPage3 As System.Windows.Forms.TabPage
    Friend WithEvents txtReport As System.Windows.Forms.TextBox
    Friend WithEvents txtReportInForum As System.Windows.Forms.TextBox
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents TSSLabelTimer As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents NotifyIcon1 As System.Windows.Forms.NotifyIcon
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ОтдельнаяОбработкаМетокРаздачВТоррентклиентуToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ПолучитьДанныеИзТоррентфайловToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
    Friend WithEvents dgv1 As System.Windows.Forms.DataGridView
    Friend WithEvents Web_Status As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Web_SizeKMGBytes As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents NameLink As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents FullSource As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents WebTorrentRegistered As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Seeds As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Peers As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents toSave As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents toTorClnt As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ПоказатьОтчётыToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ПроверитьПользователяНаСидированиеToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ОстановитьВсеРаздачиВТоррентклиентеToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents TSSTorrFilesParsing As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel2 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents СкачиваниеТорентфайловПоСпискуИРаботаСПасскеямиToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripStatusLabel1 As System.Windows.Forms.ToolStripStatusLabel

End Class
