using Entidades;

namespace Repositorio
{
    public interface IRepositorioMaestro
    {
        List<Ciudad> ObtenerCiudades();
        List<TipoDocumento> ObtenerTiposDocumento();
    }
}
