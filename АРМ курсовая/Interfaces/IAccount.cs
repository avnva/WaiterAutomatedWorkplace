using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace АРМ_курсовая.Interfaces
{
    public interface IAccount
    {
        byte[] Hash { get; set; }
        string Login { get; set; }
        string Password { get; set; }
        Role Role { get; set; }
    }
}
