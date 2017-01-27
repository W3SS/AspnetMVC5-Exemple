using DomainValidation.Interfaces.Specification;
using ModuloCongresso.Domain.Entities;
using ModuloCongresso.Domain.Validations.Documentos;

namespace ModuloCongresso.Domain.Specifications.CotacaoSpec
{
    public class CotacaoDevePossuirDataValidaSpecification : ISpecification<Cotacao>
    {
        public bool IsSatisfiedBy(Cotacao cotacao)
        {
            return DataVigenciaValidation.Validar(cotacao.DataVigenciaInicial);
        }
    }
}