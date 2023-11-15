using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SistemaEvaluacion
{
    public partial class Bienvenida : Form
    {
        public Bienvenida()
        {
            InitializeComponent();
        }

        private void pboxIniciarExamen_Click(object sender, EventArgs e)
        {
            Evaluacion examen = new Evaluacion();
            examen.ShowDialog();
        }

        private void pboxInstrucciones_Click(object sender, EventArgs e)
        {
            Instrucciones instrucciones = new Instrucciones();
            instrucciones.ShowDialog();
        }
    }
}
