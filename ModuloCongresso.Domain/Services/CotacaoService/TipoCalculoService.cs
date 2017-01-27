using System;
using System.Collections.Generic;
using System.Globalization;
using ModuloCongresso.Domain.Entities;
using ModuloCongresso.Domain.Interfaces.Repository.CotacaoRepository;
using ModuloCongresso.Domain.Interfaces.Services.CotacaoService;

namespace ModuloCongresso.Domain.Services.CotacaoService
{
    public class TipoCalculoService : ITipoCalculoService
    {
        private readonly ITipoCalculoRepository _tipoCalculoRepository;

        public TipoCalculoService(ITipoCalculoRepository tipoCalculoRepository)
        {
            _tipoCalculoRepository = tipoCalculoRepository;
        }

        public IEnumerable<TipoCalculo> ObterTodos()
        {
            return _tipoCalculoRepository.ObterTodos();
        }

        public string ObterDataVigenciaFinal(int tipoCalculoId, string dataVigenciaInicial)
        {
            var query = _tipoCalculoRepository.ObterTipoCalculoPorId(tipoCalculoId);

            var data = DateTime.Parse(dataVigenciaInicial, CultureInfo.InvariantCulture);

            switch (query.TipoCalculoId)
            {
                case (int)TipoCalculoEnum.Anual:
                    data = data.AddYears(1);
                    break;
                case (int)TipoCalculoEnum.BiAnual:
                    data = data.AddYears(2);
                    break;
            }

            return data.ToString("MM/dd/yyyy", CultureInfo.InvariantCulture);
        }

        public void Dispose()
        {
            _tipoCalculoRepository.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}