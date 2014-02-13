﻿using System;
using System.Collections.Generic;
using Persistencia.Contrato.Repositorio;
using Persistencia.Dominio.Model;

namespace Persistencia.Repositorio
{
    public class RepositorioEmpresa : RepositorioBase<Empresa>, IRepositorio<Empresa>
    {
        public int Add(Empresa entidade)
        {
            try
            {
                return _connection
                            .Sql(@"INSERT INTO Empresa (nome) VALUES (@Nome)")
                            .Open()
                            .Parameter("@Nome", entidade.Nome)
                            .ExecuteNonQuery();
            }
            finally
            {
                _connection.Close();
            }
        }

        public int Update(Empresa entidade)
        {
            throw new NotImplementedException();
        }
        
        public int Excluir(int idEntidade)
        {
            throw new NotImplementedException();
        }

        public Empresa BuscarPorId(int id)
        {
            try
            {
                return _connection
                            .Sql(@"SELECT * FROM Empresa WHERE Id = @Id")
                            .Open()
                            .Parameter("@Id", id)
                            .ExecuteReader()
                            .Firt<Empresa>();
            }
            finally
            {
                _connection.Close();
            }
        }

        public IEnumerable<Empresa> ListarTodos()
        {
            try
            {
                return _connection
                            .Sql(@"SELECT * FROM Empresa")
                            .Open()
                            .ExecuteReader()
                            .List<Empresa>();
            }
            finally
            {
                _connection.Close();
            }
        }
    }
}
