using System.ComponentModel.DataAnnotations;

namespace Veterinaria.Models
{
    public class Mascota
    {
        public int Id { get; set; }

        [Required]
        public string Nombre { get; set; }

        public int Edad { get; set; }

        public string Raza { get; set; }

        public string Genero { get; set; }

        public string Especie { get; set; }

        public string Color { get; set; } // <-- agregado
    }
}
