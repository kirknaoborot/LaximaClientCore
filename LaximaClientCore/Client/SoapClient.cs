using LaximaClientCore.Interfaces;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LaximaClientCore.Client
{
    public class SoapClient : ISoapClient
    {
        private readonly IConfiguration _configuration;

        public string DefaultLocation { get; set; }

        public string DefaultUri { get; set; }


        private readonly ICredential _credential;

        public SoapClient(IConfiguration configuration)
        {
            _configuration = configuration;

            DefaultLocation = _configuration.GetValue<string>("DefaultLocation");

            DefaultUri = _configuration.GetValue<string>("DefaultUri");
        }

        public SoapClient(ICredential credential)
        {
            _credential = credential;
        }

        public List<string> ExecuteQury(string query)
        {
            return new List<string>() {"QueryDataLogin", query, _credential.GetLogin(), _credential.GetQueryHash(query) }; 
        }
    }
}
