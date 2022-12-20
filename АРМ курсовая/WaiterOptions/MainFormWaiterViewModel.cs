using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using АРМ_курсовая.Resources;

namespace АРМ_курсовая
{
    public class MainFormWaiterViewModel
    {
        public Order newOrder = new Order();
        public  List<Table> tables = new List<Table>();
        Table firstType = new Table(8);
        Table secondType = new Table(2);
        Table thirdType = new Table(5);

        public MainFormWaiterViewModel(Quest NewQuest)
        {
            newOrder = new Order(NewQuest);
            //currentSession.Load();
        }

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
