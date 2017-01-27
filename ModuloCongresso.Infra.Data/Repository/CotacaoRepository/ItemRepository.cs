using System.Linq;
using Dapper;
using ModuloCongresso.Domain.Entities;
using ModuloCongresso.Domain.Interfaces.Repository.CotacaoRepository;
using ModuloCongresso.Infra.Data.Context;

namespace ModuloCongresso.Infra.Data.Repository.CotacaoRepository
{
    public class ItemRepository : Repository<Item>, IItemRepository
    {
        public ItemRepository(ModuloCongressoContext context) 
            : base(context)
        {
        }

        public Item ObterItemCotacao(int cotacaoId)
        {
            using (var cn = ModuloCongressoConnection)
            {
                var query = cn.Query<Item>("SELECT * FROM Item WHERE CotacaoId = @CotacaoId",
                    new { CotacaoId = cotacaoId }).FirstOrDefault();
                return query;
            }
        }
    }
}