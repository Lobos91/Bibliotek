using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bibliotek.Models
{
    public class MovieModel : ProductModel
    {
        [Column("Length(min)", Order = 5)]
        public int? Length { get; set; }
        [Column(Order = 6)]
        public string? Director { get; set; }
    }
}
