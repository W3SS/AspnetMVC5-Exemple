using ModuloCongresso.Domain.Entities;

namespace ModuloCongresso.Domain.Interfaces.Repository.CotacaoRepository
{
    public interface IItemRepository : IRepository<Item>
    {
        Item ObterItemCotacao(int cotacaoId);
    }
}