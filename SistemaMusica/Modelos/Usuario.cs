namespace SistemaMusica.Modelos
{
    public class Usuario
    {
        public string Nombre { get; set; }

        // Dictionary: Clave = Nombre de lista, Valor = Lista de canciones
        public Dictionary<string, List<Cancion>> ListasReproduccion { get; private set; }

        // Constructor: Inicializa el diccionario
        public Usuario(string nombre)
        {
            Nombre = nombre;
            ListasReproduccion = new Dictionary<string, List<Cancion>>();
        }

        // Crear lista de reproducción (verificando duplicados)
        public void CrearListaReproduccion(string nombreLista)
        {
            // Verificar si ya existe la lista
            if (ListasReproduccion.ContainsKey(nombreLista))
            {
                Console.WriteLine($"Error: La lista '{nombreLista}' ya existe.");
                return;
            }

            // Crear lista vacía
            ListasReproduccion[nombreLista] = new List<Cancion>();
            Console.WriteLine($"Lista '{nombreLista}' creada exitosamente.");
        }

        // Agregar canción a una lista específica
        public void AgregarCancionALista(string nombreLista, Cancion cancion)
        {
            // Validar que la lista existe
            if (!ListasReproduccion.ContainsKey(nombreLista))
            {
                Console.WriteLine($"Error: La lista '{nombreLista}' no existe.");
                return;
            }

            // Agregar canción
            ListasReproduccion[nombreLista].Add(cancion);
            Console.WriteLine($"Canción '{cancion.Nombre}' agregada a '{nombreLista}'.");
        }

        // Mostrar todas las listas con sus canciones
        public void MostrarListasReproduccion()
        {
            Console.WriteLine($"\n=== Listas de reproducción de {Nombre} ===");

            if (ListasReproduccion.Count == 0)
            {
                Console.WriteLine("No tienes listas de reproducción.");
                return;
            }

            foreach (var lista in ListasReproduccion)
            {
                Console.WriteLine($"\n📂 {lista.Key} ({lista.Value.Count} canciones):");

                if (lista.Value.Count == 0)
                {
                    Console.WriteLine("  (vacía)");
                }
                else
                {
                    for (int i = 0; i < lista.Value.Count; i++)
                    {
                        Console.WriteLine($"  {i + 1}. {lista.Value[i].ToString()}");
                    }
                }
            }
        }
    }
}
