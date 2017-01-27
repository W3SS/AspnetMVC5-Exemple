using System;
using System.Linq;

namespace ModuloCongresso.Application.ViewModels.Cotacao
{
    public class CoberturaItemViewModel
    {
        public CoberturaItemViewModel()
        {
            CoberturasItemId = int.Parse(GeneratorNumber());
        }

        public int CoberturasItemId { get; set; }

        public int ItemId { get; set; }

        public int CoberturaId { get; set; }

        public float Valor { get; set; }

        public virtual CoberturasViewModel Coberturas { get; set; }

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