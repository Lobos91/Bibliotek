using System.ComponentModel.DataAnnotations;

namespace Bibliotek.Models
{
    public class ReleaseModel
    {
        public int ID { get; set; } 
        public string? Title { get; set; }
        public string Genre { get; set; }   

        [DisplayFormat(ApplyFormatInEditMode = true)]
        public DateTime? LoanDateTimeStart { get; set; }
        [DisplayFormat(ApplyFormatInEditMode = true)]
        public DateTime? LoanDateTimeEnd { get; set; }
    }
}
