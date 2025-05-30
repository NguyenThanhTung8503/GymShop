﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using ShopGYM.Utilities.Constants;
using ShopGYM.ViewModels.Catalog.HinhAnh;
using ShopGYM.ViewModels.Catalog.SanPham;
using ShopGYM.ViewModels.Common;
using ShopGYM.ViewModels.System.Users;
using System.Net.Http.Headers;
using System.Text;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ShopGYM.ApiIntegration
{
    public class ProductApiClient : BaseApiClient, IProductApiClient
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IConfiguration _configuration;

        public ProductApiClient(IHttpClientFactory httpClientFactory,
            IConfiguration configuration,
            IHttpContextAccessor httpContextAccessor)
            : base(httpClientFactory, configuration, httpContextAccessor)
        {
            _httpClientFactory = httpClientFactory;
            _configuration = configuration;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<bool> CreateProduct(ProductCreateRequest request)
        {
            var sessions = _httpContextAccessor
                .HttpContext
                .Session
                .GetString(SystemConstants.AppSettings.Token);

            var client = _httpClientFactory.CreateClient();
            client.BaseAddress = new Uri(_configuration[SystemConstants.AppSettings.BaseAddress]);
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", sessions);

            var requestContent = new MultipartFormDataContent();

            if (request.ThumbnailImage != null)
            {
                byte[] data;
                using (var br = new BinaryReader(request.ThumbnailImage.OpenReadStream()))
                {
                    data = br.ReadBytes((int)request.ThumbnailImage.OpenReadStream().Length);
                }
                ByteArrayContent bytes = new ByteArrayContent(data);
                requestContent.Add(bytes, "ThumbnailImage", request.ThumbnailImage.FileName);
            }

            requestContent.Add(new StringContent(request.TenSanPham.ToString()), "TenSanPham");
            requestContent.Add(new StringContent(request.Gia.ToString()), "Gia");
            requestContent.Add(new StringContent(request.MoTa.ToString()), "MoTa");
            requestContent.Add(new StringContent(request.KichThuoc.ToString()), "KichThuoc");
            requestContent.Add(new StringContent(request.MauSac.ToString()), "MauSac");
            requestContent.Add(new StringContent(request.SoLuongTon.ToString()), "SoLuongTon");
            requestContent.Add(new StringContent(request.MaDanhMuc.ToString()), "MaDanhMuc");

            var response = await client.PostAsync($"/api/products", requestContent);
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> AddImage( HinhAnhCreateRequest request)
        {
            var sessions = _httpContextAccessor
                .HttpContext
                .Session
                .GetString(SystemConstants.AppSettings.Token);

            var client = _httpClientFactory.CreateClient();
            client.BaseAddress = new Uri(_configuration[SystemConstants.AppSettings.BaseAddress]);
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", sessions);

            var requestContent = new MultipartFormDataContent();

            if (request.ImageFile != null)
            {
                byte[] data;
                using (var br = new BinaryReader(request.ImageFile.OpenReadStream()))
                {
                    data = br.ReadBytes((int)request.ImageFile.OpenReadStream().Length);
                }
                ByteArrayContent bytes = new ByteArrayContent(data);
                requestContent.Add(bytes, "ImageFile", request.ImageFile.FileName);
            }

            requestContent.Add(new StringContent(request.MoTa.ToString()), "MoTa");

            var response = await client.PostAsync($"/api/products/{request.IdSanPham}/HinhAnh", requestContent);
            return response.IsSuccessStatusCode;
        }

        public async Task<PagedResult<ProductVM>> GetProductsPagings(GetManageProductPagingRequest request)
        {
            var data = await GetAsync<PagedResult<ProductVM>>("/api/products/paging?pageindex=" +
                $"{request.PageIndex}&pageSize={request.PageSize}&keyword={request.Keyword}&madanhmuc={request.MaDanhMuc}");
            return data;

        }

        public async Task<ProductVM> GetById(int id)
        {
            var data = await GetAsync<ProductVM>($"/api/products/{id}");
            return data;
        }

        public async Task<HinhAnhViewModel> GetImageById(int id)
        {
            var data = await GetAsync<HinhAnhViewModel>($"/api/products/HinhAnh/{id}");
            return data;
        }
        public async Task<List<HinhAnhViewModel>> GetListImages(int id)
        {
            var data = await GetListAsync<HinhAnhViewModel>($"/api/products/{id}/HinhAnh");
            return data;
        }

        public async Task<ProductVM> Detail(int id)
        {
            var data = await GetAsync<ProductVM>($"/api/products/detail/{id}");
            return data;
        }

        public async Task<bool> EditProduct(ProductUpdateRequest request)
        {
            var sessions = _httpContextAccessor
                 .HttpContext
                 .Session
                 .GetString(SystemConstants.AppSettings.Token);

            var client = _httpClientFactory.CreateClient();
            client.BaseAddress = new Uri(_configuration[SystemConstants.AppSettings.BaseAddress]);
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", sessions);

            var requestContent = new MultipartFormDataContent();

            if (request.ThumbnailImage != null)
            {
                byte[] data;
                using (var br = new BinaryReader(request.ThumbnailImage.OpenReadStream()))
                {
                    data = br.ReadBytes((int)request.ThumbnailImage.OpenReadStream().Length);
                }
                ByteArrayContent bytes = new ByteArrayContent(data);
                requestContent.Add(bytes, "ThumbnailImage", request.ThumbnailImage.FileName);
            }


            requestContent.Add(new StringContent(string.IsNullOrEmpty(request.TenSanPham) ? "" : request.TenSanPham.ToString()), "TenSanPham");

            requestContent.Add(new StringContent(string.IsNullOrEmpty(request.MoTa) ? "" : request.MoTa.ToString()), "MoTa");
            requestContent.Add(new StringContent(string.IsNullOrEmpty(request.KichThuoc) ? "" : request.KichThuoc.ToString()), "KichThuoc");
            requestContent.Add(new StringContent(string.IsNullOrEmpty(request.MauSac) ? "" : request.MauSac.ToString()), "MauSac");
            requestContent.Add(new StringContent(request.SoLuongTon.ToString()), "SoLuongTon");
            requestContent.Add(new StringContent(request.Gia.ToString()), "Gia");


            var response = await client.PutAsync($"/api/products/" + request.Id, requestContent);
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> UpdateImage( HinhAnhUpdateRequest request)
        {
            var sessions = _httpContextAccessor
                 .HttpContext
                 .Session
                 .GetString(SystemConstants.AppSettings.Token);

            var client = _httpClientFactory.CreateClient();
            client.BaseAddress = new Uri(_configuration[SystemConstants.AppSettings.BaseAddress]);
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", sessions);

            var requestContent = new MultipartFormDataContent();

            if (request.ImageFile != null)
            {
                byte[] data;
                using (var br = new BinaryReader(request.ImageFile.OpenReadStream()))
                {
                    data = br.ReadBytes((int)request.ImageFile.OpenReadStream().Length);
                }
                ByteArrayContent bytes = new ByteArrayContent(data);
                requestContent.Add(bytes, "ImageFile", request.ImageFile.FileName);
            }

            requestContent.Add(new StringContent(string.IsNullOrEmpty(request.MoTa) ? "" : request.MoTa.ToString()), "MoTa");

            var response = await client.PutAsync($"/api/products/HinhAnh/{request.IdHinhAnh}", requestContent);
            return response.IsSuccessStatusCode;
        }

        public async Task<ApiResult<bool>> CategoryAssign(int id, CategoryAssignRequest request)
        {
            var client = _httpClientFactory.CreateClient();
            client.BaseAddress = new Uri(_configuration["BaseAddress"]);

            var sessions = _httpContextAccessor.HttpContext.Session.GetString("Token");
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", sessions);

            var json = JsonConvert.SerializeObject(request);
            var httpContent = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await client.PutAsync($"/api/products/{id}/categories", httpContent);
            var result = await response.Content.ReadAsStringAsync();
            if (response.IsSuccessStatusCode)
            {
                return JsonConvert.DeserializeObject<ApiSuccessResult<bool>>(result);
            }
            return JsonConvert.DeserializeObject<ApiErrorResult<bool>>(result);
        }
        public async Task<ApiResult<bool>> SetThumbnailImage(int id, ThumbnailAssignRequest request)
        {
            var client = _httpClientFactory.CreateClient();
            client.BaseAddress = new Uri(_configuration["BaseAddress"]);

            var sessions = _httpContextAccessor.HttpContext.Session.GetString("Token");
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", sessions);

            var json = JsonConvert.SerializeObject(request);
            var httpContent = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await client.PutAsync($"/api/products/{id}/setthumbnail", httpContent);
            var result = await response.Content.ReadAsStringAsync();
            if (response.IsSuccessStatusCode)
            {
                return JsonConvert.DeserializeObject<ApiSuccessResult<bool>>(result);
            }
            return JsonConvert.DeserializeObject<ApiErrorResult<bool>>(result);
        }

       

        public async Task<List<ProductVM>> GetFeaturedProducts(int take)
        {
            var data = await GetListAsync<ProductVM>($"/api/products/featured/{take}");
            return data;
        }

        public async Task<List<ProductVM>> GetLatestProducts(int take)
        {
            var data = await GetListAsync<ProductVM>($"/api/products/latest/{take}");
            return data;
        }

        public async Task<bool> DeleteProduct(int id)
        {
            return await Delete($"/api/products/" + id);
        }
        public async Task<bool> DeleteImage(int id)
        {
            return await Delete($"/api/products/HinhAnh/" + id);
        }

    } 
}
