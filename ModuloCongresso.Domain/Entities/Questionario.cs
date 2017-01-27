using System;
using System.Linq;

namespace ModuloCongresso.Domain.Entities
{
    public class Questionario
    {
        public Questionario()
        {
            QuestionarioId = int.Parse(GeneratorNumber());
        }

        public int QuestionarioId { get; set; }

        public int CotacaoId { get; set; }

        public int? RastreadorId { get; set; }

        public int? AntiFurtoId { get; set; }

        public string CepPernoite { get; set; }

        public string RelacaoSegurado { get; set; }

        public bool FlagBlindado { get; set; }

        public bool FlagAdaptadoDeficiente { get; set; }

        public bool FlagKitGas { get; set; }

        public bool FlagAlienado { get; set; }

        public bool FlagAntiFurto { get; set; }

        public bool FlagGararem { get; set; }

        public string GararemResidencia { get; set; }

        public string GararemTrabalho { get; set; }

        public string GararemFaculdade { get; set; }

        public string PropriedadeRastreador { get; set; }

        public virtual Cotacao Cotacao { get; set; }

        public virtual Rastreador Rastreador { get; set; }

        public virtual AntiFurto AntiFurto { get; set; }

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
