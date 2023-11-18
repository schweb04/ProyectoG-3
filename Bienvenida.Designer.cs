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
            this.pboxIniciarExamen = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pboxFondo = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pboxInstrucciones)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pboxIniciarExamen)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pboxFondo)).BeginInit();
            this.SuspendLayout();
            // 
            // lblBienvenida
            // 
            this.lblBienvenida.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(22)))), ((int)(((byte)(41)))));
            this.lblBienvenida.Font = new System.Drawing.Font("Century", 15.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBienvenida.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(255)))), ((int)(((byte)(239)))));
            this.lblBienvenida.Location = new System.Drawing.Point(241, 127);
            this.lblBienvenida.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblBienvenida.Name = "lblBienvenida";
            this.lblBienvenida.Size = new System.Drawing.Size(213, 78);
            this.lblBienvenida.TabIndex = 43;
            this.lblBienvenida.Text = "Bienvenido al Examen!";
            this.lblBienvenida.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pboxInstrucciones
            // 
            this.pboxInstrucciones.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(22)))), ((int)(((byte)(41)))));
            this.pboxInstrucciones.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pboxInstrucciones.Image = global::SistemaEvaluacion.Properties.Resources.Bienvenida_Boton_Instrucciones;
            this.pboxInstrucciones.Location = new System.Drawing.Point(257, 279);
            this.pboxInstrucciones.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pboxInstrucciones.Name = "pboxInstrucciones";
            this.pboxInstrucciones.Size = new System.Drawing.Size(187, 63);
            this.pboxInstrucciones.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pboxInstrucciones.TabIndex = 44;
            this.pboxInstrucciones.TabStop = false;
            this.pboxInstrucciones.Click += new System.EventHandler(this.pboxInstrucciones_Click);
            // 
            // pboxIniciarExamen
            // 
            this.pboxIniciarExamen.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(22)))), ((int)(((byte)(41)))));
            this.pboxIniciarExamen.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pboxIniciarExamen.Image = global::SistemaEvaluacion.Properties.Resources.Bienvenida_Boton_Iniciar;
            this.pboxIniciarExamen.Location = new System.Drawing.Point(257, 388);
            this.pboxIniciarExamen.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pboxIniciarExamen.Name = "pboxIniciarExamen";
            this.pboxIniciarExamen.Size = new System.Drawing.Size(187, 60);
            this.pboxIniciarExamen.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pboxIniciarExamen.TabIndex = 41;
            this.pboxIniciarExamen.TabStop = false;
            this.pboxIniciarExamen.Click += new System.EventHandler(this.pboxIniciarExamen_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(22)))), ((int)(((byte)(41)))));
            this.pictureBox1.Image = global::SistemaEvaluacion.Properties.Resources.Bienvenida_Titulo__2_;
            this.pictureBox1.Location = new System.Drawing.Point(221, 108);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(257, 114);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            // 
            // pboxFondo
            // 
            this.pboxFondo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(12)))), ((int)(((byte)(6)))), ((int)(((byte)(26)))));
            this.pboxFondo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pboxFondo.Image = global::SistemaEvaluacion.Properties.Resources.Bienvenida_Ultimo_Fondo;
            this.pboxFondo.Location = new System.Drawing.Point(0, 0);
            this.pboxFondo.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pboxFondo.Name = "pboxFondo";
            this.pboxFondo.Size = new System.Drawing.Size(669, 539);
            this.pboxFondo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pboxFondo.TabIndex = 57;
            this.pboxFondo.TabStop = false;
            // 
            // Bienvenida
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(669, 539);
            this.Controls.Add(this.pboxInstrucciones);
            this.Controls.Add(this.lblBienvenida);
            this.Controls.Add(this.pboxIniciarExamen);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.pboxFondo);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "Bienvenida";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Bienvenida";
            ((System.ComponentModel.ISupportInitialize)(this.pboxInstrucciones)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pboxIniciarExamen)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pboxFondo)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pboxIniciarExamen;
        private System.Windows.Forms.Label lblBienvenida;
        private System.Windows.Forms.PictureBox pboxInstrucciones;
        private System.Windows.Forms.PictureBox pboxFondo;
    }
}

