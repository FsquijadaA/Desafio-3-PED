namespace Ruta_de_grafos
{
    partial class Form1
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
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
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.labelInicio = new System.Windows.Forms.Label();
            this.textBoxInicio = new System.Windows.Forms.TextBox();
            this.buttonAnchura = new System.Windows.Forms.Button();
            this.buttonProfundidad = new System.Windows.Forms.Button();
            this.textBoxResultado = new System.Windows.Forms.TextBox();
            this.panelGrafo = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // labelInicio
            // 
            this.labelInicio.AutoSize = true;
            this.labelInicio.Location = new System.Drawing.Point(12, 9);
            this.labelInicio.Name = "labelInicio";
            this.labelInicio.Size = new System.Drawing.Size(86, 16);
            this.labelInicio.TabIndex = 0;
            this.labelInicio.Text = "Vértice Inicial";
            // 
            // textBoxInicio
            // 
            this.textBoxInicio.Location = new System.Drawing.Point(12, 39);
            this.textBoxInicio.Name = "textBoxInicio";
            this.textBoxInicio.Size = new System.Drawing.Size(100, 22);
            this.textBoxInicio.TabIndex = 1;
            // 
            // buttonAnchura
            // 
            this.buttonAnchura.Location = new System.Drawing.Point(12, 81);
            this.buttonAnchura.Name = "buttonAnchura";
            this.buttonAnchura.Size = new System.Drawing.Size(208, 23);
            this.buttonAnchura.TabIndex = 2;
            this.buttonAnchura.Text = "Recorrer en anchura";
            this.buttonAnchura.UseVisualStyleBackColor = true;
            this.buttonAnchura.Click += new System.EventHandler(this.buttonAnchura_Click);
            // 
            // buttonProfundidad
            // 
            this.buttonProfundidad.Location = new System.Drawing.Point(12, 121);
            this.buttonProfundidad.Name = "buttonProfundidad";
            this.buttonProfundidad.Size = new System.Drawing.Size(208, 23);
            this.buttonProfundidad.TabIndex = 3;
            this.buttonProfundidad.Text = "Recorrer en  profundidad";
            this.buttonProfundidad.UseVisualStyleBackColor = true;
            this.buttonProfundidad.Click += new System.EventHandler(this.buttonProfundidad_Click);
            // 
            // textBoxResultado
            // 
            this.textBoxResultado.Location = new System.Drawing.Point(565, 39);
            this.textBoxResultado.Multiline = true;
            this.textBoxResultado.Name = "textBoxResultado";
            this.textBoxResultado.ReadOnly = true;
            this.textBoxResultado.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBoxResultado.Size = new System.Drawing.Size(163, 49);
            this.textBoxResultado.TabIndex = 4;
            // 
            // panelGrafo
            // 
            this.panelGrafo.BackColor = System.Drawing.Color.White;
            this.panelGrafo.Location = new System.Drawing.Point(12, 162);
            this.panelGrafo.Name = "panelGrafo";
            this.panelGrafo.Size = new System.Drawing.Size(776, 276);
            this.panelGrafo.TabIndex = 5;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.panelGrafo);
            this.Controls.Add(this.textBoxResultado);
            this.Controls.Add(this.buttonProfundidad);
            this.Controls.Add(this.buttonAnchura);
            this.Controls.Add(this.textBoxInicio);
            this.Controls.Add(this.labelInicio);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelInicio;
        private System.Windows.Forms.TextBox textBoxInicio;
        private System.Windows.Forms.Button buttonAnchura;
        private System.Windows.Forms.Button buttonProfundidad;
        private System.Windows.Forms.TextBox textBoxResultado;
        private System.Windows.Forms.Panel panelGrafo;
    }
}

