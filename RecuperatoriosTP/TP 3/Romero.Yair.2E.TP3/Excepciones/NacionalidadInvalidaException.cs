using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excepciones
{
    public class NacionalidadInvalidaException : Exception
    {
        private static string _message = "La nacionalidad no presenta relación con el número de DNI";

        public NacionalidadInvalidaException()
            : base(_message)
        {

        }
    }
}
