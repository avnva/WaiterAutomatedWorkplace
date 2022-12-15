using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using АРМ_курсовая.Resources;

namespace АРМ_курсовая
{
    public class LogInFormViewModel
    {
        public LogIn logIn;

        public bool CheckWaiter(string login, string password, out Waiter waiter)
        {
            return logIn.CheckWaiter(login, password, out waiter);
        }

        public LogInFormViewModel()
        {
            try
            {
                logIn = new LogIn();
            }
            catch (FileNotFoundException ex)
            {
                MessageBox.Show(ex.Message, "Критическая ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Environment.Exit(1);
            }
        }
    }
}
