using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Library.WebPr.ViewModels;
using WebApp.ViewModels;

namespace Library.Web.ViewModels
{
    public class StorageViewModel : BaseViewModel
    {
        public string Name { set; get; }

        public int Number { set; get; }
    }
}