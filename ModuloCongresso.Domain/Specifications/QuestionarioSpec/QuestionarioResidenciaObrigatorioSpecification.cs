using DomainValidation.Interfaces.Specification;
using ModuloCongresso.Domain.Entities;
using ModuloCongresso.Domain.Validations.Documentos;

namespace ModuloCongresso.Domain.Specifications.QuestionarioSpec
{
    public class QuestionarioResidenciaObrigatorioSpecification : ISpecification<Cotacao>
    {
        public bool IsSatisfiedBy(Cotacao cotacao)
        {
            return QuestionarioGaragemValidation.Validar(cotacao.Questionarios, QuestionarioGaragem.Residencia);
        }
    }
}