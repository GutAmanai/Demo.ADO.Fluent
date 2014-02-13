using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Persistencia.Contrato.Infra;

namespace Persistencia.Infra
{
    public abstract class Connection
    {
        static IConnection instance;
        static readonly object padlock = new object();

        public static IConnection GetInstance
        {
            get
            {
                lock (padlock)
                {
                    if (instance == null)
                        instance = FactoryConnection.GetConnection();
                }
                return instance;
            }
        }
    }
}
