namespace SistemaMusica.Modelos
{
    // Clase Cancion - Representa una canción del sistema
    public class Cancion
    {
        public string Nombre { get; set; }
        public string Artista { get; set; }
        public int DuracionSegundos { get; set; }

        // Constructor: Recibe los 3 parámetros
        public Cancion(string nombre, string artista, int duracionSegundos)
        {
            Nombre = nombre;
            Artista = artista;
            DuracionSegundos = duracionSegundos;
        }

        // ToString: Formato "Nombre - Artista (MM:SS)"
        public override string ToString()
        {
            int minutos = DuracionSegundos / 60;
            int segundos = DuracionSegundos % 60;
            return $"{Nombre} - {Artista} ({minutos}:{segundos:D2})";
        }
    }
}