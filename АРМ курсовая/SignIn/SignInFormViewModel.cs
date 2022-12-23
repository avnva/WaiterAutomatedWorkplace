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
    public class SignInFormViewModel
    {
        CurrentSession currentSession;

        public SignInFormViewModel()
        {
            try
            {
                currentSession = new CurrentSession();
            }
            catch (FileNotFoundException ex)
            {
                MessageBox.Show(ex.Message, "Критическая ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Environment.Exit(1);
            }
        }

        public SignInFormViewModel(Account CurrentAccount)
        {
            currentSession = new CurrentSession(CurrentAccount);
        }


        public void AddAccount(Account account)
        {
            currentSession.Load();
            if (currentSession.Accounts == null)
            {
                currentSession = new CurrentSession(account);
            }
            currentSession.AddAccount(account);
        }

    }
}
