using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace АРМ_курсовая.Resources
{
    public class Order
    {
        public bool isTaken;
        public int countQuests;
        public float totalBill;
        private float discount;
        public List<Quest> quest;

        public Order() 
        {
            isTaken = false;
            countQuests = 0;
            totalBill = 0;
            discount = 0;
            quest = new List<Quest>();
        }
        public Order(bool isTaken, int countQuests, float totalBill, float discount_, List<Quest> quest_)
        {
            this.isTaken = isTaken;
            this.countQuests = countQuests;
            this.totalBill = totalBill;
            Discount = discount_;
            Quest = quest_;
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

        public void AddQuest()
        {
            quest.Add(new Quest());

        }

        public void DeleteQuest()
        {
            quest.Remove(new Quest());

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
