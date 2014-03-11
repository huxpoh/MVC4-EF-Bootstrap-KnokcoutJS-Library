using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Model.Models
{
    public class Storage : BaseEntity
    {
        public Storage()
        {
            BookShelves = new List<BookShelf>();
        }

        public int StrorageNumber { set; get; }

        public string StorageName { set; get; }

        public virtual List<BookShelf> BookShelves { set; get; } 
    }
}
