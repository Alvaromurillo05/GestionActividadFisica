using Entidades;
using Repositorio;

namespace Negocio
{
    public class ServicioEvaluacion : IServicioEvaluacion
    {
        private IRepositorioEvaluacion repositorio;

        public ServicioEvaluacion(RepositorioEvaluacion repositorio)
        {
            this.repositorio = repositorio;
        }

        public ServicioEvaluacion()
        {
            repositorio = new RepositorioEvaluacionEF();
        }

        public void GuardarEvaluacion(Evaluacion evaluacion)
        {
            repositorio.GuadarEvaluacion(evaluacion);
        }
    }
}
