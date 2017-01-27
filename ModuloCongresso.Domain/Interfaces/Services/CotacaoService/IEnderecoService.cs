using System;
using ModuloCongresso.Domain.Entities;

namespace ModuloCongresso.Domain.Interfaces.Services.CotacaoService
{
    public interface IEnderecoService : IDisposable
    {
        Endereco ObterEnderecoCliente(Guid clienteId);
    }
}