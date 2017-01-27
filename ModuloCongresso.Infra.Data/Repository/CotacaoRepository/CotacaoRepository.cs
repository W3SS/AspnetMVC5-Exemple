using System;
using System.Collections.Generic;
using System.Linq;
using Dapper;
using ModuloCongresso.Domain.Entities;
using ModuloCongresso.Domain.Interfaces.Repository.CotacaoRepository;
using ModuloCongresso.Infra.Data.Context;

namespace ModuloCongresso.Infra.Data.Repository.CotacaoRepository
{
    public class CotacaoRepository : Repository<Cotacao>, ICotacaoRepository
    {
        public CotacaoRepository(ModuloCongressoContext context)
            :base(context)
        {

        }

        public Cotacao ObterCotacaoPorId(int cotacaoId)
        {
            using (var cn = ModuloCongressoConnection)
            {
                var cotacao = cn.Query<Cotacao>("SELECT * FROM Cotacao WHERE CotacaoId = @CotacaoId",
                    new { CotacaoId = cotacaoId }).FirstOrDefault();
                return cotacao;
            }
        }

        public IEnumerable<Cotacao> ObterCotacoesPorUsuario(Guid userId)
        {
            using (var cn = ModuloCongressoConnection)
            {
                var cotacao = cn.Query<Cotacao>("SELECT * FROM Cotacao WHERE UserId = @UserId",
                    new { UserId = userId });
                return cotacao;
            }
        }
    }
}
