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
        public AllOrders allOrders;
        public Order currentOrder;
        public Quest currentQuest;
        public Dish currentDish;
        public int currentNumberTable = 0;
        public int NumberEmptySeats = 0;

        public CurrentSession currentSession;
        
        public  List<Table> tables = new List<Table>();
        Table firstType = new Table(8);
        Table secondType = new Table(2);
        Table thirdType = new Table(5);
        public Menu menu;

        public MainFormWaiterViewModel(Account CurrentAccount)
        {
            currentSession = new CurrentSession(CurrentAccount);
            for (int i = 0; i < 7; i++)
            {
                tables.Add(firstType);
            }
            for (int i = 7; i < 23; i++)
            {
                tables.Add(secondType);
            }
            for (int i = 23; i < 29; i++)
            {
                tables.Add(thirdType);
            }
            menu = new Menu();
            menu.Load();
            try
            {
                allOrders = new AllOrders();
            }
            catch (FileNotFoundException ex)
            {
                MessageBox.Show(ex.Message, "Критическая ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Environment.Exit(1);
            }
            allOrders.LoadOrders();
        }
        
        public int CheckTable(int indexTable)
        {
            allOrders.LoadOrders();
            if (allOrders.Orders != null)
            {
                for (int i = 0; i < allOrders.Orders.Count; i++)
                {
                    if (allOrders.Orders[i].NumberTable == indexTable)
                    {
                        NumberEmptySeats = tables[indexTable].numberOfSeats - allOrders.Orders[i].Quests.Count;
                    }
                }
            }
            else
            {
                NumberEmptySeats = tables[indexTable].numberOfSeats;
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
            allOrders.AddOrder(order);
        }
        public void DeleteOrder(Order order)
        {
            allOrders.LoadOrders();
            allOrders.DeleteOrder(order);
        }
        public void EditOrder(Order order, int index) 
        {
            //allOrders.LoadOrders();
            allOrders.EditOrder(order, index);
        }
        public void FindOrder(int indexTable)
        {
            allOrders.LoadOrders();
            for (int i = 0; i < allOrders.Orders.Count; i++)
            {
                if (allOrders.Orders[i].NumberTable == indexTable)
                {
                    currentOrder = allOrders.Orders[i];
                }
            }
        }
        public void ChangeStatus()
        {
            int index = allOrders.CheckOrder(currentOrder);
            currentOrder.Status = Status.Завершен;
            EditOrder(currentOrder, index);
        }



        public void AddQuest(Quest quest)
        {
            if (currentOrder == null)
            {
                currentOrder = new Order(currentNumberTable, currentSession.CurrentAccount.Login);
            }
            currentOrder.AddQuest(quest);
            //currentOrder.TotalBill += quest.Bill;
        }
        public void EditQuest(Quest quest, int index)
        {

            //currentOrder.Quests[index] = quest;
            //currentOrder.TotalBill 
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
        public bool CheckQuests()
        {
            for (int i = 0; i < currentOrder.Quests.Count; i++)
            {
                if (currentOrder.Quests[i].Dishes.Count == 0)
                {
                    return false;
                }
            }
            return true;

        }
        public void MakeDiscount(float discount)
        {
            allOrders.LoadOrders();
            int ind = allOrders.CheckOrder(currentOrder);

            for (int i = 0; i < currentOrder.Quests.Count; i++)
            {
                currentOrder.TotalBill -= currentOrder.Quests[i].Bill;
                currentQuest = currentOrder.Quests[i];
                currentQuest.MakeDiscount(currentQuest, discount);
                currentOrder.TotalBill += currentQuest.Bill;
            }
            EditOrder(currentOrder, ind);
        }
        public void BringBackCost(float discount)
        {
            allOrders.LoadOrders();
            int ind = allOrders.CheckOrder(currentOrder);

            for (int i = 0; i < currentOrder.Quests.Count; i++)
            {
                currentOrder.TotalBill -= currentOrder.Quests[i].Bill;
                currentQuest = currentOrder.Quests[i];
                currentQuest.BringBackCost(currentQuest, discount);
                currentOrder.TotalBill += currentQuest.Bill;
            }
            EditOrder(currentOrder, ind);
        }



        public void AddDishes(Dish dish)
        {
            if (currentQuest.Dishes == null)
            {
                currentQuest = new Quest(dish);
            }
            else
                currentQuest.AddDishes(dish);
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



        //public void AddAccount(Account account)
        //{
        //    currentSession.Load();
        //    if (currentSession.Accounts == null)
        //    {
        //        currentSession = new CurrentSession(account);
        //    }
        //    currentSession.AddAccount(account);
        //}

        //public void AddOrder(Quest quest)
        //{
        //    //currentSession.Load();
        //    //currentSession.SaveChanges(Order.Quests, "QuestsData.json");
        //    if (newOrder.Quests == null)
        //    {
        //        newOrder = new Order(quest);
        //    }
        //    newOrder.AddQuest(quest);
        //}
    }
}
