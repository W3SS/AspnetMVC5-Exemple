using System.Collections.Generic;
using Dapper;
using ModuloCongresso.Domain.Entities;
using ModuloCongresso.Domain.Interfaces.Repository.CotacaoRepository;
using ModuloCongresso.Infra.Data.Context;
using System.Linq;

namespace ModuloCongresso.Infra.Data.Repository.CotacaoRepository
{
    public class PerfilRepository : Repository<Perfil>, IPerfilRepository
    {
        public PerfilRepository(ModuloCongressoContext context)
            : base(context)
        {

        }

        public override IEnumerable<Perfil> ObterTodos()
        {
            using (var cn = ModuloCongressoConnection)
            {
                var perfil = cn.Query<Perfil, EstadoCivil, TipoResidencia, Perfil>
                    ("SELECT * " +
                     "  FROM Perfil p" +
                     "  JOIN EstadoCivil e ON p.EstadoCivilId = e.EstadoCivilId" +
                     "  JOIN TipoResidencia t ON p.TipoResidenciaId = t.TipoResidenciaId",
                        (p, e, t) =>
                        {
                            p.EstadoCivil = e;
                            p.TipoResidencia = t;
                            return p;
                        },
                        splitOn: "PerfilId, EstadoCivilId, TipoResidenciaId");

                return perfil;
            }
        }

        public Perfil ObterPerfilCotacao(int cotacaoId)
        {
            using (var cn = ModuloCongressoConnection)
            {
                var query = cn.Query<Perfil>("SELECT * FROM Perfil WHERE CotacaoId = @CotacaoId",
                    new { CotacaoId = cotacaoId }).FirstOrDefault(); 
                return query;
            }
        }
    }
}