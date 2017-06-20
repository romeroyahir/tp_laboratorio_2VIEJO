using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Archivos
{
    public class Texto : IArchivo<string>
    {
        #region Atributos
        private string _archivo;
        #endregion

        #region Metodos y Constructor
        /// <summary>
        /// Constructor publico donde se asigna valor a atributo archivo
        /// </summary>
        /// <param name="data"></param>
        public Texto(string data)
        {
            this._archivo = Environment.CurrentDirectory + "\\" + data;
        }

        /// <summary>
        /// Guarda los datos pasados por parametro en atributo archivo
        /// </summary>
        /// <param name="datos">Cadena de string con datos a guardar</param>
        /// <returns>True si pudo guardar, False en caso contrario</returns>
        public bool Guardar(string datos)
        {
            bool valorRetorno;
            try
            {
                if (File.Exists(this._archivo))
                {
                    using (StreamWriter archivoTxt = new StreamWriter(this._archivo, true))
                    {
                        archivoTxt.WriteLine(datos);
                        archivoTxt.Close();
                    }
                }
                else
                {
                    using (StreamWriter archivoTxt = new StreamWriter(this._archivo, false))
                    {
                        archivoTxt.WriteLine(datos);
                    }
                }
                valorRetorno = true;
            }
            catch (Exception e)
            {
                Console.Write("Error al guardar: " + this._archivo + "\x0D\x0A" + e.StackTrace);
                valorRetorno = false;
            }
            return valorRetorno;
        }

        /// <summary>
        /// Lee archivo y lo guarda en la lista pasada por parámetro
        /// </summary>
        /// <param name="data">lista de cadenas string donde se guardarán los datos leidos</param>
        /// <returns>True si pudo leer, False en caso contrario</returns>
        public bool Leer (out List<string> data)
        {
            bool valorRetorno;

            try
            {
                var archivo = File.ReadAllLines(this._archivo);
                data = new List<string>(archivo);
                valorRetorno = true;
            }
            catch (Exception e)
            {
                Console.Write("Error al leer: " + this._archivo + e.Message);
                data = new List<String>();
                valorRetorno = false;
            }

            return valorRetorno;
        }

        #endregion


    }
}
