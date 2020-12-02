using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Application.Catalog.Categories;
using WebAPI.ViewModels.Catalog.Categories;

namespace WebAPI.BackendAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoriesController(
            ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll(string languageId)
        {
            var products = await _categoryService.GetAll(languageId);
            return Ok(products);
        }

        [HttpGet("paging")]
        public async Task<IActionResult> GetAllPaging([FromQuery] GetCategoryPagingRequest request)
        {
            var categories = await _categoryService.GetCategoriesPagings(request);
            return Ok(categories);
        }

        //Create
        [HttpPost]
        [Consumes("multipart/form-data")]
        public async Task<IActionResult> Create([FromForm] CategoryCreateRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var idCategory = await _categoryService.Create(request);
            if (idCategory == 0)
                return BadRequest();

            var product = await _categoryService.GetById(idCategory, request.LanguageId);

            return CreatedAtAction(nameof(GetById), new { id = idCategory }, product);
        }

        //http://localhost:port/category/1
        [HttpGet("{idCategory}/{languageId}")]
        public async Task<IActionResult> GetById(int idCategory, string languageId)
        {
            var category = await _categoryService.GetById(idCategory, languageId);
            if (category == null)
                return BadRequest("Cannot find product");
            return Ok(category);
        }
    }
}
