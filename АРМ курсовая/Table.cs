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
        
        public int number;
        public int numberOfSeats;
        public bool status;
        public static int countTables = 0;
        public Table()
        {
        }
        public Table(int _numberOfSeats)
        {
            countTables++;
            number = countTables;
            numberOfSeats = _numberOfSeats;
            status = false;
        }
    }
}
