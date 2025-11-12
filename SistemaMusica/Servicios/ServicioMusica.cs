// ============================================
// SERVICIOS
// ============================================

using SistemaMusica.Modelos;
using SistemaMusica.Gestores;

namespace SistemaMusica.Servicios
{
    // Clase ServicioMusica - Coordina el sistema completo
    public class ServicioMusica
    {
        // Gestor de canciones (catálogo)
        public GestorCanciones Gestor { get; private set; }

        // Lista de usuarios registrados
        public List<Usuario> Usuarios { get; private set; }

        // Constructor
        public ServicioMusica()
        {
            Gestor = new GestorCanciones();
            Usuarios = new List<Usuario>();
        }

        // Registrar nuevo usuario
        public void RegistrarUsuario(string nombre)
        {
            // Crear usuario y agregarlo a la lista
            Usuario nuevoUsuario = new Usuario(nombre);
            Usuarios.Add(nuevoUsuario);

            Console.WriteLine($"Usuario '{nombre}' registrado exitosamente.");
        }

        // Buscar usuario por nombre (case-insensitive)
        public Usuario BuscarUsuario(string nombre)
        {
            foreach (var usuario in Usuarios)
            {
                if (usuario.Nombre.Equals(nombre, StringComparison.OrdinalIgnoreCase))
                {
                    return usuario;
                }
            }

            return null; // Usuario no encontrado
        }
    }
}