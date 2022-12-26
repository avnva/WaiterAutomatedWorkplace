namespace АРМ_курсовая
{
    partial class SignInForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SignInForm));
            this.lblSignInWaiter = new System.Windows.Forms.Label();
            this.lbNewName = new System.Windows.Forms.Label();
            this.tbNewName = new System.Windows.Forms.TextBox();
            this.lbNewPassword = new System.Windows.Forms.Label();
            this.tbNewPassword = new System.Windows.Forms.TextBox();
            this.btSignIn = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.rbWaiter = new System.Windows.Forms.RadioButton();
            this.rbAdmin = new System.Windows.Forms.RadioButton();
            this.lblSignInWorker = new System.Windows.Forms.Label();
            this.btBack = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // lblSignInWaiter
            // 
            this.lblSignInWaiter.AutoSize = true;
            this.lblSignInWaiter.Font = new System.Drawing.Font("Yu Gothic UI Semilight", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblSignInWaiter.ForeColor = System.Drawing.Color.Azure;
            this.lblSignInWaiter.Location = new System.Drawing.Point(74, 189);
            this.lblSignInWaiter.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblSignInWaiter.Name = "lblSignInWaiter";
            this.lblSignInWaiter.Size = new System.Drawing.Size(362, 45);
            this.lblSignInWaiter.TabIndex = 0;
            this.lblSignInWaiter.Text = "Регистрация официанта";
            // 
            // lbNewName
            // 
            this.lbNewName.AutoSize = true;
            this.lbNewName.Font = new System.Drawing.Font("Yu Gothic UI Semilight", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lbNewName.ForeColor = System.Drawing.Color.Azure;
            this.lbNewName.Location = new System.Drawing.Point(82, 234);
            this.lbNewName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbNewName.Name = "lbNewName";
            this.lbNewName.Size = new System.Drawing.Size(231, 45);
            this.lbNewName.TabIndex = 5;
            this.lbNewName.Text = "Введите логин:";
            // 
            // tbNewName
            // 
            this.tbNewName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbNewName.Font = new System.Drawing.Font("Yu Gothic UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tbNewName.Location = new System.Drawing.Point(90, 285);
            this.tbNewName.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tbNewName.MaxLength = 29;
            this.tbNewName.Name = "tbNewName";
            this.tbNewName.Size = new System.Drawing.Size(329, 39);
            this.tbNewName.TabIndex = 1;
            this.tbNewName.WordWrap = false;
            // 
            // lbNewPassword
            // 
            this.lbNewPassword.AutoSize = true;
            this.lbNewPassword.Font = new System.Drawing.Font("Yu Gothic UI Semilight", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lbNewPassword.ForeColor = System.Drawing.Color.Azure;
            this.lbNewPassword.Location = new System.Drawing.Point(82, 328);
            this.lbNewPassword.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbNewPassword.Name = "lbNewPassword";
            this.lbNewPassword.Size = new System.Drawing.Size(250, 45);
            this.lbNewPassword.TabIndex = 7;
            this.lbNewPassword.Text = "Введите пароль:";
            // 
            // tbNewPassword
            // 
            this.tbNewPassword.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbNewPassword.Font = new System.Drawing.Font("Yu Gothic UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tbNewPassword.Location = new System.Drawing.Point(90, 377);
            this.tbNewPassword.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tbNewPassword.MaxLength = 29;
            this.tbNewPassword.Name = "tbNewPassword";
            this.tbNewPassword.Size = new System.Drawing.Size(329, 39);
            this.tbNewPassword.TabIndex = 2;
            this.tbNewPassword.WordWrap = false;
            // 
            // btSignIn
            // 
            this.btSignIn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(25)))));
            this.btSignIn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btSignIn.FlatAppearance.BorderColor = System.Drawing.Color.SteelBlue;
            this.btSignIn.FlatAppearance.BorderSize = 2;
            this.btSignIn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.SteelBlue;
            this.btSignIn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DeepSkyBlue;
            this.btSignIn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btSignIn.Font = new System.Drawing.Font("Yu Gothic UI Semilight", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btSignIn.ForeColor = System.Drawing.SystemColors.Control;
            this.btSignIn.Location = new System.Drawing.Point(108, 515);
            this.btSignIn.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btSignIn.Name = "btSignIn";
            this.btSignIn.Size = new System.Drawing.Size(292, 69);
            this.btSignIn.TabIndex = 5;
            this.btSignIn.Text = "Зарегистрировать";
            this.btSignIn.UseVisualStyleBackColor = false;
            this.btSignIn.Click += new System.EventHandler(this.btSignIn_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(165, 15);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(180, 169);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // rbWaiter
            // 
            this.rbWaiter.AutoSize = true;
            this.rbWaiter.Checked = true;
            this.rbWaiter.Font = new System.Drawing.Font("Yu Gothic UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.rbWaiter.ForeColor = System.Drawing.Color.Azure;
            this.rbWaiter.Location = new System.Drawing.Point(90, 426);
            this.rbWaiter.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.rbWaiter.Name = "rbWaiter";
            this.rbWaiter.Size = new System.Drawing.Size(151, 36);
            this.rbWaiter.TabIndex = 3;
            this.rbWaiter.TabStop = true;
            this.rbWaiter.Text = "Официант";
            this.rbWaiter.UseVisualStyleBackColor = true;
            this.rbWaiter.Visible = false;
            // 
            // rbAdmin
            // 
            this.rbAdmin.AutoSize = true;
            this.rbAdmin.Font = new System.Drawing.Font("Yu Gothic UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.rbAdmin.ForeColor = System.Drawing.Color.Azure;
            this.rbAdmin.Location = new System.Drawing.Point(90, 471);
            this.rbAdmin.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.rbAdmin.Name = "rbAdmin";
            this.rbAdmin.Size = new System.Drawing.Size(211, 36);
            this.rbAdmin.TabIndex = 4;
            this.rbAdmin.Text = "Администратор";
            this.rbAdmin.UseVisualStyleBackColor = true;
            this.rbAdmin.Visible = false;
            // 
            // lblSignInWorker
            // 
            this.lblSignInWorker.AutoSize = true;
            this.lblSignInWorker.Font = new System.Drawing.Font("Yu Gothic UI Semilight", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblSignInWorker.ForeColor = System.Drawing.Color.Azure;
            this.lblSignInWorker.Location = new System.Drawing.Point(74, 189);
            this.lblSignInWorker.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblSignInWorker.Name = "lblSignInWorker";
            this.lblSignInWorker.Size = new System.Drawing.Size(367, 45);
            this.lblSignInWorker.TabIndex = 8;
            this.lblSignInWorker.Text = "Регистрация сотрудника";
            this.lblSignInWorker.Visible = false;
            // 
            // btBack
            // 
            this.btBack.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(35)))));
            this.btBack.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btBack.Image = ((System.Drawing.Image)(resources.GetObject("btBack.Image")));
            this.btBack.Location = new System.Drawing.Point(0, -2);
            this.btBack.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btBack.Name = "btBack";
            this.btBack.Size = new System.Drawing.Size(56, 57);
            this.btBack.TabIndex = 9;
            this.btBack.UseVisualStyleBackColor = false;
            this.btBack.Click += new System.EventHandler(this.btBack_Click);
            // 
            // SignInForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(55)))));
            this.ClientSize = new System.Drawing.Size(486, 632);
            this.Controls.Add(this.btBack);
            this.Controls.Add(this.lblSignInWorker);
            this.Controls.Add(this.rbAdmin);
            this.Controls.Add(this.rbWaiter);
            this.Controls.Add(this.btSignIn);
            this.Controls.Add(this.lbNewPassword);
            this.Controls.Add(this.tbNewPassword);
            this.Controls.Add(this.lbNewName);
            this.Controls.Add(this.tbNewName);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.lblSignInWaiter);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.Name = "SignInForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Ресторан \"San Pizzerino\"";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblSignInWaiter;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label lbNewName;
        private System.Windows.Forms.TextBox tbNewName;
        private System.Windows.Forms.Label lbNewPassword;
        private System.Windows.Forms.TextBox tbNewPassword;
        private System.Windows.Forms.Button btSignIn;
        private System.Windows.Forms.RadioButton rbWaiter;
        private System.Windows.Forms.RadioButton rbAdmin;
        private System.Windows.Forms.Label lblSignInWorker;
        private System.Windows.Forms.Button btBack;
    }
}