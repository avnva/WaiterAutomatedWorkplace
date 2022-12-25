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
        [JsonIgnore]
        public Dish CurrentDish;
        [JsonIgnore]
        CurrentSession СurrentSession = new CurrentSession();

        public Quest()
        {
            Dishes = new List<Dish>();
            //NumberTable = new Table();
        }

        public Quest(Dish _dish)
        {
            Dishes = new List<Dish>();
            //for (int i = 0; i < _dish.Count; i++)
            //{
            //    Dishes.Add(_dish[i]);
            //    Bill += _dish[i].Cost;
            //}
            //CurrentDish = _currentDish;
        }
        public void AddDishes(Dish dish)
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
            quest.Bill = quest.Bill - (quest.Bill / 100 * discount);
        }
        public void BringBackCost(Quest quest, float discount)
        {
            quest.Bill = 0;
            for (int i = 0; i <quest.Dishes.Count; i++)
            {
                quest.Bill += quest.Dishes[i].Cost
;            }
            
        }
    }
}
