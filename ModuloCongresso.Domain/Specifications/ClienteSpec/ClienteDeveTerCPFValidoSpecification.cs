using DomainValidation.Interfaces.Specification;
using ModuloCongresso.Domain.Entities;
using ModuloCongresso.Domain.Validations.Documentos;

namespace ModuloCongresso.Domain.Specifications.ClienteSpec
{
    public class ClienteDeveTerCPFValidoSpecification : ISpecification<Cotacao>
    {
        public bool IsSatisfiedBy(Cotacao cotacao)
        {
            foreach (var cliente in cotacao.Clientes)
            {
                if (!CpfValidation.Validar(cliente.CPF))
                    return false;
            }

            return true;
        }
    }
}
