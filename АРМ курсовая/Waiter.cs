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

        [JsonProperty("accountdata")]
        public AccountData accountdata { get; set; }

        public Waiter(AccountData _accountdata)
        {
            accountdata = _accountdata;
        }
    }
}
