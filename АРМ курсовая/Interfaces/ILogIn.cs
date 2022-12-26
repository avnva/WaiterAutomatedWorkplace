using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace АРМ_курсовая
{
    public interface ILogIn
    {
        bool CheckAccount(string login, string password, out Account a);
    }
}
