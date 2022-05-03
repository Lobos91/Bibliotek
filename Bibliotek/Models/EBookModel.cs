using System.ComponentModel.DataAnnotations;

namespace Bibliotek.Models
{
    public class EBookModel
    {
        public int ID { get; set; }
        public string Tittle { get; set; }
        public string Genre { get; set; }
        public string Author { get; set; }
        public bool Lent { get; set; }
        [DisplayFormat(ApplyFormatInEditMode = true)]
        public DateTime? LoanDateTimeStart { get; set; }
        [DisplayFormat(ApplyFormatInEditMode = true)]
        public DateTime? LoanDateTimeEnd { get; set; }
    }
}
