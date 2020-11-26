using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WebAPI.Data.EF;
using WebAPI.ViewModels.Catalog.Categories;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using WebAPI.ViewModels.Common;

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
            var query = from c in _context.Categories
                        join ct in _context.CategoryTranslations on c.idCategory equals ct.CategoryId
                        where ct.LanguageId == languageId
                        select new { c, ct };
            return await query.Select(x => new CategoryVm()
            {
                Id = x.c.idCategory,
                Name = x.ct.Name
            }).ToListAsync();
        }

        public async Task<PagedResult<CategoryVm>> GetCategoriesPagings(GetCategoryPagingRequest request)
        {

            ////1. Select join
            //var query = from p in _context.Categories
            //            join pt in _context.CategoryTranslations on p.idCategory equals pt.CategoryId
            //            join pic in _context.ProductInCategories on p.idCategory equals pic.idCategory into ppic
            //            from pic in ppic.DefaultIfEmpty()
            //            join c in _context.products on pic.ProductId equals c.ProductId into picc
            //            from c in picc.DefaultIfEmpty()

            //            select new { p, pt, pic };
            ////2. filter
            //if (!string.IsNullOrEmpty(request.Keyword))
            //    query = query.Where(x => x.pt.Name.Contains(request.Keyword));

            //if (request.CategoryId != null && request.CategoryId != 0)
            //{
            //    query = query.Where(p => p.pic.idCategory == request.CategoryId);
            //}

            ////3. Paging
            //int totalRow = await query.CountAsync();

            //var data = await query.Skip((request.PageIndex - 1) * request.PageSize)
            //    .Take(request.PageSize)
            //    .Select(x => new CategoryVm()
            //    {
            //        Id = x.p.idCategory,
            //        ProductId = x.pic.ProductId,
            //        Name = x.pt.Name,
            //        SeoDescription = x.pt.SeoDescription,
            //        SeoAlias = x.pt.SeoAlias,
            //        SeoTitle = x.pt.SeoTitle,

            //    }).ToListAsync();

            ////4. Select and projection
            //var pagedResult = new PagedResult<CategoryVm>()
            //{
            //    TotalRecords = totalRow,
            //    PageSize = request.PageSize,
            //    PageIndex = request.PageIndex,
            //    Items = data
            //};
            //return pagedResult;

            //1. Select join
            var query = from p in _context.Categories
                        join pt in _context.CategoryTranslations on p.idCategory equals pt.CategoryId
                        where pt.LanguageId == request.LanguageId
                        select new { p, pt};
            //2. filter
            if (!string.IsNullOrEmpty(request.Keyword))
                query = query.Where(x => x.pt.Name.Contains(request.Keyword));

          
            //3. Paging
            int totalRow = await query.CountAsync();

            var data = await query.Skip((request.PageIndex - 1) * request.PageSize)
                .Take(request.PageSize)
                .Select(x => new CategoryVm()
                {
                    Id = x.p.idCategory,
                    Name = x.pt.Name,
                    SeoDescription = x.pt.SeoDescription,
                    SeoAlias = x.pt.SeoAlias,
                    SeoTitle = x.pt.SeoTitle,
                    LanguageId=request.LanguageId
                }).ToListAsync();

            //4. Select and projection
            var pagedResult = new PagedResult<CategoryVm>()
            {
                TotalRecords = totalRow,
                PageSize = request.PageSize,
                PageIndex = request.PageIndex,
                Items = data
            };
            return pagedResult;
        }
    }
}