using DomainValidation.Validation;
using ModuloCongresso.Domain.Specifications.ClienteSpec;
using ModuloCongresso.Domain.Specifications.CotacaoSpec;
using ModuloCongresso.Domain.Specifications.ItemSpec;
using ModuloCongresso.Domain.Specifications.QuestionarioSpec;

namespace ModuloCongresso.Domain.Validations.Cotacao
{
    public class CotacaoEstaConsistenteValidation : Validator<Entities.Cotacao>
    {
        public CotacaoEstaConsistenteValidation()
        {
            var dataInicialCotacao = new CotacaoDevePossuirDataValidaSpecification();
            var modelo = new ItemDevePossuirModeloValidoSelecionadoSpecification();
            var cpfCliente = new ClienteDeveTerCPFValidoSpecification();
            var emailCliente = new ClienteDeveTerEmailValidoSpecification();
            var clienteMaioridade = new ClienteDeveSerMaiorDeIdadeSpecification();
            var questionarioRastreador = new QuestionarioRastreadorObrigatorioSpecification();
            var questionarioPropriedade = new QuestionarioPropriedadeObrigatorioSpecification();
            var questionarioAntiFurto = new QuestionarioAntiFurtoObrigatorioSpecification();
            var questionarioResidencia = new QuestionarioResidenciaObrigatorioSpecification();
            var questionarioTrabalho = new QuestionarioTrabalhoObrigatorioSpecification();
            var questionarioFaculdade = new QuestionarioColFaculdadeObrigatorioSpecification();

            base.Add("dataInicialCotacao", new Rule<Entities.Cotacao>(dataInicialCotacao, ValidationMessages.DataInicialInvalida));
            base.Add("modelo", new Rule<Entities.Cotacao>(modelo, ValidationMessages.ModeloNaoSelecionado));
            base.Add("cpfCliente", new Rule<Entities.Cotacao>(cpfCliente, ValidationMessages.CpfInvalido));
            base.Add("emailCliente", new Rule<Entities.Cotacao>(emailCliente, ValidationMessages.EmailInvalido));
            base.Add("clienteMaioridade", new Rule<Entities.Cotacao>(clienteMaioridade, ValidationMessages.ClienteMaioridadeInvalido));
            base.Add("questionarioRastreador", new Rule<Entities.Cotacao>(questionarioRastreador, ValidationMessages.RastreadorNaoSelecionado));
            base.Add("questionarioPropriedade", new Rule<Entities.Cotacao>(questionarioPropriedade, ValidationMessages.PropriedadeNaoSelecionado));
            base.Add("questionarioAntiFurto", new Rule<Entities.Cotacao>(questionarioAntiFurto, ValidationMessages.AntiFurtoNaoSelecionado));
            base.Add("questionarioResidencia", new Rule<Entities.Cotacao>(questionarioResidencia, ValidationMessages.GaragemResidenciaNaoSelecionado));
            base.Add("questionarioTrabalho", new Rule<Entities.Cotacao>(questionarioTrabalho, ValidationMessages.GaragemTrabalhoNaoSelecionado));
            base.Add("questionarioFaculdade", new Rule<Entities.Cotacao>(questionarioFaculdade, ValidationMessages.GaragemFaculdadeNaoSelecionado));
        }
    }
}