namespace АРМ_курсовая
{
    partial class LogIn
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LogIn));
            this.lbUserName = new System.Windows.Forms.Label();
            this.lbUserPassword = new System.Windows.Forms.Label();
            this.tbUserName = new System.Windows.Forms.TextBox();
            this.tbPassword = new System.Windows.Forms.TextBox();
            this.linkSignIn = new System.Windows.Forms.LinkLabel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btLog = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // lbUserName
            // 
            this.lbUserName.AutoSize = true;
            this.lbUserName.Font = new System.Drawing.Font("Yu Gothic UI Semilight", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lbUserName.ForeColor = System.Drawing.SystemColors.Control;
            this.lbUserName.Location = new System.Drawing.Point(46, 159);
            this.lbUserName.Name = "lbUserName";
            this.lbUserName.Size = new System.Drawing.Size(76, 30);
            this.lbUserName.TabIndex = 1;
            this.lbUserName.Text = "Логин:";
            // 
            // lbUserPassword
            // 
            this.lbUserPassword.AutoSize = true;
            this.lbUserPassword.Font = new System.Drawing.Font("Yu Gothic UI Semilight", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lbUserPassword.ForeColor = System.Drawing.SystemColors.Control;
            this.lbUserPassword.Location = new System.Drawing.Point(46, 231);
            this.lbUserPassword.Name = "lbUserPassword";
            this.lbUserPassword.Size = new System.Drawing.Size(80, 25);
            this.lbUserPassword.TabIndex = 2;
            this.lbUserPassword.Text = "Пароль:";
            this.lbUserPassword.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tbUserName
            // 
            this.tbUserName.Location = new System.Drawing.Point(51, 192);
            this.tbUserName.MaxLength = 20;
            this.tbUserName.Name = "tbUserName";
            this.tbUserName.Size = new System.Drawing.Size(219, 29);
            this.tbUserName.TabIndex = 3;
            this.tbUserName.WordWrap = false;
            // 
            // tbPassword
            // 
            this.tbPassword.Location = new System.Drawing.Point(51, 261);
            this.tbPassword.MaxLength = 20;
            this.tbPassword.Name = "tbPassword";
            this.tbPassword.PasswordChar = '*';
            this.tbPassword.Size = new System.Drawing.Size(219, 29);
            this.tbPassword.TabIndex = 4;
            // 
            // linkSignIn
            // 
            this.linkSignIn.ActiveLinkColor = System.Drawing.Color.AliceBlue;
            this.linkSignIn.AutoSize = true;
            this.linkSignIn.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(240)))));
            this.linkSignIn.Location = new System.Drawing.Point(107, 354);
            this.linkSignIn.Name = "linkSignIn";
            this.linkSignIn.Size = new System.Drawing.Size(98, 21);
            this.linkSignIn.TabIndex = 5;
            this.linkSignIn.TabStop = true;
            this.linkSignIn.Text = "Регистрация";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(99, 25);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(117, 109);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // btLog
            // 
            this.btLog.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(25)))));
            this.btLog.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btLog.FlatAppearance.BorderColor = System.Drawing.Color.SteelBlue;
            this.btLog.FlatAppearance.BorderSize = 2;
            this.btLog.FlatAppearance.MouseDownBackColor = System.Drawing.Color.SteelBlue;
            this.btLog.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DeepSkyBlue;
            this.btLog.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btLog.Font = new System.Drawing.Font("Yu Gothic UI Semilight", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btLog.ForeColor = System.Drawing.SystemColors.Control;
            this.btLog.Location = new System.Drawing.Point(69, 306);
            this.btLog.Name = "btLog";
            this.btLog.Size = new System.Drawing.Size(178, 44);
            this.btLog.TabIndex = 6;
            this.btLog.Text = "Войти";
            this.btLog.UseVisualStyleBackColor = false;
            this.btLog.Click += new System.EventHandler(this.btLog_Click);
            // 
            // LogIn
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.Disable;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(55)))));
            this.ClientSize = new System.Drawing.Size(324, 411);
            this.Controls.Add(this.btLog);
            this.Controls.Add(this.linkSignIn);
            this.Controls.Add(this.tbPassword);
            this.Controls.Add(this.tbUserName);
            this.Controls.Add(this.lbUserPassword);
            this.Controls.Add(this.lbUserName);
            this.Controls.Add(this.pictureBox1);
            this.Font = new System.Drawing.Font("Yu Gothic UI Semilight", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "LogIn";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Ресторан \"San Pizzerino\"";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label lbUserName;
        private System.Windows.Forms.Label lbUserPassword;
        private System.Windows.Forms.TextBox tbUserName;
        private System.Windows.Forms.TextBox tbPassword;
        private System.Windows.Forms.LinkLabel linkSignIn;
        private System.Windows.Forms.Button btLog;
    }
}