using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculadora
{
    class Numero
    {
        #region Atributos
        /// <summary>
        /// Atributos
        /// </summary>
        private double numero;
        #endregion

        #region Constructores
        /// <summary>
        /// Constructor por defecto inicializará el atributo en 0
        /// </summary>
        public Numero()
        {
            this.numero = 0;
        }

        /// <summary>
        /// Recibirá un string que validará y seteará en el atributo
        /// </summary>
        /// <param name="_numero"></param>
        public Numero(string _numero)
        {
            this.SetNumero(_numero);
        }

        /// <summary>
        /// Recibirá un double y lo cargará en el atributo
        /// </summary>
        /// <param name="_numero"></param>
        public Numero(double _numero)
            :this()
        {
            this.numero = _numero;
        }

        #endregion

        #region Get & Set
        /// <summary>
        /// Metodo SetNumero, se asigna y valida valor ingresado al atributo.
        /// </summary>
        /// <param name="_numero"></param>
        private void SetNumero(string _numero)
        {
            this.numero = Numero.ValidarNumero(_numero);
        }

        /// <summary>
        /// Retornará el valor double del atributo.
        /// </summary>
        /// <returns></returns>
        public double GetNumero()
        {
            return this.numero;
        }
        #endregion

        /// <summary>
        /// Metodo ValidarNumero para evitar que en caso de división, el denominador sea 0.
        /// </summary>
        /// <param name="numeroString"></param>
        /// <returns>Valor Numero (Double)</returns>
        private static double ValidarNumero(string numeroString)
        {
            double numDouble = 0;
            if (double.TryParse(numeroString, out numDouble) == true)
            {
                return numDouble;
            }
            else
            {
                return numDouble;
            }
            
        }

        //#region Operadores Unarios (Suma, resta, multiplicacion, division)
        ///// <summary>
        ///// Operador de suma entre dos objetos Numero
        ///// </summary>
        ///// <param name="num1"></param>
        ///// <param name="num2"></param>
        ///// <returns>Resultado de operacion (Double)</returns>
        //public static double operator + (Numero num1, Numero num2)
        //{
        //    double resultado;
        //    resultado = num1.numero + num2.numero;
        //    return resultado;
        //}
        
        ///// <summary>
        ///// Operador - entre dos objetos Numero
        ///// </summary>
        ///// <param name="num1"></param>
        ///// <param name="num2"></param>
        ///// <returns>Resultado de operacion (Double)</returns>
        //public static double operator -(Numero num1, Numero num2)
        //{
        //    double resultado;
        //    resultado = num1.numero - num2.numero;
        //    return resultado;
        //}

        ///// <summary>
        ///// Operador * entre dos objetos Numero
        ///// </summary>
        ///// <param name="num1"></param>
        ///// <param name="num2"></param>
        ///// <returns>Resultado de operacion (Double)</returns>
        //public static double operator *(Numero num1, Numero num2)
        //{
        //    double resultado;
        //    resultado = num1.numero * num2.numero;
        //    return resultado;
        //}

        ///// <summary>
        ///// Operador / entre dos objetos Numero
        ///// </summary>
        ///// <param name="num1"></param>
        ///// <param name="num2"></param>
        ///// <returns>Resultado de operacion (Double)</returns>
        //public static double operator /(Numero num1, Numero num2)
        //{
        //    double resultado;

        //    resultado = num1.numero / num2.numero;
        //    return resultado;
        //}
        //#endregion

        //#region Operadores Comparacion
        ///// <summary>
        ///// Bool operators == y != entre objeto Numero y valor INT.
        ///// </summary>
        ///// <param name="num1"></param>
        ///// <param name="num2"></param>
        ///// <returns>True (Dada la igualdad), False (caso contrario)</returns>
        //public static bool operator ==(Numero num1, int num2)
        //{
        //    if (num1.numero == num2)
        //    {
        //        return true;
        //    }
        //    else
        //    {
        //        return false;
        //    }
        //}
        //public static bool operator !=(Numero num1, int num2)
        //{
        //    return !(num1 == num2);
        //}
        //#endregion
    }
}
