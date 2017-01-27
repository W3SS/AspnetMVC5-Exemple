using ModuloCongresso.Domain.Entities;

namespace ModuloCongresso.Domain.Interfaces.Repository.CotacaoRepository
{
    public interface ITipoCalculoRepository : IRepository<TipoCalculo>
    {
        TipoCalculo ObterTipoCalculoPorId(int tipoCalculoId);
    }
}