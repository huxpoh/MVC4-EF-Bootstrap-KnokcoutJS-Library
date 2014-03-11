using System;
using System.ComponentModel.DataAnnotations;

namespace Library.Model.Models
{
    public class BaseEntity
    {
        [Key]
        public Guid Id { set; get; }
    }
}
