using System.Collections.Generic;
using System.Linq;
using ModuloCongresso.Domain.Entities;

namespace ModuloCongresso.Domain.Validations.Documentos
{
    public class QuestionarioGaragemValidation
    {
        public static bool Validar(ICollection<Questionario> questionarios, QuestionarioGaragem option)
        {
            foreach (var quest in questionarios.Where(quest => quest.FlagGararem))
            {
                switch (option)
                {
                    case QuestionarioGaragem.Residencia:
                        if (quest.GararemResidencia == "Selecione")
                            return false;
                        break;
                    case QuestionarioGaragem.Trabalho:
                        if (quest.GararemTrabalho == "Selecione")
                            return false;
                        break;
                    case QuestionarioGaragem.Faculdade:
                        if (quest.GararemFaculdade == "Selecione")
                            return false;
                        break;
                }
            }

            return true;
        }
    }
}