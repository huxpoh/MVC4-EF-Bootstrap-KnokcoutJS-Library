﻿using System;

namespace Library.WebPr.ViewModels
{


    public class BookViewModel : BaseViewModel
    {
        public String Name { set; get; }

        public string Author { set; get; }

        public string PublishDate { set; get; }

        public Guid BookShelfId { set; get; }
    }

    public class BaseViewModel
    {
        public Guid Id { set; get; }
    }
}