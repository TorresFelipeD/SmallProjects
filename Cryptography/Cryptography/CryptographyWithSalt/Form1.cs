using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CryptographyWithSalt.Crypto;

namespace CryptographyWithSalt
{
    public partial class Form1 : Form
    {
        SaltPassword SaltPassword = new SaltPassword();

        public Form1()
        {
            InitializeComponent();
        }

        private void SubmitSignIn_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(PasswordSignIn.Text))
            {
                MessageBox.Show("Ingrese un valor");
                return;
            }

            var salt = SaltPassword.CreateSalt(500);
            var hash = SaltPassword.GenerateSHA256Hash(PasswordSignIn.Text, salt);

            SaltSignInValidate.Text = salt;
            PasswordSignInValidate.Text = hash;

        }

        private void SubmitLogIn_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(PasswordLogIn.Text))
            {
                MessageBox.Show("Ingrese un valor");
                return;
            }

            var salt = SaltSignInValidate.Text;
            var hash = SaltPassword.GenerateSHA256Hash(PasswordLogIn.Text, salt);

            SaltLogInValidate.Text = salt;
            PasswordLogInValidate.Text = hash;
            bool isValid = PasswordLogInValidate.Text == PasswordSignInValidate.Text;
            ValidateLogIn.Text = isValid ? "Contraseña Correcta" : "Contraseña Incorrecta";
        }
    }
}
