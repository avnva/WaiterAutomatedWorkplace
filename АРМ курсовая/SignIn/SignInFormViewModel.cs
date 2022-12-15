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
    public class SignInFormViewModel
    {
        CurrentSession currentSession;

        public SignInFormViewModel()
        {
            currentSession = new CurrentSession();
        }

        public SignInFormViewModel(Waiter CurrentWaiter)
        {
            currentSession = new CurrentSession(CurrentWaiter);
        }


        public void AddWaiter(Waiter waiter)
        {
            currentSession.Load();
            if (currentSession.Waiters == null)
            {
                currentSession = new CurrentSession(waiter);
            }

            currentSession.AddWaiter(waiter);
        }

    }
}
