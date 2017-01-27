using DomainValidation.Interfaces.Specification;
using ModuloCongresso.Domain.Entities;
using ModuloCongresso.Domain.Validations.Documentos;

namespace ModuloCongresso.Domain.Specifications.ClienteSpec
{
    public class ClienteDeveTerEmailValidoSpecification : ISpecification<Cotacao>
    {
        public bool IsSatisfiedBy(Cotacao cotacao)
        {
            foreach (var cliente in cotacao.Clientes)
            {
                if (!EmailValidation.Validate(cliente.email))
                    return false;
            }

            return true;
        }
    }
}
