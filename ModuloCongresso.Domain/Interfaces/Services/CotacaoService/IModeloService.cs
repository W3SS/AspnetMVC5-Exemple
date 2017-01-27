using System;
using System.Collections.Generic;
using ModuloCongresso.Domain.Entities;

namespace ModuloCongresso.Domain.Interfaces.Services.CotacaoService
{
    public interface IModeloService : IDisposable
    {
        IEnumerable<Modelo> ObterTodos();

        List<string> ObterNomeTodosModelos();

        IEnumerable<Modelo> ObterTodosMarcaModelos(int marcaId);

        List<string> ObterNomeTodosModelosPorMarca(int marcaId);

        IEnumerable<Modelo> ObterTodosSelecionados(int marcaId, string modelo, string anoFabricao, string anoModelo, 
            string zeroKm);

        Modelo ObterModeloPorId(int modeloId);

        string ObterDescricaoModelo(int modeloId);

        decimal ObterValorModelo(int modeloId);

        int ObterIdMarcaPorModelo(int modeloId);

        int ObterIdModeloCotacao(int cotacaoId);

        string ObterNomeModeloCotacao(int cotacaoId);

        string ObterAnoFabricacaoModelo(int modeloId);

        string ObterAnoModelo(int modeloId);

        ICollection<string> ObterAnoFabModCotacao(int cotacaoId);

        bool ChecarVeiculoZeroKmCotacao(int cotacaoId);
    }
}
