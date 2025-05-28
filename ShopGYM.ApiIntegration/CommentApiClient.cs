using ShopGYM.Utilities.Constants;
using ShopGYM.ViewModels.Catalog.DanhGia;
using ShopGYM.ViewModels.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using ShopGYM.ViewModels.System.Users;
using ShopGYM.ViewModels.Catalog.SanPham;
using ShopGYM.ViewModels.Catalog.DanhMuc;

namespace ShopGYM.ApiIntegration
{
    public class CommentApiClient : BaseApiClient, ICommentApiClient
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IConfiguration _configuration;
        public CommentApiClient(IHttpClientFactory httpClientFactory,
            IConfiguration configuration,
            IHttpContextAccessor httpContextAccessor)
            : base(httpClientFactory, configuration, httpContextAccessor)
        {
            _httpClientFactory = httpClientFactory;
            _configuration = configuration;
            _httpContextAccessor = httpContextAccessor;
        }
        public async Task<int> CreateComment(CreateCommentRequest request)
        {
            var json = JsonConvert.SerializeObject(request);
            var httpContent = new StringContent(json, Encoding.UTF8, "application/json");

            var client = _httpClientFactory.CreateClient("ShopGYM");
            client.BaseAddress = new Uri(_configuration["BaseAddress"]);
            var response = await client.PostAsync("/api/comments", httpContent);

            if (!response.IsSuccessStatusCode)
            {
                return 0; 
            }

            var responseContent = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<int>(responseContent); 
            return result;
        }

        public async Task<bool> DeleteComment(int id)
        {
            return await Delete($"/api/comments/{id}");
        }

        public async Task<List<CommentVm>> GetAllComments(int productId)
        {
            var data = await GetListAsync<CommentVm>($"/api/comments/{productId}");
            return data;
        }

        public async Task<int> UpdateComment(int id, UpdateCommentRequest request)
        {
            var client = _httpClientFactory.CreateClient();
            client.BaseAddress = new Uri(_configuration["BaseAddress"]);

            var sessions = _httpContextAccessor.HttpContext.Session.GetString("Token");
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", sessions);

            var json = JsonConvert.SerializeObject(request);
            var httpContent = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await client.PutAsync($"/api/comments/update/{id}", httpContent);
            var result = await response.Content.ReadAsStringAsync();

            if (!response.IsSuccessStatusCode)
            {
                return 0; 
            }

            return JsonConvert.DeserializeObject<int>(result);
        }

        public async Task<CommentVm> GetById(int id)
        {
            return await GetAsync<CommentVm>($"/api/comments/getbyid/{id}");
        }
    }
}
