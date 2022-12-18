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
        public MainFormWaiterViewModel(Quest NewQuest)
        {
            newOrder = new Order(NewQuest);
            //currentSession.Load();
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
