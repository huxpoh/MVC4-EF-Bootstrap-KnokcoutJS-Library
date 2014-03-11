using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Model.Model
{
    public class BookShelf : BaseEntity
    {
        public int Number { set; get; }

        public virtual List<Book> Books { set; get; } 
    }
}
