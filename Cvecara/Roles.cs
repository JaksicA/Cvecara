using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cvecara
{
    public static class Roles
    {
        public const string Admin = "Admin";
        public const string Employee = "Employee";
        public const string Customer = "Customer";

        public static async Task SeedRoles(RoleManager<IdentityRole> roleManager)
        {
            string[] roles = new string[] { Admin, Employee, Customer };

            foreach(var role in roles)
            {
                if (!await roleManager.RoleExistsAsync(role))
                {
                    var created = await roleManager.CreateAsync(new IdentityRole(role));
                    if (!created.Succeeded)
                    {
                        throw new Exception("Role cretaion failed");
                    }
                }
            }
        }
    }
}
