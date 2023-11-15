using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaEvaluacion
{
    internal class Pregunta
    {
        public string ID { get; set; }
        public string PreguntaTexto { get; set; }
        public string RespuestaCorrecta { get; set; }
        public string RespuestaIncorrecta1 { get; set; }
        public string RespuestaIncorrecta2 { get; set; }
        public string RespuestaIncorrecta3 { get; set; }
        public string Puntuacion { get; set; }
        public bool Seleccionada { get; set; }
        public List<string> RespuestasBarajeadas { get; set; } = new List<string>();
        public bool RespuestasBarajeadasFijas { get; set; } = false;
        public string RespuestaSeleccionada { get; set; }
    }
}
