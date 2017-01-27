using System.Collections.Generic;
using Dapper;
using ModuloCongresso.Domain.Entities;
using ModuloCongresso.Domain.Interfaces.Repository.CotacaoRepository;
using ModuloCongresso.Infra.Data.Context;

namespace ModuloCongresso.Infra.Data.Repository.CotacaoRepository
{
    public class UsoRepository : Repository<Uso>, IUsoRepository
    {
        public UsoRepository(ModuloCongressoContext context) 
            : base(context)
        {
        }

        public override IEnumerable<Uso> ObterTodos()
        {
            using (var cn = ModuloCongressoConnection)
            {
                var query = @"Select * from Uso";
                return cn.Query<Uso>(query);
            }
        }
    }
}