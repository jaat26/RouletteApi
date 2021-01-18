using System.ComponentModel.DataAnnotations;

namespace RouletteApi.Data.Entities
{
    public class Bet
    {
        public int Id { get; set; }
        [Range(0, 36, ErrorMessage = "Error solo se aceptan números entre 0 y 36.")]
        public int Number { get; set; }
        [Required]
        public string Colour { get; set; }
        [Range(1.00, 10000.00, ErrorMessage = "Valor apostado debe ser entre 1 y 10000.")]
        public double Money { get; set; }
        [Required]
        public string UserId { get; set; }
        [Required]
        public string RouletteId { get; set; }
    }
}
