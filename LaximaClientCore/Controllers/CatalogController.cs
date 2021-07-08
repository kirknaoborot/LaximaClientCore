using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LaximaClientCore.Client;
using System.Security.Cryptography;
using System.Text;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace LaximaClientCore.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CatalogController : ControllerBase
    {
        // GET: api/<CatalogController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            ServiceReference1.ServiceWsClient serviceWsClient = new ServiceReference1.ServiceWsClient();
            serviceWsClient.OpenAsync();
            ServiceReference1.ServiceWsChannel serviceWs;
            var current_query = "FindOEM:Locale=ru_RU|Brand={}|OEM={}|Options=crosses|ReplacementTypes=Replacement,Duplicate,Synonym,Bidirectional";
            var key = Convert.ToBase64String(MD5.Create().ComputeHash(Encoding.UTF8.GetBytes($"{current_query}")));
            serviceWsClient.ChannelFactory.CreateChannel();
            var result = serviceWsClient.QueryDataLoginAsync(current_query, "",key).Result;
            serviceWsClient.CloseAsync();

            //var credentials = new BasicCredential
            //{
            //    Login = "",
            //    Password = ""
            //};
            //var client = new SoapClient(credentials);
            //string query = "FindOEM:Locale=ru_RU|Brand=RVI|OEM=5001837172|Options=crosses|ReplacementTypes=Replacement,Duplicate,Synonym,Bidirectional";
            //var result = client.ExecuteQury(query);
            return new List<string>();

            //var credentials = new BasicCredential
            //{
            //    Login = "",
            //    Password = ""
            //};

            //var client = new SoapClient(credentials);
            //var laximo = new Laximo(client, new QueryBuilder());
//            client = Client('{}?wsdl'.format(endpoint[:len(endpoint) - 1]))
//    current_query = 'FindOEM:Locale=ru_RU|Brand={}|OEM={}|Options=crosses|ReplacementTypes=Replacement,Duplicate,Synonym,Bidirectional'.format(brand, oem)
//    key = '{}{}'.format(current_query, password)
//    md5_key = hashlib.md5(key.encode('utf-8')).hexdigest()
//    responce = ''
//    responce = client.service.QueryDataLogin(current_query, login, md5_key)
//    return responce

//endpoint = 'http://aws.laximo.net/ec.Kito.Aftermarket/services/Catalog.CatalogHttpSoap12Endpoint/'
//login = "yourusername"
//password = "yourpassword"
//brand = "RVI"
//oem = "5001837172"
        }

        // GET api/<CatalogController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<CatalogController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<CatalogController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<CatalogController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
