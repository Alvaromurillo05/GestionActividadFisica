using System.ComponentModel.DataAnnotations.Schema;

namespace Modelos
{
    [Table("TiposDocumento")]
    public class TipoDocumento
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public virtual ICollection<Persona> Personas { get; set; }
    }
}