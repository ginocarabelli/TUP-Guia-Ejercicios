using System.ComponentModel.DataAnnotations;

namespace EFWebApi.Models
{
    public class Rol
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Nombre { get; set; }

        public ICollection<Usuario> Usuarios = new List<Usuario>();
    }
}
