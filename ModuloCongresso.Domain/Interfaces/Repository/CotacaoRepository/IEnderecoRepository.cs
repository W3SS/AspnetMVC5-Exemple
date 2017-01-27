using System;
using ModuloCongresso.Domain.Entities;

namespace ModuloCongresso.Domain.Interfaces.Repository.CotacaoRepository
{
    public interface IEnderecoRepository : IRepository<Endereco>
    {
        Endereco ObterEnderecoCliente(Guid clienteId);
    }
}