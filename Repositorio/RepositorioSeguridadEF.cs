using Entidades;

namespace Repositorio
{
    public class RepositorioSeguridadEF : IRepositorioSeguridad
    {
        private Modelos.DBGestionActividadFisica dbGestionActividadFisica;

        public RepositorioSeguridadEF()
        {
            dbGestionActividadFisica = new Modelos.DBGestionActividadFisica();
        }

        public Usuario ObtenerUsuario(string nombreUsuario)
        {
            var usuarioActual = dbGestionActividadFisica.Usuarios.FirstOrDefault(u=>u.NombreUsuario == nombreUsuario);

            if (usuarioActual != null)
            {
                return new Usuario() { NombreUsuario = usuarioActual.NombreUsuario, Clave = usuarioActual.Clave };
            }

            return null;
        }
    }
}
