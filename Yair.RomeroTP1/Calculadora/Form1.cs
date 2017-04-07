using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Calculadora;

namespace Calculadora
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
       
        private void btnOperar_Click(object sender, EventArgs e)
        {
            //Limpio el label de resultado
            lblResultado.Text = "";

            //Operar
            double txt1;
            double txt2;
            if (double.TryParse(txtNumero1.Text, out txt1) == true && double.TryParse(txtNumero2.Text, out txt2) == true)
            {
                Numero num1 = new Numero(txt1);
                Numero num2 = new Numero(txt2);
                
                int indexcmb = cmbOperacion.SelectedIndex;
                Calculadora calc = new Calculadora();
                string comb = calc.ValidarOperador(indexcmb.ToString());

                double bla;
                bla = calc.Operar(num1, num2, comb);
                lblResultado.Text = (bla.ToString());
            }
            else
            {
                MessageBox.Show("ERROR! Ingresaste valor(es) invalido(s), vuelve a ingresarlos.");
                btnLimpiar.PerformClick();
            }  
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            txtNumero1.Clear();
            txtNumero2.Clear();
            lblResultado.Text = "";
            cmbOperacion.Text = "Operación";
        }
        
        
    }
}
