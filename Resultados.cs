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
    public partial class Resultados : Form
    {
        public Resultados()
        {
            InitializeComponent();
        }

        private void pboxPreguntas110_Click(object sender, EventArgs e)
        {
            pnlPreguntas110.Visible = true;
            pnlPreguntas1120.Visible = false;
            pnlPreguntas2130.Visible = false;
        }

        private void pboxPreguntas1120_Click(object sender, EventArgs e)
        {
            pnlPreguntas1120.Visible = true;
            pnlPreguntas110.Visible = false;
            pnlPreguntas2130.Visible = false;
        }

        private void pboxPreguntas2130_Click(object sender, EventArgs e)
        {
            pnlPreguntas2130.Visible = true;
            pnlPreguntas1120.Visible = false;
            pnlPreguntas110.Visible = false;
        }

        private void Resultados_Load(object sender, EventArgs e)
        {
            pnlPreguntas110.Visible = true;
            pnlPreguntas1120.Visible = false;
            pnlPreguntas2130.Visible = false;
        }

        private void pboxCasilla1_Click(object sender, EventArgs e)
        {

        }

        private void pboxCasilla2_Click(object sender, EventArgs e)
        {

        }

        private void pboxCasilla3_Click(object sender, EventArgs e)
        {

        }

        private void pboxCasilla4_Click(object sender, EventArgs e)
        {

        }

        private void pboxCasilla5_Click(object sender, EventArgs e)
        {

        }

        private void pboxCasilla6_Click(object sender, EventArgs e)
        {

        }

        private void pboxCasilla7_Click(object sender, EventArgs e)
        {

        }

        private void pboxCasilla8_Click(object sender, EventArgs e)
        {

        }

        private void pboxCasilla9_Click(object sender, EventArgs e)
        {

        }

        private void pboxCasilla10_Click(object sender, EventArgs e)
        {

        }

        private void pboxCasilla11_Click(object sender, EventArgs e)
        {

        }

        private void pboxCasilla12_Click(object sender, EventArgs e)
        {

        }

        private void pboxCasilla13_Click(object sender, EventArgs e)
        {

        }

        private void pboxCasilla14_Click(object sender, EventArgs e)
        {

        }

        private void pboxCasilla15_Click(object sender, EventArgs e)
        {

        }

        private void pboxCasilla16_Click(object sender, EventArgs e)
        {

        }

        private void pboxCasilla17_Click(object sender, EventArgs e)
        {

        }

        private void pboxCasilla18_Click(object sender, EventArgs e)
        {

        }

        private void pboxCasilla19_Click(object sender, EventArgs e)
        {

        }

        private void pboxCasilla20_Click(object sender, EventArgs e)
        {

        }

        private void pboxCasilla21_Click(object sender, EventArgs e)
        {

        }

        private void pboxCasilla22_Click(object sender, EventArgs e)
        {

        }

        private void pboxCasilla23_Click(object sender, EventArgs e)
        {

        }

        private void pboxCasilla24_Click(object sender, EventArgs e)
        {

        }

        private void pboxCasilla25_Click(object sender, EventArgs e)
        {

        }

        private void pboxCasilla26_Click(object sender, EventArgs e)
        {

        }

        private void pboxCasilla27_Click(object sender, EventArgs e)
        {

        }

        private void pboxCasilla28_Click(object sender, EventArgs e)
        {

        }

        private void pboxCasilla29_Click(object sender, EventArgs e)
        {

        }

        private void pboxCasilla30_Click(object sender, EventArgs e)
        {

        }

        private void pboxRepetir_Click(object sender, EventArgs e)
        {

        }

        private void pboxFinalizar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
