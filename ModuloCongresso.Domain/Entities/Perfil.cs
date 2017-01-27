using System;
using System.Linq;

namespace ModuloCongresso.Domain.Entities
{
    public class Perfil
    {
        public Perfil()
        {
            PerfilId = int.Parse(GeneratorNumber());
        }

        public int PerfilId { get; set; }

        public int CotacaoId { get; set; }

        public int EstadoCivilId { get; set; }

        public int TipoResidenciaId { get; set; }

        public string CpfPrincipalCondutor { get; set; }

        public string NomePrincipalCondutor { get; set; }

        public DateTime DataNascPrincipalCondutor { get; set; }

        public bool FlagResideMenorIdade { get; set; }

        public bool FlagSegPrincipalCondutor { get; set; }

        public bool FlagPontosCarteira { get; set; }

        public int SexoId { get; set; }

        public int TempoHabilitacaoId { get; set; }

        public int QuantidadeVeicResidencia { get; set; }

        public int DistanciaResidenciaTrabalhoId { get; set; }

        public virtual DistanciaTrabalho DistanciaTrabalho { get; set; }

        public virtual Sexo Sexo { get; set; }

        public virtual TempoHabilitacao TempoHabilitacao { get; set; }

        public virtual EstadoCivil EstadoCivil { get; set; }

        public virtual TipoResidencia TipoResidencia { get; set; }

        public virtual Cotacao Cotacao { get; set; }

        public static string GeneratorNumber()
        {
            var chars = "0123456789";
            int tamanho = 8;
            var random = new Random();
            var result = new string(
                Enumerable.Repeat(chars, tamanho)
                          .Select(s => s[random.Next(s.Length)])
                          .ToArray());

            return result;
        }
    }
}