using Braintree;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShopGYM.Application.Catalog.SanPham;
using ShopGYM.ViewModels.Catalog.HinhAnh;
using ShopGYM.ViewModels.Catalog.SanPham;
using ShopGYM.ViewModels.System.Users;
using static System.Net.Mime.MediaTypeNames;

namespace ShopGYM.BackendApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;
        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }
        //San pham
        [HttpGet("paging")]
        public async Task<IActionResult> GetAllPaging([FromQuery]GetManageProductPagingRequest request)
        {
            var sanpham = await _productService.GetAllPaging(request);
            return Ok(sanpham);
        }
        

        [HttpGet("{IdSanPham}")]
        public async Task<IActionResult> GetById(int IdSanPham)
        {
            var sanpham = await _productService.GetById(IdSanPham);
            if(sanpham == null)
                return BadRequest("Không thể tìm thấy sản phẩm");

            return Ok(sanpham);
        }

        [HttpPost]
        [Consumes("multipart/form-data")]
        [Authorize]
        public async Task<IActionResult> Create([FromForm] ProductCreateRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var Idsanpham = await _productService.Create(request);
            if (Idsanpham == 0)
                return BadRequest();

            var sanpham = await _productService.GetById(Idsanpham);

            return CreatedAtAction(nameof(GetById), new {  id = Idsanpham}, sanpham);
        }

        [HttpPut("{id}/categories")]
        public async Task<IActionResult> CategoryAssign(int id, [FromBody] CategoryAssignRequest request)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _productService.CategoryAssign(id, request);
            if (!result.IsSuccessed)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> Edit([FromRoute] int IdSanpham, ProductUpdateRequets request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            request.Id = IdSanpham;
            var affectedResult = await _productService.Edit(request);
            if (affectedResult == 0)
                return BadRequest();
            return Ok();
        }

        [HttpPatch("{IdSanPham}/{GiaMoi}")]
        public async Task<IActionResult> UpdatePrice(int IdSanPham, decimal GiaMoi)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var Issuccessful = await _productService.UpdatePrice(IdSanPham, GiaMoi);
            if (Issuccessful)
                return Ok();
            return BadRequest();
            
        }

        [HttpDelete("{IdSanPham}")]
        public async Task<IActionResult> Delete(int IdSanPham)
        {
            var affectedresult = await _productService.Delete(IdSanPham);
            if (affectedresult == 0)
                return BadRequest();


            return Ok();
        }


        //Hinh anh
        [HttpPost("{IdSanPham}/HinhAnh")]
        public async Task<IActionResult> CreateImage(int IdSanPham, [FromForm] HinhAnhCreateRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var IdHinhAnh = await _productService.AddImage(IdSanPham, request);
            if (IdHinhAnh == 0)
                return BadRequest();

            var HinhAnh = await _productService.GetImageById(IdHinhAnh);

            return CreatedAtAction(nameof(GetListImageByIdSanPham), new { id = IdSanPham }, HinhAnh);
        }

        [HttpPut("{IdSanPham}/HinhAnh/{IdHinhAnh}")]
        public async Task<IActionResult> UpdateImage(int IdHinhAnh, [FromForm] HinhAnhUpdateRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var result = await _productService.UpdateImage(IdHinhAnh, request);
            if (result == 0)
                return BadRequest();

            return Ok();
        }

        [HttpDelete("{IdSanPham}/HinhAnh/{IdHinhAnh}")]
        public async Task<IActionResult> RemoveImage(int IdHinhAnh)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var result = await _productService.RemoveImage(IdHinhAnh);
            if (result == 0)
                return BadRequest();

            return Ok();
        }

        [HttpGet("{IdSanPham}/HinhAnh")]
        public async Task<IActionResult> GetListImageByIdSanPham(int IdSanPham)
        {
            var HinhAnh = await _productService.GetListImages(IdSanPham);
            if (HinhAnh == null)
                return BadRequest("Không thể tìm thấy sản phẩm");
            return Ok(HinhAnh);
        }

    }
}
