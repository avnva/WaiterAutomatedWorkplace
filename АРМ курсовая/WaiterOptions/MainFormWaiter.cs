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
    public partial class MainFormWaiter : Form
    {
        public MainFormWaiterViewModel ViewModel;
        public Account CurrentAccount;
        public Order NewOrder;


        public MainFormWaiter(Account CurrentAccount)
        {
            InitializeComponent();

            this.lblLogin.Text = $"{CurrentAccount.Login}";
            pnlTables.Visible = false;
            ViewModel = new MainFormWaiterViewModel();
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
            //MainFormWaiterViewModel ViewModel = new MainFormWaiterViewModel(NewOrder);
            //MainFormWaiterViewModel.AddOrder(NewOrder);
        }

        private void pnlTables_Paint(object sender, PaintEventArgs e)
        {
            Button[] tables = this.pnlTables.Controls.OfType<Button>().ToArray<Button>();
            Sort_tables(tables);
            foreach (var item in pnlTables.Controls) //обходим все элементы формы
            {
                if (item is Button) // проверяем, что это кнопка
                {
                    ((Button)item).Click += TablesBtn_Click; //приводим к типу и устанавливаем обработчик события  
                }
            }
        }
        private void TablesBtn_Click(object sender, EventArgs e)
        {
            Button click = sender as Button;
            // if quests != 0 - за столом уже есть гости, вы уверены, что хотите добавить еще?
            string message = $"Стол № {click.Text}\n" +
                $"Статус: {ViewModel.tables[Convert.ToInt32(click.TabIndex)].status}\n" +
                $"Количество мест: {ViewModel.tables[Convert.ToInt32(click.TabIndex)].numberOfSeats}\n" +
                $"Добавить гостя?";
            if (MessageBox.Show(message, "Информация", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
            {

            }
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
