<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSaveRestoreTorrentsLabels
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
        Me.rbSaveLabelsToFile = New System.Windows.Forms.RadioButton()
        Me.rbRestoreLabelsFromFile = New System.Windows.Forms.RadioButton()
        Me.txtFileName = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btnSelectFile = New System.Windows.Forms.Button()
        Me.btnExecute = New System.Windows.Forms.Button()
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.TSSLbl = New System.Windows.Forms.ToolStripStatusLabel()
        Me.gbRestoreLabelsFromFile = New System.Windows.Forms.GroupBox()
        Me.BgrndWorker = New System.ComponentModel.BackgroundWorker()
        Me.StatusStrip1.SuspendLayout()
        Me.gbRestoreLabelsFromFile.SuspendLayout()
        Me.SuspendLayout()
        '
        'rbSaveLabelsToFile
        '
        Me.rbSaveLabelsToFile.AutoSize = True
        Me.rbSaveLabelsToFile.Location = New System.Drawing.Point(21, 12)
        Me.rbSaveLabelsToFile.Name = "rbSaveLabelsToFile"
        Me.rbSaveLabelsToFile.Size = New System.Drawing.Size(188, 17)
        Me.rbSaveLabelsToFile.TabIndex = 0
        Me.rbSaveLabelsToFile.TabStop = True
        Me.rbSaveLabelsToFile.Text = "Сохранить меток раздач в файл"
        Me.rbSaveLabelsToFile.UseVisualStyleBackColor = True
        '
        'rbRestoreLabelsFromFile
        '
        Me.rbRestoreLabelsFromFile.AutoSize = True
        Me.rbRestoreLabelsFromFile.Location = New System.Drawing.Point(21, 35)
        Me.rbRestoreLabelsFromFile.Name = "rbRestoreLabelsFromFile"
        Me.rbRestoreLabelsFromFile.Size = New System.Drawing.Size(199, 17)
        Me.rbRestoreLabelsFromFile.TabIndex = 1
        Me.rbRestoreLabelsFromFile.TabStop = True
        Me.rbRestoreLabelsFromFile.Text = "Загрузить метки раздач из файла"
        Me.rbRestoreLabelsFromFile.UseVisualStyleBackColor = True
        '
        'txtFileName
        '
        Me.txtFileName.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtFileName.Location = New System.Drawing.Point(9, 47)
        Me.txtFileName.Name = "txtFileName"
        Me.txtFileName.ReadOnly = True
        Me.txtFileName.Size = New System.Drawing.Size(563, 20)
        Me.txtFileName.TabIndex = 2
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(6, 31)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(84, 13)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "Укажите файл:"
        '
        'btnSelectFile
        '
        Me.btnSelectFile.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnSelectFile.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.btnSelectFile.Location = New System.Drawing.Point(578, 44)
        Me.btnSelectFile.Name = "btnSelectFile"
        Me.btnSelectFile.Size = New System.Drawing.Size(25, 23)
        Me.btnSelectFile.TabIndex = 4
        Me.btnSelectFile.Text = "..."
        Me.btnSelectFile.UseVisualStyleBackColor = True
        '
        'btnExecute
        '
        Me.btnExecute.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnExecute.Location = New System.Drawing.Point(546, 139)
        Me.btnExecute.Name = "btnExecute"
        Me.btnExecute.Size = New System.Drawing.Size(75, 23)
        Me.btnExecute.TabIndex = 5
        Me.btnExecute.Text = "Выполнить"
        Me.btnExecute.UseVisualStyleBackColor = True
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.TSSLbl})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 165)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(633, 22)
        Me.StatusStrip1.TabIndex = 6
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'TSSLbl
        '
        Me.TSSLbl.Name = "TSSLbl"
        Me.TSSLbl.Size = New System.Drawing.Size(0, 17)
        '
        'gbRestoreLabelsFromFile
        '
        Me.gbRestoreLabelsFromFile.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.gbRestoreLabelsFromFile.Controls.Add(Me.Label1)
        Me.gbRestoreLabelsFromFile.Controls.Add(Me.txtFileName)
        Me.gbRestoreLabelsFromFile.Controls.Add(Me.btnSelectFile)
        Me.gbRestoreLabelsFromFile.Enabled = False
        Me.gbRestoreLabelsFromFile.Location = New System.Drawing.Point(12, 39)
        Me.gbRestoreLabelsFromFile.Name = "gbRestoreLabelsFromFile"
        Me.gbRestoreLabelsFromFile.Size = New System.Drawing.Size(609, 91)
        Me.gbRestoreLabelsFromFile.TabIndex = 7
        Me.gbRestoreLabelsFromFile.TabStop = False
        '
        'BgrndWorker
        '
        Me.BgrndWorker.WorkerReportsProgress = True
        Me.BgrndWorker.WorkerSupportsCancellation = True
        '
        'frmSaveRestoreTorrentsLabels
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(633, 187)
        Me.Controls.Add(Me.rbRestoreLabelsFromFile)
        Me.Controls.Add(Me.gbRestoreLabelsFromFile)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.btnExecute)
        Me.Controls.Add(Me.rbSaveLabelsToFile)
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(1000, 225)
        Me.MinimizeBox = False
        Me.MinimumSize = New System.Drawing.Size(450, 225)
        Me.Name = "frmSaveRestoreTorrentsLabels"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Сохранение и восстановление меток раздач в торрент-клиенте"
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.gbRestoreLabelsFromFile.ResumeLayout(False)
        Me.gbRestoreLabelsFromFile.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents rbSaveLabelsToFile As System.Windows.Forms.RadioButton
    Friend WithEvents rbRestoreLabelsFromFile As System.Windows.Forms.RadioButton
    Friend WithEvents txtFileName As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents btnSelectFile As System.Windows.Forms.Button
    Friend WithEvents btnExecute As System.Windows.Forms.Button
    Friend WithEvents StatusStrip1 As System.Windows.Forms.StatusStrip
    Friend WithEvents TSSLbl As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents gbRestoreLabelsFromFile As System.Windows.Forms.GroupBox
    Friend WithEvents BgrndWorker As System.ComponentModel.BackgroundWorker
End Class
