using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using ShopGYM.ApiIntegration;
using ShopGYM.ViewModels.Catalog.DanhMuc;
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

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var product = await _productApiClient.GetById(id);
            var editVm = new ProductUpdateRequets()
            {
                Id = product.MaSanPham,
                TenSanPham = product.TenSanPham,
                MoTa = product.MoTa,
                KichThuoc = product.KichThuoc,
                MauSac = product.MauSac,
                SoLuongTon = product.SoLuongTon,
                TenDanhMuc = product.TenDanhMuc
            };
            return View(editVm);
        }


        [HttpPost]
        [Consumes("multipart/form-data")]
        public async Task<IActionResult> Edit([FromForm] ProductUpdateRequets request)
        
        
        {
            if (!ModelState.IsValid)
                return View();

            var result = await _productApiClient.EditProduct(request);
            if (result)
            {
                TempData["result"] = "Sửa thành công";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Sửa thất bại");
            return View(request);
        }
    }
}
