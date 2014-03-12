using System.Data.Entity;
using Library.Model.Models;

namespace Library.EF_DataLayer
{
    public class LibraryContext : DbContext
    {
        public LibraryContext(): base("DefaultConnection"){}

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Book>().HasOptional(current => current.BookShelf)
                .WithMany(c => c.Books)
                .WillCascadeOnDelete(true);

            modelBuilder.Entity<BookShelf>().HasRequired(current => current.Storage)
                .WithMany(c => c.BookShelves)
                .WillCascadeOnDelete(true);

            modelBuilder.Entity<Book>().HasOptional(current => current.Reader)
                .WithMany(c => c.Books)
                .WillCascadeOnDelete(false);

        }

        public DbSet<Book> Books { get; set; }
        public DbSet<BookShelf> BookShelfs { get; set; }
        public DbSet<Storage> Storages { get; set; }
        public DbSet<UserProfile> UserProfiles { get; set; }

        public DbSet<Role> Roles { get; set; }
        public DbSet<User> Users { get; set; }
    }
}
