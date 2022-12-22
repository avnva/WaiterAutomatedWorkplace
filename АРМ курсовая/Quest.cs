using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace АРМ_курсовая
{
    public class Quest
    {
        public float bill;
        public List<Dish> Dishes = new List<Dish>();
        public Dish CurrentDish;
        CurrentSession СurrentSession = new CurrentSession();

        public Quest()
        {
            Dishes = new List<Dish>();
        }

        public Quest(Dish _currentDish)
        {
            Dishes = new List<Dish>();
            CurrentDish = _currentDish;
        }
        public void AddDishes(Dish dish)
        {
            Dishes.Add(dish);
            bill += dish.Cost;
        }
        private void DeleteDish()
        {

        }
        //public void Load()
        //{
        //    СurrentSession.LoadChanges(out Quests, "OrdersData.json");
        //}
    }
}
