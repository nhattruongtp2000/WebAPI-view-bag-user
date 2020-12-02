using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using WebAPI.Utilities.Constants;
using WebAPI.ViewModels.Catalog.Categories;
using WebAPI.ViewModels.Common;

namespace WebAPI.AdminApp.Services
{
    public class CategoryApiClient : BaseApiClient, ICategoryApiClient
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IConfiguration _configuration;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public CategoryApiClient(IHttpClientFactory httpClientFactory,
                   IHttpContextAccessor httpContextAccessor,
                    IConfiguration configuration)
            : base(httpClientFactory, httpContextAccessor, configuration)
        {
            _configuration = configuration;
            _httpContextAccessor = httpContextAccessor;
            _httpClientFactory = httpClientFactory;

        }

        public async Task<bool> CreateProduct(CategoryCreateRequest request)
        {
            var sessions = _httpContextAccessor
                 .HttpContext
                 .Session
                 .GetString(SystemConstants.AppSettings.Token);

            var languageId = _httpContextAccessor.HttpContext.Session.GetString(SystemConstants.AppSettings.DefaultLanguageId);

            var client = _httpClientFactory.CreateClient();
            client.BaseAddress = new Uri(_configuration[SystemConstants.AppSettings.BaseAddress]);
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", sessions);

            var requestContent = new MultipartFormDataContent();

            requestContent.Add(new StringContent(request.SortOrder.ToString()), "sortorder");
            requestContent.Add(new StringContent(request.IsShowOnHome.ToString()), "isshowonHome");
            requestContent.Add(new StringContent(request.Name.ToString()), "name");
            requestContent.Add(new StringContent(request.SeoDescription.ToString()), "seodescription");
            requestContent.Add(new StringContent(request.SeoTitle.ToString()), "seotitle");
            requestContent.Add(new StringContent(languageId), "languageId");
            requestContent.Add(new StringContent(request.SeoAlias.ToString()), "seoalias");
            

            var response = await client.PostAsync($"/api/categories/", requestContent);
            return response.IsSuccessStatusCode;
        }

        public async Task<List<CategoryVm>> GetAll(string languageId)
        {
            return await GetListAsync<CategoryVm>("/api/categories?languageId=" + languageId);
        }

        public async Task<CategoryVm> GetById(int id, string languageId)
        {
            var data = await GetAsync<CategoryVm>($"/api/categories/{id}/{languageId}");

            return data;
        }

        public async Task<PagedResult<CategoryVm>> GetCategoriesPagings(GetCategoryPagingRequest request)
        {
            var data = await GetAsync<PagedResult<CategoryVm>>(
                $"/api/categories/paging?pageIndex={request.PageIndex}" +
                $"&pageSize={request.PageSize}" +
                $"&keyword={request.Keyword}&languageId={request.LanguageId}&categoryId={request.CategoryId}");

            return data;
        }
    }
}
