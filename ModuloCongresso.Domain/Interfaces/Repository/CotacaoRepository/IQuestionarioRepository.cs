using ModuloCongresso.Domain.Entities;

namespace ModuloCongresso.Domain.Interfaces.Repository.CotacaoRepository
{
    public interface IQuestionarioRepository : IRepository<Questionario>
    {
        Questionario ObterQuestionarioCotacao(int cotacaoId);
    }
}