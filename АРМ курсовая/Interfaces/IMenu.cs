using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace АРМ_курсовая.Interfaces
{
    public interface IMenu
    {
        void AddDish(Dish dish);
        void EditDish(Dish dish, int number);
        void DeleteDish(int number);
        void Load();
    }
}
