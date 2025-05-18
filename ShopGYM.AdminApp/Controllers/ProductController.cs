using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using ShopGYM.ApiIntegration;
using ShopGYM.ViewModels.Catalog.DanhMuc;
using ShopGYM.ViewModels.Catalog.HinhAnh;
using ShopGYM.ViewModels.Catalog.SanPham;
using ShopGYM.ViewModels.Common;
using ShopGYM.ViewModels.System.Users;

namespace ShopGYM.AdminApp.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductApiClient _productApiClient;
        private readonly IConfiguration _configuration;
        private readonly ICategoryApiClient _CategoryApiClient;
        public ProductController(IProductApiClient productApiClient,
            IConfiguration configuration,
            ICategoryApiClient categoryApiClient)
        {
            _productApiClient = productApiClient;
            _configuration = configuration;
            _CategoryApiClient = categoryApiClient;
        }
        public async Task<IActionResult> Index(string keyword, int? CategoryId, int pageIndex = 1, int pageSize = 10)
        {
            var request = new GetManageProductPagingRequest()
            {
                Keyword = keyword,
                PageIndex = pageIndex,
                PageSize = pageSize,
                MaDanhMuc = CategoryId
            };
            var data = await _productApiClient.GetProductsPagings(request);
            ViewBag.Keyword = keyword;

            var categories = await _CategoryApiClient.GetAll();
            ViewBag.Categories = categories.Select(c => new SelectListItem()
            {
                Text = c.TenDanhMuc,
                Value = c.Id.ToString(),
                Selected = CategoryId.HasValue && CategoryId.Value == c.Id
            }).ToList(); ;

            if (TempData["result"] != null)
            {
                ViewBag.SuccessMsg = TempData["result"];
            }
            return View(data);

        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [Consumes("multipart/form-data")]
        public async Task<IActionResult> Create([FromForm]ProductCreateRequest request)
        {
            if (!ModelState.IsValid)
            {
                return View(request);
            }
            var result = await _productApiClient.CreateProduct(request);
            if (result)
            {
                TempData["result"] = "Thêm sản phẩm thành công";
                return RedirectToAction("Index");
            }
            ModelState.AddModelError("", "Thêm sản phẩm không thành công");
            return View(request);
        }

        [HttpGet]
        public async Task<IActionResult> CategoryAssign(int id)
        {
            var roleAssignRequet = await GetCategoryAssignRequet(id);
            return View(roleAssignRequet);
        }

        [HttpPost]
        public async Task<IActionResult> CategoryAssign(CategoryAssignRequest request)
        {
            if (!ModelState.IsValid)
                return View();

            var result = await _productApiClient.CategoryAssign(request.Id, request);

            if (result.IsSuccessed)
            {
                TempData["result"] = "Cập nhật danh mục thành công";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", result.Message);
            var roleAssignRequet = await GetCategoryAssignRequet(request.Id);
            return View(roleAssignRequet);
        }

        [HttpGet]
        public async Task<IActionResult> SetThumbnailImage(int id)
        {
            var thumnnailAssignRequet = await GetThumbnailAssignRequet(id);
            return View(thumnnailAssignRequet);
        }

        [HttpPost]
        public async Task<IActionResult> SetThumbnailImage(ThumbnailAssignRequest request)
        {
            if (!ModelState.IsValid)
                return View();

            var result = await _productApiClient.SetThumbnailImage(request.Id, request);

            if (result.IsSuccessed)
            {
                TempData["result"] = "Cập nhật ảnh mặc định thành công";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", result.Message);
            var thumnnailAssignRequet = await GetThumbnailAssignRequet(request.Id);
            return View(thumnnailAssignRequet);
        }


        private async Task<CategoryAssignRequest> GetCategoryAssignRequet(int id)
        {
            var productObj = await _productApiClient.GetById(id);
            var categories = await _CategoryApiClient.GetAll();
            var categoryAssignRequet = new CategoryAssignRequest();
            foreach (var role in categories)
            {
                categoryAssignRequet.Categories.Add(new SelectItem()
                {
                    Id = role.Id.ToString(),
                    Name = role.TenDanhMuc,
                    Selected = productObj.Category.Contains(role.TenDanhMuc)
                });
            }
            return categoryAssignRequet;

        }
        

        private async Task<ThumbnailAssignRequest> GetThumbnailAssignRequet(int id)
        {
            var productObj = await _productApiClient.GetById(id);
            var images = await _productApiClient.GetListImages(id);
            var thumbnailAssignRequet = new ThumbnailAssignRequest();
            foreach (var item in images)
            {
                thumbnailAssignRequet.Images.Add(new SelectItem()
                {
                    Id = item.MaHinhAnh.ToString(),
                    Name = item.DuongDan,
                    Selected = item.IsDefault
                });
            }
            return thumbnailAssignRequet;

        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var product = await _productApiClient.GetById(id);
            var editVm = new ProductUpdateRequest()
            {
                Id = product.MaSanPham,
                TenSanPham = product.TenSanPham,
                MoTa = product.MoTa,
                KichThuoc = product.KichThuoc,
                MauSac = product.MauSac,
                SoLuongTon = product.SoLuongTon,
                Gia = product.Gia,
            };
            return View(editVm);
        }


        [HttpPost]
        [Consumes("multipart/form-data")]
        public async Task<IActionResult> Edit([FromForm] ProductUpdateRequest request)
        {
            if (!ModelState.IsValid)
                return View(request);

            var result = await _productApiClient.EditProduct(request);
            if (result)
            {
                TempData["result"] = "Sửa thành công";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Sửa thất bại");
            return View(request);
        }

        [HttpGet]
        public async Task<IActionResult> UpdateImage(int id)
        {
            var image = await _productApiClient.GetImageById(id);
            if (image == null)
            {
                return NotFound("Không tìm thấy hình ảnh");
            }

            var hinhAnhRequest = new HinhAnhUpdateRequest
            {
                IdHinhAnh = image.MaHinhAnh,
                MoTa = image.Mota,
            };
            return View(hinhAnhRequest);
        }

        [HttpPost]
        [Consumes("multipart/form-data")]
        public async Task<IActionResult> UpdateImage([FromForm] HinhAnhUpdateRequest request)
        {
            if (!ModelState.IsValid)
                return View(request);

            var result = await _productApiClient.UpdateImage(request);
            if (result)
            {
                TempData["result"] = "Sửa thành công";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Sửa thất bại");
            return View(request);
        }

        [HttpGet]
        public async Task<IActionResult> AddImage(int id)
        {
            var product = await _productApiClient.GetById(id);
            if (product == null)
            {
                return NotFound("Không tìm thấy sản phẩm");
            }

            var hinhAnhRequest = new HinhAnhCreateRequest
            {
                IdSanPham = product.MaSanPham
            };

            return View(hinhAnhRequest);
        }

        [HttpPost]
        [Consumes("multipart/form-data")]
        public async Task<IActionResult> AddImage([FromForm] HinhAnhCreateRequest request)
        {
            if (!ModelState.IsValid)
            {
                return View(request);
            }
            var result = await _productApiClient.AddImage(request);
            if (result)
            {
                TempData["result"] = "Thêm ảnh thành công";
                return RedirectToAction("Index");
            }
            ModelState.AddModelError("", "Thêm ảnh không thành công");
            return View(request);
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            return View(new ProductDeleteRequest()
            {
                Id = id
            });
        }

        [HttpPost]
        public async Task<IActionResult> Delete(ProductDeleteRequest request)
        {
            if (!ModelState.IsValid)
                return View();

            var result = await _productApiClient.DeleteProduct(request.Id);
            if (result)
            {
                TempData["result"] = "Xóa sản phẩm thành công";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Xóa không thành công");
            return View(request);
        }

        [HttpGet]
        public IActionResult DeleteImage(int id)
        {
            return View(new ImageDeleteRequest()
            {
                Id = id
            });
        }

        [HttpPost]
        public async Task<IActionResult> DeleteImage(ImageDeleteRequest request)
        {
            if (!ModelState.IsValid)
                return View();

            var result = await _productApiClient.DeleteImage(request.Id);
            if (result)
            {
                TempData["result"] = "Xóa sản phẩm thành công";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Xóa không thành công");
            return View(request);
        }


        [HttpGet]
        public async Task<IActionResult> Detail(int id)
        {
            var result = await _productApiClient.Detail(id);
            return View(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetListImages(int id)
        {
            var result = await _productApiClient.GetListImages(id);
            return View(result);
        }
    }
}
