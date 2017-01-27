using System.Collections.Generic;
using ModuloCongresso.Domain.Entities;
using ModuloCongresso.Infra.Data.Context;
using Dapper;
using ModuloCongresso.Domain.Interfaces.Repository.CotacaoRepository;
using System.Linq;

namespace ModuloCongresso.Infra.Data.Repository.CotacaoRepository
{
    public class ModeloRepository : Repository<Modelo>, IModeloRepository
    {
        public ModeloRepository(ModuloCongressoContext context)
            : base(context)
        {
        }

        public override IEnumerable<Modelo> ObterTodos()
        {
            using (var cn = ModuloCongressoConnection)
            {
                var modelo = cn.Query<Modelo, Marca, Modelo>
                ("SELECT * " +
                 "  FROM Modelo a" +
                 "  JOIN Marca b ON a.MarcaId = b.MarcaId",
                    (a, b) =>
                    {
                        a.Marca = b;
                        return a;
                    },
                    splitOn: "ModeloId, MarcaId");

                return modelo;
            }
        }

        public IEnumerable<Modelo> ObterTodosMarcaModelos(int marcaId)
        {
            using (var cn = ModuloCongressoConnection)
            {
                const string sqlModelo = @"SELECT * " +
                                         "  FROM Modelo m" +
                                         "  JOIN Marca ma ON m.MarcaId = ma.MarcaId" +
                                         " WHERE m.MarcaId = @MarcaId";

                var modelo = cn.Query<Modelo, Marca, Modelo>(sqlModelo,
                    (m, ma) =>
                    {
                        m.Marca = ma;
                        return m;
                    },
                    new {MarcaId = marcaId}, splitOn: "ModeloId, MarcaId");

                return modelo;
            }
        }

        public IEnumerable<Modelo> ObterTodosSelecionados(int marcaId, string modelo, string anoFabricao, string anoModelo, string zeroKm)
        {
            using (var cn = ModuloCongressoConnection)
            {
                const string sqlModelo = @"SELECT * " +
                                         "  FROM Modelo m" +
                                         "  JOIN Marca ma ON m.MarcaId = ma.MarcaId" +
                                         " WHERE m.MarcaId = @MarcaId" +
                                         " AND m.Nome = @Modelo" +
                                         " AND m.AnoFabricacao = @AnoFabricacao" +
                                         " AND m.AnoModelo = @AnoModelo" +
                                         " AND m.FlagZeroKm = @FlagZeroKm";

                var modeloQuery = cn.Query<Modelo, Marca, Modelo>(sqlModelo,
                    (m, ma) =>
                    {
                        m.Marca = ma;
                        return m;
                    },
                    new { MarcaId = marcaId, Modelo = modelo,
                          AnoFabricacao = anoFabricao, AnoModelo = anoModelo, FlagZeroKm = zeroKm},
                    splitOn: "ModeloId, MarcaId");

                return modeloQuery;
            }
        }

        public Modelo ObterModeloPorId(int modeloId)
        {
            using (var cn = ModuloCongressoConnection)
            {
                const string sqlModelo = @"SELECT ma.*, * " +
                                         "  FROM Modelo m" +
                                         "  JOIN Marca ma ON m.MarcaId = ma.MarcaId" +
                                         " WHERE m.ModeloId = @ModeloId";

                var modeloQuery = cn.Query<Modelo, Marca, Modelo>(sqlModelo,
                    (m, ma) =>
                    {
                        m.Marca = ma;
                        return m;
                    },
                new { ModeloId = modeloId }, splitOn: "ModeloId, MarcaId");

                return modeloQuery.FirstOrDefault();
            }
        }
    }
}
