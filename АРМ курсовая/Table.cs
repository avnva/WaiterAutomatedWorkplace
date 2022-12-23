using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace АРМ_курсовая
{
    public class Table
    {
        public int numberOfSeats;
        public bool status = false;
        public Table()
        {
        }
        public Table(int _numberOfSeats)
        {
            numberOfSeats = _numberOfSeats;
        }
    }
}
