<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCaptcha
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
        Me.pbCaptcha = New System.Windows.Forms.PictureBox()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtSite_Username = New System.Windows.Forms.TextBox()
        Me.txtSite_Password = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtCaptcha = New System.Windows.Forms.TextBox()
        Me.cmdEnter = New System.Windows.Forms.Button()
        CType(Me.pbCaptcha, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'pbCaptcha
        '
        Me.pbCaptcha.Location = New System.Drawing.Point(66, 113)
        Me.pbCaptcha.Name = "pbCaptcha"
        Me.pbCaptcha.Size = New System.Drawing.Size(130, 80)
        Me.pbCaptcha.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.pbCaptcha.TabIndex = 0
        Me.pbCaptcha.TabStop = False
        '
        'TextBox1
        '
        Me.TextBox1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TextBox1.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TextBox1.Location = New System.Drawing.Point(12, 12)
        Me.TextBox1.Multiline = True
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.ReadOnly = True
        Me.TextBox1.Size = New System.Drawing.Size(260, 49)
        Me.TextBox1.TabIndex = 1
        Me.TextBox1.Text = "По каким-то причинам сайт захотел проверить Вас. ВНИМАТЕЛЬНО проверьте введенные " & _
            "Вами имя пользователя и пароль, а также введите код."
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(28, 64)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(32, 13)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Имя:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(12, 90)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(48, 13)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "Пароль:"
        '
        'txtSite_Username
        '
        Me.txtSite_Username.Location = New System.Drawing.Point(66, 61)
        Me.txtSite_Username.Name = "txtSite_Username"
        Me.txtSite_Username.Size = New System.Drawing.Size(203, 20)
        Me.txtSite_Username.TabIndex = 0
        '
        'txtSite_Password
        '
        Me.txtSite_Password.Location = New System.Drawing.Point(66, 87)
        Me.txtSite_Password.Name = "txtSite_Password"
        Me.txtSite_Password.Size = New System.Drawing.Size(203, 20)
        Me.txtSite_Password.TabIndex = 1
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(31, 150)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(29, 13)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "Код:"
        '
        'txtCaptcha
        '
        Me.txtCaptcha.Location = New System.Drawing.Point(66, 199)
        Me.txtCaptcha.Name = "txtCaptcha"
        Me.txtCaptcha.Size = New System.Drawing.Size(203, 20)
        Me.txtCaptcha.TabIndex = 5
        '
        'cmdEnter
        '
        Me.cmdEnter.Location = New System.Drawing.Point(95, 225)
        Me.cmdEnter.Name = "cmdEnter"
        Me.cmdEnter.Size = New System.Drawing.Size(75, 23)
        Me.cmdEnter.TabIndex = 6
        Me.cmdEnter.Text = "Вход"
        Me.cmdEnter.UseVisualStyleBackColor = True
        '
        'frmCaptcha
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(284, 260)
        Me.ControlBox = False
        Me.Controls.Add(Me.cmdEnter)
        Me.Controls.Add(Me.txtCaptcha)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.txtSite_Password)
        Me.Controls.Add(Me.txtSite_Username)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.TextBox1)
        Me.Controls.Add(Me.pbCaptcha)
        Me.Controls.Add(Me.Label1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "frmCaptcha"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Ввод текста кода"
        CType(Me.pbCaptcha, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents pbCaptcha As System.Windows.Forms.PictureBox
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtSite_Username As System.Windows.Forms.TextBox
    Friend WithEvents txtSite_Password As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtCaptcha As System.Windows.Forms.TextBox
    Friend WithEvents cmdEnter As System.Windows.Forms.Button
End Class
