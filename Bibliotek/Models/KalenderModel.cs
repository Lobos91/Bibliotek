using System.ComponentModel.DataAnnotations;

namespace Bibliotek.Models
{
    public class KalenderModel
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        [Required]
        public string? Headline { get; set; }
        [Required]
        public string? Message { get; set; }
    }
}
