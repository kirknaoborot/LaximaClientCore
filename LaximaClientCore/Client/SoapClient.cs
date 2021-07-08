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
        public string DefaultLocation { get; set; } = "http://ws.laximo.net/ec.Kito.WebCatalog/services/Catalog.CatalogHttpSoap11Endpoint/";

        public string DefaultUri { get; set; } = "http://WebCatalog.Kito.ec";


        private readonly ICredential _credential;


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
