using System;

namespace Library.Spa.ViewModels
{
    public class BookViewModel : BaseViewModel
    {
        public String Name { set; get; }

        public string Author { set; get; }

        public DateTime PublishDate { set; get; }
    }

    public class BaseViewModel
    {
        public Guid Id { set; get; }
    }
}