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
        public async Task<IActionResult> GetProductsPagings([FromQuery]GetManageProductPagingRequest request)
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

        [HttpGet("detail/{IdSanPham}")]
        public async Task<IActionResult> Detail(int IdSanPham)
        {
            var sanpham = await _productService.Detail(IdSanPham);
            if (sanpham == null)
                return BadRequest("Không thể tìm thấy sản phẩm");

            return Ok(sanpham);
        }

        [HttpGet("featured/{take}")]
        [AllowAnonymous]
        public async Task<IActionResult> GetFeatureProducts(int take)
        {
            var sanpham = await _productService.GetFeatureProducts(take);

            return Ok(sanpham);
        }

        [HttpGet("latest/{take}")]
        [AllowAnonymous]
        public async Task<IActionResult> GetLatestProducts(int take)
        {
            var sanpham = await _productService.GetLatestProducts(take);

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


        [HttpPut("{id}/setthumbnail")]
        public async Task<IActionResult> SetThumbnailImage(int id, [FromBody] ThumbnailAssignRequest request)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _productService.SetThumbnailImage(id, request);
            if (!result.IsSuccessed)
            {
                return BadRequest(result.Message);
            }
            return Ok(result);
        }

        [HttpPut("{IdSanpham}")]
        [Consumes("multipart/form-data")]
        [Authorize]
        public async Task<IActionResult> Edit([FromRoute] int IdSanpham, [FromForm] ProductUpdateRequest request)
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
        [Authorize]
        public async Task<IActionResult> Delete(int IdSanPham)
        {
            var affectedresult = await _productService.Delete(IdSanPham);
            if (affectedresult == 0)
                return BadRequest();

            return Ok();
        }


        //Hinh anh

        [HttpGet("HinhAnh/{IdHinhAnh}")]
        public async Task<IActionResult> GetImageById(int IdHinhAnh)
        {
            var image = await _productService.GetImageById(IdHinhAnh);
            if (image == null)
                return BadRequest("Không thể tìm thấy ảnh");

            return Ok(image);
        }

        [HttpPost("{IdSanPham}/HinhAnh")]
        [Consumes("multipart/form-data")]
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

        [HttpPut("HinhAnh/{IdHinhAnh}")]
        [Consumes("multipart/form-data")]
        public async Task<IActionResult> UpdateImage([FromRoute] int IdHinhAnh, [FromForm] HinhAnhUpdateRequest request)
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

        [HttpDelete("HinhAnh/{IdHinhAnh}")]
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
