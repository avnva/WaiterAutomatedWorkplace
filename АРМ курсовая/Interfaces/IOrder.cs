using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace АРМ_курсовая.Interfaces
{
    public interface IOrder
    {
        Status Status { get; set; }
        float TotalBill { get; set; }
        List<Quest> Quests { get; set; }
        int NumberTable { get; set; }
        DateTime Time { get; set; }
        string WaiterLogin { get; set; }
        void AddQuest(Quest quest);
        void EditQuest(Quest quest, int index);
        void DeleteQuest(Quest quest);
        void CountTotalBill();
    }
}
