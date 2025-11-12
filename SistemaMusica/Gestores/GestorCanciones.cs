// ============================================
// GESTORES
// ============================================

using SistemaMusica.Modelos;

namespace SistemaMusica.Gestores
{
    // Clase GestorCanciones - Administra el catálogo de canciones
    public class GestorCanciones
    {
        // Lista de canciones disponibles en el sistema
        public List<Cancion> CancionesDisponibles { get; private set; }

        // Constructor
        public GestorCanciones()
        {
            CancionesDisponibles = new List<Cancion>();
        }

        // Agregar canción al catálogo
        public void AgregarCancion(Cancion cancion)
        {
            CancionesDisponibles.Add(cancion);
        }

        // Buscar canciones por nombre (búsqueda inteligente con coincidencias parciales)
        public List<Cancion> BuscarPorNombre(string nombre)
        {
            List<Cancion> resultados = new List<Cancion>();

            // Si el término de búsqueda está vacío, retornar lista vacía
            if (string.IsNullOrWhiteSpace(nombre))
            {
                return resultados;
            }

            // Normalizar el término de búsqueda
            string terminoBusqueda = nombre.Trim().ToLower();

            // Buscar coincidencias exactas y parciales
            foreach (var cancion in CancionesDisponibles)
            {
                string nombreCancion = cancion.Nombre.ToLower();
                string artistaCancion = cancion.Artista.ToLower();

                // 1. Coincidencia exacta en nombre (case-insensitive)
                if (nombreCancion.Equals(terminoBusqueda, StringComparison.OrdinalIgnoreCase))
                {
                    resultados.Add(cancion);
                    continue;
                }

                // 2. Coincidencia exacta en artista (case-insensitive)
                if (artistaCancion.Equals(terminoBusqueda, StringComparison.OrdinalIgnoreCase))
                {
                    resultados.Add(cancion);
                    continue;
                }

                // 3. Coincidencia parcial en nombre (contiene el término)
                if (nombreCancion.Contains(terminoBusqueda))
                {
                    resultados.Add(cancion);
                    continue;
                }

                // 4. Coincidencia parcial en artista (contiene el término)
                if (artistaCancion.Contains(terminoBusqueda))
                {
                    resultados.Add(cancion);
                    continue;
                }

                // 5. Búsqueda por palabras (divide el término y busca cada palabra)
                string[] palabrasBusqueda = terminoBusqueda.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                if (palabrasBusqueda.Length > 1)
                {
                    bool todasLasPalabrasCoinciden = true;

                    foreach (string palabra in palabrasBusqueda)
                    {
                        if (!nombreCancion.Contains(palabra) && !artistaCancion.Contains(palabra))
                        {
                            todasLasPalabrasCoinciden = false;
                            break;
                        }
                    }

                    if (todasLasPalabrasCoinciden)
                    {
                        resultados.Add(cancion);
                    }
                }
            }

            return resultados;
        }

        // QuickSort - Ordenar canciones por duración (ascendente)
        public void QuickSort(List<Cancion> lista, int low, int high)
        {
            if (low < high)
            {
                // 1. Particionar y obtener índice del pivote
                int pivotIndex = Partition(lista, low, high);

                // 2. Recursivamente ordenar sublistas
                QuickSort(lista, low, pivotIndex - 1);
                QuickSort(lista, pivotIndex + 1, high);
            }
        }

        // Método auxiliar de partición para QuickSort
        private int Partition(List<Cancion> lista, int low, int high)
        {
            // Seleccionar último elemento como pivote
            int pivotDuracion = lista[high].DuracionSegundos;
            int i = low - 1;

            // Reorganizar elementos menores a la izquierda
            for (int j = low; j < high; j++)
            {
                if (lista[j].DuracionSegundos < pivotDuracion)
                {
                    i++;
                    // Intercambiar
                    var temp = lista[i];
                    lista[i] = lista[j];
                    lista[j] = temp;
                }
            }

            // Colocar pivote en su posición final
            var tempPivot = lista[i + 1];
            lista[i + 1] = lista[high];
            lista[high] = tempPivot;

            return i + 1;
        }

        // Mostrar todas las canciones disponibles
        public void MostrarCancionesDisponibles()
        {
            Console.WriteLine("\n=== Catálogo de Canciones Disponibles ===");

            if (CancionesDisponibles.Count == 0)
            {
                Console.WriteLine("No hay canciones disponibles.");
                return;
            }

            for (int i = 0; i < CancionesDisponibles.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {CancionesDisponibles[i].ToString()}");
            }
        }
    }
}