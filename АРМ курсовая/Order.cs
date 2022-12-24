using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace АРМ_курсовая
{
    public class Order
    {
        [JsonProperty("isPaid")]
        public bool isPaid { get; set; }

        [JsonProperty("bill")]
        public float totalBill { get; set; }

        [JsonProperty("quests")]
        public List<Quest> Quests { get; set; }

        [JsonProperty("table")]
        public int NumberTable { get; set; }

        //[JsonProperty("table")]
        //public string Waiter { get; set; } 

        [JsonIgnore]
        public float discount { get; set; }

        [JsonIgnore]
        public Quest CurrentQuest;

        public Order()
        {
            isPaid = false;
            totalBill = 0;
            discount = 0;
            Quests = new List<Quest>();
            NumberTable = 0;
        }
        public Order(Quest _currentQuest, int _numberTable)
        {
            Quests = new List<Quest>();
            CurrentQuest = _currentQuest;
            NumberTable = _numberTable;
        }
        private float Discount
        {
            get
            {
                return discount;
            }
            set
            {
                if (value < 0 && value > 100)
                    throw new ArgumentException();
                discount = value;
            }
        }

        public void AddQuest(Quest quest)
        {
            Quests.Add(quest);
            totalBill += quest.Bill;
        }

        public void EditQuest(Quest quest, int index)
        {
            Quests[index] = quest;
        }

        public void DeleteQuest(Quest quest)
        {
            Quests.Remove(quest);
            totalBill -= quest.Bill;
        }

        private void ChangeStatus()
        {
            if (isPaid == true)
                isPaid = false;
            else
                isPaid = true;
        }
        
        private void MakeDiscount(float bill)
        {
            bill = bill - (bill / 100 * Discount);
        }
    }
}
