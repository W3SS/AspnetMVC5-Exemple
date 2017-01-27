using System.Collections.Generic;
using Dapper;
using ModuloCongresso.Domain.Entities;
using ModuloCongresso.Domain.Interfaces.Repository.CotacaoRepository;
using ModuloCongresso.Infra.Data.Context;

namespace ModuloCongresso.Infra.Data.Repository.CotacaoRepository
{
    public class DistanciaTrabalhoRepository : Repository<DistanciaTrabalho>, IDistanciaTrabalhoRepository
    {
        public DistanciaTrabalhoRepository(ModuloCongressoContext context) : base(context)
        {
        }

        public override IEnumerable<DistanciaTrabalho> ObterTodos()
        {
            using (var cn = ModuloCongressoConnection)
            {
                var query = @"Select * from DistanciaTrabalho";
                return cn.Query<DistanciaTrabalho>(query);
            }
        }
    }
}