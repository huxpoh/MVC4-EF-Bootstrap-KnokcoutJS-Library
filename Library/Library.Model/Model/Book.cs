using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Model.Model
{
    public class Book : BaseEntity
    {
        public string Name { set; get; }

        public string Author { set; get; }

        public DateTime PublishDate { set; get; }
    }
}
