﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excepciones;

namespace EntidadesAbstractas
{
    public class Persona
    {
        public enum ENacionalidad { Argentino, Extranjero }

        #region "Atributos"
        private string _nombre;
        private string _apellido;
        private ENacionalidad _nacionalidad;
        private int _dni;
        #endregion

        #region "Propiedades"
        /// <summary>
        /// Lectura y/o escritura del atributo nombre
        /// </summary>
        public string Nombre
        {
            get { return this._nombre; }
            set { this._nombre = this.ValidarNombreApellido(value); }
        }
        /// <summary>
        /// Lectura y/o escritura del atributo apellido
        /// </summary>
        public string Apellido
        {
            get { return this._apellido; }
            set { this._apellido = this.ValidarNombreApellido(value); }
        }
        /// <summary>
        ///Lectura y/o escritura del atributo nacionalidad
        /// </summary>
        public ENacionalidad Nacionalidad
        {
            get { return this._nacionalidad; }
            set { this._nacionalidad = value; }
        }
        /// <summary>
        /// Lectura y/o escritura del atributo dni
        /// </summary>
        public int Dni
        {
            get { return this._dni; }
            set { this._dni = this.ValidarDni(this.Nacionalidad, value); }
        }
        /// <summary>
        /// Convierte el dni de string a int y valida que sea correcto
        /// </summary>
        public string StringToDni
        {
            set { this._dni = this.ValidarDni(this.Nacionalidad, value); }
        }
        #endregion

        #region "Constructores"

        public Persona()
        {
            //this._apellido = "";
            //this._nombre = "";
            //this._nacionalidad = ENacionalidad.Extranjero;
            //this._dni = 0;
        }

        /// <summary>
        /// Inicializa con datos recibidos por parametro
        /// </summary>
        /// <param name="nombre">nombre de la persona</param>
        /// <param name="apellido">apellido de la persona</param>
        /// <param name="nacionalidad">Enumerado que indica si la persona es Argentino o Extranjero</param>
        public Persona(string nombre, string apellido, ENacionalidad nacionalidad)
        {
            this.Nombre = nombre;
            this.Apellido = apellido;
            this.Nacionalidad = nacionalidad;
        }
        /// <summary>
        /// Inicializa con datos recibidos por parametro
        /// </summary>
        /// <param name="nombre">nombre de la persona</param>
        /// <param name="apellido">apellido de la persona</param>
        /// <param name="dni">Número de dni de la persona</param>
        /// <param name="nacionalidad">Enumerado que indica si la persona es Argentino o Extranjero</param>
        public Persona(string nombre, string apellido, int dni, ENacionalidad nacionalidad)
            : this(nombre, apellido, nacionalidad)
        {
            this.Dni = dni;
        }
        /// <summary>
        /// Inicializa con datos recibidos por parametro
        /// </summary>
        /// <param name="nombre">nombre de la persona</param>
        /// <param name="apellido">apellido de la persona</param>
        /// <param name="dni">número de dni de la persona</param>
        /// <param name="nacionalidad">Enumerado que indica si la persona es Argentino o Extranjero</param>
        public Persona(string nombre, string apellido, string dni, ENacionalidad nacionalidad)
            : this(nombre, apellido, nacionalidad)
        {
            this.StringToDni = dni;
        }
        #endregion

        #region "Metodos"
        /// <summary>
        /// Valida que el dni sea correcto dentro del rango según su nacionalidad
        /// </summary>
        /// <param name="nacionalidad">Enum que indica si la persona es Argentino o Extranjero</param>
        /// <param name="dni">dni de la persona</param>
        /// <returns>si puede validar retorna el dni, caso contrario lanza excepcion</returns>
        private int ValidarDni(ENacionalidad nacionalidad, int dni)
        {
            switch (nacionalidad)
            {
                case ENacionalidad.Argentino:
                    if (dni < 1 || dni > 89999999)
                        throw new NacionalidadInvalidaException();
                    break;
                case ENacionalidad.Extranjero:
                    if (dni < 89999999 || dni > 99999999)
                        throw new NacionalidadInvalidaException();
                    break;
            }
            return dni;
        }

        /// <summary>
        /// Intenta convertir el string recibido a int y valida que el dni este dentro del rango correspondiente segun la nacionalidad
        /// </summary>
        /// <param name="nacionalidad">Enum que indica si la persona es Argentino o Extranjero</param>
        /// <param name="dni">número de dni de la persona en tipo Cadena de caracteres</param>
        /// <returns>si puede validar retorna el dni, caso contrario lanza una excepcion</returns>
        private int ValidarDni(ENacionalidad nacionalidad, string dni)
        {
            int auxDni = 0;
            if (dni != null)
            {
                if (!int.TryParse(dni, out auxDni))
                    throw new DniInvalidoException();
                return this.ValidarDni(nacionalidad, auxDni);
            }
            throw new DniInvalidoException();
        }

        /// <summary>
        /// Valida que la cadena recibida por parámetro solo contenga letras
        /// </summary>
        /// <param name="dato">cadena de caracteres que se analizará</param>
        /// <returns>si puede validar retorna la cadena, caso contrario retorna una cadena vacia</returns>
        private string ValidarNombreApellido(string dato)
        {
            foreach (char letra in dato)
            {
                if (!char.IsLetter(letra))
                {
                    dato = "";
                    break;
                }
            }
            return dato;
        }

        /// <summary>
        /// Retorna un string con los datos de la persona
        /// </summary>
        /// <returns>una cadena de caracteres con los datos de la persona</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("NOMBRE COMPLETO: " + this.Apellido + ", " + this.Nombre);
            sb.AppendLine("NACIONALIDAD: " + this.Nacionalidad.ToString());
            return sb.ToString();
        }
        #endregion

    }
}
