using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Library.Model.Models
{
    public class Book: BaseEntity
    {
        public string Name { set; get; }

        public string Author { set; get; }

        public DateTime PublishDate { set; get; }

        public BookShelf BookShelf { set; get; }

        public User Reader { set; get; }
    }
}
