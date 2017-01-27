using Dapper;
using ModuloCongresso.Domain.Entities;
using ModuloCongresso.Domain.Interfaces.Repository;
using ModuloCongresso.Infra.Data.Context;
using System.Collections.Generic;

namespace ModuloCongresso.Infra.Data.Repository
{
    public class ProfissaoRepository : Repository<Profissao>, IProfissaoRepository
    {
        public ProfissaoRepository(ModuloCongressoContext context)
            : base(context)
        {

        }

        public override IEnumerable<Profissao> ObterTodos()
        {
            using (var cn = ModuloCongressoConnection)
            {
                var sqlProfissao = @"Select * from Profissoes";
                return cn.Query<Profissao>(sqlProfissao);
            }
        }
    }
}
