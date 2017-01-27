using ModuloCongresso.Domain.Entities;

namespace ModuloCongresso.Domain.Interfaces.Repository.CotacaoRepository
{
    public interface IPerfilRepository : IRepository<Perfil>
    {
        Perfil ObterPerfilCotacao(int cotacaoId);
    }
}