using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace АРМ_курсовая
{
    public class AllOrders
    {
        public List<Order> Orders;
        public Order CurrentOrder;
        CurrentSession currentSession = new CurrentSession();
        public AllOrders()
        {
            Orders = new List<Order>();
        }

        public AllOrders(Order _currentOrder)
        {
            Orders = new List<Order>();
            CurrentOrder = _currentOrder;
        }

        public void LoadOrders()
        {
            currentSession.LoadChanges(out Orders, "OrdersData.json");
        }
        public void AddOrder(Order currentOrder)
        {
            Orders.Add(currentOrder);
            currentSession.SaveChanges(Orders, "OrdersData.json");

        }
        public bool DeleteOrder(Order order)
        {
            bool flag = false;
            for (int i = 0; i < Orders.Count; i++)
            {
                if (Orders[i].Equals(order))
                {
                    flag = Orders.Remove(Orders[i]);
                }
            }
            if (flag) currentSession.SaveChanges(Orders, "OrdersData.json");
            return flag;
        }
        //public void EditDish(Dish dish, int number)
        //{
        //    for (int i = 0; i < Dishes.Count; i++)
        //    {
        //        if (i == number - 1)
        //        {
        //            if (Dishes[i].Name != dish.Name || Dishes[i].Cost != dish.Cost || Dishes[i].Category != dish.Category)
        //            {
        //                Dishes[i].Name = dish.Name;
        //                Dishes[i].Cost = dish.Cost;
        //                Dishes[i].Category = dish.Category;
        //                currentSession.SaveChanges(Dishes, "DishesData.json");
        //            }
        //            else
        //                throw new ArgumentException("Такое блюдо уже существует!");
        //        }
        //    }
        //}
    }
}
