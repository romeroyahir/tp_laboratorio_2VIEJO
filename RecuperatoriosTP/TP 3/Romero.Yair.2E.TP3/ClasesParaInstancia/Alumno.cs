using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadesAbstractas;

namespace ClasesParaInstancia
{
    public sealed class Alumno : Universitario
    {
        #region "Atributos"
        private Universidad.EClases _claseATomar;
        private EEstadoCuenta _estadoDeCuenta;
        #endregion

        public enum EEstadoCuenta { AlDia, Deudor, Becado }

        #region "Constructores"
        public Alumno()
        {
        }

        /// <summary>
        /// Inicializa con valores recibidos por parametro
        /// </summary>
        /// <param name="legajo">legajo del Alumno</param>
        /// <param name="nombre">nombre del Alumno</param>
        /// <param name="apellido">apellido del Alumno</param>
        /// <param name="dni">DNI del Alumno</param>
        /// <param name="nacionalidad">Enumerado que indica si el Alumno es Argentino o Extranjero</param>
        /// <param name="claseQueToma">Enumerado que representa la clase a la que asiste el Alumno</param>
        public Alumno(int legajo, string nombre, string apellido, string dni, ENacionalidad nacionalidad, Universidad.EClases claseQueToma)
            : base(legajo, nombre, apellido, dni, nacionalidad)
        {
            this._claseATomar = claseQueToma;
        }

        /// <summary>
        /// Inicializa con valores recibidos por parametro
        /// </summary>
        /// <param name="legajo">legajo del Alumno</param>
        /// <param name="nombre">nombre del Alumno</param>
        /// <param name="apellido">apellido del Alumno</param>
        /// <param name="dni">DNI del Alumno</param>
        /// <param name="nacionalidad">Enum que indica si el Alumno es Argentino o Extranjero</param>
        /// <param name="claseQueToma">clase a la que asiste el Alumno</param>
        /// <param name="estadoDeCuenta">estado de cuenta del Alumno</param>
        public Alumno(int legajo, string nombre, string apellido, string dni, ENacionalidad nacionalidad, Universidad.EClases claseQueToma, EEstadoCuenta estadoDeCuenta)
            : this(legajo, nombre, apellido, dni, nacionalidad, claseQueToma)
        {
            this._estadoDeCuenta = estadoDeCuenta;
        }
        #endregion

        #region "Metodos"
        /// <summary>
        /// Retorna un string con datos del Alumno
        /// </summary>
        /// <returns>Cadena con los datos del Alumno</returns>
        protected override string MostrarDatos()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(base.MostrarDatos());
            sb.AppendLine("ESTADO DE CUENTA: " + this._estadoDeCuenta.ToString());
            sb.AppendLine(this.ParticiparEnClase());
            return sb.ToString();
        }

        /// <summary>
        /// Retorna una cadena con las clases que toma el Alumno
        /// </summary>
        /// <returns>String de _claseATomar</returns>
        protected override string ParticiparEnClase()
        {
            return String.Format("TOMA CLASES DE " + this._claseATomar.ToString());
        }

        /// <summary>
        /// Retorna datos del alumno
        /// </summary>
        /// <returns>string datos del Alumno</returns>
        public override string ToString()
        {
            return this.MostrarDatos();
        }

        #endregion

        #region "Operadores"
        /// <summary>
        /// Verifica si un Alumno puede participar en clases verificando su estado de cuenta y si está anotado en la clase.
        /// </summary>
        /// <param name="alum">Alumno</param>
        /// <param name="clase"></param>
        /// <returns>true si se cumplen las condiciones</returns>
        public static bool operator ==(Alumno alum, Universidad.EClases clase)
        {
            if (alum._estadoDeCuenta != EEstadoCuenta.Deudor && alum._claseATomar == clase)
                return true;
            return false;
        }
        /// <summary>
        /// Determina si un alumno no toma alguna clase
        /// </summary>
        /// <param name="alum">Alumno</param>
        /// <param name="clase"></param>
        /// <returns>true si el Alumno no toma clase especifica</returns>
        public static bool operator !=(Alumno alum, Universidad.EClases clase)
        {
            if (alum._claseATomar != clase)
                return true;
            return false;
        }
        #endregion 
    }
}
