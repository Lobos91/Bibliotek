
using Bibliotek.Models;
using Microsoft.EntityFrameworkCore;

namespace Bibliotek.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<ReleaseModel> Releases { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<EBook> EBooks { get; set; }
        public DbSet<Movie> Movies { get; set; }    

        //public DbSet<UserModel> Users { get; set; }
        //public DbSet<BookModel> Books { get; set; }
        //public DbSet<EBookModel> Ebooks { get; set; }
        //public DbSet<MovieModel> Movies { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BookModel>().HasData(new BookModel
            {
                ID = 1,
                Author = "David Willcock",
                Tittle = "Secret of the universe",
                Genre = "Document",
                Pages = 437,
                Lent = false,
            });

            modelBuilder.Entity<BookModel>().HasData(new BookModel
            {
                ID = 2,
                Author = "Mariam Jasmin",
                Tittle = "Cool book",
                Genre = "Poetry",
                Pages = 301,
                Lent = false,
            });

            modelBuilder.Entity<BookModel>().HasData(new BookModel
            {
                ID = 3,
                Author = "Arnold S.",
                Tittle = "Training techniques",
                Genre = "Manual",
                Pages = 301,
                Lent = true,
                LoanDateTimeStart = new DateTime(2022, 05, 10, 12, 0, 0),
                LoanDateTimeEnd = new DateTime(2022, 05, 25, 0, 0, 0),
            });

            modelBuilder.Entity<MovieModel>().HasData(new MovieModel
            {
                ID = 4,
                Director = "Wachowsky brothers",
                Tittle = "Matrix",
                Genre = "Document",
                Length = 94,
                Lent = false,
            });

            modelBuilder.Entity<MovieModel>().HasData(new MovieModel
            {
                ID = 5,
                Director = "Wachowsky brothers",
                Tittle = "Cloud Atlas",
                Genre = "SF",
                Length = 142,
                Lent = true,
                LoanDateTimeStart = new DateTime(2022, 05, 09, 10, 0, 0),
                LoanDateTimeEnd = new DateTime(2022, 05, 22, 0, 0, 0),
            });

            modelBuilder.Entity<EBookModel>().HasData(new EBookModel
            {
                ID = 6,
                Author = "Tom Hardy",
                Tittle = "C# for begginers",
                Genre = "Manual",
                Pages = 264,
                Lent = false,
            });

        }


    }
}
