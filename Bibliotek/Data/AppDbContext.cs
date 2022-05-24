
using Bibliotek.Models;
using Microsoft.EntityFrameworkCore;

namespace Bibliotek.Data
{
    public class AppDbContext : DbContext
    {
     
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
       
        public DbSet<ProductModel> Products { get; set; }
        public DbSet<EBookModel> Ebooks { get; set; }
        public DbSet<MovieModel> Movies { get; set; }
        public DbSet<BookModel> Books { get; set; }
        public DbSet<ReleaseModel> Releases { get; set; }
        public DbSet<UserModel> Users { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ProductModel>()
            .HasOne(p => p.User)
            .WithMany(b => b.Products);

            modelBuilder.Entity<ProductModel>()
           .HasOne(p => p.Release)
           .WithMany(b => b.Products);

            modelBuilder.Entity<ProductModel>()
            .HasDiscriminator(b => b.Type)
             .HasValue<BookModel>("Book")
             .HasValue<EBookModel>("Ebook")
             .HasValue<MovieModel>("Movie");

            /*
            Note to myself:
            Data seeding must occur in right order. Before seeding product table with users, UserTable must be poppulated.
            Then even properties must be in right order. If the UserId is the last in product table, property UserId must 
            take place last in modelBuilder.
             */

            //---------- USERS
            modelBuilder.Entity<UserModel>().HasData(new UserModel
            {
                Id = 1,
                UserName = "Marius Ohlsson",
                Role = Role.User,
            });
            modelBuilder.Entity<UserModel>().HasData(new UserModel
            {
                Id = 2,
                UserName = "Jesus Christus",
                Role = Role.User,
            });
            modelBuilder.Entity<UserModel>().HasData(new UserModel
            {
                Id = 3,
                UserName = "Sasha Grey",
                Role = Role.User,
            });

            //---------- RELEASES
            modelBuilder.Entity<ReleaseModel>().HasData(new ReleaseModel
            {
                Id = 1,
                Title = "Harry Potter",
                Author = "J. K. Rowling",
                Genre = "Fantasy",
                Pages = 503,
                
            });
            modelBuilder.Entity<ReleaseModel>().HasData(new ReleaseModel
            {
                Id = 2,
                Title = "Harry Potter 2.0",
                Author = "J. K. Rowling",
                Genre = "Fantasy",
                Pages = 582,
            });
            modelBuilder.Entity<ReleaseModel>().HasData(new ReleaseModel
            {
                Id = 3,
                Title = "C# for noobs",
                Author = "Albin Svensson",
                Genre = "Course",
                Pages = 900,
            });
            modelBuilder.Entity<ReleaseModel>().HasData(new ReleaseModel
            {
                Id = 4,
                Title = "C# for noobs extended",
                Author = "Albin Svensson",
                Genre = "Course",
                Pages = 1402,
            });
            modelBuilder.Entity<ReleaseModel>().HasData(new ReleaseModel
            {
                Id = 5,
                Title = "Matrix",
                Author = "Wachowsky brothers",
                Genre = "SF"
            });

            // PRODUCTS
            //---------- BOOKS
            modelBuilder.Entity<BookModel>().HasData(new BookModel
            {
                Id = 1,
                Lent = false,
                Type = "Book",
                ReleaseId = 1,
                BookFormat = "A2"
            });
            modelBuilder.Entity<BookModel>().HasData(new BookModel
            {
                Id = 2,
                Lent = true,
                Type = "Book",
                ReleaseId = 1,
                BookFormat = "A2",
                LoanDateTimeStart = new DateTime(2022, 05, 23, 10, 0, 0),
                LoanDateTimeEnd = new DateTime(2022, 05, 30, 10, 0, 0),
                UserId = 1

            });
            modelBuilder.Entity<BookModel>().HasData(new BookModel
            {
                Id = 3,
                Lent = false,
                Type = "Book",
                ReleaseId = 2,
                BookFormat = "A2"
            });
            //---------- EBOOKS
            modelBuilder.Entity<EBookModel>().HasData(new EBookModel
            {
                Id = 4,
                Lent = false,
                Type = "Ebook",
                ReleaseId = 3,
                DataSize = 0.6
             
            });
            modelBuilder.Entity<EBookModel>().HasData(new EBookModel
            {
                Id = 5,
                Lent = true,
                Type = "Ebook",
                ReleaseId = 3,
                DataSize = 2.3,
                LoanDateTimeStart = new DateTime(2022, 05, 15, 12, 0, 0),
                LoanDateTimeEnd = new DateTime(2022, 05, 25, 12, 0, 0),
                UserId = 1,
            });
            modelBuilder.Entity<EBookModel>().HasData(new EBookModel
            {
                Id = 6,
                Lent = true,
                Type = "Ebook",
                DataSize = 1.2,
                ReleaseId = 4,
                LoanDateTimeStart = new DateTime(2022, 05, 21, 9, 0, 0),
                LoanDateTimeEnd = new DateTime(2022, 05, 29, 9, 0, 0),
                UserId = 2,
            });
            //---------- MOVIES
            modelBuilder.Entity<MovieModel>().HasData(new MovieModel
            {
                Id = 7,
                Lent = false,
                Type = "Movie",
                ReleaseId = 5,
                Director = "Wachowsky brothers",
                Length = 94,
              
            });
            modelBuilder.Entity<MovieModel>().HasData(new MovieModel
            {
                Id = 8,
                Type = "Movie",
                ReleaseId = 5,
                Director = "Wachowsky brothers",
                Lent = false,
                Length = 94,

              

            });
            modelBuilder.Entity<MovieModel>().HasData(new MovieModel
            {
                Id = 9,
                Type = "Movie",
                ReleaseId = 5,
                Lent = true,
                LoanDateTimeStart = new DateTime(2022, 05, 24, 15, 0, 0),
                LoanDateTimeEnd = new DateTime(2022, 05, 29, 15, 0, 0),
                Director = "Wachowsky brothers",
                Length = 94,
                UserId = 3,

            });

         
           


        }
    }
}
