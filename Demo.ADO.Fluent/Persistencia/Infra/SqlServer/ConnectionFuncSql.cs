using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using Persistencia.Infra.Contrato;

namespace Persistencia.Infra.SqlServer
{
    public class ConnectionFuncSql : IConnectionFunc
    {
        private SqlConnection conn { get; set; }
        private DbTransaction tran { get; set; }
        private IDbCommand dbCommand { get; set; }
        private IList<IDbDataParameter> dbDataParameter { get; set; }
        private readonly List<string> liQuery;

        public ConnectionFuncSql(SqlConnection conn)
        {
            this.conn = conn;

            this.dbCommand = new SqlCommand();
            this.dbCommand.Connection = conn;

            liQuery = new List<string>();
        }

        public IConnectionFunc Command(string query)
        {
            this.liQuery.Add(query);
            return this;
        }

        public IConnectionFunc Parameter(string name, object value)
        {
            var parameter = dbCommand.CreateParameter();
            parameter.ParameterName = name;
            parameter.Value = value;

            this.dbDataParameter.Add(parameter);
            return this;
        }

        public IConnectionFunc Open()
        {
            if (conn != null && conn.State != ConnectionState.Open)
                conn.Open();

            return this;
        }

        public IConnectionFunc BeginTransaction()
        {
            if (tran != null)
                this.tran = conn.BeginTransaction();
            return this;
        }

        public IConnectionFunc Rollback()
        {
            if (tran != null)
                tran.Rollback();
            return this;
        }

        public int ExecuteNonQuery()
        {
            try
            {
                dbCommand.CommandText = String.Join(" ", liQuery.ToArray());

                if (dbDataParameter.Any())
                    dbDataParameter.Select(dbCommand.Parameters.Add);

                return dbCommand.ExecuteNonQuery();
            }
            catch (Exception exp)
            {
            }
            finally
            {
                this.dbDataParameter = new List<IDbDataParameter>();
            }

            return 0;
        }

        public IDataReader ExecuteReader()
        {
            try
            {
                dbCommand.CommandText = String.Join(" ", liQuery.ToArray());

                if (dbDataParameter.Any())
                    dbDataParameter.Select(dbCommand.Parameters.Add);

                return dbCommand.ExecuteReader();
            }
            catch (Exception exp)
            {
            }
            finally
            {
                this.dbDataParameter = new List<IDbDataParameter>();
            }

            return null;
        }

        public void Close()
        {
            if (conn != null && conn.State != ConnectionState.Closed)
                conn.Close();
        }
    }
}
