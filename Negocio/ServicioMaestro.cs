using Entidades;
using Repositorio;

namespace Negocio
{
    public class ServicioMaestro : IServicioMaestro
    {
        private IRepositorioMaestro repositorio;

        public ServicioMaestro(RepositorioMaestro repositorio)
        {
            this.repositorio = repositorio;
        }

        public ServicioMaestro()
        {
            repositorio = new RepositorioMaestroEF();
        }

        public List<Ciudad> ObtenerCiudades()
        => repositorio.ObtenerCiudades();

        public List<TipoDocumento> ObtenerTiposDocumento()
        => repositorio.ObtenerTiposDocumento();
    }
}
