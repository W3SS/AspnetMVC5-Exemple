using ModuloCongresso.Domain.Entities;

namespace ModuloCongresso.Domain.Interfaces.Services.Business
{
    public interface ICalculoService
    {
        decimal CalcularPremio(Cotacao cotacao, Item item, Perfil perfil, Questionario questionario);
    }
}