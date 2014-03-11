using System.Collections.Generic;

namespace Library.Model.Model
{
    public class Storage : BaseEntity
    {
        public int StorageNumber { set; get; }

        public virtual List<BookShelf> BookShelves { set; get; }
    }
}
