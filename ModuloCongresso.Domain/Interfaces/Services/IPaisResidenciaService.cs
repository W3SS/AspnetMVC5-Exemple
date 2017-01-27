using ModuloCongresso.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModuloCongresso.Domain.Interfaces.Services
{
    public interface IPaisResidenciaService : IDisposable
    {
        IEnumerable<PaisResidencia> ObterTodos();
    }
}
