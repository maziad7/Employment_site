using job.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(job.Startup))]
namespace job
{
    public partial class Startup
    {
        private ApplicationDbContext db=new ApplicationDbContext();
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            createDefaultRolesAndUsers();
        }
        public void createDefaultRolesAndUsers()
        {
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(db));
            var userManager=new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(db));
            IdentityRole role = new IdentityRole();
            if (!roleManager.RoleExists("admins"))
            {
                role.Name = "admins";
                roleManager.Create(role);
                ApplicationUser user = new ApplicationUser();
                user.UserName = "maziad";
                user.Email = "maziad@gmail.com";
                var check = userManager.Create(user, "mA@000");
                if (check.Succeeded)
                {
                    userManager.AddToRole(user.Id, "Admins");
                }

            }
        }
    }
}
