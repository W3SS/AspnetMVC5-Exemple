using System.Collections.Generic;
using Dapper;
using ModuloCongresso.Domain.Entities;
using ModuloCongresso.Domain.Interfaces.Repository.CotacaoRepository;
using ModuloCongresso.Infra.Data.Context;

namespace ModuloCongresso.Infra.Data.Repository.CotacaoRepository
{
    public class RastreadorRepository : Repository<Rastreador>, IRastreadorRepository
    {
        public RastreadorRepository(ModuloCongressoContext context)
            : base(context)
        {

        }

        public override IEnumerable<Rastreador> ObterTodos()
        {
            using (var cn = ModuloCongressoConnection)
            {
                var query = @"Select * from Rastreador";
                return cn.Query<Rastreador>(query);
            }
        }
    }
}