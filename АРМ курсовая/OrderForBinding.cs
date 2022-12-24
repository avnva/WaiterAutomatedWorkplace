using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace АРМ_курсовая
{
    internal class OrderForBinding
    {
        public int NumberTable { get; set; }
        public int CountQuests { get; set; }
        public float Bill { get; set; }
        public OrderForBinding(int numberTable, int countQuest, float bill)
        {
            NumberTable = numberTable;
            CountQuests = countQuest;
            Bill = bill;
        }
    }
}
