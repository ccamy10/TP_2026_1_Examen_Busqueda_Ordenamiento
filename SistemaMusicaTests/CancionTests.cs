using SistemaMusica.Modelos;

namespace SistemaMusicaTests
{
    public class CancionTests
    {
        [Fact]
        public void Constructor_DebeAsignarValoresCorrectamente()
        {
            // Arrange & Act
            var cancion = new Cancion("Bohemian Rhapsody", "Queen", 354);

            // Assert
            Assert.Equal("Bohemian Rhapsody", cancion.Nombre);
            Assert.Equal("Queen", cancion.Artista);
            Assert.Equal(354, cancion.DuracionSegundos);
        }

        [Fact]
        public void ToString_DebeRetornarFormatoCorrecto()
        {
            // Arrange
            var cancion = new Cancion("Bohemian Rhapsody", "Queen", 354);

            // Act
            string resultado = cancion.ToString();

            // Assert
            Assert.Equal("Bohemian Rhapsody - Queen (5:54)", resultado);
        }
    }
}