using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using Microsoft.VisualBasic.FileIO;


namespace SistemaEvaluacion
{
    public partial class Evaluacion : Form
    {
        private Timer temporizador;
        private int tiempoRestanteEnSegundos;
        private List<Pregunta> preguntas;
        private List<Pregunta> preguntasMostradas;
        private int preguntaActualIndex;
        private Random random = new Random();
        private bool PreguntasAleatoriasIniciadas = false;

        public Evaluacion()
        {
            InitializeComponent();
            InicializarPreguntas();
            ReiniciarEstadoSeleccion(); // Agrega esta línea para reiniciar el estado de selección
            InicializarPreguntasAleatorias();
            InicializarCasillas();
            // Configurar el temporizador
            tiempoRestanteEnSegundos = 30 * 60; // 30 minutos en segundos
            ConfigurarTemporizador();
        }
        private void ConfigurarTemporizador()
        {
            temporizador = new Timer();
            temporizador.Interval = 1000; // Establecer la frecuencia en 1 segundo (1000 ms)
            temporizador.Tick += Temporizador_Tick;
            temporizador.Start();
        }
        private void Temporizador_Tick(object sender, EventArgs e)
        {
            tiempoRestanteEnSegundos--;

            if (tiempoRestanteEnSegundos >= 0)
            {
                int minutos = tiempoRestanteEnSegundos / 60;
                int segundos = tiempoRestanteEnSegundos % 60;

                // Formatear y mostrar el tiempo en el Label
                lblTiempo.Text = $"{minutos} min, {segundos} seg";
            }
            else
            {
                // El tiempo ha llegado a cero
                temporizador.Stop();
                lblTiempo.Text = "Tiempo agotado";
            }
        }
        private void InicializarPreguntasAleatorias()
        {
            if (preguntasMostradas == null)
            {
                Random random = new Random();
                preguntasMostradas = ObtenerPreguntasAleatorias(30);
                preguntaActualIndex = 0;

                // Inicializa las preguntas y respuestas solo si aún no se han inicializado
                foreach (var pregunta in preguntasMostradas)
                {
                    if (pregunta.RespuestasBarajeadas == null || pregunta.RespuestasBarajeadas.Count == 0)
                    {
                        List<string> respuestas = new List<string>
                        {
                            pregunta.RespuestaCorrecta,
                            pregunta.RespuestaIncorrecta1,
                            pregunta.RespuestaIncorrecta2,
                            pregunta.RespuestaIncorrecta3
                        };

                        respuestas = respuestas.OrderBy(x => random.Next()).ToList();

                        pregunta.RespuestaCorrecta = respuestas[0];
                        pregunta.RespuestaIncorrecta1 = respuestas[1];
                        pregunta.RespuestaIncorrecta2 = respuestas[2];
                        pregunta.RespuestaIncorrecta3 = respuestas[3];

                        // Almacena las respuestas barajeadas en la propiedad RespuestasBarajeadas
                        pregunta.RespuestasBarajeadas.AddRange(respuestas);
                    }
                }
            }
        }


