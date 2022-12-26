using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace АРМ_курсовая
{
    public partial class MainFormAdmin : Form
    {
        public Account CurrentAccount;
        public Account Account;
        public MainFormAdminViewModel ViewModel;
        public MainFormAdmin(Account currentAccount, Dish dish)
        {
            InitializeComponent();
            Program.PreviousPage = this;
            ViewModel = new MainFormAdminViewModel(currentAccount, dish);
            CurrentAccount = currentAccount;
            ClosePanels();
            pnlMain.Visible = true;
            UpdateDGMenu();
            cbCategory.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        private void ClosePanels()
        {
            pnlEditDish.Visible = false;
            pnlMain.Visible = false;
            pnlAddDish.Visible = false;
            pnlDeleteWorker.Visible = false;

            btBack.Visible = false;
            btMakeChanges.Visible = false;
            btAddNewDish.Visible = false;
            btEdit.Visible = false;
            btDeleteDish.Visible = false;

            lblEdit.Visible = false;
            lblAdd.Visible = false;
            lblNumberDish.Visible = false;

            tbNewNameDish.Text = "";
            numCost.Value = 1;
            cbCategory.SelectedItem = null;
        }
        //обновление базы данных
        private void UpdateDGMenu()
        {
            dishForBindingBindingSource.Clear();
            dataGVDishes.DataSource = dishForBindingBindingSource;
            foreach (Dish _dish in ViewModel.menu.Dishes)
            {
                dishForBindingBindingSource.Add(new DishForBinding(_dish.Category, _dish.Name, _dish.Cost));
            }
            dataGVDishes.RowPrePaint += dataGridView_RowPrePaint;
            dataGVDishes.RowHeadersWidth = 55;
        }

        //установка номеров строк
        private void dataGridView_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            object headValue = ((DataGridView)sender).Rows[e.RowIndex].HeaderCell.Value;
            if (headValue == null || !headValue.Equals((e.RowIndex + 1).ToString()))
                ((DataGridView)sender).Rows[e.RowIndex].HeaderCell.Value = ((e.RowIndex + 1).ToString());
        }

        private void btAddDishToMenu_Click(object sender, EventArgs e)
        {
            ClosePanels();
            pnlAddDish.Visible = true;
            btBack.Visible = true;
            lblAdd.Visible = true;
            btAddNewDish.Visible = true;
        }
        private void btRemoveDishFromMenu_Click(object sender, EventArgs e)
        {
            ClosePanels();
            btBack.Visible = true;
            pnlEditDish.Visible = true;
            btDeleteDish.Visible = true;
        }
        private void btEditDishInMenu_Click(object sender, EventArgs e)
        {
            ClosePanels();
            btBack.Visible = true;
            pnlEditDish.Visible = true;
            btEdit.Visible = true;
        }
        private void btAddWorker_Click(object sender, EventArgs e)
        {
            Hide();
            SignInForm signinform = new SignInForm(Account, true);
            signinform.ShowDialog();
        }
        private void btDeleteWorker_Click(object sender, EventArgs e)
        {
            ClosePanels();
            btBack.Visible = true;
            pnlEditDish.Visible = true;
            btEdit.Visible = true;
            pnlDeleteWorker.Visible = true;
        }
        private void btDeleteCurrentAccount_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Вы уверены, что хотите удалить этот аккаунт?", "Внимание!", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {
                Hide();
                ViewModel.DeleteAccount(CurrentAccount.Login);
                LogInForm loginform = new LogInForm();
                loginform.ShowDialog();
            }
        }
        private void btExit_Click(object sender, EventArgs e)
        {
            Hide();
            LogInForm loginform = new LogInForm();
            Program.PreviousPage = loginform;
            loginform.ShowDialog();
            Close();
        }
        private void btBack_Click(object sender, EventArgs e)
        {
            ClosePanels();
            pnlMain.Visible = true;
        }


        private void btAddNewDish_Click(object sender, EventArgs e)
        {
            try
            {
                ViewModel.AddDish(new Dish(tbNewNameDish.Text, Convert.ToInt32(numCost.Value), cbCategory.SelectedItem.ToString()));
                MessageBox.Show("Блюдо было успешно добавлено.", "Изменение меню", MessageBoxButtons.OK, MessageBoxIcon.Information);
                UpdateDGMenu();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btEdit_Click(object sender, EventArgs e)
        {
            try
            {
                Convert.ToInt32(numEditDish.Value);
                Dish i = ViewModel.menu.Dishes[Convert.ToInt32(numEditDish.Value) - 1];
                ClosePanels();
                pnlAddDish.Visible = true;
                btMakeChanges.Visible = true;
                lblEdit.Visible = true;
                btBack.Visible = true;
                lblNumberDish.Visible = true;

                tbNewNameDish.Text = i.Name;
                numCost.Value = i.Cost;
                cbCategory.SelectedItem = i.Category;
                lblNumberDish.Text = numEditDish.Value.ToString();
            }
            catch
            {
                MessageBox.Show("Такое блюдо не существует!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btMakeChanges_Click(object sender, EventArgs e)
        {
            try
            {
                int numberDish =  Convert.ToInt32(lblNumberDish.Text) - 1;
                ViewModel.EditDish(new Dish(tbNewNameDish.Text, Convert.ToInt32(numCost.Value), cbCategory.SelectedItem.ToString()), numberDish);
                MessageBox.Show("Блюдо было успешно изменено.", "Изменение меню", MessageBoxButtons.OK, MessageBoxIcon.Information);
                UpdateDGMenu();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void btDeleteDish_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Вы уверены, что хотите удалить блюдо?", "Внимание!", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {
                ViewModel.DeleteDish(Convert.ToInt32(numEditDish.Value));
                UpdateDGMenu();
            }
        }

        private void btDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Вы уверены, что хотите удалить этот аккаунт?", "Внимание!", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {
                try
                {
                    ViewModel.DeleteAccount(tbLogin.Text);
                    MessageBox.Show("Аккаунт успешно удален", "Удаление", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
        }
    }
}
