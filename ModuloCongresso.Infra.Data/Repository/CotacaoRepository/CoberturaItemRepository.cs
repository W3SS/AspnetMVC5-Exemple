using System.Collections.Generic;
using Dapper;
using ModuloCongresso.Domain.Entities;
using ModuloCongresso.Domain.Interfaces.Repository.CotacaoRepository;
using ModuloCongresso.Infra.Data.Context;

namespace ModuloCongresso.Infra.Data.Repository.CotacaoRepository
{
    public class CoberturaItemRepository : Repository<CoberturasItem>, ICoberturaItemRepository
    {
        public CoberturaItemRepository(ModuloCongressoContext context) 
            : base(context)
        {
        }

        public IEnumerable<CoberturasItem> ObterCoberturasItems(int itemId)
        {
            using (var cn = ModuloCongressoConnection)
            {
                var query = cn.Query<CoberturasItem, Item, Coberturas, CoberturasItem>
                    ("SELECT * " +
                     "  FROM itemcoberturas it" +
                     "  JOIN Item i ON it.ItemId = i.ItemId" +
                     "  JOIN Coberturas c ON it.CoberturaId = c.CoberturaId" +
                     "  WHERE it.ItemId = @ItemId",
                        (it, i, c) =>
                        {
                            it.Item = i;
                            it.Coberturas = c;
                            return it;
                        },
                        new { ItemId = itemId }, splitOn: "CoberturasItemId, ItemId, CoberturaId");

                return query;
            }
        }
    }
}