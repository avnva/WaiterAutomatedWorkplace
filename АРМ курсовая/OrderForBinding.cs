using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace АРМ_курсовая
{
    internal class OrderForBinding
    {
        public int CountQuests { get; set; }
        public Quest Dishes { get; set; }
        public float Bill { get; set; }
        public OrderForBinding(int countQuest, Quest dishes, float bill)
        {
            CountQuests = countQuest;
            Dishes = dishes;
            Bill = bill;
        }
    }
}
