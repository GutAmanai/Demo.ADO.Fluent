using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Persistencia.Dominio.Model;

namespace Persistencia.Contrato.Repositorio
{
    public interface IRepositorio<T> where T : EntidadeBase
    {
        int Add(T entidade);
        int Update(T entidade);
        int Excluir(int idEntidade);

        T BuscarPorId(int id);
        IEnumerable<T> ListarTodos();
    }
}
