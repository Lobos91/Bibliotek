using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bibliotek.Models
{
    public class MovieModel
    {
        [Column("Length(min)")]
        public int? Length { get; set; }
        public string Director { get; set; }
    }
}
