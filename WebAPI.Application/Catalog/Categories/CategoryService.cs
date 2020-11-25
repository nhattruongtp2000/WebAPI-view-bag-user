using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WebAPI.Data.EF;
using WebAPI.ViewModels.Catalog.Categories;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace WebAPI.Application.Catalog.Categories
{
    public class CategoryService : ICategoryService
    {
        private readonly WebApiDbContext _context;

        public CategoryService(WebApiDbContext context)
        {
            _context = context;
        }
        public async Task<List<CategoryVm>> GetAll(string languageId)
        {
            var query = from c in _context.productCategories
                        join ct in _context.CategoryTranslations on c.idCategory equals ct.CategoryId
                        where ct.LanguageId == languageId
                        select new { c, ct };
            return await query.Select(x => new CategoryVm()
            {
                Id = x.c.idCategory,
                Name = x.ct.Name
            }).ToListAsync();
        }
    }
}
