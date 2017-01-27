using ModuloCongresso.Domain.Entities;

namespace ModuloCongresso.Domain.Interfaces.Services.BusinessService
{
    public interface ICalculoService
    {
        Cotacao CalcularCotacao(Cotacao cotacao, CoberturasItem coberturasItem);
    }
}