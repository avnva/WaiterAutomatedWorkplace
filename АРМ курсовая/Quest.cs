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
        }
        //public void Load()
        //{
        //    СurrentSession.LoadChanges(out Quests, "OrdersData.json");
        //}
    }
}
