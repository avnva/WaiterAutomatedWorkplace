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
        public List<Waiter> Waiters;
        public Waiter CurrentWaiter;
        String path = @"C:\Users\Admin\source\repos\3 семестр\WaiterAutomatedWorkplace\dataFiles\WaitersData.json";

        public CurrentSession()
        {
            Waiters = new List<Waiter>();

        }

        public CurrentSession(Waiter _currentWaiter)
        {
            Waiters = new List<Waiter>();
            CurrentWaiter = _currentWaiter;
        }
        private void LoadChanges<T>(out T obj, string filename)
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
            LoadChanges(out Waiters, path);
        }
        private void SaveChanges<T>(T obj, string filename)
        {
            var textJson = JsonConvert.SerializeObject(obj);
            File.WriteAllText(filename, textJson);
        }
        public void AddWaiter(Waiter waiter)
        {
            bool flag = true;
            foreach (Waiter i in Waiters)
            {
                if (waiter.accountdata.Login == i.accountdata.Login ||
                waiter.accountdata.Hash.SequenceEqual(i.accountdata.Hash))
                {
                    flag = false;
                    break;
                }
            }
            if (flag)
            {
                CurrentWaiter = waiter;
                Waiters.Add(CurrentWaiter);
                SaveChanges(Waiters, path);
            }
            else
                throw new ArgumentException("Такой логин уже используется.");
        }
      

    }
}
