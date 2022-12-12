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
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lbNewName = new System.Windows.Forms.Label();
            this.tbNewName = new System.Windows.Forms.TextBox();
            this.lbNewPassword = new System.Windows.Forms.Label();
            this.tbNewPassword = new System.Windows.Forms.TextBox();
            this.btSignIn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Yu Gothic UI Semilight", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label1.Location = new System.Drawing.Point(156, 192);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(197, 45);
            this.label1.TabIndex = 0;
            this.label1.Text = "Регистрация";
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
            // lbNewName
            // 
            this.lbNewName.AutoSize = true;
            this.lbNewName.Font = new System.Drawing.Font("Yu Gothic UI Semilight", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lbNewName.ForeColor = System.Drawing.SystemColors.Control;
            this.lbNewName.Location = new System.Drawing.Point(82, 242);
            this.lbNewName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbNewName.Name = "lbNewName";
            this.lbNewName.Size = new System.Drawing.Size(204, 45);
            this.lbNewName.TabIndex = 5;
            this.lbNewName.Text = "Введите имя:";
            // 
            // tbNewName
            // 
            this.tbNewName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbNewName.Font = new System.Drawing.Font("Yu Gothic UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tbNewName.Location = new System.Drawing.Point(90, 292);
            this.tbNewName.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tbNewName.MaxLength = 29;
            this.tbNewName.Name = "tbNewName";
            this.tbNewName.Size = new System.Drawing.Size(329, 39);
            this.tbNewName.TabIndex = 4;
            this.tbNewName.WordWrap = false;

            // 
            // lbNewPassword
            // 
            this.lbNewPassword.AutoSize = true;
            this.lbNewPassword.Font = new System.Drawing.Font("Yu Gothic UI Semilight", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lbNewPassword.ForeColor = System.Drawing.SystemColors.Control;
            this.lbNewPassword.Location = new System.Drawing.Point(82, 345);
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
            this.tbNewPassword.Location = new System.Drawing.Point(90, 395);
            this.tbNewPassword.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tbNewPassword.MaxLength = 29;
            this.tbNewPassword.Name = "tbNewPassword";
            this.tbNewPassword.Size = new System.Drawing.Size(329, 39);
            this.tbNewPassword.TabIndex = 6;
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
            this.btSignIn.Location = new System.Drawing.Point(108, 468);
            this.btSignIn.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btSignIn.Name = "btSignIn";
            this.btSignIn.Size = new System.Drawing.Size(292, 69);
            this.btSignIn.TabIndex = 8;
            this.btSignIn.Text = "Зарегистрироваться";
            this.btSignIn.UseVisualStyleBackColor = false;
            this.btSignIn.Click += new System.EventHandler(this.btSignIn_Click);
            // 
            // SignInForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(55)))));
            this.ClientSize = new System.Drawing.Size(486, 632);
            this.Controls.Add(this.btSignIn);
            this.Controls.Add(this.lbNewPassword);
            this.Controls.Add(this.tbNewPassword);
            this.Controls.Add(this.lbNewName);
            this.Controls.Add(this.tbNewName);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "SignInForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Ресторан \"San Pizzerino\"";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label lbNewName;
        private System.Windows.Forms.TextBox tbNewName;
        private System.Windows.Forms.Label lbNewPassword;
        private System.Windows.Forms.TextBox tbNewPassword;
        private System.Windows.Forms.Button btSignIn;
    }
}