using ModuloCongresso.Application.Interfaces;
using System;
using System.Collections.Generic;
using ModuloCongresso.Application.ViewModels;
using AutoMapper;
using ModuloCongresso.Domain.Entities;
using ModuloCongresso.Domain.Interfaces.Services;
using ModuloCongresso.Application.Services.Common;
using ModuloCongresso.Infra.Data.Interfaces;

namespace ModuloCongresso.Application
{
    public class ClienteAppService : AppService,  IClienteAppService
    {
        private readonly IClienteService _clienteService;

        public ClienteAppService(IClienteService clienteService, IUnitOfWork unitOfWork)
            :base(unitOfWork)
        {
            _clienteService = clienteService;
        }

        public ClienteEnderecoViewModel Adicionar(ClienteEnderecoViewModel clienteEnderecoViewModel)
        {
            var cliente = Mapper.Map<Cliente>(clienteEnderecoViewModel);
            var endereco = Mapper.Map<Endereco>(clienteEnderecoViewModel);

            cliente.Enderecos.Add(endereco);

            BeginTransaction();

            var clienteReturn = _clienteService.Adicionar(cliente);

            if (clienteReturn.ValidationResult.IsValid)
                Commit();

            return Mapper.Map<ClienteEnderecoViewModel>(clienteReturn);
        } 

        public ClienteViewModel Atualizar(ClienteViewModel clienteViewModel)
        {
            var cliente = Mapper.Map<Cliente>(clienteViewModel);

            BeginTransaction();
            _clienteService.Atualizar(cliente);
            Commit();

            return clienteViewModel;
        }

        public ClienteViewModel ObterPorCpf(string cpf)
        {
            return Mapper.Map<ClienteViewModel>(_clienteService.ObterPorCpf(cpf));
        }

        public ClienteViewModel ObterPorEmail(string email)
        {
            return Mapper.Map<ClienteViewModel>(_clienteService.ObterPorEmail(email));
        }

        public ClienteEnderecoViewModel ObterPorId(Guid id)
        {
            return Mapper.Map<ClienteEnderecoViewModel>(_clienteService.ObterPorId(id));
        }

        public IEnumerable<ClienteViewModel> ObterTodos()
        {
            return Mapper.Map<IEnumerable<ClienteViewModel>>(_clienteService.ObterTodos());
        }
        
        public ClienteEnderecoViewModel ObterClienteCotacao(int cotacaoId)
        {
            return Mapper.Map<ClienteEnderecoViewModel>(_clienteService.ObterClienteCotacao(cotacaoId));
        }

        public void Remover(Guid id)
        {
            BeginTransaction();
            _clienteService.Remover(id);
            Commit();
        }

        public void Dispose()
        {
            _clienteService.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
