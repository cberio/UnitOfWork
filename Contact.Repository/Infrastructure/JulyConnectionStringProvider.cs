using System;
using System.Configuration;
using July.Common;
using July.Common.Infrastructure.Contract;

namespace July.Common.Infrastructure
{
    public class JulyConnectionStringProvider : IConnectionStringProvider
    {

        public string ConnectionString
        {
            get
            {
                var server = ConfigurationManager.ConnectionStrings["July"].ConnectionString;
                if(string.IsNullOrEmpty(server))
                    throw new Exception("A valid connection string needs to be set in the configuration file.");
                return server;
            }
        }
    }
}