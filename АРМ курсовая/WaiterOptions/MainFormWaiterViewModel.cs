using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using АРМ_курсовая.Resources;

namespace АРМ_курсовая
{
    public class MainFormWaiterViewModel
    {
        public Order newOrder = new Order();
        public CurrentSession currentSession;
        public  List<Table> tables = new List<Table>();
        Table firstType = new Table(8);
        Table secondType = new Table(2);
        Table thirdType = new Table(5);
        public Menu menu;
        public Quest currentQuest;
        public List<Dish> Dishes = new List<Dish>();
        public List<Quest> Quests = new List<Quest>();
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
        }
        public MainFormWaiterViewModel(Account CurrentAccount, Dish CurrentDish)
        {
            currentSession = new CurrentSession(CurrentAccount);
            currentSession.Load();
            menu = new Menu(CurrentDish);
            menu.Load();
        }
        public void AddQuest(Quest quest, List<Dish> dish)
        {
            if (quest == null)
            {
                quest = new Quest();
            }
            for (int i = 0; i < dish.Count; i++)
            {
                quest.AddDishes(dish[i]);
            }
            //currentSession.SaveChanges(quest, "OrdersData.json");  
        }

        public void AddOrder(Quest quest)
        {
            //currentSession.Load();
            //currentSession.SaveChanges(Order.Quests, "QuestsData.json");
            if (newOrder.Quests == null)
            {
                newOrder = new Order(quest);
            }
            newOrder.AddQuest(quest);
        }
    }
}
