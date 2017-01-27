using Dapper;
using ModuloCongresso.Domain.Entities;
using ModuloCongresso.Domain.Interfaces.Repository.CotacaoRepository;
using ModuloCongresso.Infra.Data.Context;
using System.Linq;

namespace ModuloCongresso.Infra.Data.Repository.CotacaoRepository
{
    public class QuestionarioRepository : Repository<Questionario>, IQuestionarioRepository
    {
        public QuestionarioRepository(ModuloCongressoContext context) 
            : base(context)
        {
        }

        public Questionario ObterQuestionarioCotacao(int cotacaoId)
        {
            using (var cn = ModuloCongressoConnection)
            {
                var query = cn.Query<Questionario>("SELECT * FROM Questionario WHERE CotacaoId = @CotacaoId",
                    new { CotacaoId = cotacaoId }).FirstOrDefault();
                return query;
            }
        }
    }
}