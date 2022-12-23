using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using АРМ_курсовая;

namespace АРМ_курсовая
{
    public partial class MainFormWaiter : Form
    {
        public MainFormWaiterViewModel ViewModel;
        int index = 0;
        

        public MainFormWaiter(Account currentAccount)
        {
            InitializeComponent();
            ViewModel = new MainFormWaiterViewModel(currentAccount);
            ViewModel = new MainFormWaiterViewModel();
            SetDGSelectedDishes();
            menuQuests.Items[0].Click += new EventHandler(itemQuest_Click);
            lblLogin.Text = $"{currentAccount.Login}";
            pnlTables.Visible = false;
            btAddQuestAtTheSelectedTable.Visible = false;
        }

        //Настройка таблицы выбранных блюд
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
        private void dataGVDish_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            foreach (Dish i in ViewModel.menu.Dishes)
            {
                if (i.Name == dataGVDish.CurrentCell.Value.ToString())
                {
                    ViewModel.currentDish = i;
                    lblNameDish.Text = i.Name;
                    lblNameDish.Visible = true;
                    break;
                }
            }
        }
        private bool CheckMatchDishesDG(Dish dish, int quantity)
        {
            for (int i = 0; i < dataGVSelectedDishes.RowCount; i++)
            {
                if (dataGVSelectedDishes[0, i].Value.ToString() == dish.Name)
                {
                    int currentQuantity = Convert.ToInt32(dataGVSelectedDishes[1, i].Value);
                    dataGVSelectedDishes[1, i].Value = currentQuantity + quantity;
                    dataGVSelectedDishes[2, i].Value = dish.Cost * (currentQuantity + quantity);
                    return true;
                }
            }
            return false;
        }

        //Настройка таблицы меню
        private void UpdateDGMenu(string category)
        {
            dataGVDish.DataSource = dishForBindingBindingSource;
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
        //установка номеров строк
        private void dataGridView_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            object headValue = ((DataGridView)sender).Rows[e.RowIndex].HeaderCell.Value;
            if (headValue == null || !headValue.Equals((e.RowIndex + 1).ToString()))
                ((DataGridView)sender).Rows[e.RowIndex].HeaderCell.Value = ((e.RowIndex + 1).ToString());
        }
        
