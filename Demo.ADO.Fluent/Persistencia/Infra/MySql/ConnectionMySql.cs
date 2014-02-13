using MySql.Data.MySqlClient;
using Persistencia.Contrato.Infra;
using Persistencia.Infra.Contrato;
using System.Configuration;
using Persistencia.Infra.Mysql;

namespace Persistencia.Infra.MySql
{
    public class ConnectionMySql : IConnection
    {
        private MySqlConnection conn { get; set; }
        private IConnectionProcedure connectionProcedure { get; set; }
        private IConnectionFunc connectionFunc { get; set; }

        public ConnectionMySql()
        {
            var stConnection = ConfigurationManager.AppSettings["conn"];
            conn = new MySqlConnection(stConnection);

            this.connectionFunc = new ConnectionFuncMySql(conn);
            this.connectionProcedure = new ConnectionProcedureMySql(conn);
        }

        public IConnectionProcedure Procedure
        {
            get
            {
                return this.connectionProcedure;
            }
        }

        public IConnectionFunc Sql
        {
            get
            {
                return this.connectionFunc;
            }
        }
    }
}
