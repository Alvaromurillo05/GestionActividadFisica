using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Modelos
{
    [Table("Ciudades")]
    public class Ciudad
    {
        [Key]
        public int Id { get; set; }
        public string Nombre { get; set; }

        public virtual ICollection<Evaluacion> Evaluaciones { get; set; }
    }
}