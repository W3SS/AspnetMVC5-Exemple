using ModuloCongresso.Domain.Interfaces.Repository.CotacaoRepository;
using ModuloCongresso.Domain.Interfaces.Services.CotacaoService;
using System;
using System.Collections.Generic;
using System.Linq;
using ModuloCongresso.Domain.Entities;

namespace ModuloCongresso.Domain.Services.CotacaoService
{
    public class ModeloService : IModeloService
    {
        private readonly IModeloRepository _modeloRepository;
        private readonly IItemService _itemService;

        public ModeloService(IModeloRepository modeloRepository, IItemService itemService)
        {
            _modeloRepository = modeloRepository;
            _itemService = itemService;
        }

        public IEnumerable<Modelo> ObterTodos()
        {
            return _modeloRepository.ObterTodos();
        }

        public List<string> ObterNomeTodosModelos()
        {
            var modelos = _modeloRepository.ObterTodos();

            return modelos.Select(item => item.Nome).Distinct().ToList();
        }
        public IEnumerable<Modelo> ObterTodosMarcaModelos(int marcaId)
        {
            return _modeloRepository.ObterTodosMarcaModelos(marcaId);
        }

        public List<string> ObterNomeTodosModelosPorMarca(int marcaId)
        {
            var modelosPorMarca = _modeloRepository.ObterTodosMarcaModelos(marcaId);

            return modelosPorMarca.Select(item => item.Nome).Distinct().ToList();
        }

        public IEnumerable<Modelo> ObterTodosSelecionados(int marcaId, string modelo, string anoFabricao, string anoModelo, 
            string zeroKm)
        {
            return _modeloRepository.ObterTodosSelecionados(marcaId, modelo, anoFabricao, anoModelo, zeroKm);
        }

        public Modelo ObterModeloPorId(int modeloId)
        {
            return _modeloRepository.ObterModeloPorId(modeloId);
        }

        public string ObterDescricaoModelo(int modeloId)
        {
            return ObterModeloPorId(modeloId).Descricao ?? string.Empty;
        }

        public decimal ObterValorModelo(int modeloId)
        {
            return ObterModeloPorId(modeloId).Valor;
        }

        public int ObterIdMarcaPorModelo(int modeloId)
        {
            return ObterModeloPorId(modeloId).MarcaId;
        }

        public int ObterIdModeloCotacao(int cotacaoId)
        {
            return _itemService.ObterModeloItem(cotacaoId);
        }

        public string ObterNomeModeloCotacao(int cotacaoId)
        {
            var modeloId = ObterIdModeloCotacao(cotacaoId);

            return ObterModeloPorId(modeloId).Nome;
        }

        public string ObterAnoFabricacaoModelo(int modeloId)
        {
            return ObterModeloPorId(modeloId).AnoFabricacao;
        }

        public string ObterAnoModelo(int modeloId)
        {
            return ObterModeloPorId(modeloId).AnoModelo;
        }

        public bool ChecarVeiculoZeroKmCotacao(int cotacaoId)
        {
            var modeloId = ObterIdModeloCotacao(cotacaoId);

            return ObterModeloPorId(modeloId).FlagZeroKm;
        }

        public ICollection<string> ObterAnoFabModCotacao(int cotacaoId)
        {
            var listaAno = new List<string>();

            var modeloId = ObterIdModeloCotacao(cotacaoId);

            listaAno.Add(ObterAnoFabricacaoModelo(modeloId));
            listaAno.Add(ObterAnoModelo(modeloId));

            return listaAno;
        } 

        public void Dispose()
        {
            _modeloRepository.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
