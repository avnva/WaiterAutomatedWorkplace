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
        public int currentNumberTable = 0;
        public int NumberEmptySeats = 0;

        //public Order newOrder = new Order();
        //public Quest newQuest = new Quest();
        public CurrentSession currentSession = new CurrentSession();
        public Dish currentDish;
        public  List<Table> tables = new List<Table>();
        Table firstType = new Table(8);
        Table secondType = new Table(2);
        Table thirdType = new Table(5);
        public Menu menu;
        
        //public Order currentOrder;
        //public List<Dish> Dishes = new List<Dish>();
        //public List<Quest> Quests;
        //public List <Order> Orders = new List<Order>(); 
        //public List <Dish> dishes = new List<Dish>();

        //public MainFormWaiterViewModel(Quest NewQuest)
        //{
        //    newOrder = new Order(NewQuest);
        //    //currentSession.Load();
        //}


        public MainFormWaiterViewModel()
        {
            for (int i = 0; i < 7 ; i++)
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
        }
        public MainFormWaiterViewModel(Account CurrentAccount)
        {
            currentSession = new CurrentSession(CurrentAccount);

            //currentSession.Load();
            //menu = new Menu();
            //menu.Load();
            //LoadOrders();
        }
        
        public int CheckTables(int indexTable)
        {
            allOrders.LoadOrders();
            for (int i = 0; i < allOrders.Orders.Count; i++)
            {
                if (allOrders.Orders[i].NumberTable == indexTable)
                {
                    NumberEmptySeats = tables[indexTable].numberOfSeats - allOrders.Orders[i].Quests.Count;
                }
            }
            return NumberEmptySeats;
        }

        public void AddOrder(Order order)
        {
            allOrders.LoadOrders();
            if (allOrders.Orders == null)
            {
                allOrders = new AllOrders(order);
            }
            allOrders.AddOrder(order);
        }
        public void DeleteOrder(Order order)
        {
            allOrders.LoadOrders();
            allOrders.DeleteOrder(order);
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


        public void AddQuest(Quest quest)
        {
            if (currentOrder.Quests == null)
            {
                currentOrder = new Order(quest, currentNumberTable);
            }
            currentOrder.AddQuest(quest);
        }
        public void EditQuest(Quest quest, int index)
        {
            currentOrder.EditQuest(quest, index);
        }
        public void DeleteQuest(Quest quest)
        {
            currentOrder.DeleteQuest(quest);
        }
        public void SaveQuests(int index)
        {
            if (currentOrder.Quests.Count > index)
            {
                EditQuest(currentQuest, index);
            }
            else
                AddQuest(currentQuest);
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
