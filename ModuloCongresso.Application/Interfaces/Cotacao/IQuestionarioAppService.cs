using System;
using System.Collections.Generic;
using ModuloCongresso.Application.ViewModels.Cotacao;

namespace ModuloCongresso.Application.Interfaces.Cotacao
{
    public interface IQuestionarioAppService : IDisposable
    {
        IEnumerable<QuestionarioViewModel> ObterTodos();

        QuestionarioViewModel ObterQuestionarioCotacao(int cotacaoId);
    }
}