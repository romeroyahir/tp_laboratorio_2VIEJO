using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Net; // Avisar del espacio de nombre
using System.ComponentModel;

namespace Hilo
{
    public class Descargador
    {
        #region Atributos

        private string _html;
        private Uri _direccion;

        #endregion

        #region Delegados

        public delegate void ProgresoDeCarga(int progreso);
        public delegate void DescargaCompleta(string resultado);

        #endregion

        #region Eventos

        public event ProgresoDeCarga _progreso;
        public event DescargaCompleta _descargaFinalizada;

        #endregion

        #region Metodos y Constructor
        public Descargador(Uri direccion)
        {
            this._direccion = direccion;
            this._html = "";
        }

        public void IniciarDescarga()
        {
            try
            {
                WebClient cliente = new WebClient();
                cliente.DownloadProgressChanged += WebClientDownloadProgressChanged;
                cliente.DownloadStringCompleted += WebClientDownloadCompleted;

                cliente.DownloadStringAsync(this._direccion);
            }
            catch (Exception e)
            {
                Console.Write("Error: " + e.Message);
            }
        }

        private void WebClientDownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            this._progreso(e.ProgressPercentage);
        }
        private void WebClientDownloadCompleted(object sender, DownloadStringCompletedEventArgs e)
        {
            try
            {
                this._html = e.Result;
                this._descargaFinalizada(this._html);
            }
            catch (Exception er)
            {
                Console.WriteLine("ERROR: No se puede acceder a la URL solicitada: " + er.Message);
            }
        }
        #endregion

    }
}
