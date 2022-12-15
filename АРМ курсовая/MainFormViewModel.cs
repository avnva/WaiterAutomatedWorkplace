using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using АРМ_курсовая.Resources;

namespace АРМ_курсовая
{
    public class MainFormViewModel
    {
        public CurrentSession currentSession = new CurrentSession();
        public Order newOreder = new Order();
        public MainFormViewModel(Waiter CurrentWaiter)
        {
            currentSession = new CurrentSession(CurrentWaiter);
            currentSession.Load();
        } 

    }
}
