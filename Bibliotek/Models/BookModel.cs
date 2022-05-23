﻿using System.ComponentModel.DataAnnotations;

namespace Bibliotek.Models
{
    public class BookModel : ProductModel
    {
        public int Id { get; set; } 
        public string Author { get; set; }
        public int? Pages { get; set; }

    }
}
