using ModuloCongresso.Domain.Entities;
using System.Collections.Generic;

namespace ModuloCongresso.Domain.Interfaces.Repository
{
    public interface IClienteRepository : IRepository<Cliente>
    {
        Cliente ObterPorCpf(string cpf);

        Cliente ObterPorEmail(string email);

        IEnumerable<Cliente> ObterAtivos();

        Cliente ObterClienteCotacao(int cotacaoId);
    }
}
