using System.Collections.Generic;
using System.Linq;
using ModuloCongresso.Domain.Entities;

namespace ModuloCongresso.Domain.Validations.Documentos
{
    public class QuestionarioSegurancaValidation
    {
        public static bool Validar(ICollection<Questionario> questionarios, QuestionarioSeguranca option)
        {
            foreach (var quest in questionarios.Where(quest => quest.FlagAntiFurto))
            {
                switch (option)
                {
                    case QuestionarioSeguranca.Rastreador:
                        if (quest.RastreadorId == null)
                            return false;
                        break;
                    case QuestionarioSeguranca.Propriedade:
                        if (quest.RastreadorId != null && (string.IsNullOrEmpty(quest.PropriedadeRastreador) || quest.PropriedadeRastreador == "Selecione"))
                            return false;
                        break;
                    case QuestionarioSeguranca.AntiFurto:
                        if (quest.AntiFurtoId == null)
                            return false;
                        break;
                }
            }

            return true;
        }
    }
}