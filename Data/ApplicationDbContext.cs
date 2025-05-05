using Microsoft.EntityFrameworkCore;
using BookManagementAPI.Models;
using BookManagementAPI.Models.Entities;


namespace BookManagementAPI.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options) { }

        public DbSet<Author> Authors { get; set; }
        public DbSet<Book> Books { get; set; }
    }
}
