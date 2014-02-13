using System.Data;

namespace Persistencia.Infra.Contrato
{
    public interface IConnectionFunc
    {
        IConnectionFunc Command(string query);
        IConnectionFunc Parameter(string name, object value);
        IConnectionFunc Open();
        IConnectionFunc BeginTransaction();
        IConnectionFunc Rollback();
        int ExecuteNonQuery();
        IDataReader ExecuteReader();
        void Close();        
    }
}
