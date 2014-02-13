using Persistencia.Contrato.Infra;
using System.Configuration;
using System.Data.SqlClient;
using Persistencia.Infra.Contrato;

namespace Persistencia.Infra.SqlServer
{
    public class ConnectionSql : IConnection
    {
        private SqlConnection conn { get; set; }
        private IConnectionProcedure connectionProcedure { get; set; }
        private IConnectionFunc connectionFunc { get; set; }

        public ConnectionSql()
        {
            var stConnection = ConfigurationManager.AppSettings["conn"];
            conn = new SqlConnection(stConnection);

            this.connectionFunc = new ConnectionFuncSql(conn);
            this.connectionProcedure = new ConnectionProcedureSql(conn);
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
