using System.Collections.Generic;
using Dapper;
using ModuloCongresso.Domain.Entities;
using ModuloCongresso.Domain.Interfaces.Repository.CotacaoRepository;
using ModuloCongresso.Infra.Data.Context;

namespace ModuloCongresso.Infra.Data.Repository.CotacaoRepository
{
    public class TempoHabilitacaoRepository : Repository<TempoHabilitacao>, ITempoHabilitacaoRepository
    {
        public TempoHabilitacaoRepository(ModuloCongressoContext context) : base(context)
        {
        }

        public override IEnumerable<TempoHabilitacao> ObterTodos()
        {
            using (var cn = ModuloCongressoConnection)
            {
                var query = @"Select * from TempoHabilitacao";
                return cn.Query<TempoHabilitacao>(query);
            }
        }
    }
}