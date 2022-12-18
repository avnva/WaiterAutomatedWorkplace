using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using АРМ_курсовая.Resources;

namespace АРМ_курсовая
{
    public class MainFormAdminViewModel
    {
        public CurrentSession currentSession;
        Menu menu;
        public MainFormAdminViewModel()
        {
            try
            {
                menu = new Menu();
            }
            catch (FileNotFoundException ex)
            {
                MessageBox.Show(ex.Message, "Критическая ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Environment.Exit(1);
            }
        }

        public MainFormAdminViewModel(Account CurrentAccount, Dish CurrentDish)
        {
            currentSession = new CurrentSession(CurrentAccount);
            currentSession.Load();
            menu = new Menu(CurrentDish);
        }

        //public MainFormAdminViewModel(Account CurrentAccount)
        //{
        //    currentSession = new CurrentSession(CurrentAccount);
        //    currentSession.Load();
        //}
        public void DeleteAccount(string Login)
        {
            foreach (Account account in currentSession.Accounts)
            {
                if (account.Login == Login)
                {
                    try
                    {
                        currentSession.DeleteAccount(account);
                        MessageBox.Show("Аккаунт успешно удален", "Удаление", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        break;
                    }
                    catch (ArgumentException ex)
                    {
                        MessageBox.Show(ex.Message, "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
        public void AddDish(Dish dish)
        {
            menu.Load1();
            if (menu.Dishes== null)
            {
                menu = new Menu(dish);
            }
            menu.AddDish(dish);
        }
    }
}
