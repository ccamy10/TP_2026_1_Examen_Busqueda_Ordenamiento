// ============================================
// PROGRAMA PRINCIPAL
// ============================================

using SistemaMusica.Modelos;
using SistemaMusica.Servicios;
using SistemaMusica.Gestores;

// 1. INICIALIZACIÓN - Crear servicio y agregar canciones de ejemplo
ServicioMusica servicio = new ServicioMusica();

// Agregar 8 canciones de ejemplo al catálogo
servicio.Gestor.AgregarCancion(new Cancion("Bohemian Rhapsody", "Queen", 354));
servicio.Gestor.AgregarCancion(new Cancion("Stairway to Heaven", "Led Zeppelin", 482));
servicio.Gestor.AgregarCancion(new Cancion("Imagine", "John Lennon", 183));
servicio.Gestor.AgregarCancion(new Cancion("Hey Jude", "The Beatles", 431));
servicio.Gestor.AgregarCancion(new Cancion("Hotel California", "Eagles", 391));
servicio.Gestor.AgregarCancion(new Cancion("Sweet Child O' Mine", "Guns N' Roses", 356));
servicio.Gestor.AgregarCancion(new Cancion("Smells Like Teen Spirit", "Nirvana", 301));
servicio.Gestor.AgregarCancion(new Cancion("Billie Jean", "Michael Jackson", 294));

Console.ForegroundColor = ConsoleColor.Cyan;
Console.WriteLine("╔════════════════════════════════════════════════════════════╗");
Console.WriteLine("║       BIENVENIDO AL SISTEMA DE MÚSICA SIMPLE              ║");
Console.WriteLine("╚════════════════════════════════════════════════════════════╝");
Console.ResetColor();

// 2. REGISTRO DE USUARIO
Console.ForegroundColor = ConsoleColor.Yellow;
Console.WriteLine("\n┌─────────────────────────────────────┐");
Console.WriteLine("│         REGISTRO DE USUARIO         │");
Console.WriteLine("└─────────────────────────────────────┘");
Console.ResetColor();

Console.ForegroundColor = ConsoleColor.White;
Console.Write("Por favor, ingrese su nombre de usuario: ");
Console.ForegroundColor = ConsoleColor.Green;
string nombreUsuario = Console.ReadLine()?.Trim() ?? "";
Console.ResetColor();

// Validar que el nombre no esté vacío
while (string.IsNullOrWhiteSpace(nombreUsuario))
{
    Console.ForegroundColor = ConsoleColor.Red;
    Console.Write("Error: El nombre no puede estar vacío. Ingrese nuevamente: ");
    Console.ForegroundColor = ConsoleColor.Green;
    nombreUsuario = Console.ReadLine()?.Trim() ?? "";
    Console.ResetColor();
}

servicio.RegistrarUsuario(nombreUsuario);
Usuario usuarioActual = servicio.BuscarUsuario(nombreUsuario);

Console.ForegroundColor = ConsoleColor.Cyan;
Console.WriteLine($"\n¡Bienvenido, {nombreUsuario}!");
Console.ResetColor();

// 3. CREACIÓN DE LISTA INICIAL
Console.ForegroundColor = ConsoleColor.Yellow;
Console.WriteLine("\n┌─────────────────────────────────────┐");
Console.WriteLine("│   CREACIÓN DE LISTA DE REPRODUCCIÓN  │");
Console.WriteLine("└─────────────────────────────────────┘");
Console.ResetColor();

Console.ForegroundColor = ConsoleColor.White;
Console.Write("Ingrese un nombre para su primera lista de reproducción: ");
Console.ForegroundColor = ConsoleColor.Green;
string nombreListaInicial = Console.ReadLine()?.Trim() ?? "";
Console.ResetColor();

// Validar que el nombre de lista no esté vacío
while (string.IsNullOrWhiteSpace(nombreListaInicial))
{
    Console.ForegroundColor = ConsoleColor.Red;
    Console.Write("Error: El nombre de lista no puede estar vacío. Ingrese nuevamente: ");
    Console.ForegroundColor = ConsoleColor.Green;
    nombreListaInicial = Console.ReadLine()?.Trim() ?? "";
    Console.ResetColor();
}

usuarioActual.CrearListaReproduccion(nombreListaInicial);
string listaActual = nombreListaInicial;

// 4. MENÚ PRINCIPAL
bool continuar = true;

