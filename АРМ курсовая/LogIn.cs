using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using АРМ_курсовая.Resources;

namespace АРМ_курсовая
{
    public class LogIn
    {
        private List<Waiter> Waiters = new List<Waiter>();
        String path = @"C:\Users\Admin\source\repos\3 семестр\WaiterAutomatedWorkplace\dataFiles\WaitersData.json";

        public LogIn()
        {
            if (File.Exists(path))
            {
                Waiters = JsonConvert.DeserializeObject<List<Waiter>>(File.ReadAllText(path));
            }
            else
            {
                throw new FileNotFoundException("'WaitersData.json' не существует.");
            }

        }

        public bool CheckWaiter(string login, string password, out Waiter a)
        {
            bool flag = false;
            a = null;

            byte[] Hash;
            UnicodeEncoding ue = new UnicodeEncoding();
            byte[] bytes = ue.GetBytes(password);
            SHA256 shHash = SHA256.Create();
            Hash = shHash.ComputeHash(bytes);

            foreach (Waiter waiter in Waiters)
            {
                if (waiter.accountdata.Login == login && waiter.accountdata.Hash.SequenceEqual(Hash))
                {
                    flag = true;
                    a = waiter;
                    break;
                }
                else
                    flag = false;
            }

            return flag;
        }        
    }
}
