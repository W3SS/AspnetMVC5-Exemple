using System.Collections.Generic;
using Dapper;
using ModuloCongresso.Domain.Entities;
using ModuloCongresso.Domain.Interfaces.Repository.CotacaoRepository;
using ModuloCongresso.Infra.Data.Context;

namespace ModuloCongresso.Infra.Data.Repository.CotacaoRepository
{
    public class EstadoCivilRepository : Repository<EstadoCivil>, IEstadoCivilRepository
    {
        public EstadoCivilRepository(ModuloCongressoContext context)
            : base(context)
        {

        }

        public override IEnumerable<EstadoCivil> ObterTodos()
        {
            using (var cn = ModuloCongressoConnection)
            {
                var query = @"Select * from EstadoCivil";
                return cn.Query<EstadoCivil>(query);
            }
        }
    }
}