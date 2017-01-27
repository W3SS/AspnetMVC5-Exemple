using DomainValidation.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using ModuloCongresso.Domain.Validations.Cotacao;

namespace ModuloCongresso.Domain.Entities
{
    public class Cotacao
    {
        public Cotacao()
        {
            CotacaoId = int.Parse(GeneratorNumber());
            Itens = new List<Item>();
            Clientes = new List<Cliente>();
            Perfils = new List<Perfil>();
            Questionarios = new List<Questionario>();
        }

        public int CotacaoId { get; set; }

        public int TipoCalculoId { get; set; }

        public int TipoSeguroId { get; set; }

        public DateTime DataCalculo { get; set; }

        public DateTime DataCadastro { get; set; }

        public decimal PremioTotal { get; set; }

        public DateTime DataVigenciaInicial { get; set; }

        public DateTime DataVigenciaFinal { get; set; }

        public Guid UserId { get; set; }

        public ICollection<Cliente> Clientes { get; set; }

        public ICollection<Item> Itens { get; set; }

        public ICollection<Perfil> Perfils { get; set; }

        public ICollection<Questionario> Questionarios { get; set; }

        public virtual TipoCalculo TipoCalculo { get; set; }

        public virtual TipoSeguro TipoSeguro { get; set; }

        public ValidationResult ValidationResult { get; set; }

        public bool IsValid()
        {
            ValidationResult = new CotacaoEstaConsistenteValidation().Validate(this);
            return ValidationResult.IsValid;
        }

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
