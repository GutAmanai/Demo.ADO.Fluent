using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Persistencia.Contrato.Infra;

namespace Persistencia.Infra
{
    public class ConnectionSql : IConnection
    {
        private SqlConnection conn { get; set; }
        private DbTransaction tran { get; set; }
        private string stConnection { get; set; }
        private IDbCommand dbCommand { get; set; }
        private IList<IDbDataParameter> dbDataParameter { get; set; }
        private readonly List<string> liQuery;
 
        public ConnectionSql()
        {
            this.stConnection = ConfigurationManager.AppSettings["conn"];
            conn = new SqlConnection(this.stConnection);

            this.dbCommand = new SqlCommand();
            this.dbCommand.Connection = conn;

            liQuery = new List<string>();
        }

        public IConnection Sql(string query)
        {
            this.liQuery.Add(query);
            return this;
        }

        public IConnection Parameter(string name, object value)
        {
            var parameter = dbCommand.CreateParameter();
            parameter.ParameterName = name;
            parameter.Value = value;

            this.dbDataParameter.Add(parameter);
            return this;
        }

        public IConnection Open()
        {
            if (conn != null && conn.State != ConnectionState.Open)
                conn.Open();

            return this;
        }

        public IConnection BeginTransaction()
        {
            if (tran != null)
                this.tran = conn.BeginTransaction();
            return this;
        }

        public IConnection Rollback()
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
