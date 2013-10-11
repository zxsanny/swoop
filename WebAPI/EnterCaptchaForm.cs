using System;
using System.Net;
using System.Windows.Forms;
using uHelper.Extensions;
using uHelper.webAPI.Domains;

namespace uHelper.webAPI
{
    public partial class EnterCaptchaForm : Form
    {
        public CredentialAndCaptcha CredentialAndCaptcha
        {
            get
            {
                return new CredentialAndCaptcha(new NetworkCredential(tbUsername.Text, tbPassword.Text.ToSecureString()), tbCaptchaCode.Text);
            }
        }

        public EnterCaptchaForm()
        {
            InitializeComponent();
        }
        public EnterCaptchaForm(NetworkCredential credential, string captchaUrl) : this()
        {
            InitializeCredentials(credential, captchaUrl);
        }

        private void InitializeCredentials(NetworkCredential credential, string captchaUrl)
        {
            tbUsername.Text = credential.UserName;
            tbPassword.Text = credential.Password;

            pbCaptcha.ImageLocation = captchaUrl;
        }


        private void bOk_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(tbUsername.Text) || string.IsNullOrEmpty(tbPassword.Text) || string.IsNullOrEmpty(tbCaptchaCode.Text))
            {
                MessageBox.Show("You must fill username, password and captcha fields!", "Some fields are empty!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            DialogResult = DialogResult.OK;
            Close();
        }
    }
}
