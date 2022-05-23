
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
        public DbSet<ReleaseModel> ReleaseModels { get; set; }
        public DbSet<UserModel> Users { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ProductModel>()
            .HasOne(p => p.User)
            .WithMany(b => b.Products);

            modelBuilder.Entity<ReleaseModel>()
           .HasOne(p => p.Product)
           .WithMany(b => b.Releases);

            modelBuilder.Entity<ProductModel>()
            .HasDiscriminator(b => b.Type);
       

            //modelBuilder.Entity<EBookModel>().HasData(new EBookModel
            //{
            //    ID = 6,
            //    Author = "Tom Hardy",
            //    Tittle = "C# for begginers",
            //    Genre = "Manual",
            //    Pages = 264,
            //    Lent = false,
            //});

        }


    }
}
