using System.Collections.Generic;
using Dapper;
using ModuloCongresso.Domain.Entities;
using ModuloCongresso.Domain.Interfaces.Repository.CotacaoRepository;
using ModuloCongresso.Infra.Data.Context;

namespace ModuloCongresso.Infra.Data.Repository.CotacaoRepository
{
    public class CoberturasRepository : Repository<Coberturas>, ICoberturaRepository
    {
        public CoberturasRepository(ModuloCongressoContext context) 
            : base(context)
        {
        }

        public override IEnumerable<Coberturas> ObterTodos()
        {
            using (var cn = ModuloCongressoConnection)
            {
                var query = @"Select * from Coberturas";
                return cn.Query<Coberturas>(query);
            }
        }

        public IEnumerable<Coberturas> ObterCoberturasProdutos(int produto)
        {
            using (var cn = ModuloCongressoConnection)
            {
                var coberturas = cn.Query<Coberturas, CoberturasProduto, Coberturas>
                    ("SELECT c.*, cp.* " +
                     "  FROM Coberturas c" +
                     "  JOIN CoberturasProduto cp ON c.CoberturaId = cp.CoberturaId" +
                     "  WHERE cp.ProdutoId = @ProdutoId",
                        (c, cp) =>
                        {
                            cp.Coberturas = c;
                            return c;
                        },
                        new { ProdutoId = produto }, splitOn: "CoberturaId");

                return coberturas;
            }
        }
    }
}