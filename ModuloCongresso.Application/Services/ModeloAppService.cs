using AutoMapper;
using ModuloCongresso.Application.Interfaces.Cotacao;
using ModuloCongresso.Application.ViewModels.Cotacao;
using ModuloCongresso.Domain.Interfaces.Services.CotacaoService;
using System;
using System.Collections.Generic;

namespace ModuloCongresso.Application.Services
{
    public class ModeloAppService : IModeloAppService
    {
        private readonly IModeloService _modeloService;

        public ModeloAppService(IModeloService modeloService)
        {
            _modeloService = modeloService;
        }

        public IEnumerable<ModeloViewModel> ObterTodos()
        {
            return Mapper.Map<IEnumerable<ModeloViewModel>>(_modeloService.ObterTodos());
        }

        public List<string> ObterNomeTodosModelos()
        {
            return _modeloService.ObterNomeTodosModelos();
        }

        public IEnumerable<ModeloViewModel> ObterTodosMarcaModelos(int marcaId)
        {
            return Mapper.Map<IEnumerable<ModeloViewModel>>(_modeloService.ObterTodosMarcaModelos(marcaId));
        }
        public List<string> ObterNomeTodosModelosPorMarca(int marcaId)
        {
            return _modeloService.ObterNomeTodosModelosPorMarca(marcaId);
        }

        public IEnumerable<ModeloViewModel> ObterTodosSelecionados(int marcaId, string modelo, string anoFabricao, string anoModelo, 
            string zeroKm)
        {
            return
                Mapper.Map<IEnumerable<ModeloViewModel>>(_modeloService.ObterTodosSelecionados(marcaId, modelo,
                    anoFabricao, anoModelo, zeroKm));
        }

        public ModeloViewModel ObterModeloPorId(int modeloId)
        {
            return Mapper.Map<ModeloViewModel>(_modeloService.ObterModeloPorId(modeloId));
        }

        public decimal ObterValorModelo(int modeloId)
        {
            return _modeloService.ObterValorModelo(modeloId);
        }

        public string ObterNomeModeloCotacao(int cotacaoId)
        {
            return _modeloService.ObterNomeModeloCotacao(cotacaoId);
        }

        public ICollection<string> ObterAnoFabModCotacao(int cotacaoId)
        {
            return _modeloService.ObterAnoFabModCotacao(cotacaoId);
        }

        public bool ChecarVeiculoZeroKmCotacao(int cotacaoId)
        {
            return _modeloService.ChecarVeiculoZeroKmCotacao(cotacaoId);
        }

        public decimal ObterFranquiaModelo(int cotacaoId)
        {
            return _modeloService.ObterFranquiaModelo(cotacaoId);
        }

        public string ObterDescricaoModelo(int modeloId)
        {
            return _modeloService.ObterDescricaoModelo(modeloId);
        }

        public void Dispose()
        {
            _modeloService.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
