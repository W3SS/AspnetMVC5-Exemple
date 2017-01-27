using DomainValidation.Interfaces.Specification;
using ModuloCongresso.Domain.Entities;
using ModuloCongresso.Domain.Interfaces.Repository;
using System;

namespace ModuloCongresso.Domain.Specifications.ClienteSpec
{
    public class ClienteDevePossuirCPFUnicoSpecification : ISpecification<Cliente>
    {
        private readonly IClienteRepository _clienteRepository;

        public ClienteDevePossuirCPFUnicoSpecification(IClienteRepository clienteRepository)
        {
            _clienteRepository = clienteRepository;
        }

        public bool IsSatisfiedBy(Cliente cliente)
        {
            return _clienteRepository.ObterPorCpf(cliente.CPF) == null;
        }
    }
}
