Public Class frmCaptcha

    Private Sub frmCaptcha_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        pbCaptcha.ImageLocation = CaptchaURL
        txtSite_Username.Text = CaptchaUsername
        txtSite_Password.Text = CaptchaPassword
    End Sub

    Private Sub cmdEnter_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdEnter.Click
        CaptchaUsername = Trim(txtSite_Username.Text)
        CaptchaPassword = Trim(txtSite_Password.Text)
        Captcha = Trim(txtCaptcha.Text)
        CaptchaTextIsWritten = True
        Me.Dispose()
    End Sub
End Class