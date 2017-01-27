using System.Collections.Generic;
using Dapper;
using ModuloCongresso.Domain.Entities;
using ModuloCongresso.Domain.Interfaces.Repository.CotacaoRepository;
using ModuloCongresso.Infra.Data.Context;

namespace ModuloCongresso.Infra.Data.Repository.CotacaoRepository
{
    public class ProdutoRepository : Repository<Produto>, IProdutoRepository
    {
        public ProdutoRepository(ModuloCongressoContext context) 
            : base(context)
        {
        }

        public override IEnumerable<Produto> ObterTodos()
        {
            using (var cn = ModuloCongressoConnection)
            {
                var sqlProduto = @"Select * from Produto";
                return cn.Query<Produto>(sqlProduto);
            }
        }
    }
}