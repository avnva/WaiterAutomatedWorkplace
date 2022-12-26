using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using АРМ_курсовая.Interfaces;

namespace АРМ_курсовая
{
    public enum Status : byte
    {
        Active = 0,
        Complete = 1
    };

    public class Order : IOrder
    {
        [JsonProperty("status")]
        public Status Status { get; set; }

        [JsonProperty("bill")]
        public float TotalBill { get; set; }

        [JsonProperty("quests")]
        public List<Quest> Quests { get; set; }

        [JsonProperty("table")]
        public int NumberTable { get; set; }

        [JsonProperty ("time")]
        public DateTime Time { get; set; }

        [JsonProperty("waiter")]
        public string WaiterLogin { get; set; }

        public Order()
        {
            Status = 0;
            TotalBill = 0;
            Quests = new List<Quest>();
            NumberTable = 0;
            Time = DateTime.Now;
        }
        public Order(int _numbertable, string _waiterlogin)
        {
            Quests = new List<Quest>();
            NumberTable = _numbertable;
            WaiterLogin = _waiterlogin;
        }

        public void AddQuest(Quest quest)
        {
            Quests.Add(quest);
        }

        public void EditQuest(Quest quest, int index)
        {
            Quests[index] = quest;
        }

        public void DeleteQuest(Quest quest)
        {
            Quests.Remove(quest);
        }
        public void CountTotalBill()
        {
            TotalBill = 0;
            for (int i = 0; i < Quests.Count; i++)
            {
                TotalBill += Quests[i].Bill;
            }
        }
    }
}
