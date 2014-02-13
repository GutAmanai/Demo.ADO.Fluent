using Persistencia.Contrato.Infra;

namespace Persistencia.Infra
{
    public abstract class ConnectionInfra
    {
        static IConnection _instance;
        static readonly object padlock = new object();

        public static IConnection Instance
        {
            get
            {
                lock (padlock)
                {
                    if (_instance == null)
                        _instance = FactoryConnection.GetConnection();
                }
                return _instance;
            }
        }
    }
}
