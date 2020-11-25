using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WebAPI.ViewModels.Catalog.Categories;

namespace WebAPI.Application.Catalog.Categories
{
    public interface ICategoryService
    {
        Task<List<CategoryVm>> GetAll(string languageId);
    }
}
