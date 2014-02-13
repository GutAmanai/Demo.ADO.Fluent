using System.Data;

namespace Persistencia.Contrato.Infra
{
    public interface IConnection
    {
        IConnection Sql(string query);
        IConnection Parameter(string name, object value);
        IConnection Open();
        IConnection BeginTransaction();
        IConnection Rollback();
        int ExecuteNonQuery();
        IDataReader ExecuteReader();
        void Close();        
    }
}
