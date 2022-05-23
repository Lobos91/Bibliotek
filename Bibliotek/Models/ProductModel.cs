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

    }
}
