namespace Persistencia.Infra.Contrato
{
    public interface IConnectionProcedure
    {
        IConnectionProcedure CommandName(string name);
        IConnectionProcedure Parameter(string name, object value);
        IConnectionProcedure CommandTimeout(int timeout);
        int ExecuteCommand();
    }
}
