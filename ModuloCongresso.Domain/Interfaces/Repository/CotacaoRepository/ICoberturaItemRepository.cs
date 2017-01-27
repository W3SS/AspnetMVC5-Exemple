using System.Collections.Generic;
using ModuloCongresso.Domain.Entities;

namespace ModuloCongresso.Domain.Interfaces.Repository.CotacaoRepository
{
    public interface ICoberturaItemRepository : IRepository<CoberturasItem>
    {
        IEnumerable<CoberturasItem> ObterCoberturasItems(int itemId);
    }
}