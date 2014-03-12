using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.EF_DataLayer
{
    public class UnitOfWork
    {
        public LibraryContext _libraryContext;

        public UnitOfWork()
        {
            
        }

        public UnitOfWork(LibraryContext libraryContext)
        {
            _libraryContext = libraryContext;
        }

        public void SaveChanges()
        {
            _libraryContext.SaveChanges();
        }
    }
}
