using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using АРМ_курсовая.Interfaces;

namespace АРМ_курсовая
{
    public class Quest : IQuest
    {
        [JsonProperty("bill")]
        public float Bill { get; set; }
        [JsonProperty ("dishes")]
        public List<Dish> Dishes { get; set; }
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
