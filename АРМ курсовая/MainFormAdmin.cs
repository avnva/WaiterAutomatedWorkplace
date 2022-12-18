using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
        }

        private void btAddWorker_Click(object sender, EventArgs e)
        {
            Hide();
            SignInForm signinform = new SignInForm(Account, true);
            signinform.ShowDialog();
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

        private void btAddDishToMenu_Click(object sender, EventArgs e)
        {
            pnlMain.Visible = false;
            pnlAddDish.Visible = true;

        }

        private void btAddNewDish_Click(object sender, EventArgs e)
        {
            try
            {
                ViewModel.AddDish(new Dish(tbNewNameDish.Text, Convert.ToInt32(numCost.Value), cbCategory.SelectedItem.ToString()));
                MessageBox.Show("Блюдо было успешно добавлено.", "Меню", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btBack_Click(object sender, EventArgs e)
        {
            pnlMain.Visible = true;
            pnlAddDish.Visible = false;
        }
    }
}
