using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using АРМ_курсовая;

namespace АРМ_курсовая
{
    public class Menu
    {
        public List<Dish> Dishes;
        public Dish CurrentDish;
        readonly CurrentSession currentSession = new CurrentSession();

        public Menu()
        {
            Dishes = new List<Dish>();
        }

        public Menu(Dish _currentDish)
        {
            Dishes = new List<Dish>();
            CurrentDish = _currentDish;
        }

        public void AddDish(Dish dish)
        {
            Dishes.Add(dish);
            currentSession.SaveChanges(Dishes, "DishesData.json");

        }
        public void EditDish(Dish dish, int number)
        {
            Dishes[number].Name = dish.Name;
            Dishes[number].Cost = dish.Cost;
            Dishes[number].Category = dish.Category;
            currentSession.SaveChanges(Dishes, "DishesData.json");
        }

        public void DeleteDish(int number)
        {
            Dishes.RemoveAt(number);
            currentSession.SaveChanges(Dishes, "DishesData.json");
        }

        public void Load()
        {
            currentSession.LoadChanges(out Dishes, "DishesData.json");
        }
    }
}