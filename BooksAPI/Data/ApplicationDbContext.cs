using Microsoft.EntityFrameworkCore;
using BooksAPI.Models; // Namespace updated for BooksAPI project

namespace BooksAPI.Data // Namespace updated for BooksAPI project
{
    public class ApplicationDbContext : DbContext
    {
        // Constructor to pass DbContextOptions to the base class.
        // This allows configuration (like connection string) to be passed from Program.cs.
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        // DbSet for your BookModel, which will map to the tbl_books table in the database.
        public DbSet<BookModel> Books { get; set; }

        // This method is used to configure the model that is being created.
        // We use it here to explicitly set the table name to "tbl_books".
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configure the BookModel to map to the "tbl_books" table.
            modelBuilder.Entity<BookModel>().ToTable("tbl_books");
        }
    }
}
