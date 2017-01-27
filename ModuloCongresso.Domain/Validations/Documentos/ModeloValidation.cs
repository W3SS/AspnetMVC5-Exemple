using System.Collections.Generic;
using ModuloCongresso.Domain.Entities;

namespace ModuloCongresso.Domain.Validations.Documentos
{
    public class ModeloValidation
    {
        public static bool Validar(ICollection<Item> itens)
        {
            foreach (var item in itens)
            {
                if (item.ModeloId == 0)
                    return false;
            }

            return true;
        }
    }
}