using ModuloCongresso.Domain.Entities;

namespace ModuloCongresso.Domain.Interfaces.Repository.CotacaoRepository
{
    public interface IMarcaRepository : IRepository<Marca>
    {
        Marca ObterMarcaPorId(int marcaId);
    }
}
