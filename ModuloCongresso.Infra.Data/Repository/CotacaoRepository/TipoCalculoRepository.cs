using System.Collections.Generic;
using System.Linq;
using Dapper;
using ModuloCongresso.Domain.Entities;
using ModuloCongresso.Domain.Interfaces.Repository.CotacaoRepository;
using ModuloCongresso.Infra.Data.Context;

namespace ModuloCongresso.Infra.Data.Repository.CotacaoRepository
{
    public class TipoCalculoRepository : Repository<TipoCalculo>, ITipoCalculoRepository
    {
        public TipoCalculoRepository(ModuloCongressoContext context)
            : base(context)
        {

        }

        public override IEnumerable<TipoCalculo> ObterTodos()
        {
            using (var cn = ModuloCongressoConnection)
            {
                var query = @"Select * from TipoCalculo";
                return cn.Query<TipoCalculo>(query);
            }
        }

        public TipoCalculo ObterTipoCalculoPorId(int tipoCalculoId)
        {
            using (var cn = ModuloCongressoConnection)
            {
                var query = cn.Query<TipoCalculo>("SELECT * FROM TipoCalculo WHERE TipoCalculoId = @TipoCalculoId",
                    new { TipoCalculoId = tipoCalculoId }).FirstOrDefault();
                return query;
            }
        }
    }
}