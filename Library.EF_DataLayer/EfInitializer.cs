using System;
using System.Data.Entity;
using System.Web.Helpers;
using Library.Model.Models;

namespace Library.EF_DataLayer
{
    public class EfInitializer : DropCreateDatabaseAlways<LibraryContext>
    {
        protected override void Seed(LibraryContext context)
        {
            var newUser = new User
            {
                Id = Guid.NewGuid(),
                Username = "librarian",
                Password = Crypto.HashPassword("1234567"),
                IsApproved = true,
                Email = "huxpoh@gmail.com",
                CreateDate = DateTime.UtcNow,
                LastPasswordChangedDate = DateTime.UtcNow,
                PasswordFailuresSinceLastSuccess = 0,
                LastLoginDate = DateTime.UtcNow,
                LastActivityDate = DateTime.UtcNow,
                LastLockoutDate = DateTime.UtcNow,
                IsLockedOut = false,
                LastPasswordFailureDate = DateTime.UtcNow
            };

            var newAdmin = new User
            {
                Id = Guid.NewGuid(),
                Username = "reader",
                Password = Crypto.HashPassword("1234567"),
                IsApproved = true,
                Email = "huxpoh2@gmail.com",
                CreateDate = DateTime.UtcNow,
                LastPasswordChangedDate = DateTime.UtcNow,
                PasswordFailuresSinceLastSuccess = 0,
                LastLoginDate = DateTime.UtcNow,
                LastActivityDate = DateTime.UtcNow,
                LastLockoutDate = DateTime.UtcNow,
                IsLockedOut = false,
                LastPasswordFailureDate = DateTime.UtcNow
            };

            context.Users.Add(newUser);
            context.Users.Add(newAdmin);

            var role1 = new Role()
            {
                RoleId = Guid.NewGuid(),
                Description = "Simple user role",
                RoleName = "reader"
            };
            var role2 = new Role()
            {
                RoleId = Guid.NewGuid(),
                Description = "Admin user role",
                RoleName = "admin"
            };
            var role3 = new Role()
            {
                RoleId = Guid.NewGuid(),
                Description = "Librarian user role",
                RoleName = "librarian"
            };

            context.Roles.Add(role1);
            context.Roles.Add(role2);
            context.Roles.Add(role3);

            role1.Users.Add(newAdmin);
            role3.Users.Add(newUser);
            context.SaveChanges();

            base.Seed(context);
        }
    }
}
