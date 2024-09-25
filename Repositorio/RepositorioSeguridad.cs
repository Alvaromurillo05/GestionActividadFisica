using Entidades;

namespace Repositorio
{
    public class RepositorioSeguridad : IRepositorioSeguridad
    {
        public Usuario ObtenerUsuario(string nombreUsuario)
        {
            return new Usuario() { Clave = "123", NombreUsuario = nombreUsuario };
        }
    }
}
