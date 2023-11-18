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
    public partial class Instrucciones : Form
    {
        public Instrucciones()
        {
            InitializeComponent();
            
        }

        private void Instrucciones_FormClosing(object sender, FormClosingEventArgs e)
        {
          e.Cancel = true;
          Bienvenida bienvenida = new Bienvenida();
          bienvenida.Show();

        }
        

        private void pboxEntendido_Click(object sender, EventArgs e)
        {
            this.Close();
            Bienvenida bienvenida = new Bienvenida();
            bienvenida.Show();
            
        }

        private void Instrucciones_Load(object sender, EventArgs e)
        {
            lblInstruccionesDescripcion.Text = "El tema a evaluar en el examen será Computación, aspectos básicos de ésta que toda persona debería saber. " +
                "El examen consiste en 30 preguntas, el usuario podrá navegar libremente a través de ellas, para ello tendrá a su disposición botones que le ofrecerán recorrer las preguntas de tres formas distintas. " +
                "El usuario tendrá 30 minutos para resolver el examen en su totalidad, debe tener especial cuidado con el tiempo y leer las preguntas detenimiento. " +
                "Durante el examen, no se mostrará si la respuesta seleccionada por el usuario es correcta o incorrecta. Una vez finalizado, se mostrará la respuesta correcta, las incorrectas, y si la seleccionada por el usuario fue correcta o incorrecta. " +
                "El examen evaluará al usuario en base a 100 puntos, siendo ésta la mayor nota que puede sacar. Para aprobar, deberá responder correctamente al menos 20 preguntas. Se pueden destacar los siguientes controles, que tendrán uso frecuente: ";

            lblBoton10en10.Text = "Indica el conjunto de preguntas contenidas. Agrupa y muestra las preguntas de 10 en 10.";
            lblCasilla.Text = "Indica el número de la pregunta. Al seleccionarse, se muestra la pregunta y sus respuestas.";
            lblRetrocederAvanzar.Text = "Le indica al usuario si desea ir a la pregunta anterior o a la siguiente pregunta.";
            lblTemporizadorDescripcion.Text = "Indica el tiempo restante para que finalice el examen.";
        }
    }
}
