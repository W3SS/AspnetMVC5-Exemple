using System.Collections.Generic;
using Dapper;
using ModuloCongresso.Domain.Entities;
using ModuloCongresso.Domain.Interfaces.Repository.CotacaoRepository;
using ModuloCongresso.Infra.Data.Context;

namespace ModuloCongresso.Infra.Data.Repository.CotacaoRepository
{
    public class TipoSeguroRepository : Repository<TipoSeguro>, ITipoSeguroRepository
    {
        public TipoSeguroRepository(ModuloCongressoContext context)
            : base(context)
        {

        }

        public override IEnumerable<TipoSeguro> ObterTodos()
        {
            using (var cn = ModuloCongressoConnection) 
            {
                var query = @"Select * from TipoSeguro";
                return cn.Query<TipoSeguro>(query);
            }
        }
    }
}