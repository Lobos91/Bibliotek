
using System.ComponentModel.DataAnnotations.Schema;

namespace Bibliotek.Models
{
    public class ReleaseModel
    {
        public int Id { get; set; }
        public string Author { get; set; }
        public string Title { get; set; }
        public string Genre { get; set; }
        public int? Pages { get; set; }

        [ForeignKey(nameof(Product))]
        public int ProductId { get; set; }
        public ProductModel Product { get; set; }

    }
}
