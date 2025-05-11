using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using ShopGYM.Data.EF;
using ShopGYM.Data.Entities;
using ShopGYM.ViewModels.Catalog.DanhMuc;
using ShopGYM.ViewModels.System.Role;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopGYM.Application.Catalog.DanhMuc
{
    public class CategoryService : ICategoryService
    {
        private readonly ShopGYMDbContext _context;
        public CategoryService(ShopGYMDbContext context)
        {
            _context = context;
        }
        public async Task<List<CategoryVm>> GetAll()
        {
            var category = await _context.DanhMucs
                 .Select(c => new CategoryVm()
                 {
                     Id = c.MaDanhMuc,
                     TenDanhMuc = c.TenDanhMuc,
                 }).ToListAsync();
            return category;
        }

        public async Task<CategoryVm> GetById(int id)
        {
            var category = await _context.DanhMucs
                .Where(c => c.MaDanhMuc == id)
                .Select(c => new CategoryVm()
                {
                    Id = c.MaDanhMuc,
                    TenDanhMuc = c.TenDanhMuc
                })
                .FirstOrDefaultAsync();

            return category;
        }
    }
}
