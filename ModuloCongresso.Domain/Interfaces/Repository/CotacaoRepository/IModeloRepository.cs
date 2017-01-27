using ModuloCongresso.Domain.Entities;
using System.Collections.Generic;

namespace ModuloCongresso.Domain.Interfaces.Repository.CotacaoRepository
{
    public interface IModeloRepository : IRepository<Modelo>
    {
        IEnumerable<Modelo> ObterTodosMarcaModelos(int marcaId);

        IEnumerable<Modelo> ObterTodosSelecionados(int marcaId, string modelo, string anoFabricao, string anoModelo,
            string zeroKm);

        Modelo ObterModeloPorId(int modeloId);
    }
}
