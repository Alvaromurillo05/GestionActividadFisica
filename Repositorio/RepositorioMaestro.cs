using Entidades;

namespace Repositorio
{
    public class RepositorioMaestro : IRepositorioMaestro
    {
        public List<Ciudad> ObtenerCiudades()
        {
            var ciudades = new List<Ciudad>();
            ciudades.Add(new Ciudad() { Id = 1, Nombre = "Medellín" });
            ciudades.Add(new Ciudad() { Id = 2, Nombre = "Bello" });
            ciudades.Add(new Ciudad() { Id = 3, Nombre = "Sabaneta" });

            return ciudades;
        }

        public List<TipoDocumento> ObtenerTiposDocumento()
        {
            var tiposDocumento = new List<TipoDocumento>();

            tiposDocumento.Add(new TipoDocumento() { Id = 1, Nombre = "Cédula de Ciudadanía" });
            tiposDocumento.Add(new TipoDocumento() { Id = 2, Nombre = "Cédula de Extranjería" });
            tiposDocumento.Add(new TipoDocumento() { Id = 3, Nombre = "Tarjeta de Identidad" });

            return tiposDocumento;
        }
    }
}
