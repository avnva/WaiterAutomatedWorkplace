using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using АРМ_курсовая.Interfaces;

namespace АРМ_курсовая
{
    public enum Role : byte
    {
        Waiter = 0,
        Admin = 1
    };
    public class Account : IAccount
    {
        private string login;
        private string password;
        private Role role;

        public Account(string _login, string _password, Role _role)
        {
            Login = _login;
            Password = _password;
            Role = _role;
        }

        [JsonProperty("password_hash")]
        public byte[] Hash { get; set; }

        private Regex hasNumber = new Regex(@"[0-9]+");
        private Regex hasUpperChar = new Regex(@"[A-Z]+");
        private Regex hasMinimum6Chars = new Regex(@".{6,}");

        private void HashPassword()
        {
            UnicodeEncoding ue = new UnicodeEncoding();
            byte[] messageBytes = ue.GetBytes(password);
            SHA256 shHash = SHA256.Create();
            Hash = shHash.ComputeHash(messageBytes);
        }

        private bool ValidatePassword(string password)
        {
            bool flag = false;
            if (password != null)
                flag = hasNumber.IsMatch(password) && hasUpperChar.IsMatch(password)
                    && hasMinimum6Chars.IsMatch(password);
            return flag;
        }

        [JsonProperty("login")]
        public string Login
        {
            get { return login; }
            set { login = value; }
        }

        [JsonProperty("password")]
        public string Password
        {
            get { return password; }
            set
            {
                if (value != null && !ValidatePassword(value))
                    throw new ArgumentException("Пароль должен быть длиной не менее 6 символов, обязательно содержать хотя бы одну цифру и заглавную латинскую букву.");
                password = value;
                if (value != null) HashPassword();
                password = null;
            }
        }

        [JsonProperty("role")]
        public Role Role
        {
            get { return role; }
            set { role = value; }
        }
    }
}
