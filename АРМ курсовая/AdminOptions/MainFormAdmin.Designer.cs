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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
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
            this.label1 = new System.Windows.Forms.Label();
            this.pnlAddDish = new System.Windows.Forms.Panel();
            this.lblNumberDish = new System.Windows.Forms.Label();
            this.btMakeChanges = new System.Windows.Forms.Button();
            this.lblEdit = new System.Windows.Forms.Label();
            this.numCost = new System.Windows.Forms.NumericUpDown();
            this.btAddNewDish = new System.Windows.Forms.Button();
            this.cbCategory = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.tbNewNameDish = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.lblAdd = new System.Windows.Forms.Label();
            this.pnlEditDish = new System.Windows.Forms.Panel();
            this.btDeleteDish = new System.Windows.Forms.Button();
            this.btEdit = new System.Windows.Forms.Button();
            this.numEditDish = new System.Windows.Forms.NumericUpDown();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.dataGVDishes = new System.Windows.Forms.DataGridView();
            this.btBack = new System.Windows.Forms.Button();
            this.pnlDeleteWorker = new System.Windows.Forms.Panel();
            this.tbLogin = new System.Windows.Forms.TextBox();
            this.btDelete = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.categoryDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.costDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dishForBindingBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dishBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.pnlMain.SuspendLayout();
            this.pnlEditWorkers.SuspendLayout();
            this.pnlEditMenu.SuspendLayout();
            this.pnlAddDish.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numCost)).BeginInit();
            this.pnlEditDish.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numEditDish)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGVDishes)).BeginInit();
            this.pnlDeleteWorker.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dishForBindingBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dishBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Yu Gothic UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(324, 5);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(218, 28);
            this.label2.TabIndex = 1;
            this.label2.Text = "Управление системой.";
            // 
            // btExit
            // 
            this.btExit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(25)))));
            this.btExit.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btExit.Font = new System.Drawing.Font("Yu Gothic UI Semibold", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btExit.Location = new System.Drawing.Point(113, 420);
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
            this.pnlMain.Controls.Add(this.label1);
            this.pnlMain.Location = new System.Drawing.Point(12, 32);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Size = new System.Drawing.Size(457, 487);
            this.pnlMain.TabIndex = 6;
            // 
            // pnlEditWorkers
            // 
            this.pnlEditWorkers.Controls.Add(this.btDeleteCurrentAccount);
            this.pnlEditWorkers.Controls.Add(this.btDeleteWorker);
            this.pnlEditWorkers.Controls.Add(this.btAddWorker);
            this.pnlEditWorkers.Font = new System.Drawing.Font("Yu Gothic UI Semilight", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.pnlEditWorkers.ForeColor = System.Drawing.Color.Azure;
            this.pnlEditWorkers.Location = new System.Drawing.Point(5, 224);
            this.pnlEditWorkers.Name = "pnlEditWorkers";
            this.pnlEditWorkers.Size = new System.Drawing.Size(446, 190);
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
            this.btDeleteCurrentAccount.Size = new System.Drawing.Size(436, 50);
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
            this.btDeleteWorker.Size = new System.Drawing.Size(436, 50);
            this.btDeleteWorker.TabIndex = 3;
            this.btDeleteWorker.Text = "Удалить сотрудника";
            this.btDeleteWorker.UseVisualStyleBackColor = false;
            this.btDeleteWorker.Click += new System.EventHandler(this.btDeleteWorker_Click);
            // 
            // btAddWorker
            // 
            this.btAddWorker.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(25)))));
            this.btAddWorker.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btAddWorker.Font = new System.Drawing.Font("Yu Gothic UI Semibold", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btAddWorker.Location = new System.Drawing.Point(5, 31);
            this.btAddWorker.Name = "btAddWorker";
            this.btAddWorker.Size = new System.Drawing.Size(436, 50);
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
            this.pnlEditMenu.Location = new System.Drawing.Point(5, 33);
            this.pnlEditMenu.Name = "pnlEditMenu";
            this.pnlEditMenu.Size = new System.Drawing.Size(446, 190);
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
            this.btEditDishInMenu.Size = new System.Drawing.Size(436, 50);
            this.btEditDishInMenu.TabIndex = 4;
            this.btEditDishInMenu.Text = "Отредактировать блюдо";
            this.btEditDishInMenu.UseVisualStyleBackColor = false;
            this.btEditDishInMenu.Click += new System.EventHandler(this.btEditDishInMenu_Click);
            // 
            // btRemoveDishFromMenu
            // 
            this.btRemoveDishFromMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(25)))));
            this.btRemoveDishFromMenu.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btRemoveDishFromMenu.Font = new System.Drawing.Font("Yu Gothic UI Semibold", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btRemoveDishFromMenu.Location = new System.Drawing.Point(5, 83);
            this.btRemoveDishFromMenu.Name = "btRemoveDishFromMenu";
            this.btRemoveDishFromMenu.Size = new System.Drawing.Size(436, 50);
            this.btRemoveDishFromMenu.TabIndex = 3;
            this.btRemoveDishFromMenu.Text = "Удалить блюдо";
            this.btRemoveDishFromMenu.UseVisualStyleBackColor = false;
            this.btRemoveDishFromMenu.Click += new System.EventHandler(this.btRemoveDishFromMenu_Click);
            // 
            // btAddDishToMenu
            // 
            this.btAddDishToMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(25)))));
            this.btAddDishToMenu.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btAddDishToMenu.Font = new System.Drawing.Font("Yu Gothic UI Semibold", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btAddDishToMenu.Location = new System.Drawing.Point(5, 31);
            this.btAddDishToMenu.Name = "btAddDishToMenu";
            this.btAddDishToMenu.Size = new System.Drawing.Size(436, 50);
            this.btAddDishToMenu.TabIndex = 2;
            this.btAddDishToMenu.Text = "Добавить блюдо";
            this.btAddDishToMenu.UseVisualStyleBackColor = false;
            this.btAddDishToMenu.Click += new System.EventHandler(this.btAddDishToMenu_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Yu Gothic UI", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(125, 3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(316, 45);
            this.label1.TabIndex = 1;
            this.label1.Text = "Выберите действие:";
            // 
            // pnlAddDish
            // 
            this.pnlAddDish.Controls.Add(this.lblNumberDish);
            this.pnlAddDish.Controls.Add(this.btMakeChanges);
            this.pnlAddDish.Controls.Add(this.lblEdit);
            this.pnlAddDish.Controls.Add(this.numCost);
            this.pnlAddDish.Controls.Add(this.btAddNewDish);
            this.pnlAddDish.Controls.Add(this.cbCategory);
            this.pnlAddDish.Controls.Add(this.label6);
            this.pnlAddDish.Controls.Add(this.label5);
            this.pnlAddDish.Controls.Add(this.tbNewNameDish);
            this.pnlAddDish.Controls.Add(this.label4);
            this.pnlAddDish.Controls.Add(this.lblAdd);
            this.pnlAddDish.Location = new System.Drawing.Point(9, 29);
            this.pnlAddDish.Name = "pnlAddDish";
            this.pnlAddDish.Size = new System.Drawing.Size(465, 493);
            this.pnlAddDish.TabIndex = 10;
            this.pnlAddDish.Visible = false;
            // 
            // lblNumberDish
            // 
            this.lblNumberDish.AutoSize = true;
            this.lblNumberDish.Font = new System.Drawing.Font("Yu Gothic UI Semibold", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblNumberDish.Location = new System.Drawing.Point(322, 6);
            this.lblNumberDish.Name = "lblNumberDish";
            this.lblNumberDish.Size = new System.Drawing.Size(44, 45);
            this.lblNumberDish.TabIndex = 12;
            this.lblNumberDish.Text = "...";
            this.lblNumberDish.Visible = false;
            // 
            // btMakeChanges
            // 
            this.btMakeChanges.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(25)))));
            this.btMakeChanges.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btMakeChanges.Font = new System.Drawing.Font("Yu Gothic UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btMakeChanges.Location = new System.Drawing.Point(127, 416);
            this.btMakeChanges.Name = "btMakeChanges";
            this.btMakeChanges.Size = new System.Drawing.Size(211, 50);
            this.btMakeChanges.TabIndex = 11;
            this.btMakeChanges.Text = "Внести изменения";
            this.btMakeChanges.UseVisualStyleBackColor = false;
            this.btMakeChanges.Visible = false;
            this.btMakeChanges.Click += new System.EventHandler(this.btMakeChanges_Click);
            // 
            // lblEdit
            // 
            this.lblEdit.AutoSize = true;
            this.lblEdit.Font = new System.Drawing.Font("Yu Gothic UI Semibold", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblEdit.Location = new System.Drawing.Point(98, 6);
            this.lblEdit.Name = "lblEdit";
            this.lblEdit.Size = new System.Drawing.Size(347, 45);
            this.lblEdit.TabIndex = 10;
            this.lblEdit.Text = "Изменение блюда №";
            this.lblEdit.Visible = false;
            // 
            // numCost
            // 
            this.numCost.Font = new System.Drawing.Font("Yu Gothic UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.numCost.Location = new System.Drawing.Point(227, 105);
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
            this.numCost.Size = new System.Drawing.Size(212, 39);
            this.numCost.TabIndex = 9;
            this.numCost.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
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
            this.cbCategory.Items.AddRange(new object[] {
            "Пицца",
            "Паста",
            "Горячее",
            "Суп",
            "Салат",
            "Десерт",
            "Напиток"});
            this.cbCategory.Location = new System.Drawing.Point(227, 167);
            this.cbCategory.Name = "cbCategory";
            this.cbCategory.Size = new System.Drawing.Size(211, 40);
            this.cbCategory.TabIndex = 6;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Yu Gothic UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label6.Location = new System.Drawing.Point(8, 168);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(304, 40);
            this.label6.TabIndex = 5;
            this.label6.Text = "Выберите категорию:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Yu Gothic UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label5.Location = new System.Drawing.Point(8, 105);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(323, 40);
            this.label5.TabIndex = 3;
            this.label5.Text = "Введите цену в рублях:";
            // 
            // tbNewNameDish
            // 
            this.tbNewNameDish.Font = new System.Drawing.Font("Yu Gothic UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tbNewNameDish.Location = new System.Drawing.Point(227, 46);
            this.tbNewNameDish.Name = "tbNewNameDish";
            this.tbNewNameDish.Size = new System.Drawing.Size(211, 39);
            this.tbNewNameDish.TabIndex = 2;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Yu Gothic UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.Location = new System.Drawing.Point(8, 48);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(262, 40);
            this.label4.TabIndex = 1;
            this.label4.Text = "Введите название:";
            // 
            // lblAdd
            // 
            this.lblAdd.AutoSize = true;
            this.lblAdd.Font = new System.Drawing.Font("Yu Gothic UI Semibold", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblAdd.Location = new System.Drawing.Point(139, 2);
            this.lblAdd.Name = "lblAdd";
            this.lblAdd.Size = new System.Drawing.Size(323, 45);
            this.lblAdd.TabIndex = 0;
            this.lblAdd.Text = "Добавление блюда:";
            // 
            // pnlEditDish
            // 
            this.pnlEditDish.Controls.Add(this.btDeleteDish);
            this.pnlEditDish.Controls.Add(this.btEdit);
            this.pnlEditDish.Controls.Add(this.numEditDish);
            this.pnlEditDish.Controls.Add(this.label8);
            this.pnlEditDish.Controls.Add(this.label7);
            this.pnlEditDish.Controls.Add(this.dataGVDishes);
            this.pnlEditDish.Font = new System.Drawing.Font("Yu Gothic UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.pnlEditDish.Location = new System.Drawing.Point(4, 29);
            this.pnlEditDish.Name = "pnlEditDish";
            this.pnlEditDish.Size = new System.Drawing.Size(472, 490);
            this.pnlEditDish.TabIndex = 11;
            // 
            // btDeleteDish
            // 
            this.btDeleteDish.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(25)))));
            this.btDeleteDish.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btDeleteDish.Font = new System.Drawing.Font("Yu Gothic UI Semilight", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btDeleteDish.Location = new System.Drawing.Point(18, 424);
            this.btDeleteDish.Name = "btDeleteDish";
            this.btDeleteDish.Size = new System.Drawing.Size(210, 42);
            this.btDeleteDish.TabIndex = 6;
            this.btDeleteDish.Text = "Удалить";
            this.btDeleteDish.UseVisualStyleBackColor = false;
            this.btDeleteDish.Visible = false;
            this.btDeleteDish.Click += new System.EventHandler(this.btDeleteDish_Click);
            // 
            // btEdit
            // 
            this.btEdit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(25)))));
            this.btEdit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btEdit.Font = new System.Drawing.Font("Yu Gothic UI Semilight", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btEdit.Location = new System.Drawing.Point(249, 424);
            this.btEdit.Name = "btEdit";
            this.btEdit.Size = new System.Drawing.Size(210, 42);
            this.btEdit.TabIndex = 5;
            this.btEdit.Text = "Внести изменения";
            this.btEdit.UseVisualStyleBackColor = false;
            this.btEdit.Visible = false;
            this.btEdit.Click += new System.EventHandler(this.btEdit_Click);
            // 
            // numEditDish
            // 
            this.numEditDish.Location = new System.Drawing.Point(293, 388);
            this.numEditDish.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numEditDish.Name = "numEditDish";
            this.numEditDish.Size = new System.Drawing.Size(151, 39);
            this.numEditDish.TabIndex = 4;
            this.numEditDish.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Yu Gothic UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label8.Location = new System.Drawing.Point(4, 383);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(381, 45);
            this.label8.TabIndex = 3;
            this.label8.Text = "Выберите номер блюда:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Yu Gothic UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label7.Location = new System.Drawing.Point(144, 4);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(285, 45);
            this.label7.TabIndex = 2;
            this.label7.Text = "Изменение меню:";
            // 
            // dataGVDishes
            // 
            this.dataGVDishes.AllowUserToAddRows = false;
            this.dataGVDishes.AllowUserToDeleteRows = false;
            this.dataGVDishes.AllowUserToResizeColumns = false;
            this.dataGVDishes.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.dataGVDishes.AutoGenerateColumns = false;
            this.dataGVDishes.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGVDishes.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dataGVDishes.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(25)))));
            this.dataGVDishes.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(65)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Yu Gothic UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Azure;
            dataGridViewCellStyle1.NullValue = null;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.HotTrack;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Azure;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGVDishes.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGVDishes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGVDishes.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.categoryDataGridViewTextBoxColumn,
            this.nameDataGridViewTextBoxColumn,
            this.costDataGridViewTextBoxColumn});
            this.dataGVDishes.DataSource = this.dishForBindingBindingSource;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(55)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Yu Gothic UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Azure;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.Azure;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(55)))));
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGVDishes.DefaultCellStyle = dataGridViewCellStyle2;
            this.dataGVDishes.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnF2;
            this.dataGVDishes.GridColor = System.Drawing.Color.Azure;
            this.dataGVDishes.Location = new System.Drawing.Point(3, 35);
            this.dataGVDishes.Name = "dataGVDishes";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(55)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Yu Gothic UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.Azure;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.Azure;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(55)))));
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGVDishes.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dataGVDishes.RowHeadersWidth = 62;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopCenter;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(55)))));
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Yu Gothic UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.Azure;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.Azure;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(55)))));
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGVDishes.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.dataGVDishes.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dataGVDishes.Size = new System.Drawing.Size(462, 343);
            this.dataGVDishes.TabIndex = 1;
            // 
            // btBack
            // 
            this.btBack.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(25)))));
            this.btBack.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btBack.Font = new System.Drawing.Font("Yu Gothic UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btBack.Image = ((System.Drawing.Image)(resources.GetObject("btBack.Image")));
            this.btBack.Location = new System.Drawing.Point(4, 2);
            this.btBack.Name = "btBack";
            this.btBack.Size = new System.Drawing.Size(37, 24);
            this.btBack.TabIndex = 12;
            this.btBack.UseVisualStyleBackColor = false;
            this.btBack.Click += new System.EventHandler(this.btBack_Click);
            // 
            // pnlDeleteWorker
            // 
            this.pnlDeleteWorker.Controls.Add(this.tbLogin);
            this.pnlDeleteWorker.Controls.Add(this.btDelete);
            this.pnlDeleteWorker.Controls.Add(this.label3);
            this.pnlDeleteWorker.Location = new System.Drawing.Point(-6, 29);
            this.pnlDeleteWorker.Name = "pnlDeleteWorker";
            this.pnlDeleteWorker.Size = new System.Drawing.Size(491, 513);
            this.pnlDeleteWorker.TabIndex = 13;
            // 
            // tbLogin
            // 
            this.tbLogin.Font = new System.Drawing.Font("Yu Gothic UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tbLogin.Location = new System.Drawing.Point(118, 97);
            this.tbLogin.Name = "tbLogin";
            this.tbLogin.Size = new System.Drawing.Size(251, 45);
            this.tbLogin.TabIndex = 2;
            // 
            // btDelete
            // 
            this.btDelete.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(35)))));
            this.btDelete.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btDelete.Font = new System.Drawing.Font("Yu Gothic UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btDelete.Location = new System.Drawing.Point(159, 176);
            this.btDelete.Name = "btDelete";
            this.btDelete.Size = new System.Drawing.Size(166, 50);
            this.btDelete.TabIndex = 1;
            this.btDelete.Text = "Удалить";
            this.btDelete.UseVisualStyleBackColor = false;
            this.btDelete.Click += new System.EventHandler(this.btDelete_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(18, 23);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(399, 37);
            this.label3.TabIndex = 0;
            this.label3.Text = "Введите логин сотрудника:";
            // 
            // categoryDataGridViewTextBoxColumn
            // 
            this.categoryDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.categoryDataGridViewTextBoxColumn.DataPropertyName = "Category";
            this.categoryDataGridViewTextBoxColumn.Frozen = true;
            this.categoryDataGridViewTextBoxColumn.HeaderText = "Категория";
            this.categoryDataGridViewTextBoxColumn.MinimumWidth = 8;
            this.categoryDataGridViewTextBoxColumn.Name = "categoryDataGridViewTextBoxColumn";
            this.categoryDataGridViewTextBoxColumn.ReadOnly = true;
            this.categoryDataGridViewTextBoxColumn.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.categoryDataGridViewTextBoxColumn.Width = 150;
            // 
            // nameDataGridViewTextBoxColumn
            // 
            this.nameDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.nameDataGridViewTextBoxColumn.DataPropertyName = "Name";
            this.nameDataGridViewTextBoxColumn.HeaderText = "Название";
            this.nameDataGridViewTextBoxColumn.MinimumWidth = 8;
            this.nameDataGridViewTextBoxColumn.Name = "nameDataGridViewTextBoxColumn";
            this.nameDataGridViewTextBoxColumn.ReadOnly = true;
            this.nameDataGridViewTextBoxColumn.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // costDataGridViewTextBoxColumn
            // 
            this.costDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.costDataGridViewTextBoxColumn.DataPropertyName = "Cost";
            this.costDataGridViewTextBoxColumn.HeaderText = "Цена";
            this.costDataGridViewTextBoxColumn.MinimumWidth = 8;
            this.costDataGridViewTextBoxColumn.Name = "costDataGridViewTextBoxColumn";
            this.costDataGridViewTextBoxColumn.ReadOnly = true;
            this.costDataGridViewTextBoxColumn.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // dishForBindingBindingSource
            // 
            this.dishForBindingBindingSource.DataSource = typeof(АРМ_курсовая.DishForBinding);
            // 
            // dishBindingSource
            // 
            this.dishBindingSource.DataSource = typeof(АРМ_курсовая.Dish);
            // 
            // MainFormAdmin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(45)))));
            this.ClientSize = new System.Drawing.Size(481, 530);
            this.Controls.Add(this.btBack);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.pnlEditDish);
            this.Controls.Add(this.pnlAddDish);
            this.Controls.Add(this.pnlDeleteWorker);
            this.Controls.Add(this.pnlMain);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ForeColor = System.Drawing.Color.Azure;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.Name = "MainFormAdmin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Ресторан \"San Pizzerino\"";
            this.pnlMain.ResumeLayout(false);
            this.pnlMain.PerformLayout();
            this.pnlEditWorkers.ResumeLayout(false);
            this.pnlEditMenu.ResumeLayout(false);
            this.pnlAddDish.ResumeLayout(false);
            this.pnlAddDish.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numCost)).EndInit();
            this.pnlEditDish.ResumeLayout(false);
            this.pnlEditDish.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numEditDish)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGVDishes)).EndInit();
            this.pnlDeleteWorker.ResumeLayout(false);
            this.pnlDeleteWorker.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dishForBindingBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dishBindingSource)).EndInit();
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
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.BindingSource dishForBindingBindingSource;
        private System.Windows.Forms.Panel pnlAddDish;
        private System.Windows.Forms.NumericUpDown numCost;
        private System.Windows.Forms.Button btAddNewDish;
        private System.Windows.Forms.ComboBox cbCategory;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox tbNewNameDish;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblAdd;
        private System.Windows.Forms.Panel pnlEditDish;
        private System.Windows.Forms.DataGridView dataGVDishes;
        private System.Windows.Forms.Button btEdit;
        private System.Windows.Forms.NumericUpDown numEditDish;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btDeleteDish;
        private System.Windows.Forms.Button btBack;
        private System.Windows.Forms.Button btMakeChanges;
        private System.Windows.Forms.Label lblEdit;
        private System.Windows.Forms.Label lblNumberDish;
        private System.Windows.Forms.DataGridViewTextBoxColumn categoryDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn costDataGridViewTextBoxColumn;
        private System.Windows.Forms.Panel pnlDeleteWorker;
        private System.Windows.Forms.TextBox tbLogin;
        private System.Windows.Forms.Button btDelete;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.BindingSource dishBindingSource;
    }
}