        private void MostrarPreguntaSiguiente()
        {
            if (!PreguntasAleatoriasIniciadas)
            {
                InicializarPreguntasAleatorias();
                PreguntasAleatoriasIniciadas = true;
            }

            try
            {
                if (preguntasMostradas.Count > 0)
                {
                    preguntaActualIndex = preguntaActualIndex % preguntasMostradas.Count;
                    MostrarPreguntaEnCasilla(preguntaActualIndex + 1, preguntasMostradas[preguntaActualIndex]);

                    // Incrementa el índice para la siguiente pregunta
                    preguntaActualIndex++;
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Error al inicializar pregunta", MessageBoxButtons.OK, MessageBoxIcon.Error);
            } 
        }
        private List<Pregunta> ObtenerPreguntasAleatorias(int cantidad)
        {
            Random random = new Random();

            try
            {
                // Filtra las preguntas no seleccionadas o reinicia el estado de selección si es necesario
                var preguntasDisponibles = preguntas.Where(p => !p.Seleccionada).ToList();

                if (!preguntasDisponibles.Any())
                {
                    ReiniciarEstadoSeleccion();
                    preguntasDisponibles = preguntas.ToList();
                }

                // Selecciona preguntas aleatorias no seleccionadas
                var preguntasSeleccionadas = preguntasDisponibles.OrderBy(x => random.Next()).Take(cantidad).ToList();

                // Marca las preguntas seleccionadas como seleccionadas
                foreach (var pregunta in preguntasSeleccionadas)
                {
                    pregunta.Seleccionada = true;
                }

                return preguntasSeleccionadas;
            }
            catch(Exception ex)
            {
                // Manejo de error: La lista de preguntas está vacía o nula
                // Puedes decidir qué hacer en este caso, como lanzar una excepción o devolver una lista vacía.
                MessageBox.Show(ex.Message, "Error en la lista de preguntas", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return new List<Pregunta>();
            }
        }
        private void ReiniciarEstadoSeleccion()
        {
            // Reinicia el estado de selección para todas las preguntas
            foreach (var pregunta in preguntas)
            {
                pregunta.Seleccionada = false;
            }
        }
        private void MostrarPreguntaEnCasilla(int numPregunta, Pregunta pregunta)
        {

            // Restablece la apariencia de las respuestas
            ReiniciarAparienciaRespuestas();

            // Configura los datos de la pregunta en la casilla actual
            lblPregunta.Text = $"{numPregunta}. {pregunta.PreguntaTexto}";

            // Verifica si las respuestas barajeadas ya han sido fijadas
            if (!pregunta.RespuestasBarajeadasFijas)
            {
                pregunta.RespuestasBarajeadasFijas = true;

                // Barajea las respuestas y guárdalas en RespuestasBarajeadas
                pregunta.RespuestasBarajeadas = new List<string>
        {
            pregunta.RespuestaCorrecta,
            pregunta.RespuestaIncorrecta1,
            pregunta.RespuestaIncorrecta2,
            pregunta.RespuestaIncorrecta3
        };

                pregunta.RespuestasBarajeadas = pregunta.RespuestasBarajeadas.OrderBy(x => random.Next()).ToList();
            }

            // Configura las respuestas en los controles correspondientes
            buttonRespuestaA.Text = pregunta.RespuestasBarajeadas[0];
            buttonRespuestaB.Text = pregunta.RespuestasBarajeadas[1];
            buttonRespuestaC.Text = pregunta.RespuestasBarajeadas[2];
            buttonRespuestaD.Text = pregunta.RespuestasBarajeadas[3];

            // Verifica si el usuario ya ha seleccionado una respuesta previamente
            if (!string.IsNullOrEmpty(pregunta.RespuestaSeleccionada))
            {
                // Marca la respuesta seleccionada por el usuario
                MarcarRespuestaSeleccionada(pregunta.RespuestaSeleccionada);
            }
        }

        private void MarcarRespuestaSeleccionada(string respuesta)
        {
            switch (respuesta)
            {
                case "A":
                    buttonRespuestaA.Image = global::SistemaEvaluacion.Properties.Resources.Preguntas_Respuestas_SeleccionadaR;
                    break;
                case "B":
                    buttonRespuestaB.Image = global::SistemaEvaluacion.Properties.Resources.Preguntas_Respuestas_SeleccionadaR;
                    break;
                case "C":
                    buttonRespuestaC.Image = global::SistemaEvaluacion.Properties.Resources.Preguntas_Respuestas_SeleccionadaR;
                    break;
                case "D":
                    buttonRespuestaD.Image = global::SistemaEvaluacion.Properties.Resources.Preguntas_Respuestas_SeleccionadaR;
                    break;
            }
        }


        private void ReiniciarAparienciaRespuestas()
        {
            buttonRespuestaA.Image = global::SistemaEvaluacion.Properties.Resources.Preguntas_Respuestas_Vacio__2_1;
            buttonRespuestaB.Image = global::SistemaEvaluacion.Properties.Resources.Preguntas_Respuestas_Vacio__2_1;
            buttonRespuestaC.Image = global::SistemaEvaluacion.Properties.Resources.Preguntas_Respuestas_Vacio__2_1;
            buttonRespuestaD.Image = global::SistemaEvaluacion.Properties.Resources.Preguntas_Respuestas_Vacio__2_1;
        }
        private void InicializarCasillas()
        {
            // Itera sobre tus casillas y configura el evento Click
            for (int i = 1; i <= 30; i++)
            {
                PictureBox pboxCasilla = Controls.Find($"pboxCasilla{i}", true).FirstOrDefault() as PictureBox;
                if (pboxCasilla != null)
                {
                    pboxCasilla.Click += PboxCasilla_Click;
                }
            }
        }
        private void PboxCasilla_Click(object sender, EventArgs e)
        {
            PictureBox clickedCasilla = (PictureBox)sender;
            int numeroCasilla = int.Parse(clickedCasilla.Name.Replace("pboxCasilla", ""));
            preguntaActualIndex = numeroCasilla - 1;

            MostrarPreguntaEnCasilla(preguntaActualIndex+1, preguntasMostradas[preguntaActualIndex]);
            ActualizarVisibilidadPaneles(preguntaActualIndex + 1);
        }
        private void InicializarPreguntas()
        {
            preguntas = new List<Pregunta>();

            try
            {
                using (TextFieldParser parser = new TextFieldParser("Preguntas.csv"))
                {
                    parser.TextFieldType = FieldType.Delimited;
                    parser.SetDelimiters(",");

                    // Saltar la línea de encabezado
                    parser.ReadLine();

                    while (!parser.EndOfData)
                    {
                        string[] fields = parser.ReadFields();
                        if (fields.Length == 7)
                        {
                            preguntas.Add(new Pregunta
                            {
                                ID = fields[0],
                                PreguntaTexto = fields[1],
                                RespuestaCorrecta = fields[2],
                                RespuestaIncorrecta1 = fields[3],
                                RespuestaIncorrecta2 = fields[4],
                                RespuestaIncorrecta3 = fields[5],
                                Puntuacion = fields[6],
                                RespuestaSeleccionada = "No seleccionada"
                            });
                        }
                    }
                }
            }
            catch(Exception e) 
            {
                MessageBox.Show(e.Message,"Error al inicializar pregunta",MessageBoxButtons.OK,MessageBoxIcon.Error);
                this.Close();
            }
        }
        private void MostrarPreguntasAleatorias()
        {
            try
            {
                Random random = new Random();
                preguntasMostradas = preguntas.OrderBy(x => random.Next()).Take(30).ToList();

                // Mostrar la primera pregunta
                MostrarPreguntaEnCasilla(preguntaActualIndex + 1, preguntasMostradas[0]);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message,"Error al mostrar preguntas aleatorias",MessageBoxButtons.OK,MessageBoxIcon.Error);
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

        private void Evaluacion_Load(object sender, EventArgs e)
        {
            pnlPreguntas110.Visible = true;
            pnlPreguntas1120.Visible = false;
            pnlPreguntas2130.Visible = false;

            MostrarPreguntasAleatorias();
        }

        private void pboxFinalizar_Click(object sender, EventArgs e)
        {
            // Crea una instancia del formulario de resultados
            Resultados resultados = new Resultados();

            // Guarda los resultados en un archivo CSV
            GuardarResultadosCSV();

            // Cierra el formulario actual (Evaluacion)
            this.Close();

            // Muestra el formulario de resultados
            resultados.ShowDialog();
        }
        private void GuardarResultadosCSV()
        {
            try
            {
                // Ruta del archivo CSV de resultados
                string rutaArchivoResultados = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "resultados.csv");

                // Crear o abrir el archivo CSV de resultados
                using (StreamWriter writer = new StreamWriter(rutaArchivoResultados))
                {
                    // Escribir la cabecera en el archivo
                    writer.WriteLine("Pregunta,Respuesta Correcta,Respuesta Seleccionada,Respuesta A,Respuesta B,Respuesta C,Respuesta D");

                    // Iterar a través de las preguntas y escribir los resultados en el archivo
                    foreach (var pregunta in preguntasMostradas)
                    {
                        string preguntaTexto = pregunta.PreguntaTexto;
                        string respuestaCorrecta = pregunta.RespuestaCorrecta;
                        string respuestaSeleccionada = pregunta.RespuestaSeleccionada ?? "No respondida";
                        string respuestaA = pregunta.RespuestasBarajeadas.Count > 0 ? pregunta.RespuestasBarajeadas[0] : "No disponible";
                        string respuestaB = pregunta.RespuestasBarajeadas.Count > 1 ? pregunta.RespuestasBarajeadas[1] : "No disponible";
                        string respuestaC = pregunta.RespuestasBarajeadas.Count > 2 ? pregunta.RespuestasBarajeadas[2] : "No disponible";
                        string respuestaD = pregunta.RespuestasBarajeadas.Count > 3 ? pregunta.RespuestasBarajeadas[3] : "No disponible";

                        // Escribir la línea de resultados en el archivo
                        writer.WriteLine($"{preguntaTexto},{respuestaCorrecta},{respuestaSeleccionada},{respuestaA},{respuestaB},{respuestaC},{respuestaD}");
                    }
                }
            }
            catch (Exception ex)
            {
                // Manejar cualquier excepción que pueda ocurrir durante la escritura del archivo
                MessageBox.Show($"Error al guardar los resultados: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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
        private void ActualizarVisibilidadPaneles(int numeroCasilla)
        {
            // Establece la visibilidad de los paneles según el rango de casillas
            pnlPreguntas110.Visible = (numeroCasilla >= 1 && numeroCasilla <= 10);
            pnlPreguntas1120.Visible = (numeroCasilla >= 11 && numeroCasilla <= 20);
            pnlPreguntas2130.Visible = (numeroCasilla >= 21 && numeroCasilla <= 30);
        }

        private void pboxPreguntaAnterior_Click(object sender, EventArgs e)
        {
            preguntaActualIndex--;
            if (preguntaActualIndex < 0)
            {
                preguntaActualIndex = preguntasMostradas.Count - 1;
            }

            MostrarPreguntaEnCasilla(preguntaActualIndex + 1, preguntasMostradas[preguntaActualIndex]);
            ActualizarVisibilidadPaneles(preguntaActualIndex + 1);
        }

        private void pboxSiguientePregunta_Click(object sender, EventArgs e)
        {
            // Incrementa el índice de la pregunta actual
            preguntaActualIndex++;

            // Si el índice es mayor o igual al número de preguntas, establece el índice a 0
            if (preguntaActualIndex >= preguntasMostradas.Count)
            {
                preguntaActualIndex = 0;
            }

            // Actualiza la visibilidad de los paneles según el rango de casillas
            ActualizarVisibilidadPaneles(preguntaActualIndex + 1);

            // Muestra la pregunta actual en la interfaz gráfica
            MostrarPreguntaEnCasilla(preguntaActualIndex + 1, preguntasMostradas[preguntaActualIndex]);
        }

        private void pboxAbandonar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void PboxRespuesta_Click(object sender, EventArgs e)
        {
            Button clickedRespuesta = (Button)sender;

            // Obtén la letra de la respuesta desde el nombre del PictureBox
            string letraRespuesta = clickedRespuesta.Name;

            // Actualiza la propiedad RespuestaSeleccionada de la pregunta actual
            preguntasMostradas[preguntaActualIndex].RespuestaSeleccionada = letraRespuesta;

            // Actualiza la apariencia de las respuestas
            MostrarPreguntaEnCasilla(preguntaActualIndex + 1, preguntasMostradas[preguntaActualIndex]);
        }

        private void pboxRespuestaA_Click(object sender, EventArgs e)
        {
            // Actualiza la respuesta seleccionada por el usuario
            preguntasMostradas[preguntaActualIndex].RespuestaSeleccionada = "A";

            // Restablece la apariencia de las respuestas
            ReiniciarAparienciaRespuestas();

            // Marca la respuesta seleccionada por el usuario
            MarcarRespuestaSeleccionada("A");
        }

        private void pboxRespuestaB_Click(object sender, EventArgs e)
        {
            // Actualiza la respuesta seleccionada por el usuario
            preguntasMostradas[preguntaActualIndex].RespuestaSeleccionada = "B";

            // Restablece la apariencia de las respuestas
            ReiniciarAparienciaRespuestas();

            // Marca la respuesta seleccionada por el usuario
            MarcarRespuestaSeleccionada("B");
        }

        private void pboxRespuestaC_Click(object sender, EventArgs e)
        {
             // Actualiza la respuesta seleccionada por el usuario
            preguntasMostradas[preguntaActualIndex].RespuestaSeleccionada = "C";

            // Restablece la apariencia de las respuestas
            ReiniciarAparienciaRespuestas();

            // Marca la respuesta seleccionada por el usuario
            MarcarRespuestaSeleccionada("C");
        }

        private void pboxRespuestaD_Click(object sender, EventArgs e)
        {
            // Actualiza la respuesta seleccionada por el usuario
            preguntasMostradas[preguntaActualIndex].RespuestaSeleccionada = "D";

            // Restablece la apariencia de las respuestas
            ReiniciarAparienciaRespuestas();

            // Marca la respuesta seleccionada por el usuario
            MarcarRespuestaSeleccionada("D");
        }

        private void lblRespuestaA_Click(object sender, EventArgs e)
        {

        }

        private void lblRespuestaB_Click(object sender, EventArgs e)
        {

        }

        private void lblRespuestaC_Click(object sender, EventArgs e)
        {

        }

        private void lblRespuestaD_Click(object sender, EventArgs e)
        {

        }

        private void lblTiempo_Click(object sender, EventArgs e)
        {

        }

        private void lblPregunta_Click(object sender, EventArgs e)
        {

        }

        private void pboxPregunta_Click(object sender, EventArgs e)
        {

        }

        private void buttonRespuesta_Click(object sender, EventArgs e)
        {
            // Actualiza la respuesta seleccionada por el usuario
            preguntasMostradas[preguntaActualIndex].RespuestaSeleccionada = "A";

            // Restablece la apariencia de las respuestas
            ReiniciarAparienciaRespuestas();

            // Marca la respuesta seleccionada por el usuario
            MarcarRespuestaSeleccionada("A");
        }

        private void buttonRespuestaC_Click(object sender, EventArgs e)
        {
            // Actualiza la respuesta seleccionada por el usuario
            preguntasMostradas[preguntaActualIndex].RespuestaSeleccionada = "C";

            // Restablece la apariencia de las respuestas
            ReiniciarAparienciaRespuestas();

            // Marca la respuesta seleccionada por el usuario
            MarcarRespuestaSeleccionada("C");
        }

        private void buttonRespuestaB_Click(object sender, EventArgs e)
        {// Actualiza la respuesta seleccionada por el usuario
            preguntasMostradas[preguntaActualIndex].RespuestaSeleccionada = "B";

            // Restablece la apariencia de las respuestas
            ReiniciarAparienciaRespuestas();

            // Marca la respuesta seleccionada por el usuario
            MarcarRespuestaSeleccionada("B");

        }

        private void buttonRespuestaD_Click(object sender, EventArgs e)
        {
            // Actualiza la respuesta seleccionada por el usuario
            preguntasMostradas[preguntaActualIndex].RespuestaSeleccionada = "D";

            // Restablece la apariencia de las respuestas
            ReiniciarAparienciaRespuestas();

            // Marca la respuesta seleccionada por el usuario
            MarcarRespuestaSeleccionada("D");
        }
    }
}
