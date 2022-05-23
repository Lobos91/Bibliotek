using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bibliotek.Models
{
    public class MovieModel : ProductModel
    {
        [Column("Length(min)", Order = 6)]
        public int? Length { get; set; }
        [Column(Order = 7)]
        public string? Director { get; set; }
    }
}
