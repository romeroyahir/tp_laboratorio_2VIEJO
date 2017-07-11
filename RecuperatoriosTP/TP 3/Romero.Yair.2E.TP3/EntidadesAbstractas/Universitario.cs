using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntidadesAbstractas
{
    public abstract class Universitario : Persona
    {
        private int _legajo;

        #region "Constructores"

        public Universitario():base()
        {
        }

        /// <summary>
        /// Inicializa con valores recibidos por parametro
        /// </summary>
        /// <param name="legajo">número de legajo</param>
        /// <param name="nombre">nombre de la persona</param>
        /// <param name="apellido">apellido de la persona</param>
        /// <param name="dni">número de dni de la persona</param>
        /// <param name="nacionalidad">Enumerado que indica si la persona es Argentino o Extranjero</param>
        public Universitario(int legajo, string nombre, string apellido, string dni, ENacionalidad nacionalidad)
            : base(nombre, apellido, dni, nacionalidad)
        {
            this._legajo = legajo;
        }
        #endregion

        #region "Metodos"
        /// <summary>
        /// Genera un string con todos los datos del universitario
        /// </summary>
        /// <returns>String con los datos del Universitario</returns>
        protected virtual string MostrarDatos()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(base.ToString());
            sb.AppendFormat("LEGAJO NÚMERO: " + this._legajo);
            return sb.ToString();
        }

        protected abstract string ParticiparEnClase();

        /// <summary>
        /// Determina si el objeto recibido es de la misma clase que la instancia
        /// </summary>
        /// <param name="obj">Objeto a comparar la clase</param>
        /// <returns>true si son de la misma clase</returns>
        public override bool Equals(object obj)
        {
            return this.GetType() == obj.GetType();
        }

        #endregion

        #region "Operadores"

        /// <summary>
        /// Compara si dos universitarios son iguales tomando en cuenta legajo y dni.
        /// </summary>
        /// <param name="un1">1er universitario</param>
        /// <param name="un2">2do Universitario</param>
        /// <returns>true si todas las comparaciones son verdaderas</returns>
        public static bool operator ==(Universitario un1, Universitario un2)
        {
            if (un1.Equals(un2) && (un1._legajo == un2._legajo || un1.Dni == un2.Dni))
                return true;
            return false;
        }
        /// <summary>
        /// Compara si dos universitarios son distintos tomando en cuenta legajo y dni.
        /// </summary>
        /// <param name="un1">1er Universitario</param>
        /// <param name="un2">2do Universitario</param>
        /// <returns>true si todas las comparaciones son verdaderas</returns>
        public static bool operator !=(Universitario un1, Universitario un2)
        {
            return !(un1 == un2);
        }

        #endregion
    }
}
