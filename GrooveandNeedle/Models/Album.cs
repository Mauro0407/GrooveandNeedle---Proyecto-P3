using System;

namespace GrooveandNeedle.Models
{
    public class Album
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public DateTime FechaDeLanzamiento { get; set; }
        public string Genero { get; set; }
    }
}
