using ModuloCongresso.Domain.Entities;
using System;
using System.Collections.Generic;

namespace ModuloCongresso.Domain.Interfaces.Services
{
    public interface IClienteService : IDisposable
    {
        Cliente Adicionar(Cliente cliente);

        Cliente ObterPorId(Guid id);

        IEnumerable<Cliente> ObterTodos();

        IEnumerable<Cliente> ObterAtivos();

        Cliente ObterPorCpf(string cpf);

        Cliente ObterPorEmail(string email);

        Cliente Atualizar(Cliente cliente);

        Cliente ObterClienteCotacao(int cotacaoId);

        void Remover(Guid id);
    }
}
