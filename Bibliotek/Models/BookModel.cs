using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bibliotek.Models
{
    public class BookModel : ProductModel
    {
        [Column(Order = 4)]  public string? BookFormat { get; set; }  //A2 / A3 / A4 etc

    }
}
