using ModuloCongresso.Domain.Entities;
using System.Collections.Generic;
using System.Linq;
using ModuloCongresso.Infra.Data.Context;
using Dapper;
using ModuloCongresso.Domain.Interfaces.Repository.CotacaoRepository;

namespace ModuloCongresso.Infra.Data.Repository.CotacaoRepository
{
    public class MarcaRepository : Repository<Marca>, IMarcaRepository
    {
        public MarcaRepository(ModuloCongressoContext context) 
            : base(context)
        {
        }

        public override IEnumerable<Marca> ObterTodos()
        {
            using (var cn = ModuloCongressoConnection)
            {
                var sqlMarca = @"Select * from Marca";
                return cn.Query<Marca>(sqlMarca);
            }
        }

        public Marca ObterMarcaPorId(int marcaId)
        {
            using (var cn = ModuloCongressoConnection)
            {
                var marca = cn.Query<Marca>("SELECT * FROM Marca WHERE MarcaId = @MarcaId",
                    new { MarcaId = marcaId }).FirstOrDefault();
                return marca;
            }
        }
    }
}
