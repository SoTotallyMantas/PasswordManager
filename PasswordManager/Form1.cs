using PasswordManager.Model;
using PasswordManager.Util;

namespace PasswordManager
{
    public partial class Form1 : Form
    {
        public Login _login;

        public Form1(Login login)
        {
            _login = login;
            InitializeComponent();

            PasswordDataGrid.Columns.Add("Password", "Password");
            PasswordDataGrid.Columns["Password"].Visible = false;
            PasswordDataGrid.Columns.Add("Url", "Url");
            PasswordDataGrid.Columns.Add("Name", "Name");
            PasswordDataGrid.Columns.Add("Description", "Description");
            try
            {
                LoadPasswordCollection();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void SavePasswordCollection()
        {
            FileOperations fileOperations = new FileOperations();
            string path = fileOperations.GetAppDataPath("User Passwords", _login.UserName + ".txt");


            if (fileOperations.FileExists(path) == false)
            {
                fileOperations.CreateFolder(path);
            }

            if (PasswordDataGrid.Rows.Count == 0)
            {
                return;
            }
            try
            {
                List<Userpassword> passwords = new List<Userpassword>();
                foreach (DataGridViewRow row in PasswordDataGrid.Rows)
                {
                    Userpassword userpassword = new Userpassword();
                    if (row.Cells[0].Value != null)
                    {


                        userpassword.Password = row.Cells[0].Value.ToString();
                        userpassword.Url = row.Cells[1].Value.ToString();
                        userpassword.Name = row.Cells[2].Value.ToString();
                        userpassword.Description = row.Cells[3].Value.ToString();
                        passwords.Add(userpassword);
                    }
                }



                string PasswordFile = JSONConvert.SerializeObject(passwords);
                AES.EncryptFile(PasswordFile, _login.PasswordHashB, path);
                PasswordDataGrid.Rows.Clear();
                LoadPasswordCollection();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
        private void LoadPasswordCollection()
        {
            FileOperations fileOperations = new FileOperations();
            string path = fileOperations.GetAppDataPath("User Passwords", _login.UserName + ".txt");
            string PasswordFolderPath = fileOperations.GetAppDataPath("User Passwords");
            if (fileOperations.FileExists(PasswordFolderPath) == false)
            {
                fileOperations.CreateFolder(fileOperations.GetAppDataPath("User Passwords"));
            }
            if (fileOperations.FileExists(path) == false)
            {
                fileOperations.createFile(path);
            }
            if (fileOperations.FileIsEmpty(path) == false)
            {
                string PasswordFile = AES.DecryptFile(path, _login.PasswordHashB);

                List<Userpassword> passwords = JSONConvert.DeserializeObject<List<Userpassword>>(PasswordFile);

                foreach (Userpassword userpassword in passwords)
                {
                    PasswordDataGrid.Rows.Add(userpassword.Password, userpassword.Url, userpassword.Name, userpassword.Description);
                }
            }


        }

        private void TogglePassword_Click(object sender, EventArgs e)
        {
            if (PasswordTextBox.UseSystemPasswordChar == true)
            {

                PasswordTextBox.UseSystemPasswordChar = false;
            }
            else
            {
                PasswordTextBox.UseSystemPasswordChar = true;
            }
        }

        private void ClipBoardButton_Click(object sender, EventArgs e)
        {
            CopyToClipBoard.CopyToClipboard(PasswordTextBox.Text);
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            SavePasswordCollection();

        }

        private void DeleteButton_Click(object sender, EventArgs e)
        {
            // Delete Row that contains NameTextBox.Text
            foreach (DataGridViewRow row in PasswordDataGrid.Rows)
            {
                if (row.Cells[2].Value.ToString() == NameTextBox.Text)
                {
                    PasswordDataGrid.Rows.Remove(row);
                    break;
                }
            }
            SavePasswordCollection();

        }

        private void UpdateButton_Click(object sender, EventArgs e)
        {
            // Update Row that contains NameTextBox.Text
            foreach (DataGridViewRow row in PasswordDataGrid.Rows)
            {
                if (row.Cells[2].Value.ToString() == NameTextBox.Text)
                {
                    row.Cells[0].Value = PasswordTextBox.Text;
                    row.Cells[1].Value = URLTextBox.Text;
                    row.Cells[3].Value = DescriptionRichBox.Text;
                    break;
                }
            }
            SavePasswordCollection();

        }

        private void NameTextBox_TextChanged(object sender, EventArgs e)
        {
            // Filter PasswordDataGrid Displayed Rows based on NameTextBox.Text

            foreach (DataGridViewRow row in PasswordDataGrid.Rows)
            {
                if (!row.IsNewRow && row.Cells[2].Value != null)
                {
                    if (row.Cells[2].Value.ToString().Contains(NameTextBox.Text))
                    {
                        row.Visible = true;
                    }
                    else
                    {
                        row.Visible = false;
                    }

                }




            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            _login.Show();
        }

        private void AddToGridButton_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in PasswordDataGrid.Rows)
            {
                try
                {
                    if (!row.IsNewRow && row.Cells[2].Value != null && row.Cells[2].Value.ToString() == NameTextBox.Text)
                    {
                        MessageBox.Show("Name already exists");
                        return;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            PasswordDataGrid.Rows.Add(PasswordTextBox.Text, URLTextBox.Text, NameTextBox.Text, DescriptionRichBox.Text);



        }

        private void PasswordDataGrid_SelectionChanged(object sender, EventArgs e)
        {
            if (PasswordDataGrid.SelectedRows.Count > 0)
            {
                if (PasswordDataGrid.SelectedRows[0].Cells[0].Value != null)
                {
                    DataGridViewRow row = PasswordDataGrid.SelectedRows[0];
                    PasswordTextBox.Text = row.Cells[0].Value.ToString();
                    URLTextBox.Text = row.Cells[1].Value.ToString();
                    NameTextBox.Text = row.Cells[2].Value.ToString();
                    DescriptionRichBox.Text = row.Cells[3].Value.ToString();
                    PasswordTextBox.UseSystemPasswordChar = true;
                }
            }



        }

        private void GeneratePasswordButton_Click(object sender, EventArgs e)
        {

            PasswordTextBox.Text = PasswordGenerator.GeneratePassword(8);
        }

        private void PasswordDataGrid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (PasswordDataGrid.Rows.Count > 0)
            {
                
                if (PasswordDataGrid.Rows[e.RowIndex].Cells[0].Value != null)
                {
                    PasswordTextBox.Text = PasswordDataGrid.Rows[e.RowIndex].Cells[0].Value.ToString();
                    URLTextBox.Text = PasswordDataGrid.Rows[e.RowIndex].Cells[1].Value.ToString();
                    NameTextBox.Text = PasswordDataGrid.Rows[e.RowIndex].Cells[2].Value.ToString();
                    DescriptionRichBox.Text = PasswordDataGrid.Rows[e.RowIndex].Cells[3].Value.ToString();
                    PasswordTextBox.UseSystemPasswordChar = true;
                }

            }

        }
    }
}

