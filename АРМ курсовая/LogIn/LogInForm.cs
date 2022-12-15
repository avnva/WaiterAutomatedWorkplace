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
        public Waiter CurrentWaiter;

        public LogInForm()
        {
            InitializeComponent();
        }

        public Waiter GetCurrentWaiter
        {
            get { return CurrentWaiter; }
        }

        private void btLogIn_Click(object sender, EventArgs e)
        {
            if (ViewModel.CheckWaiter(tbLogin.Text, tbPassword.Text, out CurrentWaiter))
            {
                Hide();
                MainForm mainForm = new MainForm(CurrentWaiter);
                mainForm.ShowDialog();
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
            SignInForm signinform = new SignInForm(CurrentWaiter);
            signinform.Show();
        }
    }
}
