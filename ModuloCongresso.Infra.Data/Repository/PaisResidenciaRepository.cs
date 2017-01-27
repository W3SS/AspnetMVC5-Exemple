using ModuloCongresso.Domain.Entities;
using ModuloCongresso.Domain.Interfaces.Repository;
using System.Collections.Generic;
using ModuloCongresso.Infra.Data.Context;
using Dapper;

namespace ModuloCongresso.Infra.Data.Repository
{
    public class PaisResidenciaRepository : Repository<PaisResidencia>, IPaisResidenciaRepository
    {
        public PaisResidenciaRepository(ModuloCongressoContext context)
            : base(context)
        {

        }

        public override IEnumerable<PaisResidencia> ObterTodos()
        {
            using (var cn = ModuloCongressoConnection) //Db.Database.Connection)
            {
                var sqlPaisResidencia = @"Select * from PaisResidencia";
                return cn.Query<PaisResidencia>(sqlPaisResidencia);
            }
        }
    }
}
