using ModuloCongresso.Application.ViewModels.Cotacao;
using ModuloCongresso.Domain.Entities;

namespace ModuloCongresso.Application.AutoMapper
{
    public class SelectedPerfilToPerfilViewModel
    {
        public PerfilViewModel Map(Perfil perfil)
        {
            var viewModel = new PerfilViewModel();
            {
                viewModel.CpfPrincipalCondutor = perfil.CpfPrincipalCondutor;
                viewModel.DataNascPrincipalCondutor = perfil.DataNascPrincipalCondutor;
                viewModel.EstadoCivilId = perfil.EstadoCivilId;
                viewModel.FlagPontosCarteira = perfil.FlagPontosCarteira;
                viewModel.FlagResideMenorIdade = perfil.FlagResideMenorIdade;
                viewModel.FlagSegPrincipalCondutor = perfil.FlagSegPrincipalCondutor;
                viewModel.NomePrincipalCondutor = perfil.NomePrincipalCondutor;
                viewModel.PerfilId = perfil.PerfilId;
                viewModel.QuantidadeVeicResidencia = perfil.QuantidadeVeicResidencia;
                viewModel.TempoHabilitacaoId = perfil.TempoHabilitacaoId;
                viewModel.TipoResidenciaId = perfil.TipoResidenciaId;
                viewModel.SexoId = perfil.SexoId;
                viewModel.DistanciaTrabalhoId = perfil.DistanciaResidenciaTrabalhoId;
                viewModel.CotacaoId = perfil.CotacaoId;
            };

            return viewModel;
        }
    }
}