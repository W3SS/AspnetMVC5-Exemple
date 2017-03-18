using ModuloCongresso.Application.ViewModels.Cotacao;
using System;
using System.Collections.Generic;

namespace ModuloCongresso.Application.Interfaces.Cotacao
{
    public interface IModeloAppService : IDisposable
    {
        IEnumerable<ModeloViewModel> ObterTodos();

        List<string> ObterNomeTodosModelos();

        IEnumerable<ModeloViewModel> ObterTodosMarcaModelos(int marcaId);

        List<string> ObterNomeTodosModelosPorMarca(int marcaId);

        IEnumerable<ModeloViewModel> ObterTodosSelecionados(int marcaId, string modelo, string anoFabricao, string anoModelo, 
            string zeroKm);

        ModeloViewModel ObterModeloPorId(int modeloId);

        decimal ObterValorModelo(int modeloId);

        string ObterNomeModeloCotacao(int cotacaoId);

        ICollection<string> ObterAnoFabModCotacao(int cotacaoId);

        bool ChecarVeiculoZeroKmCotacao(int cotacaoId);

        decimal ObterFranquiaModelo(int cotacaoId);

        string ObterDescricaoModelo(int modeloId);
    }
}
