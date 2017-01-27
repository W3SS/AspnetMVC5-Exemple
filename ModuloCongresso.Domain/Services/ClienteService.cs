using ModuloCongresso.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using ModuloCongresso.Domain.Entities;
using ModuloCongresso.Domain.Interfaces.Repository;
using ModuloCongresso.Domain.Validations.Clientes;

namespace ModuloCongresso.Domain.Services
{
    public class ClienteService : IClienteService
    {
        private readonly IClienteRepository _clienteRepository;

        public ClienteService(IClienteRepository clienteRepository)
        {
            _clienteRepository = clienteRepository;
        }

        public Cliente Adicionar(Cliente cliente)
        {
            if (!cliente.IsValid())
                return cliente;

            cliente.ValidationResult = new ClienteAptoParaCadastroValidation(_clienteRepository).Validate(cliente);
            if (!cliente.ValidationResult.IsValid)
                return cliente;

            //cliente.ValidationResult.Message = "Cliente cadastrado com sucesso :)";

            return _clienteRepository.Adicionar(cliente);
        }

        public Cliente Atualizar(Cliente cliente)
        {
            return _clienteRepository.Atualizar(cliente);
        }

        public Cliente ObterPorCpf(string cpf)
        {
            return _clienteRepository.ObterPorCpf(cpf);
        }

        public Cliente ObterPorEmail(string email)
        {
            return _clienteRepository.ObterPorEmail(email);
        }

        public Cliente ObterPorId(Guid id)
        {
            return _clienteRepository.ObterPorId(id);
        }

        public IEnumerable<Cliente> ObterTodos()
        {
            return _clienteRepository.ObterTodos();
        }

        public IEnumerable<Cliente> ObterAtivos()
        {
            return _clienteRepository.ObterAtivos();
        }

        public Cliente ObterClienteCotacao(int cotacaoId)
        {
            return _clienteRepository.ObterClienteCotacao(cotacaoId);
        }

        public void Remover(Guid id)
        {
            _clienteRepository.Remover(id);
        }

        public void Dispose()
        {
            _clienteRepository.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
