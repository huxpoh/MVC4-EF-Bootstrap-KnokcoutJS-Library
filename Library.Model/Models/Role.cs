using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;

namespace Library.Model.Models
{
    public class Role
    {
        public Role()
        {
            Users = new Collection<User>();
        }

        [Key]
        public Guid RoleId { get; set; }

        [Required]
        public string RoleName { get; set; }

        public string Description { get; set; }

        public ICollection<User> Users { get; set; }
    }
}
