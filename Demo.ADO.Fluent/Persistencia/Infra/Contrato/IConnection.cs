using Persistencia.Infra.Contrato;

namespace Persistencia.Contrato.Infra
{
    public interface IConnection
    {
        IConnectionProcedure Procedure { get; }
        IConnectionFunc Sql { get; }  
    }
}
