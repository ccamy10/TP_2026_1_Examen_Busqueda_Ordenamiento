using SistemaMusica.Modelos;

namespace SistemaMusicaTests
{
    public class UsuarioTests
    {
        [Fact]
        public void CrearListaReproduccion_DebeCrearNuevaLista()
        {
            // Arrange
            var usuario = new Usuario("Ana");

            // Act
            usuario.CrearListaReproduccion("Favoritas");

            // Assert
            Assert.True(usuario.ListasReproduccion.ContainsKey("Favoritas"));
            Assert.Empty(usuario.ListasReproduccion["Favoritas"]);
        }

        [Fact]
        public void AgregarCancionALista_DebeAgregarCancionAListaCorrectamente()
        {
            // Arrange
            var usuario = new Usuario("María");
            usuario.CrearListaReproduccion("Pop");
            var cancion = new Cancion("Billie Jean", "Michael Jackson", 294);

            // Act
            usuario.AgregarCancionALista("Pop", cancion);

            // Assert
            Assert.Contains(cancion, usuario.ListasReproduccion["Pop"]);
            Assert.Single(usuario.ListasReproduccion["Pop"]);
        }
    }
}