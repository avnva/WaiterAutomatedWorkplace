using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using АРМ_курсовая.Resources;

namespace АРМ_курсовая
{
    public partial class MainFormWaiter : Form
    {
        public MainFormWaiterViewModel ViewModel;
        public Account CurrentAccount;
        public Order NewOrder;
        public Dish CurrentDish;
        public Quest currentQuest;
        private List<Dish> Dishes;
        public Dish GetCurrentDish
        {
            get { return CurrentDish; }
            set { CurrentDish = value; }
        }
        public MainFormWaiter(Account currentAccount, Dish dish)
        {
            InitializeComponent();
            ViewModel = new MainFormWaiterViewModel(currentAccount, dish);
            CurrentAccount = currentAccount;
            this.lblLogin.Text = $"{CurrentAccount.Login}";
            pnlTables.Visible = false;
            pnlMenu.Visible = false;
            ViewModel = new MainFormWaiterViewModel();
            //UpdateDGMenu();
            SetDGSelectedDishes();
        }
        private void SetDGSelectedDishes()
        {
            dataGVSelectedDishes.ColumnCount = 3;
            dataGVSelectedDishes.Columns[0].Name = "Name";
            dataGVSelectedDishes.Columns[0].HeaderText = "Название";
            dataGVSelectedDishes.Columns[1].Name = "Quantity";
            dataGVSelectedDishes.Columns[1].HeaderText = "Количество";
            dataGVSelectedDishes.Columns[2].Name = "Cost";
            dataGVSelectedDishes.Columns[2].HeaderText = "Сумма";
        }
        private bool CheckMatchDishesDG(Dish dish, int quantity)
        { 
            for (int i = 0; i < dataGVSelectedDishes.RowCount - 1; i++)
            {
                if (dataGVSelectedDishes[0, i].Value.ToString() == dish.Name)
                {
                    int currentQuantity = Convert.ToInt32(dataGVSelectedDishes[1, i].Value);
                    dataGVSelectedDishes[1, i].Value = currentQuantity + quantity;
                    return true;
                }
            }
            return false;
        }
        private void UpdateDGMenu(string category)
        {
            dataGVDish.DataSource = dishForBindingBindingSource;
            //ViewModel.currentSession.Dishes.Sort(new CompareApplicantsByID());
            foreach (Dish _dish in ViewModel.menu.Dishes)
            {
                if (_dish.Category == category)
                {
                    dishForBindingBindingSource.Add(new DishForBinding(_dish.Category, _dish.Name, _dish.Cost));
                }
            }
            dataGVDish.RowPrePaint += dataGridView_RowPrePaint;
            dataGVDish.RowHeadersWidth = 55;
            dataGVDish.CellClick += dataGVDish_CellContentClick;
        }
        private void dataGVDish_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            foreach (Dish i in ViewModel.menu.Dishes)
            {
                if (i.Name == dataGVDish.CurrentCell.Value.ToString())
                {
                    //Dish currentDish = new Dish(i.Name, i.Cost, i.Category);
                    lblNameDish.Text = i.Name;
                    lblNameDish.Visible = true;
                    //ViewModel.AddDish(currentQuest, currentDish);
                    break;
                }
            }

        }
        //установка номеров строк
        private void dataGridView_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            object headValue = ((DataGridView)sender).Rows[e.RowIndex].HeaderCell.Value;
            if (headValue == null || !headValue.Equals((e.RowIndex + 1).ToString()))
                ((DataGridView)sender).Rows[e.RowIndex].HeaderCell.Value = ((e.RowIndex + 1).ToString());
        }

        private void btCloseShift_Click(object sender, EventArgs e)
        {
            Hide();
            LogInForm loginform = new LogInForm();
            loginform.ShowDialog();
            Close();
        }

        private void btAddQuest_Click(object sender, EventArgs e)
        {
            pnlTables.Visible = true;
            pnlMenu.Visible = false;
            Quest currentQuest = new Quest(null);
            ViewModel.Dishes.Clear();
            //List<Dish> Dishes = new List<Dish>();
            //currentQuest = new Quest();
            //MainFormWaiterViewModel ViewModel = new MainFormWaiterViewModel(NewOrder);
            //MainFormWaiterViewModel.AddOrder(NewOrder);
        }

        private void pnlTables_Paint(object sender, PaintEventArgs e)
        {
            Button[] tables = this.pnlTables.Controls.OfType<Button>().ToArray<Button>();
            Sort_tables(tables);
            foreach (Button item in tables) //обходим все элементы
            {
                item.Click += TablesBtn_Click; //приводим к типу и устанавливаем обработчик события  
            }
        }
        private void TablesBtn_Click(object sender, EventArgs e)
        {
            Button click = sender as Button;
            // if quests != 0 - за столом уже есть гости, вы уверены, что хотите добавить еще?
            string message = $"Стол № {click.Text}\n" +
                $"Статус: {ViewModel.tables[Convert.ToInt32(click.TabIndex)].status}\n" +
                $"Количество мест: {ViewModel.tables[Convert.ToInt32(click.TabIndex)].numberOfSeats}\n" +
                $"Добавить гостя?";
            if (MessageBox.Show(message, "Информация", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
            {
                pnlTables.Visible = false;
                pnlMenu.Visible = true;
                lblNumberTable.Text = click.TabIndex.ToString();
            }
        }
        private void Sort_tables(Button[] tables)
        {
            Button temp = null;
            for (int i = 0; i < tables.Length - 1; i++)
            {
                for (int j = 0; j < tables.Length - i - 1; j++)
                {
                    if (Convert.ToInt32(tables[j].Text) > Convert.ToInt32(tables[j + 1].Text))
                    {
                        temp = tables[j];
                        tables[j] = tables[j + 1];
                        tables[j + 1] = temp;
                    }
                }
            }
        }

        private void btAddDishToQuest_Click(object sender, EventArgs e)
        {
            bool Flag = true;
            foreach(Dish i in ViewModel.menu.Dishes)
            {
                if (i.Name == lblNameDish.Text)
                {
                    for (int j = 0; j < DishCounter.Value; j++)
                    {
                        ViewModel.Dishes.Add(i);    
                    }
                    if (dataGVSelectedDishes.Rows.Count > 1)
                    {
                        if (CheckMatchDishesDG(i, Convert.ToInt32(DishCounter.Value)) == true) 
                        {
                            Flag = false;
                        }
                    }
                    if (Flag)
                    {
                        dataGVSelectedDishes.Rows.Add(i.Name, Convert.ToInt32(DishCounter.Value), i.Cost * Convert.ToInt32(DishCounter.Value));
                    }
                }
            }
            DishCounter.Value = 1;
            lblNameDish.Visible = false;
            //ViewModel.AddDish(), lblNameDish.Text.ToString())
        }

        private void cbCategoryDish_SelectedIndexChanged(object sender, EventArgs e)
        {
            dishForBindingBindingSource.Clear();
            UpdateDGMenu(cbCategoryDish.SelectedItem.ToString());
        }

        private void btSaveQuest_Click(object sender, EventArgs e)
        {

        }
    }
}
