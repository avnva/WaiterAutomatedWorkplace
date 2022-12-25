using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace АРМ_курсовая
{
    public class Quest
    {
        [JsonProperty("bill")]
        public float Bill;
        [JsonProperty ("dishes")]
        public List<Dish> Dishes;

        public Quest()
        {
            Dishes = new List<Dish>();
        }
        public void AddDish(Dish dish)
        {
            Dishes.Add(dish);
            Bill += dish.Cost;
        }
        public void DeleteDish(Dish dish)
        {
            Dishes.Remove(dish);
            Bill -= dish.Cost;
        }

        public void MakeDiscount(Quest quest, float discount)
        {
            quest.Bill -= (quest.Bill / 100 * discount);
        }
        public void BringBackCost(Quest quest)
        {
            quest.Bill = 0;
            for (int i = 0; i <quest.Dishes.Count; i++)
            {
                quest.Bill += quest.Dishes[i].Cost
;           }
        }
    }
}
