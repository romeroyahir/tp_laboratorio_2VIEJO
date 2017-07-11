using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibArchivos;
using Excepciones;

namespace ClasesParaInstancia
{
    public class Jornada
    {
        #region "Atributos"
        private List<Alumno> _alumnos;
        private Universidad.EClases _clase;
        private Profesor _profesor;
        #endregion

        #region "Propiedades"
        /// <summary>
        /// Lectura y/o escritura de lista de Alumnos
        /// </summary>
        public List<Alumno> Alumnos
        {
            get { return this._alumnos; }
            set { this._alumnos = value; }
        }

        /// <summary>
        /// Lectura y/o escritura del atributo clase
        /// </summary>
        public Universidad.EClases Clase
        {
            get { return this._clase; }
            set { this._clase = value; }
        }

        /// <summary>
        /// Lectura y/o escritura del atributo profesor
        /// </summary>
        public Profesor Instructor
        {
            get { return this._profesor; }
            set { this._profesor = value; }
        }
        #endregion

        #region "Constructores"
        /// <summary>
        /// Inicializa con valores por defecto en sus atributos
        /// </summary>
        private Jornada()
        {
            this.Alumnos = new List<Alumno>();
        }

        /// <summary>
        /// Inicializa con los valores recibidos por parametro
        /// </summary>
        /// <param name="clase">clase de la Jornada</param>
        /// <param name="instructor">Profesor</param>
        public Jornada(Universidad.EClases clase, Profesor instructor)
            : this()
        {
            this.Clase = clase;
            this.Instructor = instructor;
        }
        #endregion

        #region "Metodos"
        /// <summary>
        /// Guardara los datos de la jornada en un archivo de texto
        /// </summary>
        /// <param name="jornada">Jornada</param>
        /// <returns>Retorna true si pudo guardar, sino lanza un ArchivosException()</returns>
        public static bool Guardar(Jornada jornada)
        {
            try
            {
                Texto txt = new Texto();
                txt.Guardar("../../../Jornada.txt", jornada.ToString());
                return true;
            }
            catch (Exception)
            {
                throw new ArchivosException();
            }
        }

        /// <summary>
        /// Lee archivo de texto y lo muestra por pantalla
        /// </summary>
        /// <returns>Retorna true si pudo leer, sino false</returns>
        public static bool Leer()
        {
            string datos;
            Texto txt = new Texto();
            if (!txt.Leer("Jornada.txt", out datos))
            {
                Console.WriteLine("Error al leer TXT");
                return false;
            }
            else
            {
                Console.WriteLine(datos);
                return true;
            }
        }

        /// <summary>
        /// Sobrecarga el metodo ToString
        /// </summary>
        /// <returns>string con los datos de la jornada</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("JORNADA:");
            sb.Append("CLASE DE " + this._clase.ToString() + " POR " + this.Instructor.ToString());
            sb.AppendLine("ALUMNOS: ");
            foreach (Alumno a in this._alumnos)
            {
                sb.AppendLine(a.ToString());
            }
            return sb.ToString();
        }

        #endregion

        #region "Operadores"

        /// <summary>
        /// Verifica si el alumno esta en la jornada
        /// </summary>
        /// <param name="j">Jornada</param>
        /// <param name="a">Alumno</param>
        /// <returns>Retorna true si encuentra al alumno, sino false</returns>
        public static bool operator ==(Jornada j, Alumno a)
        {
            foreach (Alumno al in j._alumnos)
            {
                if (al == a)
                    throw new AlumnoRepetidoException();
            }
            return false;
        }

        /// <summary>
        /// Verifica si un alumno no esta en la jornada
        /// </summary>
        /// <param name="j">Jornada</param>
        /// <param name="a">Alumno</param>
        /// <returns>Retorna flase si encuentra al alumno, sino true</returns>
        public static bool operator !=(Jornada j, Alumno a)
        {
            return !(j == a);
        }

        /// <summary>
        /// Agrega un alumno a la jornada si no esta en ella
        /// </summary>
        /// <param name="j">Jornada</param>
        /// <param name="a">Alumno</param>
        /// <returns>Retorna la jornada</returns>
        public static Jornada operator +(Jornada j, Alumno a)
        {
            if (j != a)
                j._alumnos.Add(a);
            return j;
        }

        #endregion
    }
}
