using ModuloCongresso.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModuloCongresso.Application.Interfaces
{
    public interface IPaisResidenciaAppService : IDisposable
    {
        IEnumerable<PaisResidenciaViewModel> ObterTodos();
    }
}
