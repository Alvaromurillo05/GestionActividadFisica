using Entidades;

namespace Repositorio
{
    public class RepositorioEvaluacionEF : IRepositorioEvaluacion
    {
        private Modelos.DBGestionActividadFisica dbGestionActividadFisica;

        public RepositorioEvaluacionEF()
        {
            dbGestionActividadFisica = new Modelos.DBGestionActividadFisica();
        }

        public void GuadarEvaluacion(Evaluacion evaluacion)
        {
            var personaActual = dbGestionActividadFisica.Personas.FirstOrDefault(p => p.IdTipoDocumento == evaluacion.Persona.TipoDocumento.Id &&
            p.NumeroDocumento == evaluacion.Persona.NumeroDocumento);

            int idPersona = 0;
            if(personaActual != null)
            {
                personaActual.PrimerNombre = evaluacion.Persona.PrimerNombre;
                personaActual.SegundoNombre = evaluacion.Persona.SegundoNombre;
                personaActual.PrimerApellido = evaluacion.Persona.PrimerApellido;
                personaActual.SegundoApellido = evaluacion.Persona.SegundoApellido;
                personaActual.FechaNacimiento = evaluacion.Persona.FechaNacimiento;
                personaActual.IdSexo = evaluacion.Persona.Sexo.Id;
                idPersona = personaActual.Id;

                dbGestionActividadFisica.SaveChanges();
            }
            else
            {
                var personaIngresar = new Modelos.Persona()
                {
                    PrimerNombre = evaluacion.Persona.PrimerNombre,
                    SegundoNombre = evaluacion.Persona.SegundoNombre,
                    PrimerApellido = evaluacion.Persona.PrimerApellido,
                    SegundoApellido = evaluacion.Persona.SegundoApellido,
                    FechaNacimiento = evaluacion.Persona.FechaNacimiento,
                    IdSexo = evaluacion.Persona.Sexo.Id,
                    IdTipoDocumento = evaluacion.Persona.TipoDocumento.Id,
                    NumeroDocumento = evaluacion.Persona.NumeroDocumento,
                };
                dbGestionActividadFisica.Personas.Add(personaIngresar);
                dbGestionActividadFisica.SaveChanges();

                idPersona = personaIngresar.Id;
            }

            var evaluacionIngresar = new Modelos.Evaluacion()
            {
                IdPersona = idPersona,
                Fecha = evaluacion.Fecha,
                IdCiudad = evaluacion.Ciudad.Id,
                IdRegimenAfiliacion = evaluacion.RegimenAfiliacion.Id,
                AntecendenteCancer = evaluacion.AntecendenteCancer,
                AntecendenteDiabetes = evaluacion.AntecendenteDiabetes,
                Peso = evaluacion.Peso,
                Talla = evaluacion.Talla,
                PresionSistolica = evaluacion.PresionSistolica,
                PresionDiastolica = evaluacion.PresionDiastolica,
                PliegueTriceps = evaluacion.PliegueTriceps,
                Biceps = evaluacion.Biceps,
                PliegueSubescapular = evaluacion.PliegueSubescapular,
                PliegueCrestaIliaca = evaluacion.PliegueCrestaIliaca,
                PliegueSuparespinal = evaluacion.PliegueSuparespinal,
                PliegueAbdominal = evaluacion.PliegueAbdominal,
                PliegueMuslo = evaluacion.PliegueMuslo,
                PlieguePierna = evaluacion.PlieguePierna,
                PerimetroCintura = evaluacion.PerimetroCintura,
                PerimetroCadera = evaluacion.PerimetroCadera,
                PerimetroPierna = evaluacion.PerimetroPierna,
                PerimetroCodo = evaluacion.PerimetroCodo,
                BrazoDescansado = evaluacion.BrazoDescansado,
                BrazoTenso = evaluacion.BrazoTenso,
                DiametroRodilla = evaluacion.DiametroRodilla
            };

            dbGestionActividadFisica.Evaluaciones.Add(evaluacionIngresar);
            dbGestionActividadFisica.SaveChanges();

        }
    }
}
