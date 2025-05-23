using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using ShopGYM.Data.Entities;
using ShopGYM.Utilities.Constants;
using ShopGYM.ViewModels.Catalog.Checkout;
using System.Net.Http.Headers;
using System.Text;

namespace ShopGYM.ApiIntegration
{

    public class OrderApiClient : BaseApiClient, IOrderApiClient
    {

        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IConfiguration _configuration;
        public OrderApiClient(IHttpClientFactory httpClientFactory,
            IConfiguration configuration,
            IHttpContextAccessor httpContextAccessor)
            : base(httpClientFactory, configuration, httpContextAccessor)
        {
            _httpClientFactory = httpClientFactory;
            _configuration = configuration;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<int> CreateOrder(CheckoutRequest request)
        {
            var sessions = _httpContextAccessor.HttpContext.Session.GetString(SystemConstants.AppSettings.Token);
            if (string.IsNullOrEmpty(sessions))
            {
                throw new Exception("Token không tồn tại trong Session.");
            }

            var client = _httpClientFactory.CreateClient();
            client.BaseAddress = new Uri(_configuration[SystemConstants.AppSettings.BaseAddress]);
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", sessions);

            // Tạo nội dung form data
            var formContent = new MultipartFormDataContent
    {
        { new StringContent(request.UserId.ToString()), "UserId" },
        { new StringContent(request.Address ?? ""), "Address" },
        { new StringContent(request.Name ?? ""), "Name" },
        { new StringContent(request.PhoneNumber ?? ""), "PhoneNumber" }
    };

            // Xử lý OrderDetails (nếu có)
            if (request.OrderDetails != null)
            {
                for (int i = 0; i < request.OrderDetails.Count; i++)
                {
                    var detail = request.OrderDetails[i];
                    formContent.Add(new StringContent(detail.ProductId.ToString()), $"OrderDetails[{i}].ProductId");
                    formContent.Add(new StringContent(detail.Quantity.ToString()), $"OrderDetails[{i}].Quantity");
                    formContent.Add(new StringContent(detail.Total.ToString()), $"OrderDetails[{i}].Total");
                }
            }

            var response = await client.PostAsync($"/api/orders", formContent);

            if (!response.IsSuccessStatusCode)
            {
                var errorContent = await response.Content.ReadAsStringAsync();
                throw new Exception($"Không thể tạo đơn hàng: {response.ReasonPhrase} - {errorContent}");
            }

            var responseContent = await response.Content.ReadAsStringAsync();
            if (!int.TryParse(responseContent, out var maDonHang) || maDonHang <= 0)
            {
                throw new Exception("Không thể lấy MaDonHang từ phản hồi API.");
            }

            return maDonHang;
        }

       
        public async Task<bool> DeleteOrder(int id)
        {
            return await Delete($"/api/orders/{id}");
        }

        public async Task<List<OrderVm>> GetAll(Guid userId)
        {
            var data = await GetListAsync<OrderVm>($"/api/orders/{userId}/getall");
            return data;
        }

        public async Task<OrderVm> GetById(int id)
        {
            var data = await GetAsync<OrderVm>($"/api/orders/{id}");
            return data;
        }
    }
}
