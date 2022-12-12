using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using АРМ_курсовая.Resources;

namespace АРМ_курсовая
{
    public partial class SignInForm : Form
    {
        public SignInFormViewModel ViewModel;
        public SignInForm(Waiter CurrentWaiter)
        {
            InitializeComponent();
            ViewModel = new SignInFormViewModel(CurrentWaiter);
            DialogResult = DialogResult.None;
        }
        private void btSignIn_Click(object sender, EventArgs e)
        {
            try
            {
                Waiter current = new Waiter(new AccountData(tbNewName.Text, tbNewPassword.Text));
                ViewModel.AddWaiter(current);
                MessageBox.Show("Аккаунт успешно зарегистрирован.", "Регистрация", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LogInForm loginForm = new LogInForm();
                loginForm.ShowDialog();
                Close();
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
