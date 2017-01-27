using ModuloCongresso.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModuloCongresso.Domain.Entities;
using ModuloCongresso.Domain.Interfaces.Repository;

namespace ModuloCongresso.Domain.Services
{
    public class PaisResidenciaService : IPaisResidenciaService
    {
        private readonly IPaisResidenciaRepository _paisResidenciaRepository;

        public PaisResidenciaService(IPaisResidenciaRepository paisResidenciaRepository)
        {
            _paisResidenciaRepository = paisResidenciaRepository;
        }

        public IEnumerable<PaisResidencia> ObterTodos()
        {
            return _paisResidenciaRepository.ObterTodos();
        }

        public void Dispose()
        {
            _paisResidenciaRepository.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
