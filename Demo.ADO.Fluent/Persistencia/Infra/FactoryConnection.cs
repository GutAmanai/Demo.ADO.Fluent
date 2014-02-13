using System.Configuration;
using Persistencia.Contrato.Infra;
using Persistencia.Infra.MySql;
using Persistencia.Infra.SqlServer;

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