while (continuar)
{
    Console.ForegroundColor = ConsoleColor.Cyan;
    Console.WriteLine("\n╔════════════════════════════════════════════════════════════╗");
    Console.WriteLine("║                      MENÚ PRINCIPAL                       ║");
    Console.WriteLine("╚════════════════════════════════════════════════════════════╝");
    Console.ResetColor();

    Console.ForegroundColor = ConsoleColor.White;
    Console.WriteLine($"Usuario actual: {usuarioActual.Nombre}");
    int cantidadCanciones = usuarioActual.ListasReproduccion.ContainsKey(listaActual)
        ? usuarioActual.ListasReproduccion[listaActual].Count
        : 0;
    Console.WriteLine($"Lista actual: '{listaActual}' ({cantidadCanciones} canciones)");

    Console.WriteLine("\n1. Buscar canciones para agregar a mi lista");
    Console.WriteLine("2. Ver mi lista de reproducción (ordenada por duración)");
    Console.WriteLine("3. Ver todas las canciones disponibles");
    Console.WriteLine("4. Crear nueva lista de reproducción");
    Console.WriteLine("5. Cambiar de lista actual");
    Console.WriteLine("6. Salir");

    Console.Write("\nSeleccione una opción: ");
    Console.ForegroundColor = ConsoleColor.Green;
    string opcion = Console.ReadLine() ?? "";
    Console.ResetColor();

    switch (opcion)
    {
        case "1":
            // OPCIÓN 1: Buscar canciones para agregar a mi lista
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\n┌─────────────────────────────────────┐");
            Console.WriteLine("│         BUSCAR CANCIONES            │");
            Console.WriteLine("└─────────────────────────────────────┘");
            Console.ResetColor();

            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("Ingrese el nombre de la canción o artista a buscar: ");
            Console.ForegroundColor = ConsoleColor.Green;
            string busqueda = Console.ReadLine()?.Trim() ?? "";
            Console.ResetColor();

            // Validar que la búsqueda no esté vacía
            if (string.IsNullOrWhiteSpace(busqueda))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Error: Debe ingresar un término de búsqueda.");
                Console.ResetColor();
                break;
            }

            // Usar la búsqueda inteligente del GestorCanciones
            var resultados = servicio.Gestor.BuscarPorNombre(busqueda);

            if (resultados.Count == 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"No se encontraron canciones con el término '{busqueda}'.");
                Console.ResetColor();

                // Mostrar sugerencia de canciones disponibles
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("\n¿Desea ver todas las canciones disponibles? (s/n): ");
                Console.ResetColor();
                string verTodas = Console.ReadLine()?.ToLower() ?? "";
                if (verTodas == "s" || verTodas == "si")
                {
                    servicio.Gestor.MostrarCancionesDisponibles();
                }
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"Se encontraron {resultados.Count} canciones:");
                Console.ResetColor();

                for (int i = 0; i < resultados.Count; i++)
                {
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.Write($"{i + 1}. ");
                    Console.ResetColor();
                    Console.WriteLine($"{resultados[i].ToString()}");
                }

                Console.ForegroundColor = ConsoleColor.White;
                Console.Write("\nSeleccione el número de la canción a agregar (0 para cancelar): ");
                Console.ForegroundColor = ConsoleColor.Green;
                string input = Console.ReadLine() ?? "";
                Console.ResetColor();

                if (int.TryParse(input, out int seleccion))
                {
                    if (seleccion > 0 && seleccion <= resultados.Count)
                    {
                        usuarioActual.AgregarCancionALista(listaActual, resultados[seleccion - 1]);
                    }
                    else if (seleccion == 0)
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine("Operación cancelada.");
                        Console.ResetColor();
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Selección inválida.");
                        Console.ResetColor();
                    }
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Entrada inválida. Debe ingresar un número.");
                    Console.ResetColor();
                }
            }
            break;

        case "2":
            // OPCIÓN 2: Ver lista de reproducción (ordenada por duración)
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\n┌─────────────────────────────────────┐");
            Console.WriteLine("│    LISTA ORDENADA POR DURACIÓN      │");
            Console.WriteLine("└─────────────────────────────────────┘");
            Console.ResetColor();

            if (!usuarioActual.ListasReproduccion.ContainsKey(listaActual))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Error: La lista no existe.");
                Console.ResetColor();
                break;
            }

            var listaParaOrdenar = usuarioActual.ListasReproduccion[listaActual];

            if (listaParaOrdenar.Count == 0)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("La lista está vacía.");
                Console.ResetColor();
                break;
            }

            // Crear una copia para no modificar la lista original
            var listaCopia = new List<Cancion>(listaParaOrdenar);

            // Ordenar usando QuickSort por duración
            servicio.Gestor.QuickSort(listaCopia, 0, listaCopia.Count - 1);

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine($"Lista '{listaActual}' ordenada por duración:");
            Console.ResetColor();

            for (int i = 0; i < listaCopia.Count; i++)
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write($"{i + 1}. ");
                Console.ResetColor();
                Console.WriteLine($"{listaCopia[i].ToString()}");
            }

            // Calcular y mostrar duración total
            int duracionTotal = CalcularDuracionTotal(listaCopia);
            int minutosTotales = duracionTotal / 60;
            int segundosTotales = duracionTotal % 60;

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"Duración total: {minutosTotales}:{segundosTotales:D2}");
            Console.ResetColor();
            break;

        case "3":
            // OPCIÓN 3: Ver todas las canciones disponibles
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\n┌─────────────────────────────────────┐");
            Console.WriteLine("│       CANCIONES DISPONIBLES         │");
            Console.WriteLine("└─────────────────────────────────────┘");
            Console.ResetColor();
            servicio.Gestor.MostrarCancionesDisponibles();
            break;

        case "4":
            // OPCIÓN 4: Crear nueva lista de reproducción
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\n┌─────────────────────────────────────┐");
            Console.WriteLine("│       CREAR NUEVA LISTA             │");
            Console.WriteLine("└─────────────────────────────────────┘");
            Console.ResetColor();

            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("Ingrese el nombre de la nueva lista: ");
            Console.ForegroundColor = ConsoleColor.Green;
            string nombreNuevaLista = Console.ReadLine()?.Trim() ?? "";
            Console.ResetColor();

            if (string.IsNullOrWhiteSpace(nombreNuevaLista))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Error: El nombre de lista no puede estar vacío.");
                Console.ResetColor();
                break;
            }

            usuarioActual.CrearListaReproduccion(nombreNuevaLista);
            break;

        case "5":
            // OPCIÓN 5: Cambiar de lista actual
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\n┌─────────────────────────────────────┐");
            Console.WriteLine("│       CAMBIAR LISTA ACTUAL          │");
            Console.WriteLine("└─────────────────────────────────────┘");
            Console.ResetColor();

            if (usuarioActual.ListasReproduccion.Count == 0)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("No tienes listas de reproducción.");
                Console.ResetColor();
                break;
            }

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("Tus listas de reproducción:");
            Console.ResetColor();

            int indice = 1;
            foreach (var lista in usuarioActual.ListasReproduccion.Keys)
            {
                int count = usuarioActual.ListasReproduccion[lista].Count;
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write($"{indice}. ");
                Console.ResetColor();
                Console.WriteLine($"{lista} ({count} canciones)");
                indice++;
            }

            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("\nSeleccione el número de lista: ");
            Console.ForegroundColor = ConsoleColor.Green;
            string listaInput = Console.ReadLine() ?? "";
            Console.ResetColor();

            if (int.TryParse(listaInput, out int numLista) && numLista > 0 && numLista <= usuarioActual.ListasReproduccion.Count)
            {
                listaActual = usuarioActual.ListasReproduccion.Keys.ElementAt(numLista - 1);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"Lista actual cambiada a: '{listaActual}'");
                Console.ResetColor();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Selección inválida.");
                Console.ResetColor();
            }
            break;

        case "6":
            // OPCIÓN 6: Salir
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("\n╔════════════════════════════════════════════════════════════╗");
            Console.WriteLine("║     ¡Gracias por usar el Sistema de Gestión de Música!    ║");
            Console.WriteLine("╚════════════════════════════════════════════════════════════╝");
            Console.ResetColor();
            continuar = false;
            break;

        default:
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Opción inválida. Intente de nuevo.");
            Console.ResetColor();
            break;
    }

    // Pausa antes de continuar
    if (continuar)
    {
        Console.ForegroundColor = ConsoleColor.DarkGray;
        Console.WriteLine("\nPresione cualquier tecla para continuar...");
        Console.ResetColor();
        Console.ReadKey();
    }
}

// FUNCIÓN AUXILIAR: Calcular duración total de una lista
static int CalcularDuracionTotal(List<Cancion> canciones)
{
    int total = 0;
    foreach (var cancion in canciones)
    {
        total += cancion.DuracionSegundos;
    }
    return total;
}