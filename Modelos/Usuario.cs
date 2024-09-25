using System.ComponentModel.DataAnnotations.Schema;

namespace Modelos
{
    [Table("Usuarios")]
    public class Usuario
    {
        public int Id { get; set; }
        public string NombreUsuario { get; set; }
        public string Clave { get; set; }
        public int IdPersona { get; set; }
        public virtual Persona Persona { get; set; }
    }
}
