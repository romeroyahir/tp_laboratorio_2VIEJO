using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Threading;
using Hilo;

namespace Navegador
{
    public partial class frmWebBrowser : Form
    {

        #region Atributos
        private const string ESCRIBA_AQUI = "Escriba aquí...";
        Archivos.Texto archivos;
        #endregion

        #region Metodos y Constructor

        public frmWebBrowser()
        {
            InitializeComponent();
        }

        private void frmWebBrowser_Load(object sender, EventArgs e)
        {
            this.txtUrl.SelectionStart = 0;  //This keeps the text
            this.txtUrl.SelectionLength = 0; //from being highlighted
            this.txtUrl.ForeColor = Color.Gray;
            this.txtUrl.Text = frmWebBrowser.ESCRIBA_AQUI;

            archivos = new Archivos.Texto(frmHistorial.ARCHIVO_HISTORIAL);
        }

        #region "Escriba aquí..."
        private void txtUrl_MouseMove(object sender, MouseEventArgs e)
        {
            Cursor.Current = Cursors.IBeam; //Without this the mouse pointer shows busy
        }

        private void txtUrl_KeyDown(object sender, KeyEventArgs e)
        {
            if (this.txtUrl.Text.Equals(frmWebBrowser.ESCRIBA_AQUI) == true)
            {
                this.txtUrl.Text = "";
                this.txtUrl.ForeColor = Color.Black;
            }
        }

        private void txtUrl_KeyUp(object sender, KeyEventArgs e)
        {
            if (this.txtUrl.Text.Equals(null) == true || this.txtUrl.Text.Equals("") == true)
            {
                this.txtUrl.Text = frmWebBrowser.ESCRIBA_AQUI;
                this.txtUrl.ForeColor = Color.Gray;
            }
        }

        private void txtUrl_MouseDown(object sender, MouseEventArgs e)
        {
            this.txtUrl.SelectAll();
        }
        #endregion

        delegate void ProgresoDescargaCallback(int progreso);

        private void ProgresoDescarga(int progreso)
        {
            if (statusStrip.InvokeRequired)
            {
                ProgresoDescargaCallback d = new ProgresoDescargaCallback(ProgresoDescarga);
                this.Invoke(d, new object[] { progreso });
            }
            else
            {
                tspbProgreso.Value = progreso;
            }
        }

        delegate void FinDescargaCallback(string html);

        private void FinDescarga(string html)
        {
            if (rtxtHtmlCode.InvokeRequired)
            {
                FinDescargaCallback d = new FinDescargaCallback(FinDescarga);
                this.Invoke(d, new object[] { html });
            }
            else
            {
                rtxtHtmlCode.Text = html;
            }
        }

        #endregion

        #region Eventos
        /// <summary>
        /// Evento de click sobre botón IR
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnIr_Click(object sender, EventArgs e)    
        {
            string _url = this.txtUrl.Text.ToString(); 
            List<string> _historial;

            try
            {

                Uri link;
                if (Uri.TryCreate(this.txtUrl.Text, UriKind.Absolute, out link) == false)
                {
                    txtUrl.Text = "http://" + txtUrl.Text;
                    link = new Uri(txtUrl.Text);
                }
                
                Descargador downloader = new Descargador(link);

                downloader._progreso += this.ProgresoDescarga;
                downloader._descargaFinalizada += this.FinDescarga;

                Thread hilo = new Thread(downloader.IniciarDescarga);
                hilo.Start();

                try
                {
                    this.archivos.Leer(out _historial);
                    this.archivos.Guardar(this.txtUrl.Text);
                }
                catch (Exception)
                {

                    throw;
                }
            }
            catch (Exception er)
            {
                this.rtxtHtmlCode.Text = er.Message;
            }
        }

        #endregion

        /// <summary>
        /// Evento de click sobre Mostrar todo el Historial Tooltip
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void mostrarTodoElHistorialToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmHistorial formHistorial = new frmHistorial();
            formHistorial.ShowDialog();
        }
    }
}
