namespace АРМ_курсовая
{
    partial class MainFormAdmin
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainFormAdmin));
            this.label2 = new System.Windows.Forms.Label();
            this.btExit = new System.Windows.Forms.Button();
            this.pnlMain = new System.Windows.Forms.Panel();
            this.pnlEditWorkers = new System.Windows.Forms.GroupBox();
            this.btDeleteCurrentAccount = new System.Windows.Forms.Button();
            this.btDeleteWorker = new System.Windows.Forms.Button();
            this.btAddWorker = new System.Windows.Forms.Button();
            this.pnlEditMenu = new System.Windows.Forms.GroupBox();
            this.btEditDishInMenu = new System.Windows.Forms.Button();
            this.btRemoveDishFromMenu = new System.Windows.Forms.Button();
            this.btAddDishToMenu = new System.Windows.Forms.Button();
            this.pnlAddDish = new System.Windows.Forms.Panel();
            this.numCost = new System.Windows.Forms.NumericUpDown();
            this.btBack = new System.Windows.Forms.Button();
            this.btAddNewDish = new System.Windows.Forms.Button();
            this.cbCategory = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.tbNewNameDish = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.pnlMain.SuspendLayout();
            this.pnlEditWorkers.SuspendLayout();
            this.pnlEditMenu.SuspendLayout();
            this.pnlAddDish.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numCost)).BeginInit();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Yu Gothic UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(5, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(150, 19);
            this.label2.TabIndex = 1;
            this.label2.Text = "Управление системой.";
            // 
            // btExit
            // 
            this.btExit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(25)))));
            this.btExit.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btExit.Font = new System.Drawing.Font("Yu Gothic UI Semibold", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btExit.Location = new System.Drawing.Point(125, 420);
            this.btExit.Name = "btExit";
            this.btExit.Size = new System.Drawing.Size(230, 54);
            this.btExit.TabIndex = 5;
            this.btExit.Text = "Выйти";
            this.btExit.UseVisualStyleBackColor = false;
            this.btExit.Click += new System.EventHandler(this.btExit_Click);
            // 
            // pnlMain
            // 
            this.pnlMain.Controls.Add(this.pnlEditWorkers);
            this.pnlMain.Controls.Add(this.btExit);
            this.pnlMain.Controls.Add(this.pnlEditMenu);
            this.pnlMain.Location = new System.Drawing.Point(0, 31);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Size = new System.Drawing.Size(480, 486);
            this.pnlMain.TabIndex = 6;
            // 
            // pnlEditWorkers
            // 
            this.pnlEditWorkers.Controls.Add(this.btDeleteCurrentAccount);
            this.pnlEditWorkers.Controls.Add(this.btDeleteWorker);
            this.pnlEditWorkers.Controls.Add(this.btAddWorker);
            this.pnlEditWorkers.Font = new System.Drawing.Font("Yu Gothic UI Semilight", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.pnlEditWorkers.ForeColor = System.Drawing.Color.Azure;
            this.pnlEditWorkers.Location = new System.Drawing.Point(10, 224);
            this.pnlEditWorkers.Name = "pnlEditWorkers";
            this.pnlEditWorkers.Size = new System.Drawing.Size(460, 190);
            this.pnlEditWorkers.TabIndex = 5;
            this.pnlEditWorkers.TabStop = false;
            this.pnlEditWorkers.Text = "Редактировать сотрудников:";
            // 
            // btDeleteCurrentAccount
            // 
            this.btDeleteCurrentAccount.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(25)))));
            this.btDeleteCurrentAccount.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btDeleteCurrentAccount.Font = new System.Drawing.Font("Yu Gothic UI Semibold", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btDeleteCurrentAccount.Location = new System.Drawing.Point(5, 135);
            this.btDeleteCurrentAccount.Name = "btDeleteCurrentAccount";
            this.btDeleteCurrentAccount.Size = new System.Drawing.Size(450, 50);
            this.btDeleteCurrentAccount.TabIndex = 4;
            this.btDeleteCurrentAccount.Text = "Удалить текущий аккаунт";
            this.btDeleteCurrentAccount.UseVisualStyleBackColor = false;
            this.btDeleteCurrentAccount.Click += new System.EventHandler(this.btDeleteCurrentAccount_Click);
            // 
            // btDeleteWorker
            // 
            this.btDeleteWorker.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(25)))));
            this.btDeleteWorker.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btDeleteWorker.Font = new System.Drawing.Font("Yu Gothic UI Semibold", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btDeleteWorker.Location = new System.Drawing.Point(5, 83);
            this.btDeleteWorker.Name = "btDeleteWorker";
            this.btDeleteWorker.Size = new System.Drawing.Size(450, 50);
            this.btDeleteWorker.TabIndex = 3;
            this.btDeleteWorker.Text = "Удалить сотрудника";
            this.btDeleteWorker.UseVisualStyleBackColor = false;
            // 
            // btAddWorker
            // 
            this.btAddWorker.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(25)))));
            this.btAddWorker.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btAddWorker.Font = new System.Drawing.Font("Yu Gothic UI Semibold", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btAddWorker.Location = new System.Drawing.Point(5, 31);
            this.btAddWorker.Name = "btAddWorker";
            this.btAddWorker.Size = new System.Drawing.Size(450, 50);
            this.btAddWorker.TabIndex = 2;
            this.btAddWorker.Text = "Добавить сотрудника";
            this.btAddWorker.UseVisualStyleBackColor = false;
            this.btAddWorker.Click += new System.EventHandler(this.btAddWorker_Click);
            // 
            // pnlEditMenu
            // 
            this.pnlEditMenu.Controls.Add(this.btEditDishInMenu);
            this.pnlEditMenu.Controls.Add(this.btRemoveDishFromMenu);
            this.pnlEditMenu.Controls.Add(this.btAddDishToMenu);
            this.pnlEditMenu.Font = new System.Drawing.Font("Yu Gothic UI Semilight", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.pnlEditMenu.ForeColor = System.Drawing.Color.Azure;
            this.pnlEditMenu.Location = new System.Drawing.Point(10, 33);
            this.pnlEditMenu.Name = "pnlEditMenu";
            this.pnlEditMenu.Size = new System.Drawing.Size(460, 190);
            this.pnlEditMenu.TabIndex = 4;
            this.pnlEditMenu.TabStop = false;
            this.pnlEditMenu.Text = "Редактировать меню ресторана:";
            // 
            // btEditDishInMenu
            // 
            this.btEditDishInMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(25)))));
            this.btEditDishInMenu.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btEditDishInMenu.Font = new System.Drawing.Font("Yu Gothic UI Semibold", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btEditDishInMenu.Location = new System.Drawing.Point(5, 135);
            this.btEditDishInMenu.Name = "btEditDishInMenu";
            this.btEditDishInMenu.Size = new System.Drawing.Size(450, 50);
            this.btEditDishInMenu.TabIndex = 4;
            this.btEditDishInMenu.Text = "Отредактировать блюдо";
            this.btEditDishInMenu.UseVisualStyleBackColor = false;
            // 
            // btRemoveDishFromMenu
            // 
            this.btRemoveDishFromMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(25)))));
            this.btRemoveDishFromMenu.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btRemoveDishFromMenu.Font = new System.Drawing.Font("Yu Gothic UI Semibold", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btRemoveDishFromMenu.Location = new System.Drawing.Point(5, 83);
            this.btRemoveDishFromMenu.Name = "btRemoveDishFromMenu";
            this.btRemoveDishFromMenu.Size = new System.Drawing.Size(450, 50);
            this.btRemoveDishFromMenu.TabIndex = 3;
            this.btRemoveDishFromMenu.Text = "Удалить блюдо";
            this.btRemoveDishFromMenu.UseVisualStyleBackColor = false;
            // 
            // btAddDishToMenu
            // 
            this.btAddDishToMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(25)))));
            this.btAddDishToMenu.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btAddDishToMenu.Font = new System.Drawing.Font("Yu Gothic UI Semibold", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btAddDishToMenu.Location = new System.Drawing.Point(5, 31);
            this.btAddDishToMenu.Name = "btAddDishToMenu";
            this.btAddDishToMenu.Size = new System.Drawing.Size(450, 50);
            this.btAddDishToMenu.TabIndex = 2;
            this.btAddDishToMenu.Text = "Добавить блюдо";
            this.btAddDishToMenu.UseVisualStyleBackColor = false;
            this.btAddDishToMenu.Click += new System.EventHandler(this.btAddDishToMenu_Click);
            // 
            // pnlAddDish
            // 
            this.pnlAddDish.Controls.Add(this.numCost);
            this.pnlAddDish.Controls.Add(this.btBack);
            this.pnlAddDish.Controls.Add(this.btAddNewDish);
            this.pnlAddDish.Controls.Add(this.cbCategory);
            this.pnlAddDish.Controls.Add(this.label1);
            this.pnlAddDish.Controls.Add(this.label6);
            this.pnlAddDish.Controls.Add(this.label5);
            this.pnlAddDish.Controls.Add(this.tbNewNameDish);
            this.pnlAddDish.Controls.Add(this.label4);
            this.pnlAddDish.Controls.Add(this.label3);
            this.pnlAddDish.Location = new System.Drawing.Point(4, 27);
            this.pnlAddDish.Name = "pnlAddDish";
            this.pnlAddDish.Size = new System.Drawing.Size(474, 478);
            this.pnlAddDish.TabIndex = 7;
            this.pnlAddDish.Visible = false;
            // 
            // numCost
            // 
            this.numCost.Font = new System.Drawing.Font("Yu Gothic UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.numCost.Location = new System.Drawing.Point(226, 105);
            this.numCost.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.numCost.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numCost.Name = "numCost";
            this.numCost.Size = new System.Drawing.Size(212, 29);
            this.numCost.TabIndex = 9;
            this.numCost.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // btBack
            // 
            this.btBack.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(25)))));
            this.btBack.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btBack.Image = ((System.Drawing.Image)(resources.GetObject("btBack.Image")));
            this.btBack.Location = new System.Drawing.Point(3, 4);
            this.btBack.Name = "btBack";
            this.btBack.Size = new System.Drawing.Size(42, 28);
            this.btBack.TabIndex = 8;
            this.btBack.UseVisualStyleBackColor = false;
            this.btBack.Click += new System.EventHandler(this.btBack_Click);
            // 
            // btAddNewDish
            // 
            this.btAddNewDish.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(25)))));
            this.btAddNewDish.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btAddNewDish.Font = new System.Drawing.Font("Yu Gothic UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btAddNewDish.Location = new System.Drawing.Point(127, 223);
            this.btAddNewDish.Name = "btAddNewDish";
            this.btAddNewDish.Size = new System.Drawing.Size(211, 50);
            this.btAddNewDish.TabIndex = 7;
            this.btAddNewDish.Text = "Добавить блюдо";
            this.btAddNewDish.UseVisualStyleBackColor = false;
            this.btAddNewDish.Click += new System.EventHandler(this.btAddNewDish_Click);
            // 
            // cbCategory
            // 
            this.cbCategory.Font = new System.Drawing.Font("Yu Gothic UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.cbCategory.FormattingEnabled = true;
            this.cbCategory.Items.AddRange(new object[] {
            "Пицца",
            "Паста",
            "Салат",
            "Горячее",
            "Десерт",
            "Напиток"});
            this.cbCategory.Location = new System.Drawing.Point(227, 167);
            this.cbCategory.Name = "cbCategory";
            this.cbCategory.Size = new System.Drawing.Size(211, 29);
            this.cbCategory.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Yu Gothic UI", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(132, 4);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(218, 30);
            this.label1.TabIndex = 1;
            this.label1.Text = "Выберите действие:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Yu Gothic UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label6.Location = new System.Drawing.Point(8, 168);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(198, 25);
            this.label6.TabIndex = 5;
            this.label6.Text = "Выберите категорию:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Yu Gothic UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label5.Location = new System.Drawing.Point(8, 105);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(212, 25);
            this.label5.TabIndex = 3;
            this.label5.Text = "Введите цену в рублях:";
            // 
            // tbNewNameDish
            // 
            this.tbNewNameDish.Font = new System.Drawing.Font("Yu Gothic UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tbNewNameDish.Location = new System.Drawing.Point(227, 46);
            this.tbNewNameDish.Name = "tbNewNameDish";
            this.tbNewNameDish.Size = new System.Drawing.Size(211, 29);
            this.tbNewNameDish.TabIndex = 2;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Yu Gothic UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.Location = new System.Drawing.Point(8, 48);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(172, 25);
            this.label4.TabIndex = 1;
            this.label4.Text = "Введите название:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Yu Gothic UI Semibold", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(139, 2);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(211, 30);
            this.label3.TabIndex = 0;
            this.label3.Text = "Добавление блюда:";
            // 
            // MainFormAdmin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(45)))));
            this.ClientSize = new System.Drawing.Size(482, 529);
            this.Controls.Add(this.pnlAddDish);
            this.Controls.Add(this.pnlMain);
            this.Controls.Add(this.label2);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ForeColor = System.Drawing.Color.Azure;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "MainFormAdmin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Ресторан \"San Pizzerino\"";
            this.pnlMain.ResumeLayout(false);
            this.pnlEditWorkers.ResumeLayout(false);
            this.pnlEditMenu.ResumeLayout(false);
            this.pnlAddDish.ResumeLayout(false);
            this.pnlAddDish.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numCost)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btExit;
        private System.Windows.Forms.Panel pnlMain;
        private System.Windows.Forms.GroupBox pnlEditWorkers;
        private System.Windows.Forms.Button btDeleteCurrentAccount;
        private System.Windows.Forms.Button btDeleteWorker;
        private System.Windows.Forms.Button btAddWorker;
        private System.Windows.Forms.GroupBox pnlEditMenu;
        private System.Windows.Forms.Button btEditDishInMenu;
        private System.Windows.Forms.Button btRemoveDishFromMenu;
        private System.Windows.Forms.Button btAddDishToMenu;
        private System.Windows.Forms.Panel pnlAddDish;
        private System.Windows.Forms.NumericUpDown numCost;
        private System.Windows.Forms.Button btBack;
        private System.Windows.Forms.Button btAddNewDish;
        private System.Windows.Forms.ComboBox cbCategory;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox tbNewNameDish;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
    }
}