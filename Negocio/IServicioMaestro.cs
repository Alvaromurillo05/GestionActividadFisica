using Entidades;

namespace Negocio
{
    public interface IServicioMaestro
    {
        List<Ciudad> ObtenerCiudades();
        List<TipoDocumento> ObtenerTiposDocumento();
    }
}
