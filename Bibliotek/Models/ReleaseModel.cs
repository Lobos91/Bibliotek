using System.ComponentModel.DataAnnotations;

namespace Bibliotek.Models
{
    public class ReleaseModel
    {
        public int ID { get; set; } 
        public string? Title { get; set; }
        public string Genre { get; set; }   
        public bool Lent { get; set; }

        [DisplayFormat(ApplyFormatInEditMode = true)]
        public DateTime? LoanDateTimeStart { get; set; }
        [DisplayFormat(ApplyFormatInEditMode = true)]
        public DateTime? LoanDateTimeEnd { get; set; }
    }

    public class Book : ReleaseModel
    {
        public string Author { get; set; }
        public int? Pages { get; set; }
    }

    public class EBook : ReleaseModel
    {
        public string Author { get; set; }
        public int? Pages { get; set; }
        public string Type { get; set; } // PDF, EPUB, MOBI, IBA etc
    }

    public class Movie : ReleaseModel
    {
        public int? Length { get; set; }
        public string Director { get; set; }
    }
}
