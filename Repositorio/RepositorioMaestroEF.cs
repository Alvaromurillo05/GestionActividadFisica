using Entidades;

namespace Repositorio
{
    public class RepositorioMaestroEF : IRepositorioMaestro
    {
        private Modelos.DBGestionActividadFisica dbGestionActividadFisica;

        public RepositorioMaestroEF()
        {
            dbGestionActividadFisica = new Modelos.DBGestionActividadFisica();
        }

        public List<Ciudad> ObtenerCiudades()
        {
            var ciudades = dbGestionActividadFisica.Ciudades
                .Select(c => new Ciudad() { Id = c.Id, Nombre = c.Nombre })
                .OrderBy(c => c.Nombre)
                .ToList();

            return ciudades;
        }

        public List<TipoDocumento> ObtenerTiposDocumento()
        {
            var tiposDocumento = dbGestionActividadFisica.TiposDocumentos
                .Select(c => new TipoDocumento() { Id = c.Id, Nombre = c.Nombre })
                .OrderBy(c => c.Nombre)
                .ToList();

            return tiposDocumento;
        }
    }
}
