using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel;
using System.Text;
using System.Threading.Tasks;

namespace АРМ_курсовая
{
    public class DishForBinding
    {
        public string Category { get; set; }
        public string Name { get; set; }
        public int Cost { get; set; }
        public DishForBinding(string category, string name, int cost)
        {
            Category = category;
            Name = name;
            Cost = cost;
        }
    }
}
