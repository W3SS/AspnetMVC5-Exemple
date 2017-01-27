using System;
using System.Linq;

namespace ModuloCongresso.Domain.Entities
{
    public class CoberturasItem
    {
        public CoberturasItem()
        {
            CoberturasItemId = int.Parse(GeneratorNumber());
        }

        public int CoberturasItemId { get; set; }

        public int ItemId { get; set; }

        public int CoberturaId { get; set; }

        public double Valor { get; set; }

        public virtual Item Item { get; set; }

        public virtual Coberturas Coberturas { get; set; }

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