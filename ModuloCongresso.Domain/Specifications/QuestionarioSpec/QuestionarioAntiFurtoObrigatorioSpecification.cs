using DomainValidation.Interfaces.Specification;
using ModuloCongresso.Domain.Entities;
using ModuloCongresso.Domain.Validations.Documentos;

namespace ModuloCongresso.Domain.Specifications.QuestionarioSpec
{
    public class QuestionarioAntiFurtoObrigatorioSpecification : ISpecification<Cotacao>
    {
        public bool IsSatisfiedBy(Cotacao cotacao)
        {
            return QuestionarioSegurancaValidation.Validar(cotacao.Questionarios, QuestionarioSeguranca.AntiFurto);
        }
    }
}