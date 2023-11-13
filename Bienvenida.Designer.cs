namespace SistemaEvaluacion
{
    partial class Bienvenida
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
            this.lblBienvenida = new System.Windows.Forms.Label();
            this.pboxInstrucciones = new System.Windows.Forms.PictureBox();
            this.pboxSalir = new System.Windows.Forms.PictureBox();
            this.pboxIniciarExamen = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pboxInstrucciones)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pboxSalir)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pboxIniciarExamen)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // lblBienvenida
            // 
            this.lblBienvenida.AutoSize = true;
            this.lblBienvenida.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(22)))), ((int)(((byte)(41)))));
            this.lblBienvenida.Font = new System.Drawing.Font("Century", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBienvenida.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(255)))), ((int)(((byte)(239)))));
            this.lblBienvenida.Location = new System.Drawing.Point(151, 70);
            this.lblBienvenida.Name = "lblBienvenida";
            this.lblBienvenida.Size = new System.Drawing.Size(70, 16);
            this.lblBienvenida.TabIndex = 43;
            this.lblBienvenida.Text = "Bienvenida";
            // 
            // pboxInstrucciones
            // 
            this.pboxInstrucciones.Image = global::SistemaEvaluacion.Properties.Resources.Bienvenida_Boton_Instrucciones;
            this.pboxInstrucciones.Location = new System.Drawing.Point(84, 271);
            this.pboxInstrucciones.Name = "pboxInstrucciones";
            this.pboxInstrucciones.Size = new System.Drawing.Size(203, 62);
            this.pboxInstrucciones.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pboxInstrucciones.TabIndex = 44;
            this.pboxInstrucciones.TabStop = false;
            this.pboxInstrucciones.Click += new System.EventHandler(this.pboxInstrucciones_Click);
            // 
            // pboxSalir
            // 
            this.pboxSalir.Image = global::SistemaEvaluacion.Properties.Resources.Bienvenida_Boton_Salir;
            this.pboxSalir.Location = new System.Drawing.Point(84, 353);
            this.pboxSalir.Name = "pboxSalir";
            this.pboxSalir.Size = new System.Drawing.Size(203, 62);
            this.pboxSalir.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pboxSalir.TabIndex = 42;
            this.pboxSalir.TabStop = false;
            this.pboxSalir.Click += new System.EventHandler(this.pboxSalir_Click);
            // 
            // pboxIniciarExamen
            // 
            this.pboxIniciarExamen.Image = global::SistemaEvaluacion.Properties.Resources.Bienvenida_Boton_Iniciar;
            this.pboxIniciarExamen.Location = new System.Drawing.Point(84, 189);
            this.pboxIniciarExamen.Name = "pboxIniciarExamen";
            this.pboxIniciarExamen.Size = new System.Drawing.Size(203, 62);
            this.pboxIniciarExamen.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pboxIniciarExamen.TabIndex = 41;
            this.pboxIniciarExamen.TabStop = false;
            this.pboxIniciarExamen.Click += new System.EventHandler(this.pboxIniciarExamen_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::SistemaEvaluacion.Properties.Resources.Bienvenida_Titulo__2_;
            this.pictureBox1.Location = new System.Drawing.Point(50, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(274, 155);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            // 
            // Bienvenida
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(383, 438);
            this.Controls.Add(this.pboxInstrucciones);
            this.Controls.Add(this.lblBienvenida);
            this.Controls.Add(this.pboxSalir);
            this.Controls.Add(this.pboxIniciarExamen);
            this.Controls.Add(this.pictureBox1);
            this.Name = "Bienvenida";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Bienvenida";
            ((System.ComponentModel.ISupportInitialize)(this.pboxInstrucciones)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pboxSalir)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pboxIniciarExamen)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pboxIniciarExamen;
        private System.Windows.Forms.PictureBox pboxSalir;
        private System.Windows.Forms.Label lblBienvenida;
        private System.Windows.Forms.PictureBox pboxInstrucciones;
    }
}

