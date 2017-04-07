namespace Calculadora
{
    partial class Form1
    {
        /// <summary>
        /// Variable del diseñador requerida.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén utilizando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben eliminar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido del método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblResultado = new System.Windows.Forms.Label();
            this.txtNumero1 = new System.Windows.Forms.TextBox();
            this.cmbOperacion = new System.Windows.Forms.ComboBox();
            this.txtNumero2 = new System.Windows.Forms.TextBox();
            this.btnLimpiar = new System.Windows.Forms.Button();
            this.btnOperar = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblResultado
            // 
            this.lblResultado.AutoSize = true;
            this.lblResultado.BackColor = System.Drawing.SystemColors.ControlDark;
            this.lblResultado.Font = new System.Drawing.Font("EYInterstate", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblResultado.Location = new System.Drawing.Point(3, 23);
            this.lblResultado.Name = "lblResultado";
            this.lblResultado.Size = new System.Drawing.Size(0, 36);
            this.lblResultado.TabIndex = 0;
            // 
            // txtNumero1
            // 
            this.txtNumero1.BackColor = System.Drawing.SystemColors.Menu;
            this.txtNumero1.Font = new System.Drawing.Font("EYInterstate Light", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNumero1.Location = new System.Drawing.Point(12, 103);
            this.txtNumero1.Name = "txtNumero1";
            this.txtNumero1.Size = new System.Drawing.Size(100, 35);
            this.txtNumero1.TabIndex = 1;
            // 
            // cmbOperacion
            // 
            this.cmbOperacion.Font = new System.Drawing.Font("EYInterstate Light", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbOperacion.FormattingEnabled = true;
            this.cmbOperacion.Items.AddRange(new object[] {
            "+ (Suma)",
            "- (Resta)",
            "* (Multiplicación)",
            "/ (División)"});
            this.cmbOperacion.Location = new System.Drawing.Point(146, 103);
            this.cmbOperacion.Name = "cmbOperacion";
            this.cmbOperacion.Size = new System.Drawing.Size(177, 34);
            this.cmbOperacion.TabIndex = 2;
            this.cmbOperacion.Text = "Operación";
            // 
            // txtNumero2
            // 
            this.txtNumero2.BackColor = System.Drawing.SystemColors.Menu;
            this.txtNumero2.Font = new System.Drawing.Font("EYInterstate Light", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNumero2.Location = new System.Drawing.Point(359, 103);
            this.txtNumero2.Name = "txtNumero2";
            this.txtNumero2.Size = new System.Drawing.Size(100, 35);
            this.txtNumero2.TabIndex = 3;
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnLimpiar.Font = new System.Drawing.Font("EY Gothic Cond Demi", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLimpiar.Location = new System.Drawing.Point(94, 178);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(90, 41);
            this.btnLimpiar.TabIndex = 4;
            this.btnLimpiar.Text = "CC";
            this.btnLimpiar.UseVisualStyleBackColor = true;
            this.btnLimpiar.Click += new System.EventHandler(this.btnLimpiar_Click);
            // 
            // btnOperar
            // 
            this.btnOperar.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOperar.Location = new System.Drawing.Point(291, 178);
            this.btnOperar.Name = "btnOperar";
            this.btnOperar.Size = new System.Drawing.Size(90, 41);
            this.btnOperar.TabIndex = 5;
            this.btnOperar.Text = "=";
            this.btnOperar.UseVisualStyleBackColor = true;
            this.btnOperar.Click += new System.EventHandler(this.btnOperar_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ControlDark;
            this.panel1.Controls.Add(this.lblResultado);
            this.panel1.Location = new System.Drawing.Point(37, 5);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(404, 78);
            this.panel1.TabIndex = 6;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.ClientSize = new System.Drawing.Size(477, 233);
            this.Controls.Add(this.btnOperar);
            this.Controls.Add(this.btnLimpiar);
            this.Controls.Add(this.txtNumero2);
            this.Controls.Add(this.cmbOperacion);
            this.Controls.Add(this.txtNumero1);
            this.Controls.Add(this.panel1);
            this.Name = "Form1";
            this.Text = "Calculator";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblResultado;
        private System.Windows.Forms.TextBox txtNumero1;
        private System.Windows.Forms.ComboBox cmbOperacion;
        private System.Windows.Forms.TextBox txtNumero2;
        private System.Windows.Forms.Button btnLimpiar;
        private System.Windows.Forms.Button btnOperar;
        private System.Windows.Forms.Panel panel1;
    }
}

