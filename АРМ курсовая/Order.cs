using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace АРМ_курсовая
{
    public enum Status : byte
    {
        //[Description("Worker can add, delete and find applicants")]
        Активен = 0,
        //[Description("Admin can add, delete workers, add, delete and find applicants")]
        Завершен = 1
    };
    public class Order
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
        //[JsonProperty("table")]
        //public string Waiter { get; set; } 

        //[JsonIgnore]
        //public float discount { get; set; }

        public Order()
        {
            Status = 0;
            TotalBill = 0;
            //discount = 0;
            Quests = new List<Quest>();
            NumberTable = 0;
            Time = DateTime.Now;
        }
        public Order(int _numbertable, string _waiterlogin)
        {
            Quests = new List<Quest>();
            //currentquest = _currentquest;
            NumberTable = _numbertable;
            WaiterLogin = _waiterlogin;

        }
        //private float Discount
        //{
        //    get
        //    {
        //        return discount;
        //    }
        //    set
        //    {
        //        if (value < 0 && value > 100)
        //            throw new ArgumentException();
        //        discount = value;
        //    }
        //}

        public void AddQuest(Quest quest)
        {
            Quests.Add(quest);
            TotalBill += quest.Bill;
        }

        public void EditQuest(Quest quest, int index)
        {
            TotalBill -= Quests[index].Bill;
            Quests[index] = quest;
            TotalBill += Quests[index].Bill;
        }

        public void DeleteQuest(Quest quest)
        {
            Quests.Remove(quest);
            TotalBill -= quest.Bill;
        }

        //private void ChangeStatus()
        //{
        //    if (isPaid == true)
        //        isPaid = false;
        //    else
        //        isPaid = true;
        //}


    }
}
