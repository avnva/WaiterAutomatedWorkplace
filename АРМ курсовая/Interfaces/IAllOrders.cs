using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace АРМ_курсовая.Interfaces
{
    public interface IAllOrders
    {
        void LoadOrders();
        void AddOrder(Order currentOrder);
        void DeleteOrder(int index);
        void EditOrder(Order order, int index);
        float CountingAverageBill(Status status);
        int CheckOrder(Order order);

    }
}
