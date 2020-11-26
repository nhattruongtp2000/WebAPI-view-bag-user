﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using WebAPI.AdminApp.Services;
using WebAPI.Utilities.Constants;
using WebAPI.ViewModels.Catalog.Categories;

namespace WebAPI.AdminApp.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ICategoryApiClient _categoryApiClient;
        private readonly IConfiguration _configuration;
        private readonly IProductApiClient _productApiClient;
        public CategoryController(ICategoryApiClient categoryApiClient, IConfiguration configuration, IProductApiClient productApiClient)
        {
            _categoryApiClient = categoryApiClient;
            _configuration = configuration;
            _productApiClient = productApiClient;
        }

        public async Task<IActionResult> Index(string keyword, int pageIndex = 1, int pageSize = 10)
        {
            var languageId = HttpContext.Session.GetString(SystemConstants.AppSettings.DefaultLanguageId);

            var sessions = HttpContext.Session.GetString("Token");
            var request = new GetCategoryPagingRequest()
            {               
                Keyword = keyword,
                PageIndex = pageIndex,
                PageSize = pageSize,
                LanguageId=languageId
            };
            var data = await _categoryApiClient.GetCategoriesPagings(request);
            ViewBag.Keyword = keyword;
            if (TempData["result"] != null)
            {
                ViewBag.SuccessMsg = TempData["result"];
            }

            return View(data);
        }
    }
}