        //Настройка панели с картой столов
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
            ViewModel.NumberEmptySeats = ViewModel.tables[Convert.ToInt32(click.TabIndex)].numberOfSeats;
            if (ViewModel.tables[Convert.ToInt32(click.TabIndex)].status == true)
            {
                ViewModel.NumberEmptySeats = ViewModel.CheckTables(Convert.ToInt32(click.TabIndex));
                if (ViewModel.NumberEmptySeats != 0)
                {
                    if (MessageBox.Show("Этот стол уже занят. Вы уверены, что хотите добавить еще одного гостя?" +
                        $"Количество свободных мест {ViewModel.NumberEmptySeats}", "Информация", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                    {
                        ViewModel.NumberEmptySeats -= 1;
                        pnlTables.Visible = false;
                        btAddQuestAtTheSelectedTable.Visible = true;
                        lblNumberTable.Text = click.TabIndex.ToString();
                        lblEmptySeats.Text = ViewModel.NumberEmptySeats.ToString();
                        ViewModel.FindOrder(Convert.ToInt32(click.TabIndex));
                        ViewModel.currentQuest = new Quest();
                    }
                }
                else
                    MessageBox.Show("За этим столом не осталось свободных мест", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                string message = $"Стол № {click.Text}\n" +
                    $"Количество мест: {ViewModel.tables[Convert.ToInt32(click.TabIndex)].numberOfSeats}\n" +
                    $"Добавить гостя?";
                if (MessageBox.Show(message, "Информация", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                {
                    ViewModel.NumberEmptySeats -= 1;
                    pnlTables.Visible = false;
                    btAddQuestAtTheSelectedTable.Visible = true;
                    lblNumberTable.Text = click.TabIndex.ToString();
                    lblEmptySeats.Text = ViewModel.NumberEmptySeats.ToString();
                    ViewModel.currentNumberTable = Convert.ToInt32(click.TabIndex) - 1;
                    ViewModel.currentOrder = new Order();
                    ViewModel.currentQuest = new Quest();
                }
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
            btAddQuestAtTheSelectedTable.Visible = false;
            index = 0;
        }

        private void btAddDishToQuest_Click(object sender, EventArgs e)
        {
            if (ViewModel.currentDish != null)
            {
                foreach (Dish i in ViewModel.menu.Dishes)
                {
                    if (i.Name == ViewModel.currentDish.Name)
                    {
                        for (int j = 0; j < DishCounter.Value; j++)
                        {
                            ViewModel.AddDishes(i);
                        }
                        if (CheckMatchDishesDG(i, Convert.ToInt32(DishCounter.Value)) == true)
                        {
                            break;
                        }
                        dataGVSelectedDishes.Rows.Add(i.Name, Convert.ToInt32(DishCounter.Value), i.Cost * Convert.ToInt32(DishCounter.Value));
                        break;
                    }
                }
                DishCounter.Value = 1;
                lblNameDish.Text = "";
                ViewModel.currentDish = null;
                ViewModel.SaveQuests(index);
            }
            else
                MessageBox.Show("Блюдо не выбрано!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);

        }

        private void UpdatedataGVSelectedDishes (List <Dish> dishes)
        {
            int quantity = 0;
            if (dishes.Count > 0)
            {
                for (int i = 0; i < dishes.Count - 1; i++)
                {
                    if (dishes[i] == dishes[i + 1])
                    {
                        quantity += 1;
                    }
                    else
                    {
                        if (i >= 1 && quantity != 0)
                        {
                            if (CheckMatchDishesDG(dishes[i], quantity + 1) == false)
                            {
                                dataGVSelectedDishes.Rows.Add(dishes[i].Name, quantity + 1, dishes[i].Cost);
                            }
                        }
                        else
                        {
                            dataGVSelectedDishes.Rows.Add(dishes[i].Name, 1, dishes[i].Cost);
                        }
                        quantity = 0;
                    }
                }
                if (quantity != 0)
                {
                    if (CheckMatchDishesDG(dishes[dishes.Count - 1], quantity + 1) == false)
                    {
                        dataGVSelectedDishes.Rows.Add(dishes[dishes.Count - 1].Name, quantity + 1, dishes[dishes.Count - 1].Cost);
                    }
                }
                else
                {
                    dataGVSelectedDishes.Rows.Add(dishes[dishes.Count - 1].Name, 1, dishes[dishes.Count - 1].Cost);
                }
            }
        }

        private void cbCategoryDish_SelectedIndexChanged(object sender, EventArgs e)
        {
            dishForBindingBindingSource.Clear();
            UpdateDGMenu(cbCategoryDish.SelectedItem.ToString());
        }

        private void btAddQuestToSelectedTable_Click(object sender, EventArgs e)
        {
            //проверка чтобы у всех были блюда сделать
            if (ViewModel.NumberEmptySeats != 0)
            {
                if (ViewModel.currentQuest.Dishes.Count != 0)
                {
                    int CountItems = 0;
                    foreach (ToolStripItem toolItem in menuQuests.Items)
                    {
                        CountItems += 1;
                    }
                    ToolStripItem item = new ToolStripMenuItem();
                    item.Text = $"Гость {CountItems + 1}";
                    item.Name = $"Quest {CountItems + 1}";
                    menuQuests.Items.Add(item);
                    item.Click += new EventHandler(itemQuest_Click);
                    ViewModel.NumberEmptySeats -= 1;
                    lblEmptySeats.Text = ViewModel.NumberEmptySeats.ToString();
                }
                else
                    MessageBox.Show("Вы не можете добавить нового гостя, пока текущему не добавлены блюда!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
                MessageBox.Show("За этим столом не осталось свободных мест", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void itemQuest_Click(object sender, EventArgs e)
        {
            ToolStripItem ClickItem = sender as ToolStripItem;
            index = Convert.ToInt32(Regex.Replace(ClickItem.Name, @"[^\d]+", ""));


            if (ClickItem.Pressed == false)
            {
                lblNumberQuest.Text = ClickItem.Text;

                if (ViewModel.currentOrder.Quests.Count >= index)
                {
                    index -= 1;
                    dataGVSelectedDishes.Rows.Clear();
                    UpdatedataGVSelectedDishes(ViewModel.currentOrder.Quests[index].Dishes);
                    ViewModel.currentQuest = ViewModel.currentOrder.Quests[index];
                }
                else
                {
                    index -= 1;
                    dataGVSelectedDishes.Rows.Clear();
                    ViewModel.currentQuest = new Quest();
                }
            }
        }

        private void btDeleteDish_Click(object sender, EventArgs e)
        {

            if(dataGVSelectedDishes.CurrentCell != null)
            {
                string NameDish = dataGVSelectedDishes[0, dataGVSelectedDishes.CurrentCell.RowIndex].Value.ToString();
                ViewModel.DeleteDish(NameDish);
                dataGVSelectedDishes.Rows.Clear();
                UpdatedataGVSelectedDishes(ViewModel.currentQuest.Dishes);
                ViewModel.SaveQuests(index);
                MessageBox.Show("Блюдо успешно удалено!", "Удаление", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
                MessageBox.Show("Блюдо для удаления не выбрано", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void btCreateOrder_Click(object sender, EventArgs e)
        {
            //проверка чтобы у всех были блюда сделать
            ViewModel.AddOrder(ViewModel.currentOrder);
        }
    }
}
