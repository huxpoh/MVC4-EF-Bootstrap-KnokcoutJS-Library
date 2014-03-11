using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Model.Model
{
    public class BaseEntity
    {
        [Key]
        public Guid Guid { set; get; }
    }
}
