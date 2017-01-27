using Dapper;
using ModuloCongresso.Domain.Entities;
using ModuloCongresso.Domain.Interfaces.Repository;
using ModuloCongresso.Infra.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ModuloCongresso.Infra.Data.Repository
{
    public class ClienteRepository : Repository<Cliente>, IClienteRepository
    {
        public ClienteRepository(ModuloCongressoContext context)
            :base(context)
        {

        }

        public IEnumerable<Cliente> ObterAtivos()
        {
            return Buscar(c => c.Ativo);   
        }

        public Cliente ObterPorCpf(string cpf)
        {
            return Buscar(c => c.CPF == cpf).FirstOrDefault();
        }

        public Cliente ObterPorEmail(string email)
        {
            return Buscar(c => c.email == email).FirstOrDefault();
        }

        public override IEnumerable<Cliente> ObterTodos()
        {
            using (var cn = Db.Database.Connection)
            {
                var cliente = cn.Query<Cliente, Profissao, Cliente>
                    ("SELECT * " +
                     "  FROM Clientes c" +
                     "  JOIN Profissoes p ON c.ProfissaoId = p.ProfissaoId",
                        (c, p) =>
                        {
                            c.Profissao = p;
                            return c;
                        },
                        splitOn: "ClienteId, ProfissaoId");

                return cliente;
            }
            //return Db.Clientes.OrderBy(c => c.DataCadastro); 
        }

        public override Cliente ObterPorId(Guid id)
        {
            using (var cn = Db.Database.Connection)
            {
                var sqlCliente = @"SELECT * " +
                         "  FROM Clientes c" +
                         "  LEFT JOIN Enderecos e ON e.ClienteId = c.ClienteId" +
                         "  JOIN Profissoes p ON c.ProfissaoId = p.ProfissaoId" +
                         " WHERE c.ClienteId = @ClienteId";

                var cliente = cn.Query<Cliente, Endereco, Profissao, Cliente>(sqlCliente,
                        (c, e, p) =>
                        {
                            c.Profissao = p;
                            c.Enderecos.Add(e);
                            return c;
                        },
                        new { ClienteId = id }, splitOn: "ClienteId, EnderecoId, ProfissaoId");

                return cliente.FirstOrDefault();
            }
        }

        public Cliente ObterClienteCotacao(int cotacaoId)
        {
            using (var cn = ModuloCongressoConnection)
            {
                const string sql = @"SELECT * " +
                                     "  FROM Clientes c" +
                                     "  LEFT JOIN Enderecos e ON e.ClienteId = c.ClienteId" +
                                     " WHERE c.CotacaoId = @CotacaoId";

                var query = cn.Query<Cliente, Endereco, Cliente>(sql,
                    (c, e) =>
                    {
                        c.Enderecos.Add(e); 
                        return c;
                    },
                new { CotacaoId = cotacaoId }, splitOn: "ClienteId, EnderecoId");

                return query.FirstOrDefault();
            }
        }

        public override void Remover(Guid id)
        {
            var cliente = ObterPorId(id);

            cliente.Ativo = false;

            Atualizar(cliente);
        }
    }
}
