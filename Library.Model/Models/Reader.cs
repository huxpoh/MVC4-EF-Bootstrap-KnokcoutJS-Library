using System.Collections.Generic;

namespace Library.Model.Models
{
    public class Reader : BaseEntity
    {
        public string FirstName { set; get; }

        public string LastName { set; get; }

        public virtual List<Book> Books { set; get; }
        
       // public UserProfile User { set; get; }
    }
}
