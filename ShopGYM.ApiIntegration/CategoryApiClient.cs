using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using ShopGYM.ViewModels.Catalog.DanhMuc;
using ShopGYM.ViewModels.Common;

namespace ShopGYM.ApiIntegration
{
    public class CategoryApiClient : BaseApiClient, ICategoryApiClient
    {
        private readonly HttpClient _httpClient;
        public CategoryApiClient(IHttpClientFactory httpClientFactory,
            IConfiguration configuration,
            IHttpContextAccessor httpContextAccessor)
            : base(httpClientFactory, configuration, httpContextAccessor)
        {
        }
        public async Task<List<CategoryVm>> GetAll()
        {
            return await GetListAsync<CategoryVm>("/api/categories");

        }

        public async Task<CategoryVm> GetById(int id)
        {
            return await GetAsync<CategoryVm>($"/api/categories/{id}");
        }

    }
}
