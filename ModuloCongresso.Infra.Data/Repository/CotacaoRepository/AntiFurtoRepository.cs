using System.Collections.Generic;
using Dapper;
using ModuloCongresso.Domain.Entities;
using ModuloCongresso.Domain.Interfaces.Repository.CotacaoRepository;
using ModuloCongresso.Infra.Data.Context;

namespace ModuloCongresso.Infra.Data.Repository.CotacaoRepository
{
    public class AntiFurtoRepository : Repository<AntiFurto>, IAntiFurtoRepository
    {
        public AntiFurtoRepository(ModuloCongressoContext context)
            : base(context)
        {

        }

        public override IEnumerable<AntiFurto> ObterTodos()
        {
            using (var cn = ModuloCongressoConnection)
            {
                var query = @"Select * from Antifurto";
                return cn.Query<AntiFurto>(query);
            }
        }
    }
}