using System;
using Microsoft.Owin;
using Owin;
using InzSklep.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

[assembly: OwinStartupAttribute(typeof(InzSklep.Startup))]
namespace InzSklep
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            createRolesAndUsers();
        }

        private void createRolesAndUsers()
        {
            ApplicationDbContext context = new ApplicationDbContext();
            var roleManager = new RoleManager<IdentityRole>(new
            RoleStore<IdentityRole>(context));
            var UserManager = new UserManager<ApplicationUser>(new
            UserStore<ApplicationUser>(context));

            if (!roleManager.RoleExists("User"))
            {
                var role = new IdentityRole();
                role.Name = "User";
                roleManager.Create(role);
            }

            if (!roleManager.RoleExists("Manager"))
            {
                var role = new IdentityRole();
                role.Name = "Manager";
                roleManager.Create(role);
            }

            if (!roleManager.RoleExists("Admin"))
            {
                var role = new IdentityRole();
                role.Name = "Admin";
                roleManager.Create(role);
            }
            if (UserManager.FindByEmail("admin@suplesklep.pl") == null)
            {
                var user = new ApplicationUser() { UserName = "admin@suplesklep.pl", Email = "admin@suplesklep.pl" };
                UserManager.Create(user, "User123.");
                UserManager.AddToRole(user.Id, "Admin");
            }
            if (UserManager.FindByEmail("manager@suplesklep.pl") == null)
            {
                var user = new ApplicationUser() { UserName = "manager@suplesklep.pl", Email = "manager@suplesklep.pl" };
                UserManager.Create(user, "User123.");
                UserManager.AddToRole(user.Id, "Manager");
            }
            if (UserManager.FindByEmail("user@suplesklep.pl") == null)
            {
                var user = new ApplicationUser() { UserName = "user@suplesklep.pl", Email = "user@suplesklep.pl" };
                UserManager.Create(user, "User123.");
                UserManager.AddToRole(user.Id, "User");
            }
        }
    }
}
