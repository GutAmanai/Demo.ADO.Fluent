using System.Collections.Generic;
using Persistencia.Dominio.Model;

namespace Persistencia.Dominio.Contrato.Repositorio
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
