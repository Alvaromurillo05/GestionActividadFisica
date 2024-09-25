using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;

namespace Modelos
{
    [Table("RegimenAfiliaciones")]
    public class RegimenAfiliacion
    {
       
        public int Id { get; set; }
        public string Nombre { get; set; }
        public virtual ICollection<Persona> Personas { get; set; }
    }
}