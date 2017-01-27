using ModuloCongresso.Application.ViewModels;
using System;
using System.Collections.Generic;

namespace ModuloCongresso.Application.Interfaces
{
    public interface IClienteAppService : IDisposable
    {
        ClienteEnderecoViewModel Adicionar(ClienteEnderecoViewModel clienteEnderecoViewModel);

        ClienteEnderecoViewModel ObterPorId(Guid id);

        IEnumerable<ClienteViewModel> ObterTodos();

        ClienteViewModel ObterPorCpf(string cpf);

        ClienteViewModel ObterPorEmail(string email);

        ClienteViewModel Atualizar(ClienteViewModel clienteViewModel);

        ClienteEnderecoViewModel ObterClienteCotacao(int cotacaoId);

        void Remover(Guid id);
    }
}
