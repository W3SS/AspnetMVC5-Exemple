using System;
using System.Collections.Generic;
using System.Linq;

namespace ModuloCongresso.Domain.Entities
{
    public class Item
    {
        public Item()
        {
            ItemId = int.Parse(GeneratorNumber());
            Coberturas = new List<CoberturasItem>();
        }

        public int ItemId { get; set; }

        public int CotacaoId { get; set; }

        public int ProdutoId { get; set; }

        public int ModeloId { get; set; }

        public int UsoId { get; set; }

        public int ImpostoId { get; set; }

        public long? NumChassi { get; set; }

        public bool FlagRemarcado { get; set; }

        public virtual Uso Uso { get; set; }

        public virtual Imposto Imposto { get; set; }

        public virtual Modelo Modelo { get; set; }

        public virtual Produto Produto { get; set; }

        public virtual Cotacao Cotacao { get; set; }

        public ICollection<CoberturasItem> Coberturas { get; set; }

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
