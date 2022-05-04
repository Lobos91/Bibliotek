
using Bibliotek.Models;
using Microsoft.EntityFrameworkCore;

namespace Bibliotek.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<UserModel> Users { get; set; }
        public DbSet<BookModel> Books { get; set; }

    }
}
