namespace GUI
{
    partial class ConfigForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label1 = new Label();
            txtServer = new TextBox();
            txtDatabase = new TextBox();
            label2 = new Label();
            txtUID = new TextBox();
            label3 = new Label();
            txtPassword = new TextBox();
            label4 = new Label();
            chkWindowsAuth = new CheckBox();
            btnSave = new Button();
            btnCancel = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(26, 36);
            label1.Name = "label1";
            label1.Size = new Size(50, 20);
            label1.TabIndex = 0;
            label1.Text = "Server";
            // 
            // txtServer
            // 
            txtServer.Location = new Point(108, 29);
            txtServer.Name = "txtServer";
            txtServer.Size = new Size(255, 27);
            txtServer.TabIndex = 1;
            // 
            // txtDatabase
            // 
            txtDatabase.Location = new Point(108, 66);
            txtDatabase.Name = "txtDatabase";
            txtDatabase.Size = new Size(255, 27);
            txtDatabase.TabIndex = 3;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(26, 73);
            label2.Name = "label2";
            label2.Size = new Size(72, 20);
            label2.TabIndex = 2;
            label2.Text = "Database";
            // 
            // txtUID
            // 
            txtUID.Location = new Point(108, 106);
            txtUID.Name = "txtUID";
            txtUID.Size = new Size(255, 27);
            txtUID.TabIndex = 5;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(26, 113);
            label3.Name = "label3";
            label3.Size = new Size(34, 20);
            label3.TabIndex = 4;
            label3.Text = "UID";
            // 
            // txtPassword
            // 
            txtPassword.Location = new Point(108, 150);
            txtPassword.Name = "txtPassword";
            txtPassword.Size = new Size(255, 27);
            txtPassword.TabIndex = 7;
            txtPassword.UseSystemPasswordChar = true;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(26, 157);
            label4.Name = "label4";
            label4.Size = new Size(70, 20);
            label4.TabIndex = 6;
            label4.Text = "Password";
            // 
            // chkWindowsAuth
            // 
            chkWindowsAuth.AutoSize = true;
            chkWindowsAuth.Location = new Point(26, 194);
            chkWindowsAuth.Name = "chkWindowsAuth";
            chkWindowsAuth.Size = new Size(187, 24);
            chkWindowsAuth.TabIndex = 8;
            chkWindowsAuth.Text = "Window Authentication";
            chkWindowsAuth.UseVisualStyleBackColor = true;
            chkWindowsAuth.CheckedChanged += chkWindowsAuth_CheckedChanged;
            // 
            // btnSave
            // 
            btnSave.Location = new Point(54, 239);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(137, 41);
            btnSave.TabIndex = 9;
            btnSave.Text = "Save";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // btnCancel
            // 
            btnCancel.Location = new Point(197, 239);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(137, 41);
            btnCancel.TabIndex = 10;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Click += btnCancel_Click;
            // 
            // ConfigForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(393, 306);
            Controls.Add(btnCancel);
            Controls.Add(btnSave);
            Controls.Add(chkWindowsAuth);
            Controls.Add(txtPassword);
            Controls.Add(label4);
            Controls.Add(txtUID);
            Controls.Add(label3);
            Controls.Add(txtDatabase);
            Controls.Add(label2);
            Controls.Add(txtServer);
            Controls.Add(label1);
            Name = "ConfigForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "ConfigForm";
            Load += ConfigForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox txtServer;
        private TextBox txtDatabase;
        private Label label2;
        private TextBox txtUID;
        private Label label3;
        private TextBox txtPassword;
        private Label label4;
        private CheckBox chkWindowsAuth;
        private Button btnSave;
        private Button btnCancel;
    }
}