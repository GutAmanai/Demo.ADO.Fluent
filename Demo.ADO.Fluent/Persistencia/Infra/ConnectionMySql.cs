using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Persistencia.Contrato.Infra;

namespace Persistencia.Infra
{
    public class ConnectionMySql : IConnection
    {
        public IConnection Sql(string query)
        {
            throw new NotImplementedException();
        }

        public IConnection Parameter(string name, object value)
        {
            throw new NotImplementedException();
        }

        public IConnection Open()
        {
            throw new NotImplementedException();
        }

        public IConnection BeginTransaction()
        {
            throw new NotImplementedException();
        }

        public IConnection Rollback()
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
