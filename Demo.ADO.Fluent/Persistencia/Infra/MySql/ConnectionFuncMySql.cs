using System;
using System.Collections.Generic;
using System.Data;
using MySql.Data.MySqlClient;
using Persistencia.Infra.Contrato;

namespace Persistencia.Infra.MySql
{
    public class ConnectionFuncMySql : IConnectionFunc
    {
        private MySqlConnection conn { get; set; }
        private IDbCommand dbCommand { get; set; }
        private IList<IDbDataParameter> dbDataParameter { get; set; }

        public ConnectionFuncMySql(MySqlConnection conn)
        {
            this.conn = conn;

            this.dbCommand = new MySqlCommand();
            this.dbCommand.Connection = conn;
        }

        public IConnectionFunc Command(string query)
        {
            throw new NotImplementedException();
        }

        public IConnectionFunc Parameter(string name, object value)
        {
            throw new NotImplementedException();
        }

        public IConnectionFunc Open()
        {
            throw new NotImplementedException();
        }

        public IConnectionFunc BeginTransaction()
        {
            throw new NotImplementedException();
        }

        public IConnectionFunc Rollback()
        {
            throw new NotImplementedException();
        }

        public int ExecuteNonQuery()
        {
            throw new NotImplementedException();
        }

        public IDataReader ExecuteReader()
        {
            throw new NotImplementedException();
        }

        public void Close()
        {
            throw new NotImplementedException();
        }
    }
}
