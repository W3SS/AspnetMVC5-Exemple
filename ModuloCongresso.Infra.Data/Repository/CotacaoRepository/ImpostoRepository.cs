using System.Collections.Generic;
using Dapper;
using ModuloCongresso.Domain.Entities;
using ModuloCongresso.Domain.Interfaces.Repository.CotacaoRepository;
using ModuloCongresso.Infra.Data.Context;

namespace ModuloCongresso.Infra.Data.Repository.CotacaoRepository
{
    public class ImpostoRepository : Repository<Imposto>, IImpostoRepository
    {
        public ImpostoRepository(ModuloCongressoContext context) : base(context)
        {
        }

        public override IEnumerable<Imposto> ObterTodos()
        {
            using (var cn = ModuloCongressoConnection)
            {
                var query = @"Select * from Imposto";
                return cn.Query<Imposto>(query);
            }
        }
    }
}