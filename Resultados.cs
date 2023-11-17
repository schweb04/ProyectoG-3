using Microsoft.VisualBasic.FileIO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;


namespace SistemaEvaluacion
{
    public partial class Resultados : Form
    {
        private List<Pregunta> preguntas;
        private int indiceActual = 0;
        private int preguntasCorrectas = 0;
        private int preguntasIncorrectas = 0;

        public Resultados()
        {
            InitializeComponent();
            preguntas = new List<Pregunta>();
            CargarDatosCasillas();
        }

        private void MostrarPreguntaYRespuestas(int preguntaActualIndex)
        {
            // Ruta del archivo CSV
            string rutaArchivo = "resultados.csv";

            // Verifica si el archivo CSV existe
            if (File.Exists(rutaArchivo))
            {
                // Utiliza LINQ para leer el archivo CSV y obtener la pregunta deseada
                var preguntaActual = File.ReadLines(rutaArchivo, Encoding.UTF8)
                    .Skip(1) // Salta la primera línea (encabezado)
                    .ElementAtOrDefault(preguntaActualIndex - 1) // Obtiene la línea de la pregunta actual
                    ?.Split(',') // Divide la línea en campos
                    .Select((campo, index) => new { Index = index, Campo = campo }) // Crea un objeto anónimo con índices
                    .ToDictionary(item => item.Index, item => item.Campo); // Convierte a un diccionario

                if (preguntaActual != null)
                {
                    // Crea una nueva instancia de Pregunta con los datos obtenidos
                    Pregunta pregunta = new Pregunta
                    {
                        PreguntaTexto = preguntaActual.TryGetValue(0, out var preguntaTexto) ? preguntaTexto : "",
                        RespuestaCorrecta = preguntaActual.TryGetValue(1, out var respuestaCorrecta) ? respuestaCorrecta : "",
                        RespuestaSeleccionada = preguntaActual.TryGetValue(2, out var respuestaSeleccionada) ? respuestaSeleccionada : "",
                        RespuestasBarajeadas = preguntaActual.Skip(3).Select(pair => pair.Value).ToList()
                    };

                    // Asigna los valores a las labels
                    lblPregunta.Text = $"{preguntaActualIndex}. {pregunta.PreguntaTexto}";
                    lblRespuestaA.Text = pregunta.RespuestasBarajeadas[0];
                    lblRespuestaB.Text = pregunta.RespuestasBarajeadas[1];
                    lblRespuestaC.Text = pregunta.RespuestasBarajeadas[2];
                    lblRespuestaD.Text = pregunta.RespuestasBarajeadas[3];

                    // Compara la respuesta seleccionada con la respuesta correcta y cambia el color de las labels
                    bool esRespuestaCorrecta = pregunta.RespuestaSeleccionada == pregunta.RespuestaCorrecta;
                    CambiarColorRespuesta(lblRespuestaA, pregunta.RespuestasBarajeadas[0] == pregunta.RespuestaCorrecta);
                    CambiarColorRespuesta(lblRespuestaB, pregunta.RespuestasBarajeadas[1] == pregunta.RespuestaCorrecta);
                    CambiarColorRespuesta(lblRespuestaC, pregunta.RespuestasBarajeadas[2] == pregunta.RespuestaCorrecta);
                    CambiarColorRespuesta(lblRespuestaD, pregunta.RespuestasBarajeadas[3] == pregunta.RespuestaCorrecta);

                    // Marca la respuesta seleccionada visualmente
                    MarcarRespuestaSeleccionada(pregunta.RespuestaSeleccionada);
                }
            }
            else
            {
                MessageBox.Show("El archivo CSV no existe.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void MarcarRespuestaSeleccionada(string respuesta)
        {
            // Primero, reinicia la apariencia de todas las respuestas
            ReiniciarAparienciaRespuestas();

            // Luego, marca la respuesta seleccionada
            switch (respuesta)
            {
                case "A":
                    pboxRespuestaA.Image = global::SistemaEvaluacion.Properties.Resources.Preguntas_Respuestas_Seleccionada__2_;
                    break;
                case "B":
                    pboxRespuestaB.Image = global::SistemaEvaluacion.Properties.Resources.Preguntas_Respuestas_Seleccionada__2_;
                    break;
                case "C":
                    pboxRespuestaC.Image = global::SistemaEvaluacion.Properties.Resources.Preguntas_Respuestas_Seleccionada__2_;
                    break;
                case "D":
                    pboxRespuestaD.Image = global::SistemaEvaluacion.Properties.Resources.Preguntas_Respuestas_Seleccionada__2_;
                    break;
            }
        }

        private void ReiniciarAparienciaRespuestas()
        {
            pboxRespuestaA.Image = global::SistemaEvaluacion.Properties.Resources.Preguntas_Respuestas_Vacio__2_;
            pboxRespuestaB.Image = global::SistemaEvaluacion.Properties.Resources.Preguntas_Respuestas_Vacio__2_;
            pboxRespuestaC.Image = global::SistemaEvaluacion.Properties.Resources.Preguntas_Respuestas_Vacio__2_;
            pboxRespuestaD.Image = global::SistemaEvaluacion.Properties.Resources.Preguntas_Respuestas_Vacio__2_;
        }

        private void CambiarColorRespuesta(Label label, bool esRespuestaCorrecta)
        {
            if (esRespuestaCorrecta)
            {
                label.ForeColor = Color.FromArgb(32, 255, 60); // Respuesta correcta en verde
            }
            else
            {
                label.ForeColor = Color.Red; // Respuestas incorrectas en rojo
            }
        }

        private void CargarDatosCasillas()
        {
            // Ruta del archivo CSV
            string rutaArchivo = "resultados.csv";

            // Verifica si el archivo CSV existe
            if (File.Exists(rutaArchivo))
            {
                // Lee todas las líneas del archivo y crea las preguntas
                var lineas = File.ReadLines(rutaArchivo).Skip(1); // Saltar la primera línea (encabezado)
                preguntas = lineas.Select(linea =>
                {
                    var campos = linea.Split(',');
                    return new Pregunta
                    {
                        PreguntaTexto = campos[0],
                        RespuestaCorrecta = campos[1],
                        RespuestaSeleccionada = campos[2], // Ajusta según tu estructura real
                        RespuestasBarajeadas = new List<string> { campos[3], campos[4], campos[5], campos[6] }
                    };
                }).ToList();

                // Cargar datos en las casillas y evaluar respuestas
                for (int i = 1; i <= preguntas.Count; i++)
                {
                    CargarDatosCasilla(i);
                }
            }
            else
            {
                MessageBox.Show("El archivo CSV no existe.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CargarDatosCasilla(int numeroCasilla)
        {
            // Verifica si el número de casilla está en un rango válido (1-30)
            if (numeroCasilla >= 1 && numeroCasilla <= preguntas.Count)
            {
                Pregunta preguntaActual = preguntas[numeroCasilla - 1];
                AsignarValoresCasilla(numeroCasilla, preguntaActual);
            }
            else
            {
                MessageBox.Show("Número de casilla no válido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void AsignarValoresCasilla(int numeroCasilla, Pregunta pregunta)
        {
            // Busca el PictureBox correspondiente a la casilla
            PictureBox pboxCasilla = Controls.Find($"pboxCasilla{numeroCasilla}", true).FirstOrDefault() as PictureBox;

            // Busca las labels correspondientes a la casilla
            Label lblPreguntaCasilla = Controls.Find($"lblPregunta", true).FirstOrDefault() as Label;
            Label lblRespuestaCorrectaCasilla = Controls.Find($"lblRespuestaCorrecta", true).FirstOrDefault() as Label;
            Label lblRespuestaSeleccionadaCasilla = Controls.Find($"lblRespuestaSeleccionada", true).FirstOrDefault() as Label;

            // Asigna los valores a las labels de la casilla
            if (pboxCasilla != null && lblPreguntaCasilla != null && lblRespuestaCorrectaCasilla != null && lblRespuestaSeleccionadaCasilla != null)
            {
                // Configura los datos de la pregunta en la casilla actual
                pboxCasilla.Tag = pregunta; // Guarda la pregunta como Tag para futuras referencias
                lblPreguntaCasilla.Text = $"{numeroCasilla}. {pregunta.PreguntaTexto}";
                lblRespuestaCorrectaCasilla.Text = $"Respuesta Correcta: {pregunta.RespuestaCorrecta}";
                lblRespuestaSeleccionadaCasilla.Text = $"Respuesta Seleccionada: {pregunta.RespuestaSeleccionada}";
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
            CargarDatosCasillas();
            pnlPreguntas110.Visible = true;
            pnlPreguntas1120.Visible = false;
            pnlPreguntas2130.Visible = false;
        }



        private void pboxCasilla2_Click_1(object sender, EventArgs e)
        {
            indiceActual = 2;
            MostrarPreguntaYRespuestas(2);
        }

        private void pboxCasilla3_Click_1(object sender, EventArgs e)
        {
            indiceActual = 3;
            MostrarPreguntaYRespuestas(3);
        }

        private void pboxCasilla4_Click(object sender, EventArgs e)
        {
            indiceActual = 4;
            MostrarPreguntaYRespuestas(4);
        }

        private void pboxCasilla5_Click(object sender, EventArgs e)
        {
            indiceActual = 5;
            MostrarPreguntaYRespuestas(5);
        }

        private void pboxCasilla6_Click(object sender, EventArgs e)
        {
            indiceActual = 6;
            MostrarPreguntaYRespuestas(6);
        }

        private void pboxCasilla7_Click(object sender, EventArgs e)
        {
            indiceActual = 7;
            MostrarPreguntaYRespuestas(7);
        }

        private void pboxCasilla8_Click(object sender, EventArgs e)
        {
            indiceActual = 8;
            MostrarPreguntaYRespuestas(8);
        }

        private void pboxCasilla9_Click(object sender, EventArgs e)
        {
            indiceActual = 9;
            MostrarPreguntaYRespuestas(9);
        }

        private void pboxCasilla10_Click_1(object sender, EventArgs e)
        {
            indiceActual = 10;
            MostrarPreguntaYRespuestas(10);
        }

        private void pboxCasilla11_Click_1(object sender, EventArgs e)
        {
            indiceActual = 11;
            MostrarPreguntaYRespuestas(11);
        }

        private void pboxCasilla12_Click_1(object sender, EventArgs e)
        {
            indiceActual = 12;
            MostrarPreguntaYRespuestas(12);
        }

        private void pboxCasilla13_Click_1(object sender, EventArgs e)
        {
            indiceActual = 13;
            MostrarPreguntaYRespuestas(13);
        }

        private void pboxCasilla14_Click_1(object sender, EventArgs e)
        {
            indiceActual = 14;
            MostrarPreguntaYRespuestas(14);
        }

        private void pboxCasilla15_Click_1(object sender, EventArgs e)
        {
            indiceActual = 15;
            MostrarPreguntaYRespuestas(15);
        }

        private void pboxCasilla16_Click_1(object sender, EventArgs e)
        {
            indiceActual = 16;
            MostrarPreguntaYRespuestas(16);
        }

        private void pboxCasilla17_Click_1(object sender, EventArgs e)
        {
            indiceActual = 17;
            MostrarPreguntaYRespuestas(17);
        }

        private void pboxCasilla18_Click_1(object sender, EventArgs e)
        {
            indiceActual = 18;
            MostrarPreguntaYRespuestas(18);
        }

        private void pboxCasilla19_Click_1(object sender, EventArgs e)
        {
            indiceActual = 19;
            MostrarPreguntaYRespuestas(19);
        }

        private void pboxCasilla20_Click_1(object sender, EventArgs e)
        {
            indiceActual = 20;
            MostrarPreguntaYRespuestas(20);
        }

        private void pboxCasilla21_Click_1(object sender, EventArgs e)
        {
            indiceActual = 21;
            MostrarPreguntaYRespuestas(21);
        }

        private void pboxCasilla22_Click_1(object sender, EventArgs e)
        {
            indiceActual = 22;
            MostrarPreguntaYRespuestas(22);
        }

        private void pboxCasilla23_Click_1(object sender, EventArgs e)
        {
            indiceActual = 23;
            MostrarPreguntaYRespuestas(23);
        }

        private void pboxCasilla24_Click_1(object sender, EventArgs e)
        {
            indiceActual = 24;
            MostrarPreguntaYRespuestas(24);
        }

        private void pboxCasilla25_Click_1(object sender, EventArgs e)
        {
            indiceActual = 25;
            MostrarPreguntaYRespuestas(25);
        }

        private void pboxCasilla26_Click_1(object sender, EventArgs e)
        {
            indiceActual = 26;
            MostrarPreguntaYRespuestas(26);
        }

        private void pboxCasilla27_Click_1(object sender, EventArgs e)
        {
            indiceActual = 27;
            MostrarPreguntaYRespuestas(27);
        }

        private void pboxCasilla28_Click_1(object sender, EventArgs e)
        {
            indiceActual = 28;
            MostrarPreguntaYRespuestas(28);
        }

        private void pboxCasilla29_Click_1(object sender, EventArgs e)
        {
            indiceActual = 29;
            MostrarPreguntaYRespuestas(29);
        }

        private void pboxCasilla30_Click_1(object sender, EventArgs e)
        {
            indiceActual = 30;
            MostrarPreguntaYRespuestas(30);
        }

        private void pboxRepetir_Click(object sender, EventArgs e)
        {

        }

        private void pboxFinalizar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void ActualizarIndiceCasilla(int nuevoIndice)
        {
            indiceActual = nuevoIndice;
            MostrarPreguntaYRespuestas(indiceActual);
        }
        private void pboxSiguientePregunta_Click(object sender, EventArgs e)
        {
            if (indiceActual < preguntas.Count - 1)
            {
                ActualizarIndiceCasilla(indiceActual + 1);
            }
            else
            {
                // Si es la última casilla, vuelve a la primera
                ActualizarIndiceCasilla(0);
            }

            ActualizarPanelPreguntas();
        }

        private void pboxPreguntaAnterior_Click(object sender, EventArgs e)
        {
            if (indiceActual > 0)
            {
                ActualizarIndiceCasilla(indiceActual - 1);
            }
            else
            {
                // Si es la primera casilla, vuelve a la última
                ActualizarIndiceCasilla(preguntas.Count - 1);
            }

            ActualizarPanelPreguntas();
        }

        private void ActualizarPanelPreguntas()
        {
            // Verifica el rango de casillas y muestra el panel correspondiente
            if (indiceActual >= 0 && indiceActual < 10)
            {
                MostrarPanel(pnlPreguntas110);
            }
            else if (indiceActual >= 10 && indiceActual < 20)
            {
                MostrarPanel(pnlPreguntas1120);
            }
            else if (indiceActual >= 20 && indiceActual < 30)
            {
                MostrarPanel(pnlPreguntas2130);
            }
        }

        private void MostrarPanel(Panel panelAMostrar)
        {
            // Oculta todos los paneles primero
            pnlPreguntas110.Visible = false;
            pnlPreguntas1120.Visible = false;
            pnlPreguntas2130.Visible = false;

            // Muestra el panel especificado
            panelAMostrar.Visible = true;
        }

        private void pboxResultados_Click(object sender, EventArgs e)
        {

        }

        private void pboxPregunta_Click(object sender, EventArgs e)
        {

        }

        private void pboxCasilla1_Click(object sender, EventArgs e)
        {
            MostrarPreguntaYRespuestas(1);
        }


        private void lblRespuestaA_Click(object sender, EventArgs e)
        {

        }

        private void lblRespuestaC_Click(object sender, EventArgs e)
        {

        }

        private void lblRespuestaB_Click(object sender, EventArgs e)
        {

        }

        private void lblRespuestaD_Click(object sender, EventArgs e)
        {

        }

        private void pboxMensajeResultado_Click(object sender, EventArgs e)
        {

        }

        private void pboxAciertos_Click(object sender, EventArgs e)
        {

        }

        private void lblCorrectas_Click(object sender, EventArgs e)
        {

        }

        private void lblIncorrectas_Click(object sender, EventArgs e)
        {

        }

        private void lblPregunta_Click(object sender, EventArgs e)
        {

        }

        private void pboxResultadosFondo_Click(object sender, EventArgs e)
        {

        }

        private void pboxRespuestaA_Click(object sender, EventArgs e)
        {

        }

        private void pboxRespuestaC_Click(object sender, EventArgs e)
        {

        }

        private void pboxErrores_Click(object sender, EventArgs e)
        {

        }
    }
}
