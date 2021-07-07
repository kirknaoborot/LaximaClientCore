using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LaximaClientCore.Interfaces
{
    public interface ICredential
    {
        string GetQueryHash(string query);
        string GetLogin();
    }
}
