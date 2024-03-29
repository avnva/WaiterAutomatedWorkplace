﻿using System;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace АРМ_курсовая
{
    public partial class SignInForm : Form
    {
        public SignInFormViewModel ViewModel;
        public SignInForm(Account CurrentAccount, bool mode)
        {
            InitializeComponent();
            if (mode) 
            {
                lblSignInWorker.Visible = true;
                lblSignInWaiter.Visible = false;
                rbWaiter.Visible = true;
                rbAdmin.Visible = true;
            }
            
            ViewModel = new SignInFormViewModel(CurrentAccount);
            DialogResult = DialogResult.None;
        }
        private void btSignIn_Click(object sender, EventArgs e)
        {
            try
            {
                if (rbAdmin.Visible)
                {
                    ViewModel.AddAccount(new Account(tbNewName.Text, tbNewPassword.Text, rbAdmin.Checked ? Role.Admin : Role.Waiter));
                }
                else
                    ViewModel.AddAccount(new Account(tbNewName.Text, tbNewPassword.Text, Role.Waiter));

                MessageBox.Show("Аккаунт успешно зарегистрирован.", "Регистрация", MessageBoxButtons.OK, MessageBoxIcon.Information);
                DialogResult = DialogResult.OK;
                Program.PreviousPage.Show();
                Close();
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show(ex.Message, "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void btBack_Click(object sender, EventArgs e)
        {
            Program.PreviousPage.Show();
            Close();
        }
    }
}


