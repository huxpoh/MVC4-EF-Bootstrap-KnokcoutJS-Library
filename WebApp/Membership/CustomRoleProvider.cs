using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web.Security;
using Library.EF_DataLayer;
using Library.Model.Models;

namespace WebApp.Membership
{
    public class CodeFirstRoleProvider : RoleProvider
    {
        public override string ApplicationName
        {
            get
            {
                return this.GetType().Assembly.GetName().Name.ToString();
            }
            set
            {
                this.ApplicationName = this.GetType().Assembly.GetName().Name.ToString();
            }
        }

        public override bool RoleExists(string roleName)
        {
            if (string.IsNullOrEmpty(roleName))
            {
                return false;
            }
            using (LibraryContext Context = new LibraryContext())
            {
                Role Role = null;
                Role = Context.Roles.FirstOrDefault(Rl => Rl.RoleName == roleName);
                if (Role != null)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public override bool IsUserInRole(string username, string roleName)
        {
            if (string.IsNullOrEmpty(username))
            {
                return false;
            }
            if (string.IsNullOrEmpty(roleName))
            {
                return false;
            }
            using (var context = new LibraryContext())
            {
                var user = context.Users.FirstOrDefault(usr => usr.Username == username);
                if (user == null)
                {
                    return false;
                }
                var role = context.Roles.FirstOrDefault(Rl => Rl.RoleName == roleName);
                if (role == null)
                {
                    return false;
                }
                return user.Roles.Contains(role);
            }
        }

        public override string[] GetAllRoles()
        {
            using (var context = new LibraryContext())
            {
                return context.Roles.Select(Rl => Rl.RoleName).ToArray();
            }
        }

        public override string[] GetUsersInRole(string roleName)
        {
            if (string.IsNullOrEmpty(roleName))
            {
                return null;
            }
            using (var context = new LibraryContext())
            {
                Role role = null;
                role = context.Roles.FirstOrDefault(rl => rl.RoleName == roleName);
                if (role != null)
                {
                    return role.Users.Select(usr => usr.Username).ToArray();
                }
                return null;
            }
        }

        public override string[] GetRolesForUser(string username)
        {
            if (string.IsNullOrEmpty(username))
            {
                return null;
            }
            using (var context = new LibraryContext())
            {
                User user = null;
                user = context.Users.AsQueryable().Include(x=>x.Roles).FirstOrDefault(Usr => Usr.Username == username);
                if (user != null)
                {
                    return user.Roles.Select(Rl => Rl.RoleName).ToArray();
                }
                return null;
            }
        }

        public override string[] FindUsersInRole(string roleName, string usernameToMatch)
        {
            if (string.IsNullOrEmpty(roleName))
            {
                return null;
            }

            if (string.IsNullOrEmpty(usernameToMatch))
            {
                return null;
            }

            using (LibraryContext Context = new LibraryContext())
            {

                return (from Rl in Context.Roles from Usr in Rl.Users where Rl.RoleName == roleName && Usr.Username.Contains(usernameToMatch) select Usr.Username).ToArray();
            }
        }

        public override void CreateRole(string roleName)
        {
            if (!string.IsNullOrEmpty(roleName))
            {
                using (LibraryContext Context = new LibraryContext())
                {
                    Role Role = null;
                    Role = Context.Roles.FirstOrDefault(Rl => Rl.RoleName == roleName);
                    if (Role == null)
                    {
                        Role NewRole = new Role
                        {
                            RoleId = Guid.NewGuid(),
                            RoleName = roleName
                        };
                        Context.Roles.Add(NewRole);
                        Context.SaveChanges();
                    }
                }
            }
        }

        public override bool DeleteRole(string roleName, bool throwOnPopulatedRole)
        {
            if (string.IsNullOrEmpty(roleName))
            {
                return false;
            }
            using (LibraryContext Context = new LibraryContext())
            {
                Role Role = null;
                Role = Context.Roles.FirstOrDefault(Rl => Rl.RoleName == roleName);
                if (Role == null)
                {
                    return false;
                }
                if (throwOnPopulatedRole)
                {
                    if (Role.Users.Any())
                    {
                        return false;
                    }
                }
                else
                {
                    Role.Users.Clear();
                }
                Context.Roles.Remove(Role);
                Context.SaveChanges();
                return true;
            }
        }

        public override void AddUsersToRoles(string[] usernames, string[] roleNames)
        {
            using (LibraryContext Context = new LibraryContext())
            {
                List<User> Users = Context.Users.Where(Usr => usernames.Contains(Usr.Username)).ToList();
                List<Role> Roles = Context.Roles.Where(Rl => roleNames.Contains(Rl.RoleName)).ToList();
                foreach (User user in Users)
                {
                    foreach (Role role in Roles)
                    {
                        if (!user.Roles.Contains(role))
                        {
                            user.Roles.Add(role);
                        }
                    }
                }
                Context.SaveChanges();
            }
        }

        public override void RemoveUsersFromRoles(string[] usernames, string[] roleNames)
        {
            using (LibraryContext Context = new LibraryContext())
            {
                foreach (String username in usernames)
                {
                    String us = username;
                    User user = Context.Users.FirstOrDefault(U => U.Username == us);
                    if (user != null)
                    {
                        foreach (String roleName in roleNames)
                        {
                            String rl = roleName;
                            Role role = user.Roles.FirstOrDefault(R => R.RoleName == rl);
                            if (role != null)
                            {
                                user.Roles.Remove(role);
                            }
                        }
                    }
                }
                Context.SaveChanges();
            }
        }
    }
}