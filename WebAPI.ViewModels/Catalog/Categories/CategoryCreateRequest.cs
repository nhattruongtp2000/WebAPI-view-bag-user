using System;
using System.Collections.Generic;
using System.Text;

namespace WebAPI.ViewModels.Catalog.Categories
{
    public class CategoryCreateRequest
    {
        public int SortOrder { set; get; }
        public bool IsShowOnHome { set; get; }
        public string Name { set; get; }
        public string SeoDescription { set; get; }
        public string SeoTitle { set; get; }
        public string LanguageId { set; get; }
        public string SeoAlias { set; get; }
    }
}
