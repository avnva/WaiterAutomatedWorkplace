using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using АРМ_курсовая;

namespace АРМ_курсовая
{
    public class MainFormWaiterViewModel
    {
        public CurrentSession currentSession;
        public Menu menu;
        public AllOrders allOrders;
        public Order currentOrder;
        public Quest currentQuest;
        public Dish currentDish;

        public int currentNumberTable = 0;
        public int NumberEmptySeats = 0;
        public float AverageBill = 0;
        public int index = 0;
        
        public  List<Table> tables = new List<Table>();
        private readonly Table firstType = new Table(8);
        private readonly Table secondType = new Table(2);
        private readonly Table thirdType = new Table(5);

        public MainFormWaiterViewModel(Account CurrentAccount)
        {
            currentSession = new CurrentSession(CurrentAccount);

            for (int i = 0; i < 6; i++)
                tables.Add(firstType);

            for (int i = 6; i < 22; i++)
                tables.Add(secondType);

            for (int i = 22; i < 29; i++)
                tables.Add(thirdType);

            try
            {
                allOrders = new AllOrders();
                menu = new Menu();
            }
            catch (FileNotFoundException ex)
            {
                MessageBox.Show(ex.Message, "Критическая ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Environment.Exit(1);
            }
            allOrders.LoadOrders();
            menu.Load();
        }
        
        public int CheckTable(int NumberTable)
        {
            allOrders.LoadOrders();
            if (allOrders.Orders != null)
            {
                for (int i = 0; i < allOrders.Orders.Count; i++)
                {
                    if (allOrders.Orders[i].NumberTable == NumberTable && allOrders.Orders[i].Status == Status.Active)
                    {
                        NumberEmptySeats = tables[NumberTable].numberOfSeats - allOrders.Orders[i].Quests.Count;
                    }
                }
            }
            else
            {
                NumberEmptySeats = tables[NumberTable].numberOfSeats;
            }
            return NumberEmptySeats;
        }


        public void AddOrder(Order order)
        {
            order.Time = DateTime.Now;
            allOrders.LoadOrders();
            if (allOrders.Orders == null)
            {
                allOrders = new AllOrders();
            }
            order.CountTotalBill();
            allOrders.AddOrder(order);
        }
        public void DeleteOrder()
        {
            int index = allOrders.CheckOrder(currentOrder);
            allOrders.LoadOrders();
            allOrders.DeleteOrder(index);
        }
        public void EditOrder(Order order, int index) 
        {
            order.CountTotalBill();
            allOrders.EditOrder(order, index);
        }
        public void FindOrder(int indexTable)
        {
            bool Flag = true;
            allOrders.LoadOrders();
            for (int i = 0; i < allOrders.Orders.Count; i++)
            {
                if (allOrders.Orders[i].NumberTable == indexTable && 
                    allOrders.Orders[i].WaiterLogin == currentSession.CurrentAccount.Login &&
                    allOrders.Orders[i].Status == Status.Active)
                {
                    currentOrder = allOrders.Orders[i];
                    Flag = false;
                    break;
                }
            }
            if (Flag)
                throw new Exception("Такой заказ не существует!");
        }
        public void ChangeStatus()
        {
            int index = allOrders.CheckOrder(currentOrder);
            currentOrder.Status = Status.Complete;
            EditOrder(currentOrder, index);
        }
        public float CountingAverageBill(Status status)
        {
            allOrders.LoadOrders();
            AverageBill = allOrders.CountingAverageBill(status);
            return AverageBill;        
        }


        public void AddQuest(Quest quest)
        {
            if (currentOrder == null)
            {
                currentOrder = new Order(currentNumberTable, currentSession.CurrentAccount.Login);
            }
            currentOrder.AddQuest(quest);
        }
        public void EditQuest(Quest quest, int index)
        {
            currentOrder.EditQuest(quest, index);
        }
        public void DeleteQuest()
        {
            currentOrder.DeleteQuest(currentQuest);
        }
        public void SaveQuests(int index)
        {
            if (currentOrder != null)
            {
                if (currentOrder.Quests.Count > index)
                {
                    EditQuest(currentQuest, index);
                }
                else
                    AddQuest(currentQuest);
            }
            else
                AddQuest(currentQuest);
        }
        public void CheckQuestsAdd()
        {
            bool Flag = false;
            if (currentOrder != null)
            {
                for (int i = 0; i < currentOrder.Quests.Count; i++)
                {
                    if (currentOrder.Quests[i].Dishes.Count == 0)
                    {
                        Flag = true;
                    }
                }
            }
            else
                Flag = true;
            if (Flag)
            {
                throw new Exception("Вы не можете добавить нового гостя, пока у текущего не добавлены блюда!");
            }
        }
        public void CheckQuestsSave()
        {
            bool Flag = false;
            for (int i = 0; i < currentOrder.Quests.Count; i++)
            {
                if (currentOrder.Quests[i].Dishes.Count == 0)
                {
                    Flag = true;
                }
            }
            if (Flag)
            {
                throw new Exception("Вы не можете создать заказ, пока у гостя не добавлены блюда!");
            }
        }
        public void MakeDiscount(float discount)
        {
            allOrders.LoadOrders();
            int ind = allOrders.CheckOrder(currentOrder);

            for (int i = 0; i < currentOrder.Quests.Count; i++)
            {
                
                currentQuest = currentOrder.Quests[i];
                currentQuest.MakeDiscount(currentQuest, discount);
                
            }
            EditOrder(currentOrder, ind);
        }
        public void BringBackCost()
        {
            allOrders.LoadOrders();
            int ind = allOrders.CheckOrder(currentOrder);

            for (int i = 0; i < currentOrder.Quests.Count; i++)
            {
                currentQuest = currentOrder.Quests[i];
                currentQuest.BringBackCost(currentQuest);
            }
            EditOrder(currentOrder, ind);
        }



        public void AddDish(Dish dish)
        {
            if (currentQuest.Dishes == null)
            {
                currentQuest = new Quest();
            }
            else
                currentQuest.AddDish(dish);
        }
        public void DeleteDish(string NameDish)
        {
            for (int i = 0; i < currentQuest.Dishes.Count; i++)
            {
                if (currentQuest.Dishes[i].Name == NameDish)
                {
                    Dish deleteDish = currentQuest.Dishes[i];
                    currentQuest.DeleteDish(deleteDish);
                    break;
                }
            }
        }
        public void CheckDish(Dish dish)
        {
            bool flag = true;
            if (dish == null)
                flag = false;
            else
            {
                foreach (Dish i in menu.Dishes)
                {
                    if (i.Name == dish.Name)
                    {
                        flag = false;
                    }
                }
            }
            if (flag)
                throw new Exception("Блюдо не выбрано!");
        }
    }
}
