using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace АРМ_курсовая
{
    public class Waiter
    {
        private string name;
        private string surname;

        [JsonProperty("date_of_birth")]
        public DateTime DateOfBirth { get; set; }

        [JsonProperty("name")]
        public string Name
        {
            get { return name; }
            set
            {
                if (value == "")
                    throw new ArgumentException("Имя не должно являться пустой строкой.");
                name = value;
            }
        }

        [JsonProperty("surname")]
        public string Surname
        {
            get { return surname; }
            set
            {
                if (value == "")
                    throw new ArgumentException("Фамилия не должна являться пустой строкой.");
                surname = value;
            }
        }

        [JsonProperty("credentials")]
        public AccountData accountdata { get; set; }

        public Waiter(string _name, string _surname, AccountData _accountdata)
        {
            Name = _name;
            Surname = _surname;
            accountdata = _accountdata;
        }
    }
}
