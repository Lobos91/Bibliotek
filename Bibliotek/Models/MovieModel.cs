using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bibliotek.Models
{
    public class MovieModel : ProductModel
    {
        public int Id { get; set; }
        [Column("Length(min)")]
        public int? Length { get; set; }
        public string Director { get; set; }
    }
}
