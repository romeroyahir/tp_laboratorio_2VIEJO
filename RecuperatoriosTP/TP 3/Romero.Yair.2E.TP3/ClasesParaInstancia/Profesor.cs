using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadesAbstractas;

namespace ClasesParaInstancia
{
    public sealed class Profesor : Universitario
    {
        #region "Atributos"
        private Queue<Universidad.EClases> _clasesDelDia;
        private static Random _random;
        #endregion

        #region "Constructores"

        public Profesor()
        {
        }

        /// <summary>
        /// Inicializa el atributo estatico random
        /// </summary>
        static Profesor()
        {
            _random = new Random();
        }

        /// <summary>
        /// Inicializa con los valores recibidos por parametro
        /// </summary>
        /// <param name="legajo">legajo del Profesor</param>
        /// <param name="nombre">nombre del Profesor</param>
        /// <param name="apellido">apellido del Profesor</param>
        /// <param name="dni">DNI del Profesor</param>
        /// <param name="nacionalidad">Enumerado que indica si el Profesor es Argentino o Extranjero</param>
        public Profesor(int legajo, string nombre, string apellido, string dni, ENacionalidad nacionalidad)
            : base(legajo, nombre, apellido, dni, nacionalidad)
        {
            this._clasesDelDia = new Queue<Universidad.EClases>();
            this._randomClases();
        }
        #endregion

        #region "Metodos"
        /// <summary>
        /// Asigna aleatoriamente clase al profesor
        /// </summary>
        private void _randomClases()
        {
            for (int i = 0; i < 2; i++)
                this._clasesDelDia.Enqueue(((Universidad.EClases)_random.Next(0, 4)));
        }

        /// <summary>
        /// Genera un string con los datos del Profesor
        /// </summary>
        /// <returns>String con los datos del Profesor</returns>
        protected override string MostrarDatos()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(base.MostrarDatos());
            sb.AppendLine(this.ParticiparEnClase());
            return sb.ToString();
        }

        /// <summary>
        /// Retorna una cadena de caracteres con las clases que da el Profesor
        /// </summary>
        /// <returns>String con valores del atributo _clasesDelDia</returns>
        protected override string ParticiparEnClase()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("CLASES DEL DIA:");
            foreach (Universidad.EClases c in this._clasesDelDia)
            {
                sb.AppendLine(c.ToString());
            }
            return sb.ToString();
        }

        /// <summary>
        /// Retorna los datos del profesor en una cadena de caracteres
        /// </summary>
        /// <returns>String con los datos del Profesor</returns>
        public override string ToString()
        {
            return this.MostrarDatos();
        }
        #endregion

        #region "Operadores"
        /// <summary>
        /// Operador de igualdad que compara profesor con una clase, si el prof dá la misma
        /// </summary>
        /// <param name="p">Profesor</param>
        /// <param name="clase"></param>
        /// <returns>true si el Profesor da la clase</returns>
        public static bool operator ==(Profesor p, Universidad.EClases clase)
        {
            foreach (Universidad.EClases c in p._clasesDelDia)
            {
                if (c == clase)
                    return true;
            }
            return false;
        }

        /// <summary>
        /// Operador de desigualdad que compara profesor con una clase, si el profesor no dá la misma
        /// </summary>
        /// <param name="p">Profesor</param>
        /// <param name="clase"></param>
        /// <returns>true si el Profesor no da la clase</returns>
        public static bool operator !=(Profesor p, Universidad.EClases clase)
        {
            return !(p == clase);
        }
        #endregion
    }
}
