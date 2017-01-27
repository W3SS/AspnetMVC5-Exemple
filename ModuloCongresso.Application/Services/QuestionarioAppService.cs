using System;
using System.Collections.Generic;
using AutoMapper;
using ModuloCongresso.Application.Interfaces.Cotacao;
using ModuloCongresso.Application.ViewModels.Cotacao;
using ModuloCongresso.Domain.Interfaces.Services.CotacaoService;

namespace ModuloCongresso.Application.Services
{
    public class QuestionarioAppService : IQuestionarioAppService
    {
        private readonly IQuestionarioService _questionarioService;

        public QuestionarioAppService(IQuestionarioService questionarioService)
        {
            _questionarioService = questionarioService;
        }

        public IEnumerable<QuestionarioViewModel> ObterTodos()
        {
            return Mapper.Map<IEnumerable<QuestionarioViewModel>>(_questionarioService.ObterTodos());
        }

        public QuestionarioViewModel ObterQuestionarioCotacao(int cotacaoId)
        {
            return Mapper.Map<QuestionarioViewModel>(_questionarioService.ObterQuestionarioCotacao(cotacaoId));
        }

        public void Dispose()
        {
            _questionarioService.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}