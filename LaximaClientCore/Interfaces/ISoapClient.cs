using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LaximaClientCore.Interfaces
{
    public interface ISoapClient
    {
        List<string> ExecuteQury(string query);
    }
}
