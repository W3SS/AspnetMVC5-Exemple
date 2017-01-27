using System;
using ModuloCongresso.Domain.Entities;
using ModuloCongresso.Domain.Interfaces.Repository.CotacaoRepository;
using ModuloCongresso.Domain.Interfaces.Services.CotacaoService;

namespace ModuloCongresso.Domain.Services.CotacaoService
{
    public class EnderecoService : IEnderecoService
    {
        private readonly IEnderecoRepository _enderecoRepository;

        public EnderecoService(IEnderecoRepository enderecoRepository)
        {
            _enderecoRepository = enderecoRepository;
        }
        
        public Endereco ObterEnderecoCliente(Guid clienteId)
        {
            return _enderecoRepository.ObterEnderecoCliente(clienteId);
        }

        public void Dispose()
        {
            _enderecoRepository.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}