using DomainValidation.Interfaces.Specification;
using ModuloCongresso.Domain.Entities;
using ModuloCongresso.Domain.Interfaces.Repository;

namespace ModuloCongresso.Domain.Specifications.ClienteSpec
{
    public class ClienteDevePossuirEmailUnicoSpecification : ISpecification<Cliente>
    {
        private readonly IClienteRepository _clienteRepository;

        public ClienteDevePossuirEmailUnicoSpecification(IClienteRepository clienteRepository)
        {
            _clienteRepository = clienteRepository;
        }

        public bool IsSatisfiedBy(Cliente cliente)
        {
            return _clienteRepository.ObterPorEmail(cliente.email) == null;
        }
    }
}
