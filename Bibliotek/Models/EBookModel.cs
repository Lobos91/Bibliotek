using System.ComponentModel.DataAnnotations;

namespace Bibliotek.Models
{
    public class EBookModel
    {
        public string Author { get; set; }
        public int? Pages { get; set; }
    }
}
