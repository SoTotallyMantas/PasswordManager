namespace PasswordManager
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            SaveButton = new Button();
            NameTextBox = new TextBox();
            URLTextBox = new TextBox();
            PasswordTextBox = new TextBox();
            UpdateButton = new Button();
            DeleteButton = new Button();
            AddToGridButton = new Button();
            PasswordDataGrid = new DataGridView();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            DescriptionRichBox = new RichTextBox();
            TogglePassword = new Button();
            ClipBoardButton = new Button();
            GeneratePasswordButton = new Button();
            ((System.ComponentModel.ISupportInitialize)PasswordDataGrid).BeginInit();
            SuspendLayout();
            // 
            // SaveButton
            // 
            SaveButton.Location = new Point(93, 359);
            SaveButton.Name = "SaveButton";
            SaveButton.Size = new Size(75, 23);
            SaveButton.TabIndex = 0;
            SaveButton.Text = "Save";
            SaveButton.UseVisualStyleBackColor = true;
            SaveButton.Click += SaveButton_Click;
            // 
            // NameTextBox
            // 
            NameTextBox.Location = new Point(12, 27);
            NameTextBox.Name = "NameTextBox";
            NameTextBox.Size = new Size(100, 23);
            NameTextBox.TabIndex = 1;
            NameTextBox.TextChanged += NameTextBox_TextChanged;
            // 
            // URLTextBox
            // 
            URLTextBox.Location = new Point(12, 80);
            URLTextBox.Name = "URLTextBox";
            URLTextBox.Size = new Size(100, 23);
            URLTextBox.TabIndex = 2;
            // 
            // PasswordTextBox
            // 
            PasswordTextBox.Location = new Point(12, 135);
            PasswordTextBox.Name = "PasswordTextBox";
            PasswordTextBox.Size = new Size(100, 23);
            PasswordTextBox.TabIndex = 3;
            PasswordTextBox.UseSystemPasswordChar = true;
            // 
            // UpdateButton
            // 
            UpdateButton.Location = new Point(12, 359);
            UpdateButton.Name = "UpdateButton";
            UpdateButton.Size = new Size(75, 23);
            UpdateButton.TabIndex = 6;
            UpdateButton.Text = "Update";
            UpdateButton.UseVisualStyleBackColor = true;
            UpdateButton.Click += UpdateButton_Click;
            // 
            // DeleteButton
            // 
            DeleteButton.Location = new Point(93, 330);
            DeleteButton.Name = "DeleteButton";
            DeleteButton.Size = new Size(75, 23);
            DeleteButton.TabIndex = 7;
            DeleteButton.Text = "Delete";
            DeleteButton.UseVisualStyleBackColor = true;
            DeleteButton.Click += DeleteButton_Click;
            // 
            // AddToGridButton
            // 
            AddToGridButton.Location = new Point(12, 330);
            AddToGridButton.Name = "AddToGridButton";
            AddToGridButton.Size = new Size(75, 23);
            AddToGridButton.TabIndex = 8;
            AddToGridButton.Text = "Add";
            AddToGridButton.UseVisualStyleBackColor = true;
            AddToGridButton.Click += AddToGridButton_Click;
            // 
            // PasswordDataGrid
            // 
            PasswordDataGrid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            PasswordDataGrid.Location = new Point(213, 42);
            PasswordDataGrid.Name = "PasswordDataGrid";
            PasswordDataGrid.ReadOnly = true;
            PasswordDataGrid.Size = new Size(575, 396);
            PasswordDataGrid.TabIndex = 10;
            PasswordDataGrid.CellClick += PasswordDataGrid_CellClick;
            PasswordDataGrid.SelectionChanged += PasswordDataGrid_SelectionChanged;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 9);
            label2.Name = "label2";
            label2.Size = new Size(39, 15);
            label2.TabIndex = 13;
            label2.Text = "Name";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(12, 62);
            label3.Name = "label3";
            label3.Size = new Size(94, 15);
            label3.TabIndex = 14;
            label3.Text = "URL/Application";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(12, 117);
            label4.Name = "label4";
            label4.Size = new Size(57, 15);
            label4.TabIndex = 15;
            label4.Text = "Password";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(12, 210);
            label5.Name = "label5";
            label5.Size = new Size(67, 15);
            label5.TabIndex = 16;
            label5.Text = "Description";
            // 
            // DescriptionRichBox
            // 
            DescriptionRichBox.Location = new Point(12, 228);
            DescriptionRichBox.Name = "DescriptionRichBox";
            DescriptionRichBox.Size = new Size(195, 96);
            DescriptionRichBox.TabIndex = 17;
            DescriptionRichBox.Text = "";
            // 
            // TogglePassword
            // 
            TogglePassword.Location = new Point(12, 164);
            TogglePassword.Name = "TogglePassword";
            TogglePassword.Size = new Size(89, 23);
            TogglePassword.TabIndex = 18;
            TogglePassword.Text = "Toggle View";
            TogglePassword.UseVisualStyleBackColor = true;
            TogglePassword.Click += TogglePassword_Click;
            // 
            // ClipBoardButton
            // 
            ClipBoardButton.Location = new Point(107, 164);
            ClipBoardButton.Name = "ClipBoardButton";
            ClipBoardButton.Size = new Size(100, 23);
            ClipBoardButton.TabIndex = 19;
            ClipBoardButton.Text = "Copy Clipboard";
            ClipBoardButton.UseVisualStyleBackColor = true;
            ClipBoardButton.Click += ClipBoardButton_Click;
            // 
            // GeneratePasswordButton
            // 
            GeneratePasswordButton.Location = new Point(118, 135);
            GeneratePasswordButton.Name = "GeneratePasswordButton";
            GeneratePasswordButton.Size = new Size(75, 23);
            GeneratePasswordButton.TabIndex = 20;
            GeneratePasswordButton.Text = "Generate";
            GeneratePasswordButton.UseVisualStyleBackColor = true;
            GeneratePasswordButton.Click += GeneratePasswordButton_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(GeneratePasswordButton);
            Controls.Add(ClipBoardButton);
            Controls.Add(TogglePassword);
            Controls.Add(DescriptionRichBox);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(PasswordDataGrid);
            Controls.Add(AddToGridButton);
            Controls.Add(DeleteButton);
            Controls.Add(UpdateButton);
            Controls.Add(PasswordTextBox);
            Controls.Add(URLTextBox);
            Controls.Add(NameTextBox);
            Controls.Add(SaveButton);
            Name = "Form1";
            Text = "Form1";
            FormClosing += Form1_FormClosing;
            ((System.ComponentModel.ISupportInitialize)PasswordDataGrid).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button SaveButton;
        private TextBox NameTextBox;
        private TextBox URLTextBox;
        private TextBox PasswordTextBox;
        private Button UpdateButton;
        private Button DeleteButton;
        private Button AddToGridButton;
        private DataGridView PasswordDataGrid;
        private TextBox textBox6;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private RichTextBox DescriptionRichBox;
        private Button TogglePassword;
        private Button ClipBoardButton;
        private Button GeneratePasswordButton;
    }
}
