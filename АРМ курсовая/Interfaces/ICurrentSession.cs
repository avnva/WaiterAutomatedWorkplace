using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace АРМ_курсовая
{
    public interface ICurrentSession
    {
        void Load();
        void AddAccount(Account currentAccount);
        void DeleteAccount(int index);
    }
}
