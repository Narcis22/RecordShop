using System.Collections.Generic;
using System.Linq;
using System.Text;
using System;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;
using RecordShop.DAL.Entities;

namespace RecordShop.DAL
{
    public class InitialSeed
    {
        private readonly RoleManager<Role> _roleManager;

        public InitialSeed(RoleManager<Role> roleManager)
        {
            _roleManager = roleManager;
        }

        //async if it's not working
        public void CreateRoles()
        {
            string[] roleNames =
            {
                "Admin",
                "User"
            };

            foreach (var name in roleNames)
            {
                var role = new Role
                {
                    Name = name
                };

                _roleManager.CreateAsync(role).Wait();
            }
        }
    }
}
