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
    public partial class LogInForm : Form
    {
        public LogInFormViewModel ViewModel = new LogInFormViewModel();
        public Account CurrentAccount;

        public LogInForm()
        {
            InitializeComponent();
            Program.PreviousPage = this;
        }

        public Account GetCurrentAccount
        {
            get { return CurrentAccount; }
        }

        private void btLogIn_Click(object sender, EventArgs e)
        {
            if (ViewModel.CheckAccount(tbLogin.Text, tbPassword.Text, out CurrentAccount))
            {
                
                if (CurrentAccount.Role == Role.Waiter) 
                {
                    MainFormWaiter waiterForm = new MainFormWaiter(CurrentAccount);
                    waiterForm.ShowDialog();
                }
                else
                {
                    MainFormAdmin adminForm = new MainFormAdmin(CurrentAccount, null);
                    adminForm.ShowDialog();
                }
                Close();
            }
            else
            {
                MessageBox.Show("Введен неверный логин или пароль.",
                    "Ошибка авторизации!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void linkSignIn_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Hide();
            SignInForm signinform = new SignInForm(CurrentAccount, false);
            signinform.Show();
        }
    }
}
