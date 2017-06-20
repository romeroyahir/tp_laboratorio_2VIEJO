using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Navegador
{
    public partial class frmHistorial : Form
    {
        #region Atributos
        public List<string> _historial;
        public const string ARCHIVO_HISTORIAL = "historico.dat";
        #endregion

        #region Constructor
        public frmHistorial()
        {
            InitializeComponent();
        }
        #endregion

        /// <summary>
        /// Load de formulario
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmHistorial_Load(object sender, EventArgs e)
        {
            Archivos.Texto archivos = new Archivos.Texto(frmHistorial.ARCHIVO_HISTORIAL);

            this._historial = new List<string>();

            archivos.Leer(out _historial);

            lstHistorial.DataSource = this._historial;

        }
    }
}
