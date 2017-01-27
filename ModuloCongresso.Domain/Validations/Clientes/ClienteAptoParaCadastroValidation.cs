using DomainValidation.Validation;
using ModuloCongresso.Domain.Entities;
using ModuloCongresso.Domain.Interfaces.Repository;
using ModuloCongresso.Domain.Specifications.ClienteSpec;

namespace ModuloCongresso.Domain.Validations.Clientes
{
    public class ClienteAptoParaCadastroValidation : Validator<Cliente>
    {
        public ClienteAptoParaCadastroValidation(IClienteRepository clienteRepository)
        {
            var cpfDuplicado = new ClienteDevePossuirCPFUnicoSpecification(clienteRepository);
            var emailDuplicado = new ClienteDevePossuirEmailUnicoSpecification(clienteRepository);

            base.Add("cpfDuplicado", new Rule<Cliente>(cpfDuplicado, ValidationMessages.CpfJaCadastrado));
            base.Add("emailDuplicado", new Rule<Cliente>(emailDuplicado, ValidationMessages.EmailJaCadastrado));
        }
    }
}
