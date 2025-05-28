using ShopGYM.ViewModels.Catalog.DanhGia;
using ShopGYM.ViewModels.Catalog.DanhMuc;
using ShopGYM.ViewModels.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopGYM.ApiIntegration
{
    public interface ICommentApiClient
    {
        Task<int> CreateComment(CreateCommentRequest request);
        Task<int> UpdateComment(int id, UpdateCommentRequest request);
        Task<bool> DeleteComment(int id);
        Task<List<CommentVm>> GetAllComments(int productId);
        Task<CommentVm> GetById(int id);
    }
}
