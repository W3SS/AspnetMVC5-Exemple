using System.Collections.Generic;
using Dapper;
using ModuloCongresso.Domain.Entities;
using ModuloCongresso.Domain.Interfaces.Repository.CotacaoRepository;
using ModuloCongresso.Infra.Data.Context;

namespace ModuloCongresso.Infra.Data.Repository.CotacaoRepository
{
    public class SexoRepository : Repository<Sexo>, ISexoRepository
    {
        public SexoRepository(ModuloCongressoContext context) 
            : base(context)
        {
        }

        public override IEnumerable<Sexo> ObterTodos()
        {
            using (var cn = ModuloCongressoConnection)
            {
                var query = @"Select * from Sexo";
                return cn.Query<Sexo>(query);
            }
        }
    }
}