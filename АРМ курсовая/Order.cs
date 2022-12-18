using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace АРМ_курсовая.Resources
{
    public class Order
    {
        [JsonProperty("status")]
        public bool isTaken { get; set; }

        [JsonProperty("bill")]
        public float totalBill { get; set; }

        [JsonProperty("discount")]
        public float discount { get; set; }

        [JsonProperty("quests")]
        public List<Quest> Quests { get; set; }

        public int countQuests;
        public List<Quest> quest;
        public Quest CurrentQuest;
        //public Waiter CurrentWaiter;
        //public List <Quest> Quests;

        public Order()
        {
            isTaken = false;
            countQuests = 0;
            totalBill = 0;
            discount = 0;
            quest = null;
            Quests = new List<Quest>();
        }
        public Order(Quest _currentQuest)
        {
            Quests = new List<Quest>();
            CurrentQuest = _currentQuest;
            this.isTaken = isTaken;
            //this.countQuests = _countQuests;
            this.totalBill = totalBill;
            //Discount = discount_;
            //Quest = quest_;
            //quests = JsonConvert.DeserializeObject<List<string>>(File.ReadAllText("QuestsData.json"));
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
        public List<Quest> Quest
        {
            get { return quest; }
            set { quest = value; }
        }

        public void AddQuest(Quest quest)
        {
            Quests.Add(quest);

        }

        public void DeleteQuest(Quest quest)
        {
            Quests.Remove(quest);
        }

        private void ChangeStatus()
        {
            if (isTaken==true)
                isTaken = false;
            else
                isTaken = true;
        }
        
        private void MakeDiscount(float bill)
        {
            bill = bill - (bill / 100 * Discount);
        }

    }
}
