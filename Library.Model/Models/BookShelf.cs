using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Model.Models
{
    public class BookShelf : BaseEntity
    {
        public BookShelf()
        {
            Books = new List<Book>();
        }
        public int Number { set; get; }

        public virtual List<Book> Books { set; get; }

        public Storage Storage { set; get; }
    }
}
