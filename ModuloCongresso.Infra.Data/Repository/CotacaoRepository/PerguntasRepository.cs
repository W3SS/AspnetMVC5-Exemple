using Dapper;
using ModuloCongresso.Domain.Entities;
using ModuloCongresso.Domain.Interfaces.Repository.CotacaoRepository;
using ModuloCongresso.Infra.Data.Context;
using System.Collections.Generic;

namespace ModuloCongresso.Infra.Data.Repository.CotacaoRepository
{
    public class PerguntasRepository : Repository<Perguntas>, IPerguntaRepository
    {
        public PerguntasRepository(ModuloCongressoContext context) 
            : base(context)
        {
        }

        public override IEnumerable<Perguntas> ObterTodos()
        {
            using (var cn = ModuloCongressoConnection)
            {
                var sqlperguntas = @"Select * from Perguntas";
                return cn.Query<Perguntas>(sqlperguntas);
            }
        }
    }
}