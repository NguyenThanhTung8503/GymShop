using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ShopGYM.ViewModels.Catalog.DanhGia;
using System.Security.Claims;
using ShopGYM.ApiIntegration;

namespace ShopGYM.WebApp.Controllers
{
    public class CommentController : Controller
    {
        private readonly ICommentApiClient _commentApiClient;

        public CommentController(ICommentApiClient commentApiClient)
        {
            _commentApiClient = commentApiClient;
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Create(CreateCommentRequest request)
        {
            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Login", "Account");
            }

            if (!ModelState.IsValid)
            {
                TempData["Error"] = "Dữ liệu bình luận không hợp lệ";
                return RedirectToAction("Detail", "Product", new { id = request.IdSanPham });
            }

            var userId = HttpContext.User?.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            request.IdUser = Guid.Parse(userId);

            var commentId = await _commentApiClient.CreateComment(request);
            if (commentId == 0)
            {
                TempData["Error"] = "Không thể tạo bình luận";
                return RedirectToAction("Detail", "Product", new { id = request.IdSanPham });
            }

            TempData["Success"] = "Bình luận đã được tạo thành công";
            return RedirectToAction("Detail", "Product", new { id = request.IdSanPham });
        }

        [HttpPost]
        public async Task<IActionResult> Update(int id, UpdateCommentRequest request)
        {
            if (!ModelState.IsValid)
            {
                TempData["Error"] = "Dữ liệu cập nhật không hợp lệ";
                return RedirectToAction("Detail", "Product", new { id = request.IdSanPham });
            }

            var comment = await _commentApiClient.GetById(id);

            request.Id = id;
            var result = await _commentApiClient.UpdateComment(id, request);
            if (result == 0)
            {
                TempData["Error"] = "Không thể cập nhật bình luận";
                return RedirectToAction("Detail", "Product", new { id = request.IdSanPham });
            }

            TempData["Success"] = "Bình luận đã được cập nhật thành công";
            return RedirectToAction("Detail", "Product", new { id = request.IdSanPham });
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id, int productId)
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var comment = await _commentApiClient.GetById(id);

            if (comment == null || comment.MaNguoiDung != Guid.Parse(userId))
            {
                TempData["Error"] = "Bạn không có quyền xóa bình luận này";
                return RedirectToAction("Detail", "Product", new { id = productId });
            }

            var result = await _commentApiClient.DeleteComment(id);
            if (result == false)
            {
                TempData["Error"] = "Không thể xóa bình luận";
                return RedirectToAction("Detail", "Product", new { id = productId });
            }

            TempData["Success"] = "Bình luận đã được xóa thành công";
            return RedirectToAction("Detail", "Product", new { id = productId });
        }
    }
}