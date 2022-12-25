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
using static System.Windows.Forms.LinkLabel;

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
            SetDGSelectedDishes();
            menuQuests.Items[0].Click += new EventHandler(itemQuest_Click);
            lblLogin.Text = $"{currentAccount.Login}";
            pnlTables.Visible = false;
            pnlAddQuest.Visible = false;
            btSaveOrder.Visible = false;
            cbCategoryDish.DropDownStyle = ComboBoxStyle.DropDownList;
            cbDiscount.DropDownStyle = ComboBoxStyle.DropDownList;
            if (ViewModel.allOrders.Orders == null)
            {
                BlockButtons();
                pnInformation.BackColor = Color.FromArgb(0, 0, 45);
                btAddQuest.Enabled = true;
                btAddQuest.BackColor = Color.FromArgb(0, 0, 25);
                btCloseShift.Enabled = true;
                btCloseShift.BackColor = Color.FromArgb(0, 0, 25);
            }
        }
        private void UpdateDGOrders(Status status)
        {
            dataGVOrders.DataSource = orderForBindingBindingSource;
            dataGVOrders.Rows.Clear();
            ViewModel.allOrders.LoadOrders();
            foreach (Order _order in ViewModel.allOrders.Orders)
            {
                if (_order.WaiterLogin == ViewModel.currentSession.CurrentAccount.Login && _order.Status == status)
                    orderForBindingBindingSource.Add(new OrderForBinding(_order.Status, _order.NumberTable, _order.Quests.Count, _order.TotalBill, _order.WaiterLogin, _order.Time));
            }
            dataGVOrders.RowPrePaint += dataGridView_RowPrePaint;
            dataGVOrders.RowHeadersWidth = 55;
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
            ViewModel.NumberEmptySeats = ViewModel.tables[Convert.ToInt32(click.TabIndex) - 1].numberOfSeats;
            ViewModel.NumberEmptySeats = ViewModel.CheckTable(Convert.ToInt32(click.TabIndex));


            if (ViewModel.NumberEmptySeats == ViewModel.tables[Convert.ToInt32(click.TabIndex) - 1].numberOfSeats)
            {
                string message = $"Стол № {click.Text}\n" +
                    $"Количество мест: {ViewModel.NumberEmptySeats}\n" +
                    $"Добавить гостя?";
                if (MessageBox.Show(message, "Информация", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                {
                    ViewModel.NumberEmptySeats -= 1;
                    pnlTables.Visible = false;
                    pnlAddQuest.Visible = true;
                    lblNumberTable.Text = click.TabIndex.ToString();
                    lblEmptySeats.Text = ViewModel.NumberEmptySeats.ToString();
                    ViewModel.currentNumberTable = Convert.ToInt32(click.TabIndex);
                    index = 0;
                    ViewModel.currentQuest = new Quest();
                    index = 0;
                    BlockButtons();
                }
            }
            else if (ViewModel.NumberEmptySeats > 0)
            {
                if (MessageBox.Show("Этот стол уже занят.\nВы уверены, что хотите добавить еще одного гостя?\n" +
                    $"Количество свободных мест: {ViewModel.NumberEmptySeats}", "Информация", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                {
                    ViewModel.NumberEmptySeats -= 1;
                    pnlTables.Visible = false;
                    pnlAddQuest.Visible = true;
                    lblNumberTable.Text = click.TabIndex.ToString();
                    lblEmptySeats.Text = ViewModel.NumberEmptySeats.ToString();
                    ViewModel.FindOrder(Convert.ToInt32(click.TabIndex));
                    index = ViewModel.currentOrder.Quests.Count;
                    ViewModel.currentQuest = new Quest();
                    ViewModel.currentOrder.Quests.Add(ViewModel.currentQuest);
                    ViewModel.DeleteOrder(ViewModel.currentOrder);
                    BlockButtons();
                    UpdateMenuQuests();
                }
            }
            else
                MessageBox.Show("За этим столом не осталось свободных мест", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void BlockButtons()
        {
            pnInformation.BackColor = Color.FromArgb(93, 118, 203);
            pnAboutQuests.BackColor = Color.FromArgb(93, 118, 203);
            Panel.BackColor = Color.FromArgb(93, 118, 203);
            pnStatistics.BackColor = Color.FromArgb(93, 118, 203);
            btAddQuest.Enabled = false;
            btAddQuest.BackColor = Color.FromArgb(93, 118, 203);
            btCloseShift.Enabled = false;
            btCloseShift.BackColor = Color.FromArgb(93, 118, 203);
            btPayOrder.Enabled = false;
            btPayOrder.BackColor = Color.FromArgb(93, 118, 203);
            btCurrentOrders.Enabled = false;
            btCurrentOrders.BackColor = Color.FromArgb(93, 118, 203);
            btMakeChages.Enabled = false;
            btMakeChages.BackColor = Color.FromArgb(93, 118, 203);
            btClosedOrders.Enabled = false;
            btClosedOrders.BackColor = Color.FromArgb(93, 118, 203);
        }
        private void UnblockButtons()
        {
            if (ViewModel.allOrders.Orders == null)
            {
                BlockButtons();
                pnInformation.BackColor = Color.FromArgb(0, 0, 45);
                btAddQuest.Enabled = true;
                btAddQuest.BackColor = Color.FromArgb(0, 0, 25);
                btCloseShift.Enabled = true;
                btCloseShift.BackColor = Color.FromArgb(0, 0, 25);
            }
            else
            {
                pnInformation.BackColor = Color.FromArgb(0, 0, 45);
                pnAboutQuests.BackColor = Color.FromArgb(0, 0, 45);
                pnStatistics.BackColor = Color.FromArgb(0, 0, 45);
                Panel.BackColor = Color.FromArgb(0, 0, 45);
                btAddQuest.Enabled = true;
                btAddQuest.BackColor = Color.FromArgb(0, 0, 25);
                btCloseShift.Enabled = true;
                btCloseShift.BackColor = Color.FromArgb(0, 0, 25);
                btPayOrder.Enabled = true;
                btPayOrder.BackColor = Color.FromArgb(0, 0, 25);
                btCurrentOrders.Enabled = true;
                btCurrentOrders.BackColor = Color.FromArgb(0, 0, 25);
                btMakeChages.Enabled = true;
                btMakeChages.BackColor = Color.FromArgb(0, 0, 25);
                btClosedOrders.Enabled = true;
                btClosedOrders.BackColor = Color.FromArgb(0, 0, 25);
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
            pnlAddQuest.Visible = false;
            ViewModel.currentOrder = null;
            ViewModel.currentQuest = null;
            ViewModel.currentDish = null;
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
                btSaveOrder.Visible = true;
            }
            else
                MessageBox.Show("Блюдо не выбрано!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);

        }

        private void UpdateDataGVSelectedDishes(List<Dish> dishes)
        {
            int quantity = 0;
            if (dishes.Count > 0)
            {
                for (int i = 0; i < dishes.Count - 1; i++)
                {
                    if (dishes[i].Name == dishes[i + 1].Name)
                    {
                        quantity += 1;
                    }
                    else
                    {
                        if (i >= 1 && quantity != 0)
                        {
                            if (CheckMatchDishesDG(dishes[i], quantity + 1) == false)
                            {
                                dataGVSelectedDishes.Rows.Add(dishes[i].Name, quantity + 1, dishes[i].Cost * (quantity + 1));
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
                        dataGVSelectedDishes.Rows.Add(dishes[dishes.Count - 1].Name, quantity + 1, dishes[dishes.Count - 1].Cost * (quantity + 1));
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

        private void UpdateMenuQuests()
        {
            menuQuests.Items.Clear();
            for (int i = 0; i < ViewModel.currentOrder.Quests.Count; i++)
            {
                ToolStripItem item = new ToolStripMenuItem
                {
                    Text = $"Гость {i + 1}",
                    Name = $"Quest{i}"
                };
                menuQuests.Items.Add(item);
                item.Click += new EventHandler(itemQuest_Click);
                if (item.Name == $"Quest0")
                {
                    EventArgs e = new EventArgs();
                    itemQuest_Click(item, e);
                }
            }
        }
        private void btAddQuestToSelectedTable_Click(object sender, EventArgs e)
        {
            if (ViewModel.NumberEmptySeats != 0)
            {
                if (ViewModel.currentOrder != null)
                {
                    if (ViewModel.CheckQuests())
                    {
                        int CountItems = 0;
                        foreach (ToolStripItem toolItem in menuQuests.Items)
                        {
                            CountItems += 1;
                        }
                        ToolStripItem item = new ToolStripMenuItem();
                        item.Text = $"Гость {CountItems + 1}";
                        item.Name = $"Quest{CountItems}";
                        menuQuests.Items.Add(item);
                        item.Click += new EventHandler(itemQuest_Click);
                        ViewModel.NumberEmptySeats -= 1;
                        lblEmptySeats.Text = ViewModel.NumberEmptySeats.ToString();
                        ViewModel.currentQuest = new Quest();
                        ViewModel.currentOrder.Quests.Add(ViewModel.currentQuest);
                        ViewModel.currentQuest = ViewModel.currentOrder.Quests[index];
                        btSaveOrder.Visible = false;
                        EventArgs a = new EventArgs();
                        itemQuest_Click(item, a);
                    }
                    else
                        MessageBox.Show("Вы не можете добавить нового гостя, пока текущему не добавлены блюда!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                foreach (ToolStripItem toolItem in menuQuests.Items)
                {
                    toolItem.BackColor = Color.Azure;
                    toolItem.ForeColor = Color.Black;
                }
                lblNumberQuest.Text = ClickItem.Text;
                ClickItem.BackColor = Color.FromArgb(0, 0, 55);
                ClickItem.ForeColor = Color.Azure;
                dataGVSelectedDishes.Rows.Clear();
                UpdateDataGVSelectedDishes(ViewModel.currentOrder.Quests[index].Dishes);
                ViewModel.currentQuest = ViewModel.currentOrder.Quests[index];
            }
        }

        private void btDeleteDish_Click(object sender, EventArgs e)
        {

            if (dataGVSelectedDishes.CurrentCell != null)
            {
                string NameDish = dataGVSelectedDishes[0, dataGVSelectedDishes.CurrentCell.RowIndex].Value.ToString();
                ViewModel.DeleteDish(NameDish);
                dataGVSelectedDishes.Rows.Clear();
                UpdateDataGVSelectedDishes(ViewModel.currentQuest.Dishes);
                ViewModel.SaveQuests(index);
                if (ViewModel.currentQuest.Dishes.Count == 0)
                {
                    btSaveOrder.Visible = false;
                }
            }
            else
                MessageBox.Show("Блюдо для удаления не выбрано", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }



        private void btDeleteQuest_Click(object sender, EventArgs e)
        {
            if (ViewModel.currentOrder != null && ViewModel.currentOrder.Quests.Count > 1)
            {
                ViewModel.DeleteQuest();
                ViewModel.NumberEmptySeats += 1;
                lblEmptySeats.Text = ViewModel.NumberEmptySeats.ToString();
                menuQuests.Items.Remove(menuQuests.Items[index]);
                if (ViewModel.currentOrder.Quests.Count > index)
                {
                    ViewModel.currentQuest = ViewModel.currentOrder.Quests[index];
                    foreach (ToolStripItem toolItem in menuQuests.Items)
                    {
                        int currentIndex = Convert.ToInt32(Regex.Replace(toolItem.Name, @"[^\d]+", "")) - 1;
                        if ((currentIndex) >= index)
                        {
                            toolItem.Text = $"Гость {currentIndex + 1}";
                            toolItem.Name = $"Quest{currentIndex}";
                        }
                    }
                }
                else
                {
                    index -= 1;
                    ViewModel.currentQuest = ViewModel.currentOrder.Quests[index];
                }
                foreach (ToolStripItem toolItem in menuQuests.Items)
                {
                    if (toolItem.Name == $"Quest0")
                    {
                        EventArgs a = new EventArgs();
                        itemQuest_Click(toolItem, a);
                    }
                }
                btSaveOrder.Visible = true;
            }
            else
                MessageBox.Show("Вы не можете удалить единственного гостя!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void btCancelOrder_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Заказ будет удален.\n" +
                        "Вы уверены, что хотите выйти?", "Информация", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
            {
                if (ViewModel.currentOrder != null)
                {
                    ViewModel.currentOrder.Quests.Clear();
                }
                ViewModel.currentQuest.Dishes.Clear();
                ViewModel.currentOrder = null;
                ViewModel.currentQuest = null;
                ViewModel.currentDish = null;
                pnlAddQuest.Visible = false;
                UnblockButtons();
            }
        }

        private void btPayOrder_Click(object sender, EventArgs e)
        {
            pnlOrders.Visible = true;
            pnlAddQuest.Visible = false;
            pnlTables.Visible = false;
            lblPay.Visible = true;
            btPayTable.Visible = true;
            numericTable.Visible = true;
            pnlPayTable.Visible = false;
            lblAverageBill.Visible = false;
            tbAverageBill.Visible = false;
            lblChange.Visible = false;
            btChange.Visible = false;
            UpdateDGOrders(АРМ_курсовая.Status.Активен);
        }

        private void btBack_Click(object sender, EventArgs e)
        {
            pnlOrders.Visible = false;
            pnlPayTable.Visible = false;
            pnlAddQuest.Visible = false;
            pnlTables.Visible = false;
            UnblockButtons();
        }

        private void btPayTable_Click(object sender, EventArgs e)
        {
            bool Flag = false;
            for (int i = 0; i < ViewModel.allOrders.Orders.Count; i++)
            {
                if (ViewModel.allOrders.Orders[i].NumberTable == Convert.ToInt32(numericTable.Value) && ViewModel.allOrders.Orders[i].Status == АРМ_курсовая.Status.Активен)
                {
                    Flag = true;
                    ViewModel.currentOrder = ViewModel.allOrders.Orders[i];
                    pnlPayTable.Visible = true;
                    dataGVOrders.Visible = false;
                    btPayTable.Visible = false;
                    lblPay.Visible = false;
                    numericTable.Visible = false;
                    int CountQuest = ViewModel.currentOrder.Quests.Count;
                    lblTable.Text = $"Стол№ {ViewModel.currentOrder.NumberTable}";
                    lblNumberQuests.Text = $"Гостей всего: {CountQuest}";
                    lblCost.Text = $"Общая сумма: {ViewModel.currentOrder.TotalBill}";
                    Label[] labelQuest = new Label[CountQuest];
                    Label[] labelCost = new Label[CountQuest];
                    for (int j = 0; j < CountQuest; j++)
                    {
                        labelQuest[j] = new Label();
                        labelQuest[j].Name = $"Quest{j}";
                        labelQuest[j].Location = new Point(65, 110 + j * 40);
                        labelQuest[j].Text = $"Гость {j + 1}:";
                        labelQuest[j].Visible = true;
                        pnlPayTable.Controls.Add(labelQuest[j]);
                        labelCost[j] = new Label();
                        labelCost[j].Name = $"Cost{j}";
                        labelCost[j].Location = new Point(170, 110 + j * 40);
                        labelCost[j].Text = ViewModel.currentOrder.Quests[j].Bill.ToString();
                        labelCost[j].Visible = true;
                        pnlPayTable.Controls.Add(labelCost[j]);
                    }
                }
            }
            if (!Flag)
            {
                MessageBox.Show("Такого заказа не существует!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btMakeDiscount_Click(object sender, EventArgs e)
        {
            if (lblDiscount.Visible == true)
            {
                if (cbDiscount.SelectedItem != null)
                {
                    float discount = Convert.ToInt32(Regex.Replace(cbDiscount.SelectedItem.ToString(), @"[^\d]+", ""));
                    ViewModel.BringBackCost(discount);
                    UpdateCostLbl();
                }
                lblDiscount.Visible = false;
                cbDiscount.Visible = false;
            }
            else
            {
                lblDiscount.Visible = true;
                cbDiscount.Visible = true;
                cbDiscount.Enabled = true;
            }
        }
        private void UpdateCostLbl()
        {
            lblCost.Text = $"Общая сумма: {ViewModel.currentOrder.TotalBill}";
            foreach (Control lblCost in pnlPayTable.Controls)
            {
                if (lblCost.GetType() == typeof(Label))
                {
                    for (int i = 0; i < ViewModel.currentOrder.Quests.Count; i++)
                    {
                        if (lblCost.Name == $"Cost{i}")
                        {
                            lblCost.Text = ViewModel.currentOrder.Quests[i].Bill.ToString();
                        }
                    }
                }
            }
        }

        private void RemoveLbl()
        {
            for (int i = 0; i < pnlPayTable.Controls.Count; i++)
            {
                if (pnlPayTable.Controls[i].GetType() == typeof(Label))
                {
                    if (lbl.Text == $"Cost{i}" || lbl.Name == $"Quest{i}")
                    {
                        pnlPayTable.Controls.Remove(lbl);
                    }
                }
            }
        }
        private void cbDiscount_SelectedIndexChanged(object sender, EventArgs e)
        {
            float discount = Convert.ToInt32(Regex.Replace(cbDiscount.SelectedItem.ToString(), @"[^\d]+", ""));
            ViewModel.MakeDiscount(discount);
            UpdateCostLbl();
            cbDiscount.Enabled = false;
        }

        private void btSeparateBill_Click(object sender, EventArgs e)
        {
            lblJoin.Visible = true;
            checkedListBoxBill.Visible = true;
            for (int i = 0; i < ViewModel.currentOrder.Quests.Count; i++)
            {
                checkedListBoxBill.Items.Insert(i, $"Гость {i + 1}");
            }
        }

        private void btPay_Click(object sender, EventArgs e)
        {
            if (checkedListBoxBill.CheckedIndices.Count > 0)
            {
                int count = checkedListBoxBill.CheckedIndices.Count;

                for (int i = 0; i < count; i++)
                {
                    checkedListBoxBill.Items.RemoveAt(checkedListBoxBill.CheckedIndices[0]);
                    
                }
            }
            if (checkedListBoxBill.Items.Count == 0)
            {
                ViewModel.ChangeStatus();
                MessageBox.Show("Заказ оплачен!", "Оплата", MessageBoxButtons.OK, MessageBoxIcon.Information);
                pnlAddQuest.Visible = false;
                pnlOrders.Visible = false;
                pnlPayTable.Visible = false;
                pnlTables.Visible = false;
                lblDiscount.Visible = false;
                lblJoin.Visible = false;
                cbDiscount.Visible = false;
                btMakeDiscount.Visible = false;
                checkedListBoxBill.Items.Clear();
                RemoveLbl();
            }
        }

        private void btCurrentOrders_Click(object sender, EventArgs e)
        {
            UpdateDGOrders(АРМ_курсовая.Status.Активен);
            pnlOrders.Visible = true;
            pnlAddQuest.Visible = false;
            pnlTables.Visible = false;
            lblPay.Visible = false;
            btPayTable.Visible = false;
            numericTable.Visible = false;
            pnlPayTable.Visible = false;
            lblAverageBill.Visible = true;
            tbAverageBill.Visible = true;
            lblChange.Visible = false;
            btChange.Visible = false;
            tbAverageBill.Text = ViewModel.CountingAverageBill(АРМ_курсовая.Status.Активен).ToString();
        }

        private void btMakeChages_Click(object sender, EventArgs e)
        {
            UpdateDGOrders(АРМ_курсовая.Status.Активен);
            pnlOrders.Visible = true;
            pnlAddQuest.Visible = false;
            pnlTables.Visible = false;
            lblPay.Visible = false;
            btPayTable.Visible = false;
            numericTable.Visible = true;
            pnlPayTable.Visible = false;
            lblAverageBill.Visible = false;
            tbAverageBill.Visible = false;
            lblChange.Visible = true;
            btChange.Visible = true;

        }

        private void btClosedOrders_Click(object sender, EventArgs e)
        {
            UpdateDGOrders(АРМ_курсовая.Status.Завершен);
            pnlOrders.Visible = true;
            pnlAddQuest.Visible = false;
            pnlTables.Visible = false;
            lblPay.Visible = false;
            btPayTable.Visible = false;
            numericTable.Visible = false;
            pnlPayTable.Visible = false;
            lblAverageBill.Visible = true;
            tbAverageBill.Visible = true;
            lblChange.Visible = false;
            btChange.Visible = false;
            tbAverageBill.Text = ViewModel.CountingAverageBill(АРМ_курсовая.Status.Завершен).ToString();
        }

        private void btChange_Click(object sender, EventArgs e)
        {
            bool Flag = false;
            for (int i = 0; i < ViewModel.allOrders.Orders.Count; i++)
            {
                if (ViewModel.allOrders.Orders[i].NumberTable == Convert.ToInt32(numericTable.Value))
                {
                    if (ViewModel.allOrders.Orders[i].Status == АРМ_курсовая.Status.Активен)
                    {
                        Flag = true;
                        pnlOrders.Visible = false;
                        pnlAddQuest.Visible = true;
                        pnlTables.Visible = false;
                        pnlPayTable.Visible = false;
                        ViewModel.FindOrder(Convert.ToInt32(numericTable.Value));
                        ViewModel.currentQuest = ViewModel.currentOrder.Quests[0];
                        ViewModel.currentNumberTable = ViewModel.currentOrder.NumberTable;
                        lblNumberTable.Text = ViewModel.currentNumberTable.ToString();
                        ViewModel.NumberEmptySeats = ViewModel.CheckTable(Convert.ToInt32(ViewModel.currentNumberTable));
                        lblEmptySeats.Text = ViewModel.NumberEmptySeats.ToString();
                        BlockButtons();
                        UpdateMenuQuests();
                        //btSaveOrder.Visible = true;
                        ViewModel.DeleteOrder(ViewModel.currentOrder);
                        break;
                    }
                    else
                        MessageBox.Show("Вы не можете менять завершенные заказы.", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
                }
            }
            if (!Flag)
            {
                MessageBox.Show("Такого заказа не существует", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
           
        }
        private void btSaveOrder_Click(object sender, EventArgs e)
        {
            if (ViewModel.CheckQuests())
            {
                ViewModel.AddOrder(ViewModel.currentOrder);
                MessageBox.Show("Заказ сохранен!", "Сохранение", MessageBoxButtons.OK, MessageBoxIcon.Information);
                pnlAddQuest.Visible = false;
                ViewModel.currentOrder.Quests.Clear();
                ViewModel.currentQuest.Dishes.Clear();
                ViewModel.currentOrder = null;
                ViewModel.currentQuest = null;
                ViewModel.currentDish = null;
                pnlAddQuest.Visible = false;
                UnblockButtons();
            }
            else
                MessageBox.Show("Вы не можете сохранить заказ, пока у одного из гостей не добавлены блюда", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
