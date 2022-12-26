using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using АРМ_курсовая;

namespace АРМ_курсовая
{
    public class LogIn : ILogIn
    {
        private readonly List<Account> Accounts = new List<Account>();

        public LogIn()
        {
            if (File.Exists("WorkersData.json"))
            {
                Accounts = JsonConvert.DeserializeObject<List<Account>>(File.ReadAllText("WorkersData.json"));
            }
            else
            {
                throw new FileNotFoundException("'WorkersData.json' не существует.");
            }

        }

        public bool CheckAccount(string login, string password, out Account a)
        {
            bool flag = false;
            a = null;

            byte[] Hash;
            UnicodeEncoding ue = new UnicodeEncoding();
            byte[] bytes = ue.GetBytes(password);
            SHA256 shHash = SHA256.Create();
            Hash = shHash.ComputeHash(bytes);

            foreach (Account account in Accounts)
            {
                if (account.Login == login && account.Hash.SequenceEqual(Hash))
                {
                    flag = true;
                    a = account;
                    break;
                }
                else
                    flag = false;
            }

            return flag;
        }        
    }
}
