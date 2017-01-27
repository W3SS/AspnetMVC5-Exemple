using System.Collections.Generic;
using System.Linq;
using Dapper;
using ModuloCongresso.Domain.Entities;
using ModuloCongresso.Domain.Interfaces.Repository.CotacaoRepository;
using ModuloCongresso.Infra.Data.Context;

namespace ModuloCongresso.Infra.Data.Repository.CotacaoRepository
{
    public class CoberturasProdutoRepository : Repository<CoberturasProduto>, ICoberturasProdutoRepository
    {
        public CoberturasProdutoRepository(ModuloCongressoContext context) 
            : base(context)
        {
        }

        public override IEnumerable<CoberturasProduto> ObterTodos()
        {
            using (var cn = ModuloCongressoConnection)
            {
                var coberturas = cn.Query<CoberturasProduto, Coberturas, Produto, CoberturasProduto>
                    ("SELECT * " +
                     "  FROM CoberturasProduto cp" +
                     "  JOIN Coberturas c ON cp.CoberturaId = c.CoberturaId" +
                     "  JOIN Produto p ON cp.ProdutoId = p.ProdutoId",
                        (cp, c, p) =>
                        {
                            cp.Coberturas = c;
                            cp.Produtos = p;
                            return cp;
                        },
                        splitOn: "CoberturasProdutoId, CoberturaId, ProdutoId");

                return coberturas;
            }
        }

        public IEnumerable<CoberturasProduto> ObterCoberturasProdutos(int produto)
        {
            using (var cn = ModuloCongressoConnection)
            {
                var coberturas = cn.Query<CoberturasProduto, Coberturas, Produto, CoberturasProduto>
                    ("SELECT * " +
                     "  FROM CoberturasProduto cp" +
                     "  JOIN Coberturas c ON cp.CoberturaId = c.CoberturaId" +
                     "  JOIN Produto p ON cp.ProdutoId = p.ProdutoId" +
                     "  WHERE cp.ProdutoId = @ProdutoId",
                        (cp, c, p) =>
                        {
                            cp.Coberturas = c;
                            cp.Produtos = p;
                            return cp;
                        },
                        new { ProdutoId = produto }, splitOn: "CoberturasProdutoId, CoberturaId, ProdutoId");

                return coberturas;
            }
        }

        public CoberturasProduto ObterCoberturaProdutos(int produto, int coberturaId)
        {
            using (var cn = ModuloCongressoConnection)
            {
                var sqlCobertura = @"SELECT * " +
                         "  FROM CoberturasProduto cp" +
                         "  JOIN Coberturas c ON cp.CoberturaId = c.CoberturaId" +
                         "  JOIN Produto p ON cp.ProdutoId = p.ProdutoId" +
                         " WHERE cp.ProdutoId = @ProdutoId AND cp.CoberturaId = @CoberturaId";

                var cobertura = cn.Query<CoberturasProduto, Coberturas, Produto, CoberturasProduto>(sqlCobertura,
                        (cp, c, p) =>
                        {
                            cp.Coberturas = c;
                            cp.Produtos = p;
                            return cp;
                        },
                        new { ProdutoId = produto, CoberturaId = coberturaId }, splitOn: "CoberturaProdutoId, CoberturaId, ProdutoId");

                return cobertura.FirstOrDefault();
            }
        }
    }
}