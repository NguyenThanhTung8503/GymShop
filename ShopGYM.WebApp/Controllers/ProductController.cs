using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using ShopGYM.ApiIntegration;
using ShopGYM.ViewModels.Catalog.SanPham;
using ShopGYM.WebApp.Models;

namespace ShopGYM.WebApp.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductApiClient _productApiClient;
        private readonly ICategoryApiClient _categoryApiClient;
        public ProductController(IProductApiClient productApiClient, ICategoryApiClient categoryApiClient)
        {
            _productApiClient = productApiClient;
            _categoryApiClient = categoryApiClient;
        }
        public async Task<IActionResult> Index(string keyword, int? CategoryId, int pageIndex = 1, int pageSize = 9)
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

            var categories = await _categoryApiClient.GetAll();
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


        public async Task<IActionResult> Detail(int id, string culture)
        {
            var product = await _productApiClient.GetById(id);
            return View(new ProductDetailViewModel()
            {
                Product = product
            });
        }

        public async Task<IActionResult> Category(int id, int page = 1)
        {
            var products = await _productApiClient.GetProductsPagings(new GetManageProductPagingRequest()
            {
                MaDanhMuc = id,
                PageIndex = page,
                PageSize = 10
            });
            return View(new ProductCategoryViewModel()
            {
                Category = await _categoryApiClient.GetById(id),
                Products = products
            }); ;
        }
    }
}
