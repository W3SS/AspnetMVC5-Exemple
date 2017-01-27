using DomainValidation.Interfaces.Specification;
using ModuloCongresso.Domain.Entities;
using ModuloCongresso.Domain.Validations.Documentos;

namespace ModuloCongresso.Domain.Specifications.ItemSpec
{
    public class ItemDevePossuirModeloValidoSelecionadoSpecification : ISpecification<Cotacao>
    {
        public bool IsSatisfiedBy(Cotacao cotacao)
        {
            return ModeloValidation.Validar(cotacao.Itens);
        }
    }
}