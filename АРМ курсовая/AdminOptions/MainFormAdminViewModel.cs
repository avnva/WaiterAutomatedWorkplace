using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using АРМ_курсовая;

namespace АРМ_курсовая
{
    public class MainFormAdminViewModel
    {
        public CurrentSession currentSession;
        public Menu menu;
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
            menu.Load();
        }

        public void DeleteAccount(string Login)
        {
            bool flag = false;
            foreach (Account account in currentSession.Accounts)
            {
                if (account.Login == Login)
                {
                    try
                    {
                        currentSession.DeleteAccount(account);
                        flag = true;
                        MessageBox.Show("Аккаунт успешно удален", "Удаление", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        break;
                    }
                    catch (ArgumentException ex)
                    {
                        MessageBox.Show(ex.Message, "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            if (!flag)
            {
                MessageBox.Show("Такой аккаунт не существует!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void AddDish(Dish dish)
        {
            menu.Load();
            if (menu.Dishes== null)
            {
                menu = new Menu(dish);
            }
            bool flag = true;
            foreach (Dish i in menu.Dishes)
            {
                if (dish.Name == i.Name)
                {
                    flag = false;
                    break;
                }
            }
            if (flag)
            {
                menu.AddDish(dish);
            }
            else
                throw new Exception("Не удалось добавить блюдо, так как такое блюдо уже существует.");
        }

        public void EditDish(Dish dish, int number)
        {
            menu.Load();
            menu.EditDish(dish, number);
            for (int i = 0; i < menu.Dishes.Count; i++)
            {
                if (i == number - 1)
                {
                    if (menu.Dishes[i].Name != dish.Name || menu.Dishes[i].Cost != dish.Cost || menu.Dishes[i].Category != dish.Category)
                    {
                        menu.EditDish(dish, number - 1);
                    }
                    else
                        throw new ArgumentException("Такое блюдо уже существует!");
                }
            }
        }

        public void DeleteDish(int number)
        {
            menu.Load();
            try
            {
                menu.DeleteDish(number - 1);
                MessageBox.Show("Блюдо было успешно удалено", "Удаление", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch 
            {
                MessageBox.Show("Такое блюдо не существует!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
