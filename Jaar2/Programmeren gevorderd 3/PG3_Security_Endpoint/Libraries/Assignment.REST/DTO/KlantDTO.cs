using System.ComponentModel.DataAnnotations;

namespace Assignment.REST.DTO
{
    public class KlantDTO
    {
        [Required]
        public int KlantId { get; set; }

        [Required]
        public string Naam { get; set; } = null!;

        public string Adres { get; set; } = null!;

        public string Telefoon { get; set; } = null!;

        [Required]
        public string Email { get; set; } = null!;
    }
}