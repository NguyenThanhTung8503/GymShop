using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShopGYM.Application.Catalog.DanhGia;
using ShopGYM.Application.Catalog.SanPham;
using ShopGYM.Data.Entities;
using ShopGYM.ViewModels.Catalog.DanhGia;
using ShopGYM.ViewModels.Catalog.SanPham;

namespace ShopGYM.BackendApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentsController : ControllerBase
    {
        private readonly ICommentService _commentService;
        public CommentsController(ICommentService commentService)
        {
            _commentService = commentService;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAll(int id)
        {
            var comment = await _commentService.GetAll(id);
            if (comment == null)
                return BadRequest("Không thể bình luận");
            return Ok(comment);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateCommentRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var comment = await _commentService.Create(request);
            if (comment == 0)
                return BadRequest();

            return Ok(comment);
        }

        [HttpPut("update/{Id}")]
        public async Task<IActionResult> Edit([FromRoute] int Id, [FromBody] UpdateCommentRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            request.Id = Id;
            var affectedResult = await _commentService.Edit(request);
            if (affectedResult == 0)
                return BadRequest();
            return Ok(affectedResult);
        }

        [HttpDelete("{Id}")]
        public async Task<IActionResult> Delete(int Id)
        {
            var affectedresult = await _commentService.Delete(Id);
            if (affectedresult == 0)
                return BadRequest();

            return Ok();
        }

        [HttpGet("getbyid/{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var comment = await _commentService.GetById(id);
            return Ok(comment);
        }
    }
}
