using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml.Serialization;
using Excepciones;

namespace LibArchivos
{
    public class XML<T> : IArchivo<T>
    {
        /// <summary>
        /// Genera un archivo xml con los datos recibidos
        /// </summary>
        /// <param name="archivo">Nombre y ruta del archivo</param>
        /// <param name="datos">Cadena con los datos a guardar</param>
        /// <returns>true si pudo generar el archivo, sino lanza un ArchivosException()</returns>
        public bool Guardar(string archivo, T datos)
        {
            bool retorno = false;
            try
            {
                using (StreamWriter sw = new StreamWriter(archivo))
                {
                    XmlSerializer s = new XmlSerializer(typeof(T));

                    s.Serialize(sw, datos);
                    sw.Close();

                    retorno = true;
                }
            }
            catch (Exception)
            {
                throw new ArchivosException();
            }
            return retorno;
        }

        /// <summary>
        /// Lee un archivo xml y lo guarda en el parametro de salida
        /// </summary>
        /// <param name="archivo">Archivo a ser leido</param>
        /// <param name="datos">Parametro de salida donde se guardara el valor de "archivo"</param>
        /// <returns>true si pudo leer el archivo, sino lanza un ArchivosException()</returns>
        public bool Leer(string archivo, out T datos)
        {
            bool retorno = false;
            try
            {
                XmlSerializer serializer = new XmlSerializer(typeof(T));
                TextReader reader = new StreamReader(archivo);
                datos = (T)serializer.Deserialize(reader);
                reader.Close();
                retorno = true;
            }
            catch (Exception)
            {
                datos = default(T);
                throw new ArchivosException();
            }
            return retorno;
        }
    }
}
