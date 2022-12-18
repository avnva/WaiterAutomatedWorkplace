using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using АРМ_курсовая.Resources;

namespace АРМ_курсовая
{
    public class Menu
    {
        public List<Dish> Dishes;
        public Dish CurrentDish;
        CurrentSession СurrentSession = new CurrentSession();

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
                bool flag = true;
                foreach (Dish i in Dishes)
                {
                    if (dish.Name == i.Name && dish.Cost == i.Cost)
                    {
                        flag = false;
                        break;
                    }
                }
                if (flag)
                {
                    Dishes.Add(dish);
                    СurrentSession.SaveChanges(Dishes, "DishesData.json");
                }
                else
                    throw new ArgumentException("Не удалось добавить блюдо, так как такое блюдо уже существует.");
        }
        public void EditDish(Dish dish, int number)
        {
            for (int i = 0; i < Dishes.Count; i++)
            {
                if (i == number - 1)
                {
                    if (Dishes[i].Name != dish.Name || Dishes[i].Cost != dish.Cost || Dishes[i].Category != dish.Category)
                    {
                        Dishes[i].Name = dish.Name;
                        Dishes[i].Cost = dish.Cost;
                        Dishes[i].Category = dish.Category;
                        СurrentSession.SaveChanges(Dishes, "DishesData.json");
                    }
                    else
                        throw new ArgumentException("Такое блюдо уже существует!");
                }
            }    
        }
        public void Load()
        {
            СurrentSession.LoadChanges(out Dishes, "DishesData.json");
        }
    }
}

        //pizzas = new List<Dish>() 
        //{ 
        //    new Dish("Пепперони", 290),
        //    new Dish("Маргарита", 280),
        //    new Dish("4 сыра", 350),
        //    new Dish("Вулкан", 590),
        //    new Dish("Гавайи", 530),
        //    new Dish("Барбекю", 650)
        //};
        //pastas = new List<Dish>()
        //{
        //    new Dish("Карбонара", 440),
        //    new Dish("С говядиной в перечном соусе", 560),
        //    new Dish("Болоньезе", 440),
        //    new Dish("Фетучини с курицей и грибами", 440),
        //    new Dish("Помадоро", 360),
        //    new Dish("Мак энд чиз", 590),
        //};
        //salads = new List<Dish>()
        //{
        //     new Dish("Цезарь с курицей", 430),
        //     new Dish("Цезарь с тигровыми креветками", 590),
        //     new Dish("С сёмгой и яйцом-пашот", 590),
        //     new Dish("Грин с креветками", 540),
        //     new Dish("С ростбифом", 390),
        //     new Dish("Греческий", 390),
        //};
        //deserts = new List<Dish>()
        //{
        //    new Dish("Чизкейк", 340),
        //    new Dish("Вишневая лазанья", 320),
        //    new Dish("Медовик с облепихой", 330),
        //    new Dish("Тирамису", 360),
        //    new Dish("Венера", 350),
        //    new Dish("Томат", 360)
        //};
        //drinks = new List<Dish>()
        //{
        //    new Dish("Мохито", 330),
        //    new Dish("Апельсиновый лимонад", 230),
        //    new Dish("Смузи апельсиновый с манго", 390),
        //    new Dish("Морковный фреш", 310),
        //    new Dish("Кофе", 250),
        //    new Dish("Чай", 230),
        //    new Dish("Pizzerino", 350)
        //};