using SistemaMusica.Modelos;
using SistemaMusica.Gestores;

namespace SistemaMusicaTests
{
    public class GestorCancionesTests
    {
        [Fact]
        public void AgregarCancion_DebeAumentarLista()
        {
            // Arrange
            var gestor = new GestorCanciones();
            var cancion = new Cancion("Hey Jude", "The Beatles", 431);

            // Act
            gestor.AgregarCancion(cancion);

            // Assert
            Assert.Single(gestor.CancionesDisponibles);
            Assert.Contains(cancion, gestor.CancionesDisponibles);
        }

        [Fact]
        public void BuscarPorNombre_DebeEncontrarCanciones()
        {
            // Arrange
            var gestor = new GestorCanciones();
            gestor.AgregarCancion(new Cancion("Bohemian Rhapsody", "Queen", 354));
            gestor.AgregarCancion(new Cancion("Bohemian Like You", "The Dandy Warhols", 199));
            gestor.AgregarCancion(new Cancion("Imagine", "John Lennon", 183));

            // Act
            var resultados = gestor.BuscarPorNombre("bohemian"); // Minúsculas

            // Assert
            Assert.Equal(2, resultados.Count); // Debe encontrar 2 canciones
            Assert.All(resultados, c => Assert.Contains("Bohemian", c.Nombre, StringComparison.OrdinalIgnoreCase));
        }

        [Fact]
        public void QuickSort_DebeOrdenarPorDuracionAscendente()
        {
            // Arrange
            var gestor = new GestorCanciones();
            var cancion1 = new Cancion("Larga", "Artist1", 500);
            var cancion2 = new Cancion("Corta", "Artist2", 100);
            var cancion3 = new Cancion("Media", "Artist3", 300);

            var lista = new List<Cancion> { cancion1, cancion2, cancion3 };

            // Act
            gestor.QuickSort(lista, 0, lista.Count - 1);

            // Assert
            Assert.Equal(100, lista[0].DuracionSegundos);
            Assert.Equal(300, lista[1].DuracionSegundos);
            Assert.Equal(500, lista[2].DuracionSegundos);
        }
    }
}