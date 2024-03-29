﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using Newtonsoft.Json.Converters;
using System.Security.Policy;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using АРМ_курсовая;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace АРМ_курсовая
{
    public class CurrentSession : ICurrentSession
    {
        public List<Account> Accounts;
        public Account CurrentAccount;

        public CurrentSession()
        {
            Accounts = new List<Account>();
        }

        public CurrentSession(Account _currentAccount)
        {
            Accounts = new List<Account>();
            CurrentAccount = _currentAccount;
        }
        public void LoadChanges<T>(out T obj, string filename)
        {
            if (File.Exists(filename))
            {
                var textfile = File.ReadAllText(filename);
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
            LoadChanges(out Accounts, "WorkersData.json");
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
                if (currentAccount.Login == i.Login)
                {
                    flag = false;
                    break;
                }
            }
            if (flag)
            {
                CurrentAccount = currentAccount;
                Accounts.Add(CurrentAccount);
                SaveChanges(Accounts, "WorkersData.json");
            }
            else
                throw new ArgumentException("Такой логин уже используется.");
        }

        public void DeleteAccount(int index)
        {
            Accounts.Remove(Accounts[index]);
            SaveChanges(Accounts, "WorkersData.json");
        }
    }
}
