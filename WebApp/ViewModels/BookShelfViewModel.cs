using System;
using Library.Web.ViewModels;

namespace Library.WebPr.ViewModels
{
    public class BookShelfViewModel : BaseViewModel
    {
        public int Number { set; get; }

        public Guid StorageId { set; get; }
    }
}