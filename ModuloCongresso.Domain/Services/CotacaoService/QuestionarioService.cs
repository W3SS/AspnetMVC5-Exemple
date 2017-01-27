using System;
using System.Collections.Generic;
using ModuloCongresso.Domain.Entities;
using ModuloCongresso.Domain.Interfaces.Repository.CotacaoRepository;
using ModuloCongresso.Domain.Interfaces.Services.CotacaoService;

namespace ModuloCongresso.Domain.Services.CotacaoService
{
    public class QuestionarioService : IQuestionarioService
    {
        private readonly IQuestionarioRepository _questionarioRepository;

        public QuestionarioService(IQuestionarioRepository questionarioRepository)
        {
            _questionarioRepository = questionarioRepository;
        }

        public IEnumerable<Questionario> ObterTodos()
        {
            return _questionarioRepository.ObterTodos();
        }

        public void Dispose()
        {
            _questionarioRepository.Dispose();
            GC.SuppressFinalize(this);
        }

        public Questionario ObterQuestionarioCotacao(int cotacaoId)
        {
            return _questionarioRepository.ObterQuestionarioCotacao(cotacaoId);
        }
    }
}