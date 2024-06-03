using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Security.Cryptography;
using PasswordManager.Util;

namespace PasswordManager
{

    public partial class Register : Form
    {
        public Login _login;
        public Register(Login login)
        {
            InitializeComponent();
            _login = login;
        }

        private void RegisterButton_Click(object sender, EventArgs e)
        {
            if (UserNameTextBox.Text == "" || PasswordTextBox.Text == "")
            {
                MessageBox.Show("Please fill all the fields");
                return;
            }
            HashAlgorithmName hashAlgorithm = HashAlgorithmName.SHA256;
            byte[] PasswordPbkdf2 = Rfc2898DeriveBytes.Pbkdf2(PasswordTextBox.Text, Encoding.ASCII.GetBytes(UserNameTextBox.Text), 1000, hashAlgorithm, 32);

            string PasswordHash = Convert.ToBase64String(PasswordPbkdf2);
            Util.FileOperations fileOperations = new Util.FileOperations();

            string path = fileOperations.GetAppDataPath("Users", UserNameTextBox.Text + ".txt");
            if (fileOperations.FileExists(fileOperations.GetAppDataPath("Users")) == false)
            {
                fileOperations.CreateFolder(fileOperations.GetAppDataPath("Users"));
            }


            if (fileOperations.FileExists(path))
            {
                MessageBox.Show("User already exists");
                return;

            }

            fileOperations.SaveFile(path, PasswordHash);


            AES.EncryptFile(PasswordHash, PasswordHash, fileOperations.GetAppDataPath("Users", UserNameTextBox.Text + ".txt"));



            MessageBox.Show("User Registered Successfully");
            _login.Show();
            _login.SetRegisteredDetails(UserNameTextBox.Text, PasswordTextBox.Text);
            this.Hide();

        }

        private void Register_FormClosing(object sender, FormClosingEventArgs e)
        {
            _login.Show();
        }
    }
}

