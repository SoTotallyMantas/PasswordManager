using PasswordManager.Util;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PasswordManager
{
    public partial class Login : Form
    {
        public string UserName { get; set; }
        public string PasswordHashB { get; set; }

        public Login()
        {
            InitializeComponent();

        }
        public void SetRegisteredDetails(string username, string password)
        {
            UserNameTextBox.Text = username;
            PasswordTextBox.Text = password;
        }
        private void RegisterButton_Click(object sender, EventArgs e)
        {
            Register register = new Register(this);
            register.Show();
            this.Hide();

        }

        private void LoginButton_Click(object sender, EventArgs e)
        {
            HashAlgorithmName hashAlgorithm = HashAlgorithmName.SHA256;
            byte[] PasswordPbkdf2 = Rfc2898DeriveBytes.Pbkdf2(PasswordTextBox.Text, Encoding.ASCII.GetBytes(UserNameTextBox.Text), 1000, hashAlgorithm, 32);
            FileOperations fileOperations = new FileOperations();
            string PasswordHash = Convert.ToBase64String(PasswordPbkdf2);
            try
            {
                string DecryptedPasswordHash = AES.DecryptFile(fileOperations.GetAppDataPath("Users", UserNameTextBox.Text + ".txt"), PasswordHash);


                if (PasswordHash == DecryptedPasswordHash)
                {
                    MessageBox.Show("Login Successful");
                    UserName = UserNameTextBox.Text;
                    PasswordHashB = PasswordHash;
                    this.Hide();
                    Form1 form1 = new Form1(this);
                    form1.Show();
                }
                else
                {
                    MessageBox.Show("Login Failed");
                }
            } catch (Exception ex)
            {
                   MessageBox.Show("Login Failed");
            }
         }
    }
}
