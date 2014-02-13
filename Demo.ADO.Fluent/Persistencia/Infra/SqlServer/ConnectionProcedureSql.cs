using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Persistencia.Infra.Contrato;

namespace Persistencia.Infra.SqlServer
{
    public class ConnectionProcedureSql : IConnectionProcedure
    {
        private SqlConnection conn { get; set; }
        private IDbCommand dbCommand { get; set; }
        private IList<IDbDataParameter> dbDataParameter { get; set; }

        public ConnectionProcedureSql(SqlConnection conn)
        {
            this.conn = conn;

            this.dbCommand = new SqlCommand();
            this.dbCommand.Connection = conn;
        }

        public IConnectionProcedure CommandName(string name)
        {
            throw new NotImplementedException();
        }

        public IConnectionProcedure Parameter(string name, object value)
        {
            throw new NotImplementedException();
        }

        public IConnectionProcedure CommandTimeout(int timeout)
        {
            throw new NotImplementedException();
        }

        public int ExecuteCommand()
        {
            throw new NotImplementedException();
        }
    }
}
