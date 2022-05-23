using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bibliotek.Models
{
    public class EBookModel : ProductModel 
    {
        [Column("Size(Mb)", Order = 4)]
       
        public double? DataSize { get; set; }
    }
}
