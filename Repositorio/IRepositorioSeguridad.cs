using Entidades;

namespace Repositorio
{
    public interface IRepositorioSeguridad
    {
        public Usuario ObtenerUsuario(string nombreUsuario);
    }
}