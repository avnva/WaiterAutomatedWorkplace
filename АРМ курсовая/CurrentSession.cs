using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using Newtonsoft.Json.Converters;
using System.Security.Policy;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using АРМ_курсовая.Resources;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace АРМ_курсовая
{
    public class CurrentSession
    {
        public List<Account> Accounts;
        public Account CurrentAccount;
        public 
        String path = @"C:\Users\Admin\source\repos\3 семестр\WaiterAutomatedWorkplace\dataFiles\WaitersData.json";

        public CurrentSession()
        {
            Accounts = new List<Account>();
        }

        public CurrentSession(Account _currentAccount)
        {
            Accounts = new List<Account>();
            CurrentAccount = _currentAccount;
        }
        public void LoadChanges<T>(out T obj, string filename, string path)
        {
            if (File.Exists(filename))
            {
                var textfile = File.ReadAllText(path);
                obj = JsonConvert.DeserializeObject<T>(textfile);
            }
            else
            {
                MessageBox.Show($"Не удалось найти '{filename}'!", "Критическая ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Environment.Exit(1);
                throw new FileNotFoundException($"'{filename}' не существует.");
            }
        }
        public void Load()
        {
            LoadChanges(out Accounts, path, path);
        }
        public void SaveChanges<T>(T obj, string filename)
        {
            var textJson = JsonConvert.SerializeObject(obj);
            File.WriteAllText(filename, textJson);
        }
        public void AddAccount(Account currentAccount)
        {
            bool flag = true;
            foreach (Account i in Accounts)
            {
                if (currentAccount.Login == i.Login ||
                currentAccount.Hash.SequenceEqual(i.Hash))
                {
                    flag = false;
                    break;
                }
            }
            if (flag)
            {
                CurrentAccount = currentAccount;
                Accounts.Add(CurrentAccount);
                SaveChanges(Accounts, path);
            }
            else
                throw new ArgumentException("Такой логин уже используется.");
        }

        public bool DeleteAccount(Account account)
        {
            bool flag = false;
            for (int i = 0; i < Accounts.Count; i++)
            {
                if (Accounts[i].Equals(account))
                {
                    flag = Accounts.Remove(Accounts[i]);
                }
            }
            if (flag) SaveChanges(Accounts, path);
            return flag;
        }

    }
}
