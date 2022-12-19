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
            pnlEditDish.Visible = false;
            pnlMain.Visible = true;
            pnlAddDish.Visible = false;
            btBack.Visible = false;
            UpdateDGMenu();

        }

        //обновление базы данных
        private void UpdateDGMenu()
        {
            dataGVDishes.DataSource = dishForBindingBindingSource;
            //ViewModel.currentSession.Dishes.Sort(new CompareApplicantsByID());
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
            pnlMain.Visible = false;
            pnlAddDish.Visible = true;
            pnlEditDish.Visible = false;
            btBack.Visible = true;
            lblEdit.Visible = false;
            lblAdd.Visible = true;
            lblNumberDish.Visible = false;
            btMakeChanges.Visible = false;
            btAddNewDish.Visible = true;
            tbNewNameDish.Text = "";
            numCost.Value = 1;
            cbCategory.SelectedItem = null;
        }
        private void btRemoveDishFromMenu_Click(object sender, EventArgs e)
        {
            btBack.Visible = true;
            pnlEditDish.Visible = true;
            pnlMain.Visible = false;
            pnlAddDish.Visible = false;
            btEdit.Visible = false;
            btDeleteDish.Visible = true;
            btMakeChanges.Visible = false;
            btAddNewDish.Visible = true;
        }
        private void btEditDishInMenu_Click(object sender, EventArgs e)
        {
            btBack.Visible = true;
            pnlEditDish.Visible = true;
            pnlMain.Visible = false;
            pnlAddDish.Visible = false;
            btEdit.Visible = true;
            btDeleteDish.Visible = false;
        }
        private void btAddWorker_Click(object sender, EventArgs e)
        {
            Hide();
            SignInForm signinform = new SignInForm(Account, true);
            signinform.ShowDialog();
        }
        private void btDeleteWorker_Click(object sender, EventArgs e)
        {

        }
        private void btDeleteCurrentAccount_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Вы уверены, что хотите удалить этот аккаунт?", "Внимание!", MessageBoxButtons.YesNo, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
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
            loginform.ShowDialog();
            Close();
        }
        private void btBack_Click(object sender, EventArgs e)
        {
            pnlMain.Visible = true;
            pnlAddDish.Visible = false;
            pnlEditDish.Visible = false;
            btBack.Visible = false;
        }


        private void btAddNewDish_Click(object sender, EventArgs e)
        {
            try
            {
                ViewModel.AddDish(new Dish(tbNewNameDish.Text, Convert.ToInt32(numCost.Value), cbCategory.SelectedItem.ToString()));
                MessageBox.Show("Блюдо было успешно добавлено.", "Изменение меню", MessageBoxButtons.OK, MessageBoxIcon.Information);
                dishForBindingBindingSource.Clear();
                UpdateDGMenu();
            }
            catch (ArgumentException ex)
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
                pnlMain.Visible = false;
                pnlAddDish.Visible = true;
                pnlEditDish.Visible = false;
                btBack.Visible = false;
                btMakeChanges.Visible = true;
                btAddNewDish.Visible = false;
                lblEdit.Visible = true;
                lblAdd.Visible = false;
                btBack.Visible = true;
                lblNumberDish.Visible = true;

                tbNewNameDish.Text = i.Name;
                numCost.Value = i.Cost;
                cbCategory.SelectedItem = i.Category;
                lblNumberDish.Text = numEditDish.Value.ToString();
            }
            catch
            {
                MessageBox.Show("Такое блюдо не существует!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btMakeChanges_Click(object sender, EventArgs e)
        {
            try
            {
                int numberDish =  Convert.ToInt32(lblNumberDish.Text);
                //////////////////////Строка ниже
                ViewModel.EditDish(new Dish(tbNewNameDish.Text, Convert.ToInt32(numCost.Value), cbCategory.SelectedItem.ToString()), numberDish);
                MessageBox.Show("Блюдо было успешно изменено.", "Изменение меню", MessageBoxButtons.OK, MessageBoxIcon.Information);
                dishForBindingBindingSource.Clear();
                UpdateDGMenu();
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btDeleteDish_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Вы уверены, что хотите удалить блюдо?", "Внимание!", MessageBoxButtons.YesNo, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {
                ViewModel.DeleteDish(Convert.ToInt32(numEditDish.Value));
                dishForBindingBindingSource.Clear();
                UpdateDGMenu();
            }
        }
    }
}
