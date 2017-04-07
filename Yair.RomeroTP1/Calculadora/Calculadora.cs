using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculadora
{
    class Calculadora
    {
        #region Atributos
        /// <summary>
        /// Atributos
        /// </summary>
        double resultado;
        #endregion

        #region Metodos

        /// <summary>
        /// Realizará la operación que indique el operador entre los dos objetos Numero que reciba.
        /// </summary>
        /// <param name="numero1"></param>
        /// <param name="numero2"></param>
        /// <param name="operador"></param>
        /// <returns>Resultado (Double)</returns>
        public double Operar(Numero numero1, Numero numero2, string operador)
        {
            int op;
            ValidarOperador(operador); 
            op = int.Parse(operador);
            switch (op)
            {
                case 0:
                          resultado = numero1.GetNumero() + numero2.GetNumero();
                          break;
                case 1:
                          resultado = numero1.GetNumero() - numero2.GetNumero();
                          break;
                case 2:
                          resultado = numero1.GetNumero() * numero2.GetNumero();
                          break;
                case 3: 
                          if (numero2.GetNumero() == 0)
                          {
                              resultado = 0;
                              break;
                          }
                          else
                          {
                              resultado = numero1.GetNumero() / numero2.GetNumero();
                              break;
                          }
                          
                          
            }
                    return resultado;

        }

        /// <summary>
        /// Validará que el operador recibido sea un carácter válido
        /// </summary>
        /// <param name="operador"></param>
        /// <returns></returns>
        public string ValidarOperador(string operador)
        {
            int op;
            op = int.Parse(operador);
            if (op == -1)
            {
                op = 0;
                return op.ToString();
            }
            else
            {
                
                return op.ToString();
            }
        }
        #endregion

    }
}
