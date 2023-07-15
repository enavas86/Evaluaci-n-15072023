using System.ComponentModel.DataAnnotations;

namespace webAppClientes.Models
{
    public class ClienteModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage="El campo es obligatorio")]
        public string? PrimerNombre { get; set; }

        [Required(ErrorMessage = "El campo es obligatorio")]
        public string? PrimerApellido { get; set;}

        [Required(ErrorMessage = "El campo es obligatorio")]
        public int Edad { get; set; }

        public DateTime FechaCreacion { get; set; }
    }
}
