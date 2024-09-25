using System.ComponentModel.DataAnnotations.Schema;

namespace Modelos
{
    [Table("Sexos")]
    public class Sexo
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public virtual ICollection<Persona> Personas { get; set; }
    }
}