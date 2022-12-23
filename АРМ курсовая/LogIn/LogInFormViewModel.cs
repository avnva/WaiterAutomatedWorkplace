using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using АРМ_курсовая;

namespace АРМ_курсовая
{
    public class LogInFormViewModel
    {
        public LogIn logIn;

        public CurrentSession currentSession;

        public LogInFormViewModel(Account CurrentAccount)
        {
            currentSession.Load();
            currentSession = new CurrentSession(CurrentAccount);
        }

        public bool CheckAccount(string login, string password, out Account currentAccount)
        {
            return logIn.CheckAccount(login, password, out currentAccount);
        }

        public LogInFormViewModel()
        {
            try
            {
                logIn = new LogIn();
                currentSession = new CurrentSession();
            }
            catch (FileNotFoundException ex)
            {
                MessageBox.Show(ex.Message, "Критическая ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Environment.Exit(1);
            }
        }
    }
}
