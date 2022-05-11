using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bibliotek.Models
{
    public class MovieModel
    {
        public int ID { get; set; }
        public string Tittle { get; set; }
        public string? Genre { get; set; }
        [Column("Length(min)")]
        public int? Length { get; set; }
        public string Director { get; set; }
        public bool Lent { get; set; }
        [DisplayFormat(ApplyFormatInEditMode = true)]
        public DateTime? LoanDateTimeStart { get; set; }
        [DisplayFormat(ApplyFormatInEditMode = true)]
        public DateTime? LoanDateTimeEnd { get; set; }
    }
}
