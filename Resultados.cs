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

         private void MostrarPreguntaYRespuestas(int preguntaActualIndex)
        {
            // Ruta del archivo CSV
            string rutaArchivo = "resultados.csv";

            // Verifica si el archivo CSV existe
            if (File.Exists(rutaArchivo))
            {
                // Utiliza TextFieldParser para leer el archivo CSV
                using (TextFieldParser parser = new TextFieldParser(rutaArchivo))
                {
                    parser.TextFieldType = FieldType.Delimited;
                    parser.SetDelimiters(",");

                    // Salta la primera línea (encabezado)
                    parser.ReadLine();

                    // Salta las líneas hasta llegar a la pregunta deseada
                    for (int i = 0; i < preguntaActualIndex; i++)
                    {
                        parser.ReadLine();
                    }

                    // Lee la línea actual como un array de campos
                    string[] campos = parser.ReadFields();

                    // Crea una nueva instancia de Pregunta con los campos obtenidos
                    Pregunta preguntaActual = new Pregunta
                    {
                        PreguntaTexto = campos[0],
                        RespuestaCorrecta = campos[1],
                        RespuestaSeleccionada = campos[2], // Ajusta según tu estructura real
                        RespuestasBarajeadas = new List<string> { campos[3], campos[4], campos[5], campos[6] }
                    };

                    // Asigna los valores a las labels
                    lblPregunta.Text = $"{preguntaActualIndex+1}. {preguntaActual.PreguntaTexto}";
                    lblRespuestaA.Text = preguntaActual.RespuestasBarajeadas[0];
                    lblRespuestaB.Text = preguntaActual.RespuestasBarajeadas[1];
                    lblRespuestaC.Text = preguntaActual.RespuestasBarajeadas[2];
                    lblRespuestaD.Text = preguntaActual.RespuestasBarajeadas[3];
                }
            }
            else
            {
                MessageBox.Show("El archivo CSV no existe.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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

                private void pboxCasilla1_Click_1(object sender, EventArgs e)
        {
            MostrarPreguntaYRespuestas(0);
        }

        private void pboxCasilla2_Click(object sender, EventArgs e)
        {
            MostrarPreguntaYRespuestas(1);
        }

        private void pboxCasilla3_Click(object sender, EventArgs e)
        {
            MostrarPreguntaYRespuestas(2);
        }

        private void pboxCasilla4_Click(object sender, EventArgs e)
        {
            MostrarPreguntaYRespuestas(3);
        }

        private void pboxCasilla5_Click(object sender, EventArgs e)
        {
            MostrarPreguntaYRespuestas(4);
        }

        private void pboxCasilla6_Click(object sender, EventArgs e)
        {
            MostrarPreguntaYRespuestas(5);
        }

        private void pboxCasilla7_Click(object sender, EventArgs e)
        {
            MostrarPreguntaYRespuestas(6);
        }

        private void pboxCasilla8_Click(object sender, EventArgs e)
        {
            MostrarPreguntaYRespuestas(7);
        }

        private void pboxCasilla9_Click(object sender, EventArgs e)
        {
            MostrarPreguntaYRespuestas(8);
        }

        private void pboxCasilla10_Click(object sender, EventArgs e)
        {
            MostrarPreguntaYRespuestas(9);
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

        private void pboxPreguntaAnterior_Click(object sender, EventArgs e)
        {

        }

        private void pboxSiguientePregunta_Click(object sender, EventArgs e)
        {

        }
    }
}
