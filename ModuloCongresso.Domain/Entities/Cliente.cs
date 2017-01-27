using DomainValidation.Validation;
using ModuloCongresso.Domain.Validations.Clientes;
using System;
using System.Collections.Generic;

namespace ModuloCongresso.Domain.Entities
{
    public class Cliente
    {
        public Cliente()
        {
            ClienteID = Guid.NewGuid();
            Enderecos = new List<Endereco>();
        }

        public Guid ClienteID { get; set; }

        public int CotacaoId { get; set; }

        public string Nome { get; set; }

        public string SobreNome { get; set; }

        public string CPF { get; set; }

        public string telefone { get; set; }

        public string RG { get; set; }

        public string email { get; set; }

        public DateTime DataNascimento { get; set; }

        public DateTime DataCadastro { get; set; }

        public bool Ativo { get; set; }

        public bool Inscrito { get; set; }

        public byte[] ImagePhoto { get; set; }

        public int ProfissaoID { get; set; }

        public int PaisResidenciaID { get; set; }

        public virtual Profissao Profissao { get; set; }

        public virtual PaisResidencia PaisResidencia { get; set; }

        //public ICollection<Palestra> Palestras { get; set; }

        public ICollection<Endereco> Enderecos { get; set; }

        public virtual Cotacao Cotacao { get; set; }

        public ValidationResult ValidationResult { get; set; }

        public bool IsValid()
        {
            //ValidationResult = new ClienteEstaConsistenteValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
