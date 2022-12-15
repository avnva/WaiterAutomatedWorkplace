using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using АРМ_курсовая.Resources;

namespace АРМ_курсовая
{
    public partial class MainForm : Form
    {
        public MainFormViewModel ViewModel;
        public Waiter CurrentWaiter;
        
        public MainForm(Waiter CurrentWaiter)
        {
            InitializeComponent();
            ViewModel = new MainFormViewModel(CurrentWaiter);
            this.lblLogin.Text = $"{ViewModel.currentSession.CurrentWaiter.accountdata.Login}";
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
            
        }

        private void pnlTables_Paint(object sender, PaintEventArgs e)
        {
            Button[] tables = this.pnlTables.Controls.OfType<Button>().ToArray<Button>();
            Sort_tables(tables);
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
    }
}
