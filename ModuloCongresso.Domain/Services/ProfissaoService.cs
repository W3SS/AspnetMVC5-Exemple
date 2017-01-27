using ModuloCongresso.Domain.Entities;
using ModuloCongresso.Domain.Interfaces.Repository;
using ModuloCongresso.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModuloCongresso.Domain.Services
{
    public class ProfissaoService : IProfissaoService
    {
        private readonly IProfissaoRepository _profisssaoRepository;

        public ProfissaoService(IProfissaoRepository profissaoRepository)
        {
            _profisssaoRepository = profissaoRepository;
        }

        public IEnumerable<Profissao> ObterTodos()
        {
            return _profisssaoRepository.ObterTodos();
        }

        public void Dispose()
        {
            _profisssaoRepository.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
