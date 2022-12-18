using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace АРМ_курсовая
{
    public class Dish
    {
        private string name;
        private int cost;
        private string category; 
        public Dish() 
        { 
            name = string.Empty;
            cost= 0;
            category= string.Empty;
        }
        public Dish(string _name, int _cost, string _category )
        {
            Name = _name;
            cost = _cost;
            category = _category;
        }

        [JsonProperty("dishName")]
        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        [JsonProperty("cost")]
        public int Cost
        {
            get { return cost; }
            set 
            {
                try
                {
                    if (value > 0)
                        cost = value;
                }
                catch 
                {
                    throw new ArgumentException("Цена не должна быть равна 0");
                }
            }
        }

        [JsonProperty("category")]
        public string Category
        {
            get { return category; }
            set { category = value; }
        }
    }
}
