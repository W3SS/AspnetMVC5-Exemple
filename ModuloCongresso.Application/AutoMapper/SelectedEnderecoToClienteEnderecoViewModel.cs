using AutoMapper;
using ModuloCongresso.Application.ViewModels;
using ModuloCongresso.Domain.Interfaces.Services;
using ModuloCongresso.Domain.Interfaces.Services.CotacaoService;

namespace ModuloCongresso.Application.AutoMapper
{
    public class SelectedEnderecoToClienteEnderecoViewModel
    {
        private readonly IClienteService _clienteService;
        private readonly IEnderecoService _enderecoService;

        public SelectedEnderecoToClienteEnderecoViewModel(IClienteService clienteService, IEnderecoService enderecoService)
        {
            _clienteService = clienteService;
            _enderecoService = enderecoService;
        }

        public ClienteEnderecoViewModel Map(int cotacaoId)
        {
            var viewModel = Mapper.Map<ClienteEnderecoViewModel>(_clienteService.ObterClienteCotacao(cotacaoId));
            var enderecoViewModel = Mapper.Map<EnderecoViewModel>(_enderecoService.ObterEnderecoCliente(viewModel.ClienteId));

            viewModel.Bairro = enderecoViewModel.Bairro;
            viewModel.EnderecoId = enderecoViewModel.EnderecoId;
            viewModel.CEP = enderecoViewModel.CEP;
            viewModel.Logradouro = enderecoViewModel.Logradouro;
            viewModel.Numero = enderecoViewModel.Numero;
            viewModel.Complemento = enderecoViewModel.Complemento;
            viewModel.Bairro = enderecoViewModel.Bairro;
            viewModel.Cidade = enderecoViewModel.Cidade;
            viewModel.Estado = enderecoViewModel.Estado;
            viewModel.ClienteId = enderecoViewModel.ClienteId;

            return viewModel;
        }
    }
}