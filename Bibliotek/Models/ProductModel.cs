using System.ComponentModel.DataAnnotations;

namespace Bibliotek.Models
{
    public class ProductModel
    {
        public bool Lent { get; set; }

        [DisplayFormat(ApplyFormatInEditMode = true)]
        public DateTime? LoanDateTimeStart { get; set; }
        [DisplayFormat(ApplyFormatInEditMode = true)]
        public DateTime? LoanDateTimeEnd { get; set; }

        public class Book : ProductModel
        {
            public string Author { get; set; }
            public int? Pages { get; set; }
        }

        public class EBook : ProductModel
        {
            public string Author { get; set; }
            public int? Pages { get; set; }
            public string Type { get; set; } // PDF, EPUB, MOBI, IBA etc
        }

        public class Movie : ProductModel
        {
            public int? Length { get; set; }
            public string Director { get; set; }
        }
    }
}
