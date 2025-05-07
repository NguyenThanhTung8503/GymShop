using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using ShopGYM.Application.System.Role;
using ShopGYM.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopGYM.ViewModels.System.Role
{
    public class RoleService : IRoleService
    {
        private readonly RoleManager<AppRole> _roleManager;
        public RoleService(RoleManager<AppRole> roleManager)
        {
            _roleManager = roleManager;
        }
        public async Task<List<RoleVM>> GetAllRole()
        {
            var roles = await _roleManager.Roles
                 .Select(r => new RoleVM()
                 {
                     Id = r.Id,
                     Name = r.Name,
                     MoTa = r.MoTa
                 }).ToListAsync();
            return roles;

        }
    }
}
