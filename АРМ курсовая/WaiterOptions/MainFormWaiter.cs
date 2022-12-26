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
        public MainFormWaiter(Account currentAccount)
        {
            InitializeComponent();
            ViewModel = new MainFormWaiterViewModel(currentAccount);
            SetDGSelectedDishes();
            SetPnlTables();

            lblLogin.Text = $"{currentAccount.Login}";
            ClosePanels();

            cbCategoryDish.DropDownStyle = ComboBoxStyle.DropDownList;
            cbDiscount.DropDownStyle = ComboBoxStyle.DropDownList;
            menuQuests.Items[0].Click += new EventHandler(itemQuest_Click);

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
        private void ClosePanels()
        {
            pnlTables.Visible = false;
            pnlAddQuest.Visible = false;
            pnlOrders.Visible = false;
            pnlPayTable.Visible = false;
            btSaveOrder.Visible = false;

            lblPay.Visible = false;
            btPayTable.Visible = false;
            numericTable.Visible = false;
            lblAverageBill.Visible = false;
            tbAverageBill.Visible = false;
            lblChange.Visible = false;
            btChange.Visible = false;

            lblDiscount.Visible = false;
            cbDiscount.Visible = false;
            lblJoin.Visible = false;
            checkedListBoxBill.Visible = false;
        }

        //Настройка таблиц
        //Установка таблицы выбранных блюд
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
        private void UpdateDataGVSelectedDishes(List<Dish> dishes)
        {
            int quantity = 0;
            dataGVSelectedDishes.Rows.Clear();
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

        private bool CheckMatchDishesDG(Dish dish, int quantity)
        {
            for (int i = 0; i < dataGVSelectedDishes.RowCount; i++)
            {
                if (dataGVSelectedDishes[0, i].Value.ToString() == dish.Name)
                {
                    if (int.TryParse(dataGVSelectedDishes[1, i].Value.ToString(), out int currentQuantity))
                    {
                        dataGVSelectedDishes[1, i].Value = currentQuantity + quantity;
                        dataGVSelectedDishes[2, i].Value = dish.Cost * (currentQuantity + quantity);
                        return true;
                    }
                }
            }
            return false;
        }

        //Настройка таблицы меню
        private void UpdateDGMenu(string category)
        {
            dishForBindingBindingSource.Clear();
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
        private void cbCategoryDish_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateDGMenu(cbCategoryDish.SelectedItem.ToString());
        }

        //Установка номеров строк
        private void dataGridView_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            object headValue = ((DataGridView)sender).Rows[e.RowIndex].HeaderCell.Value;
            if (headValue == null || !headValue.Equals((e.RowIndex + 1).ToString()))
                ((DataGridView)sender).Rows[e.RowIndex].HeaderCell.Value = ((e.RowIndex + 1).ToString());
        }

        //Настройка таблицы заказов
        private void UpdateDGOrders(Status status)
        {
            orderForBindingBindingSource.Clear();
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

        //Настройка панели с картой столов
        private void SetPnlTables()
        {
            Button[] tables = this.pnlTables.Controls.OfType<Button>().ToArray<Button>();
            Sort_tables(tables);
            foreach (Button item in tables)
            {
                item.Click += TablesBtn_Click;
            }
        }
        private void TablesBtn_Click(object sender, EventArgs e)
        {
            Button click = sender as Button;
            int NumTable = Convert.ToInt32(click.TabIndex) - 1;
            ViewModel.NumberEmptySeats = ViewModel.tables[NumTable].numberOfSeats;
            ViewModel.NumberEmptySeats = ViewModel.CheckTable(NumTable + 1);

            if (ViewModel.NumberEmptySeats == ViewModel.tables[NumTable].numberOfSeats)
            {
                string message = $"Стол № {click.Text}\n" +
                    $"Количество мест: {ViewModel.NumberEmptySeats}\n" +
                    $"Добавить гостя?";
                if (MessageBox.Show(message, "Информация", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                {
                    ViewModel.NumberEmptySeats -= 1;
                    ViewModel.currentNumberTable = Convert.ToInt32(click.TabIndex);
                    ViewModel.index = 0;
                    ViewModel.currentQuest = new Quest();

                    ClosePanels();
                    pnlAddQuest.Visible = true;
                    lblNumberTable.Text = click.TabIndex.ToString();
                    lblEmptySeats.Text = ViewModel.NumberEmptySeats.ToString();
                    BlockButtons();
                }
            }
            else if (ViewModel.NumberEmptySeats > 0)
            {
                if (MessageBox.Show("Этот стол уже занят.\nВы уверены, что хотите добавить еще одного гостя?\n" +
                    $"Количество свободных мест: {ViewModel.NumberEmptySeats}", "Информация", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                {
                    ViewModel.NumberEmptySeats -= 1;
                    ViewModel.FindOrder(NumTable + 1);
                    ViewModel.index = ViewModel.currentOrder.Quests.Count;
                    ViewModel.currentQuest = new Quest();
                    ViewModel.currentOrder.Quests.Add(ViewModel.currentQuest);
                    ViewModel.DeleteOrder();

                    ClosePanels();
                    pnlAddQuest.Visible = true;
                    lblNumberTable.Text = click.TabIndex.ToString();
                    lblEmptySeats.Text = ViewModel.NumberEmptySeats.ToString();
                    BlockButtons();
                    UpdateMenuQuests();
                }
            }
            else
                MessageBox.Show("За этим столом не осталось свободных мест", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void Sort_tables(Button[] tables)
        {
            Button temp;
            for (int i = 0; i < tables.Length - 1; i++)
            {
                for (int j = 0; j < tables.Length - i - 1; j++)
                {
                    if (int.TryParse(tables[j].Text, out int Numberj) && int.TryParse(tables[j + 1].Text, out int Numberj1))
                    {
                        if (Numberj > Numberj1)
                        {
                            temp = tables[j];
                            tables[j] = tables[j + 1];
                            tables[j + 1] = temp;
                        }
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
            ClosePanels();
            pnlTables.Visible = true;
            ViewModel.currentOrder = null;
            ViewModel.currentQuest = null;
            ViewModel.currentDish = null;
        }

        private void btAddDishToQuest_Click(object sender, EventArgs e)
        {
            try 
            {
                ViewModel.CheckDish(ViewModel.currentDish);
                for (int i = 0; i < DishCounter.Value; i++)
                {
                    ViewModel.AddDish(ViewModel.currentDish);
                }
                if (CheckMatchDishesDG(ViewModel.currentDish, Convert.ToInt32(DishCounter.Value)) != true)
                {
                    dataGVSelectedDishes.Rows.Add(ViewModel.currentDish.Name, Convert.ToInt32(DishCounter.Value), ViewModel.currentDish.Cost * Convert.ToInt32(DishCounter.Value));
                }
                DishCounter.Value = 1;
                lblNameDish.Text = "";
                ViewModel.currentDish = null;
                ViewModel.SaveQuests(ViewModel.index);
                btSaveOrder.Visible = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }    
        }
        private void btDeleteDish_Click(object sender, EventArgs e)
        {
            if (dataGVSelectedDishes.CurrentCell != null)
            {
                string NameDish = dataGVSelectedDishes[0, dataGVSelectedDishes.CurrentCell.RowIndex].Value.ToString();
                ViewModel.DeleteDish(NameDish);
                UpdateDataGVSelectedDishes(ViewModel.currentQuest.Dishes);
                ViewModel.SaveQuests(ViewModel.index);
                if (ViewModel.currentQuest.Dishes.Count == 0)
                {
                    btSaveOrder.Visible = false;
                }
            }
            else
                MessageBox.Show("Блюдо для удаления не выбрано", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void btAddQuestToSelectedTable_Click(object sender, EventArgs e)
        {
            if (ViewModel.NumberEmptySeats != 0)
            {
                try
                {
                    ViewModel.CheckQuestsAdd();
                    ViewModel.NumberEmptySeats -= 1;
                    lblEmptySeats.Text = ViewModel.NumberEmptySeats.ToString();
                    ViewModel.currentQuest = new Quest();
                    ViewModel.currentOrder.Quests.Add(ViewModel.currentQuest);
                    AddItem();
                    btSaveOrder.Visible = false;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
                MessageBox.Show("За этим столом не осталось свободных мест", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        //Работа с панелью гостей
        private void AddItem()
        {
            int CountItems = 0;
            foreach (ToolStripItem toolItem in menuQuests.Items)
            {
                CountItems += 1;
            }
            ToolStripItem item = new ToolStripMenuItem
            {
                Text = $"Гость {CountItems + 1}",
                Name = $"Quest{CountItems}"
            };
            menuQuests.Items.Add(item);
            item.Click += new EventHandler(itemQuest_Click);
            EventArgs a = new EventArgs();
            itemQuest_Click(item, a);
        }
        private void itemQuest_Click(object sender, EventArgs e)
        {
            ToolStripItem ClickItem = sender as ToolStripItem;
            ViewModel.index = Convert.ToInt32(Regex.Replace(ClickItem.Name, @"[^\d]+", ""));

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
                ViewModel.currentQuest = ViewModel.currentOrder.Quests[ViewModel.index];
                UpdateDataGVSelectedDishes(ViewModel.currentQuest.Dishes);
            }
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

        private void btDeleteQuest_Click(object sender, EventArgs e)
        {
            if (ViewModel.currentOrder != null && ViewModel.currentOrder.Quests.Count > 1)
            {
                ViewModel.DeleteQuest();
                ViewModel.NumberEmptySeats += 1;
                lblEmptySeats.Text = ViewModel.NumberEmptySeats.ToString();
                menuQuests.Items.Remove(menuQuests.Items[ViewModel.index]);
                UpdateMenuQuests();
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
                ViewModel.currentOrder?.Quests.Clear();
                ViewModel.currentQuest.Dishes.Clear();
                ViewModel.currentOrder = null;
                ViewModel.currentQuest = null;
                ViewModel.currentDish = null;
                pnlAddQuest.Visible = false;
                UnblockButtons();
            }
        }
        private void btSaveOrder_Click(object sender, EventArgs e)
        {
            try
            {
                ViewModel.CheckQuestsSave();
                ViewModel.AddOrder(ViewModel.currentOrder);
                MessageBox.Show("Заказ сохранен!", "Сохранение", MessageBoxButtons.OK, MessageBoxIcon.Information);
                pnlAddQuest.Visible = false;
                ViewModel.currentOrder.Quests.Clear();
                ViewModel.currentQuest.Dishes.Clear();
                ViewModel.currentOrder = null;
                ViewModel.currentQuest = null;
                ViewModel.currentDish = null;
                ClosePanels();
                UnblockButtons();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        
        //Расчет стола
        private void btPayOrder_Click(object sender, EventArgs e)
        {
            ClosePanels();
            pnlOrders.Visible = true;
            lblPay.Visible = true;
            btPayTable.Visible = true;
            numericTable.Visible = true;

            UpdateDGOrders(АРМ_курсовая.Status.Active);
        }
        private void btPayTable_Click(object sender, EventArgs e)
        {
            try
            {
                ViewModel.FindOrder(Convert.ToInt32(numericTable.Value));
                ClosePanels();
                pnlOrders.Visible = true;
                pnlPayTable.Visible = true;

                int CountQuest = ViewModel.currentOrder.Quests.Count;
                lblTable.Text = $"Стол№ {ViewModel.currentOrder.NumberTable}";
                lblNumberQuests.Text = $"Гостей всего: {CountQuest}";
                lblCost.Text = $"Общая сумма: {ViewModel.currentOrder.TotalBill}";
                SetLabel(CountQuest);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btMakeDiscount_Click(object sender, EventArgs e)
        {
            if (lblDiscount.Visible == false)
            {
                lblDiscount.Visible = true;
                cbDiscount.Visible = true;
                cbDiscount.Enabled = true;
            }
            else
            {
                if (cbDiscount.SelectedItem != null)
                {
                    ViewModel.BringBackCost();
                    UpdateCostLbl();
                    lblDiscount.Visible = false;
                    cbDiscount.Visible = false;
                }
                else
                    MessageBox.Show("Категория не выбрана!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void cbDiscount_SelectedIndexChanged(object sender, EventArgs e)
        {
            float discount = Convert.ToInt32(Regex.Replace(cbDiscount.SelectedItem.ToString(), @"[^\d]+", ""));
            ViewModel.MakeDiscount(discount);
            UpdateCostLbl();
            cbDiscount.Enabled = false;
        }

        //Работа с Label
        private void SetLabel(int Count)
        {
            Label[] labelQuest = new Label[Count];
            Label[] labelCost = new Label[Count];
            for (int j = 0; j < Count; j++)
            {
                labelQuest[j] = new Label
                {
                    Name = $"Quest{j}",
                    Location = new Point(65, 110 + j * 40),
                    Text = $"Гость {j + 1}:",
                    Visible = true
                };
                pnlPayTable.Controls.Add(labelQuest[j]);

                labelCost[j] = new Label
                {
                    Name = $"Cost{j}",
                    Location = new Point(170, 110 + j * 40),
                    Text = ViewModel.currentOrder.Quests[j].Bill.ToString(),
                    Visible = true
                };
                pnlPayTable.Controls.Add(labelCost[j]);
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

        private void btSeparateBill_Click(object sender, EventArgs e)
        {
            lblJoin.Visible = true;
            checkedListBoxBill.Visible = true;
            checkedListBoxBill.Items.Clear();
            for (int i = 0; i < ViewModel.currentOrder.Quests.Count; i++)
            {
                checkedListBoxBill.Items.Insert(i, $"Гость {i + 1}");
            }
        }

        private void btPay_Click(object sender, EventArgs e)
        {
            int CountCheck = checkedListBoxBill.CheckedIndices.Count;
            if (CountCheck > 0)
            {
                for (int i = 0; i < CountCheck; i++)
                {
                    checkedListBoxBill.Items.RemoveAt(checkedListBoxBill.CheckedIndices[0]);
                }
            }
            else
                MessageBox.Show("Гости не выбраны!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);

            if (checkedListBoxBill.Items.Count == 0)
            {
                ViewModel.ChangeStatus();
                MessageBox.Show("Заказ оплачен!", "Оплата", MessageBoxButtons.OK, MessageBoxIcon.Information);
                checkedListBoxBill.Items.Clear();
                RemoveLbl();
                ClosePanels();
            } 
        }

        private void btCurrentOrders_Click(object sender, EventArgs e)
        {
            UpdateDGOrders(АРМ_курсовая.Status.Active);
            ClosePanels();
            pnlOrders.Visible = true;
            lblAverageBill.Visible = true;
            tbAverageBill.Visible = true;
            tbAverageBill.Text = ViewModel.CountingAverageBill(АРМ_курсовая.Status.Active).ToString();
        }

        private void btMakeChages_Click(object sender, EventArgs e)
        {
            UpdateDGOrders(АРМ_курсовая.Status.Active);
            ClosePanels();
            pnlOrders.Visible = true;
            numericTable.Visible = true;
            lblChange.Visible = true;
            btChange.Visible = true;
        }
        private void btChange_Click(object sender, EventArgs e)
        {
            try
            {
                ViewModel.FindOrder(Convert.ToInt32(numericTable.Value));
                ViewModel.currentQuest = ViewModel.currentOrder.Quests[0];
                ViewModel.currentNumberTable = ViewModel.currentOrder.NumberTable;
                ViewModel.NumberEmptySeats = ViewModel.CheckTable(ViewModel.currentNumberTable);
                ViewModel.DeleteOrder();
                UpdateMenuQuests();

                lblNumberTable.Text = ViewModel.currentNumberTable.ToString();
                lblEmptySeats.Text = ViewModel.NumberEmptySeats.ToString();
                ClosePanels();
                BlockButtons();
                pnlAddQuest.Visible = true;
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }

        private void btClosedOrders_Click(object sender, EventArgs e)
        {
            UpdateDGOrders(АРМ_курсовая.Status.Complete);
            ClosePanels();
            pnlOrders.Visible = true;
            lblAverageBill.Visible = true;
            tbAverageBill.Visible = true;
            tbAverageBill.Text = ViewModel.CountingAverageBill(АРМ_курсовая.Status.Complete).ToString();
        }

        private void btBack_Click(object sender, EventArgs e)
        {
            ClosePanels();
        }
    }
}
