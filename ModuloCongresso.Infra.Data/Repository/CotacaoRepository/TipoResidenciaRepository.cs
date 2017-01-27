using System.Collections.Generic;
using Dapper;
using ModuloCongresso.Domain.Entities;
using ModuloCongresso.Domain.Interfaces.Repository.CotacaoRepository;
using ModuloCongresso.Infra.Data.Context;

namespace ModuloCongresso.Infra.Data.Repository.CotacaoRepository
{
    public class TipoResidenciaRepository : Repository<TipoResidencia>, ITipoResidenciaRepository
    {
        public TipoResidenciaRepository(ModuloCongressoContext context)
            : base(context)
        {

        }

        public override IEnumerable<TipoResidencia> ObterTodos()
        {
            using (var cn = ModuloCongressoConnection)
            {
                var query = @"Select * from TipoResidencia";
                return cn.Query<TipoResidencia>(query);
            }
        }
    }
}