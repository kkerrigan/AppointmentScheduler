using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AppointmentScheduler.Models;
using AppointmentScheduler.Utility;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace AppointmentScheduler.DbInitializer
{
    public class DbInitializer : IDbInitializer
    {
        private readonly ApplicationDbContext _db;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public DbInitializer(ApplicationDbContext db, UserManager<ApplicationUser> userManager,
            RoleManager<IdentityRole> roleManager)
        {
            _db = db;
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public void Initialize()
        {
            try
            {
                if (_db.Database.GetPendingMigrations().Any())
                {
                    _db.Database.Migrate();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }

            if (_db.Roles.Any(x => x.Name == Helper.Admin)) return;

            
             _roleManager.CreateAsync(new IdentityRole(Helper.Admin)).GetAwaiter().GetResult();
             _roleManager.CreateAsync(new IdentityRole(Helper.Patient)).GetAwaiter().GetResult();
             _roleManager.CreateAsync(new IdentityRole(Helper.Doctor)).GetAwaiter().GetResult();

             _userManager.CreateAsync(new ApplicationUser
             {
                 UserName = "k.burnard@hotmail.com",
                 Email = "k.burnard@hotmail.com",
                 EmailConfirmed = true,
                 Name = "Admin Kristian"
             }, "?FallingIn91").GetAwaiter().GetResult();

             ApplicationUser user = _db.Users.FirstOrDefault(u => u.Email == "k.burnard@hotmail.com");
             _userManager.AddToRoleAsync(user, Helper.Admin).GetAwaiter().GetResult();

        }
    }
}
