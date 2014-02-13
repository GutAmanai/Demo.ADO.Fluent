using Persistencia.Contrato.Infra;
using Persistencia.Infra;

namespace Persistencia.Repositorio
{
    public abstract class RepositorioBase<T>
    {
        protected readonly IConnection _connection;

        protected RepositorioBase()
        {
            this._connection = ConnectionInfra.Instance;
        }
    }
}
