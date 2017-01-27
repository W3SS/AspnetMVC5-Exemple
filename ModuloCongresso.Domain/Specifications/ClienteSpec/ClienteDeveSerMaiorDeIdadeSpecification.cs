using DomainValidation.Interfaces.Specification;
using ModuloCongresso.Domain.Entities;
using System;
using System.Linq;

namespace ModuloCongresso.Domain.Specifications.ClienteSpec
{
    public class ClienteDeveSerMaiorDeIdadeSpecification : ISpecification<Cotacao>
    {
        public bool IsSatisfiedBy(Cotacao cotacao)
        {
            return cotacao.Clientes.All(cliente => DateTime.Now.Year - cliente.DataNascimento.Year >= 18);
        }
    }
}
