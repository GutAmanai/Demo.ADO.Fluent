using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Persistencia.Contrato.Infra;

namespace Persistencia.Infra
{
    public class FactoryConnection
    {
        public static IConnection GetConnection()
        {
            var stringBase = ConfigurationManager.AppSettings["banco"].ToString().ToLower();

            if (stringBase == "sqlserver")
                return new ConnectionSql();
            if (stringBase == "mysql")
                return new ConnectionMySql();

            return null;
        }
    }
}
