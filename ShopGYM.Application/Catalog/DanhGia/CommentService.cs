using Microsoft.EntityFrameworkCore;
using ShopGYM.Application.Common;
using ShopGYM.Data.EF;
using ShopGYM.Data.Entities;
using ShopGYM.Utilities.Exceptions;
using ShopGYM.ViewModels.Catalog.DanhGia;
using ShopGYM.ViewModels.Catalog.DanhMuc;
using ShopGYM.ViewModels.Catalog.HinhAnh;
using ShopGYM.ViewModels.Catalog.SanPham;
using ShopGYM.ViewModels.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopGYM.Application.Catalog.DanhGia
{
    public class CommentService : ICommentService
    {
        private readonly ShopGYMDbContext _context;
        public CommentService(ShopGYMDbContext context)
        {
            _context = context;
        }
        public async Task<int> Create(CreateCommentRequest request)
        {
            var comment = new Data.Entities.DanhGia
            {
                MaSanPham = request.IdSanPham,
                NoiDung = request.NoiDung,
                MaNguoiDung = request.IdUser,
                NgayDanhGia = DateTime.Now
            };
            _context.DanhGias.Add(comment);
            await _context.SaveChangesAsync();
            return comment.MaDanhGia;
        }

        public async Task<int> Delete(int Id)
        {
            var comment = await _context.DanhGias.FindAsync(Id);
            if (comment == null) throw new ShopGYMException($"Khong the tim thay danh gia: {Id}");


            _context.DanhGias.Remove(comment);
            return await _context.SaveChangesAsync();
        }

        public async Task<int> Edit(UpdateCommentRequest request)
        {
            var comment = await _context.DanhGias.FindAsync(request.Id);
            if (comment == null)
                throw new ShopGYMException($"Khong the tim thay danh gia voi id: {request.Id}");
            comment.NoiDung = request.NoiDung;
            
            return await _context.SaveChangesAsync();
        }

        public async Task<List<CommentVm>> GetAll(int id)
        {
            var product = await _context.SanPhams.FindAsync(id);
            if (product == null)
            {
                return new List<CommentVm>();
            }
            
            var query = from dg in _context.DanhGias
                        join u in _context.Users on dg.MaNguoiDung equals u.Id 
                        join sp in _context.SanPhams on dg.MaSanPham equals sp.MaSanPham
                        where sp.MaSanPham == id
                        select new
                        {
                            sp, u, dg
                        };

            query = query.OrderByDescending(x => x.dg.NgayDanhGia);

            var items = await query
                .Select(x => new CommentVm
                {
                    Id = x.dg.MaDanhGia,
                    NoiDung = x.dg.NoiDung,
                    NgayDanhGia = x.dg.NgayDanhGia,
                    TenNguoiDanhGia = x.u.UserName,
                    MaNguoiDung = x.u.Id
                })
                .ToListAsync();

            return items;
        }

        public async Task<CommentVm> GetById(int id)
        {
            var comment = await _context.DanhGias
                .Where(c => c.MaDanhGia == id)
                .Select(c => new CommentVm
                {
                    Id = c.MaDanhGia,
                    NoiDung = c.NoiDung,
                    NgayDanhGia = c.NgayDanhGia,
                    MaNguoiDung = c.MaNguoiDung,
                    TenNguoiDanhGia = _context.Users
                        .Where(u => u.Id == c.MaNguoiDung)
                        .Select(u => u.UserName)
                        .FirstOrDefault()
                })
                .FirstOrDefaultAsync();

            return comment;
        }
    }
}
