using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bibliotek.Models
{
    public class EBookModel : ProductModel 
    {
        [Column("Size(Mb)", Order = 5)]
       
        public double? DataSize { get; set; }
    }
}
