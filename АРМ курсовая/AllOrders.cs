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

        public int CheckOrder(Order order)
        {
            bool flag = false;
            int index = -1;
            for (int i = 0; i < Orders.Count; i++)
            {
                Order newOrder = Orders[i];
                if (newOrder.Status == order.Status &&
                    newOrder.Time == order.Time && 
                    newOrder.WaiterLogin == order.WaiterLogin)
                {
                    for (int j = 0; j < order.Quests.Count; j++)
                    {
                        for (int k = 0; k < order.Quests[j].Dishes.Count; k++)
                        {
                            if (newOrder.Quests[j].Dishes[k].Name == order.Quests[j].Dishes[k].Name &&
                                newOrder.Quests[j].Dishes[k].Cost == order.Quests[j].Dishes[k].Cost &&
                                newOrder.Quests[j].Dishes[k].Category == order.Quests[j].Dishes[k].Category)
                            {
                                flag = true;
                            }
                            else flag = false;
                        }
                    }
                }
                if (flag)
                {
                    index = i; break;
                }
            }
            return index;
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
        public void EditOrder(Order order, int index)
        {
            for (int i = 0; i < Orders.Count; i++)
            {
                if (i == index)
                {
                    Orders[i] = order;
                }
            }
            currentSession.SaveChanges(Orders, "OrdersData.json");
        }
    }
}
