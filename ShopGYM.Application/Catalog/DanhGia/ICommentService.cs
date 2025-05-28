using ShopGYM.ViewModels.Catalog.DanhGia;
using ShopGYM.ViewModels.Catalog.SanPham;
using ShopGYM.ViewModels.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopGYM.Application.Catalog.DanhGia
{
    public interface ICommentService
    {
        Task<int> Create(CreateCommentRequest request);
        Task<int> Edit(UpdateCommentRequest request);
        Task<int> Delete(int Id);
        Task<List<CommentVm>> GetAll(int id);
        Task<CommentVm> GetById(int id);
    }
}
