using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bibliotek.Models
{
    public class ProductModel
    {
        [Column(Order = 1)] public int Id { get; set; }
        [Column(Order = 2)] public string Type { get; set; }
        public bool Lent { get; set; }

        [DisplayFormat(ApplyFormatInEditMode = true)]
        public DateTime? LoanDateTimeStart { get; set; }
        [DisplayFormat(ApplyFormatInEditMode = true)]
        public DateTime? LoanDateTimeEnd { get; set; }

  
        public List<ReleaseModel> Releases { get; set; }

      
        public int UserId { get; set; }
        public UserModel? User { get; set; }

    }
}
