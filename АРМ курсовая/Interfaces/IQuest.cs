using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace АРМ_курсовая.Interfaces
{
    public interface IQuest
    {
        float Bill { get; set; }
        List<Dish> Dishes { get; set; }
        void AddDish(Dish dish);
        void DeleteDish(Dish dish);
        void MakeDiscount(Quest quest, float discount);
        void BringBackCost(Quest quest);
    }
}
