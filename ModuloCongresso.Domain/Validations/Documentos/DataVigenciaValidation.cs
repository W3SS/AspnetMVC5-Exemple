using System;

namespace ModuloCongresso.Domain.Validations.Documentos
{
    public class DataVigenciaValidation
    {
        public static bool Validar(DateTime dataVigenciaInicial)
        {
            var localDate = DateTime.Now;

            if (dataVigenciaInicial.Date < localDate.Date)
                return false;
            else
                return true; 
        }
    }
}