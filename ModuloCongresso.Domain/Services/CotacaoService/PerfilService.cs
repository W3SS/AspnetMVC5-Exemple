using System;
using System.Collections.Generic;
using ModuloCongresso.Domain.Entities;
using ModuloCongresso.Domain.Interfaces.Repository.CotacaoRepository;
using ModuloCongresso.Domain.Interfaces.Services.CotacaoService;

namespace ModuloCongresso.Domain.Services.CotacaoService
{
    public class PerfilService : IPerfilService
    {
        private readonly IPerfilRepository _perfilRepository;

        public PerfilService(IPerfilRepository perfilRepository)
        {
            _perfilRepository = perfilRepository;
        }

        public IEnumerable<Perfil> ObterTodos()
        {
            return _perfilRepository.ObterTodos();
        }

        public Perfil ObterPerfilCotacao(int cotacaoId)
        {
            return _perfilRepository.ObterPerfilCotacao(cotacaoId);
        }

        public void Dispose()
        {
            _perfilRepository.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}