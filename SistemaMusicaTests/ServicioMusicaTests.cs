using SistemaMusica.Servicios;

namespace SistemaMusicaTests
{
    public class ServicioMusicaTests
    {
        [Fact]
        public void RegistrarUsuario_DebeAgregarNuevoUsuario()
        {
            // Arrange
            var servicio = new ServicioMusica();

            // Act
            servicio.RegistrarUsuario("Juan");

            // Assert
            Assert.Single(servicio.Usuarios);
            Assert.Equal("Juan", servicio.Usuarios[0].Nombre);
        }

        [Fact]
        public void BuscarUsuario_DebeRetornarUsuarioExistente()
        {
            // Arrange
            var servicio = new ServicioMusica();
            servicio.RegistrarUsuario("Carlos");

            // Act
            var resultado = servicio.BuscarUsuario("CARLOS"); // Mayúsculas

            // Assert
            Assert.NotNull(resultado);
            Assert.Equal("Carlos", resultado.Nombre);
            Assert.Null(servicio.BuscarUsuario("No existente"));
        }
    }
}