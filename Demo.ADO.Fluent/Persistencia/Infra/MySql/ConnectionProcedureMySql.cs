using MySql.Data.MySqlClient;
using Persistencia.Infra.Contrato;
using System;
using System.Collections.Generic;
using System.Data;

namespace Persistencia.Infra.Mysql
{
    public class ConnectionProcedureMySql : IConnectionProcedure
    {
        private MySqlConnection conn { get; set; }
        private IDbCommand dbCommand { get; set; }
        private IList<IDbDataParameter> dbDataParameter { get; set; }

        public ConnectionProcedureMySql(MySqlConnection conn)
        {
            this.conn = conn;

            this.dbCommand = new MySqlCommand();
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
