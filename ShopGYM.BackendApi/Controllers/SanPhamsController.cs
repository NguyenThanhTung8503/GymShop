using Braintree;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShopGYM.Application.Catalog.SanPham;
using ShopGYM.ViewModels.Catalog.HinhAnh;
using ShopGYM.ViewModels.Catalog.SanPham;
using static System.Net.Mime.MediaTypeNames;

namespace ShopGYM.BackendApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SanPhamsController : ControllerBase
    {
        private readonly IPublicSanPhamService _publicSanPhamService;
        private readonly IManageSanPhamService _manageSanPhamService;
        public SanPhamsController(IPublicSanPhamService publicSanPhamService, IManageSanPhamService manageSanPhamService)
        {
            _publicSanPhamService = publicSanPhamService;
            _manageSanPhamService = manageSanPhamService;
        }
        //San pham
        //http://localhost:port/SanPham/public-paging
        [HttpGet("public-paging")]
        public async Task<IActionResult> GetAllPaging([FromQuery]GetPublicSanPhamPagingRequest request)
        {
            var sanpham = await _publicSanPhamService.GetAllByMaDanhMuc(request);
            return Ok(sanpham);
        }
        //http://localhost:port/SanPham/1
        [HttpGet("{IdSanPham}")]
        [Authorize]
        public async Task<IActionResult> GetById(int IdSanPham)
        {
            var sanpham = await _manageSanPhamService.GetById(IdSanPham);
            if(sanpham == null)
                return BadRequest("Khong tim thay san pham");

            return Ok(sanpham);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromForm] SanPhamCreateRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var Idsanpham = await _manageSanPhamService.Create(request);
            if (Idsanpham == 0)
                return BadRequest();

            var sanpham = await _manageSanPhamService.GetById(Idsanpham);

            return CreatedAtAction(nameof(GetById), new {  id = Idsanpham}, sanpham);
        }
        
        [HttpPut]
        public async Task<IActionResult> Update([FromForm] SanPhamUpdateRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var Idsanpham = await _manageSanPhamService.Update(request);
            var affectedResult = await _manageSanPhamService.Update(request);
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
            var Issuccessful = await _manageSanPhamService.UpdatePrice(IdSanPham, GiaMoi);
            if (Issuccessful)
                return Ok();
            return BadRequest();
            
        }

        [HttpDelete("{IdSanPham}")]
        public async Task<IActionResult> Delete(int IdSanPham)
        {
            var affectedresult = await _manageSanPhamService.Delete(IdSanPham);
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
            var IdHinhAnh = await _manageSanPhamService.AddImage(IdSanPham, request);
            if (IdHinhAnh == 0)
                return BadRequest();

            var HinhAnh = await _manageSanPhamService.GetImageById(IdHinhAnh);

            return CreatedAtAction(nameof(GetListImageByIdSanPham), new { id = IdSanPham }, HinhAnh);
        }

        [HttpPut("{IdSanPham}/HinhAnh/{IdHinhAnh}")]
        public async Task<IActionResult> UpdateImage(int IdHinhAnh, [FromForm] HinhAnhUpdateRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var result = await _manageSanPhamService.UpdateImage(IdHinhAnh, request);
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
            var result = await _manageSanPhamService.RemoveImage(IdHinhAnh);
            if (result == 0)
                return BadRequest();

            return Ok();
        }

        [HttpGet("{IdSanPham}/HinhAnh")]
        public async Task<IActionResult> GetListImageByIdSanPham(int IdSanPham)
        {
            var HinhAnh = await _manageSanPhamService.GetListImages(IdSanPham);
            if (HinhAnh == null)
                return BadRequest("Khong the tim thay san pham");
            return Ok(HinhAnh);
        }

    }
}
