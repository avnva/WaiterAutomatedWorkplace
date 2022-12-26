using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace АРМ_курсовая.Interfaces
{
    public interface IDish
    {
        string Name { get; set; }
        int Cost { get; set; }
        string Category { get; set; }
    }
}
