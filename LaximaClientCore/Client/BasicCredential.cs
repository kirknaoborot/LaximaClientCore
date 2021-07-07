using LaximaClientCore.Interfaces;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace LaximaClientCore.Client
{
    public class BasicCredential : ICredential
    {
        /// <summary>
        /// Логин
        /// </summary>
        public string Login { get; set; }
        /// <summary>
        /// Пароль
        /// </summary>
        public string Password { get; set; }

        public string GetLogin()
        {
            return Login;
        }

        public string GetQueryHash(string query)
        {
            return Convert.ToBase64String(MD5.Create().ComputeHash(Encoding.UTF8.GetBytes($"{query}.{Password}")));
        }
    }
}
