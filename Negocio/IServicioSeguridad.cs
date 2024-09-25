using Entidades;

namespace Negocio
{
    public interface IServicioSeguridad
    {
        public bool ValidarUsuario(Usuario usuario);
    }
}