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
        public string Waiter { get; set; }
        public DateTime Time { get; set; }
        public Status Status { get; set; } 
        public OrderForBinding(Status _status, int numberTable, int countQuest, float bill, string waiter, DateTime _time)
        {
            Status = _status;
            NumberTable = numberTable;
            CountQuests = countQuest;
            Bill = bill;
            Waiter = waiter;
            Time = _time;
        }
    }
}
