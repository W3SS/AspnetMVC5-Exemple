using System;
using System.Linq;
using Dapper;
using ModuloCongresso.Domain.Entities;
using ModuloCongresso.Domain.Interfaces.Repository.CotacaoRepository;
using ModuloCongresso.Infra.Data.Context;

namespace ModuloCongresso.Infra.Data.Repository.CotacaoRepository
{
    public class EnderecoRepository : Repository<Endereco>, IEnderecoRepository
    {
        public EnderecoRepository(ModuloCongressoContext context)
            :base(context)
        {

        }

        public Endereco ObterEnderecoCliente(Guid clienteId)
        {
            using (var cn = ModuloCongressoConnection)
            {
                var query = cn.Query<Endereco>("SELECT * FROM Enderecos WHERE ClienteId = @ClienteId",
                    new { ClienteId = clienteId }).FirstOrDefault();
                return query;
            }
        }
    }
}