using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library.Model.Model;

namespace Library.EfDataLayer
{
    public class LibraryContext : DbContext
    {
        public LibraryContext()
            : base("DefaultConnection")
        {
            
        }

        public DbSet<Book> Books { get; set; }
        public DbSet<BookShelf> BookShelfs { get; set; }
        public DbSet<Storage> Storages { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<User> Users { get; set; }
    }
}
