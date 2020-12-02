using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace WebAPI.ViewModels.Catalog.Products
{
    public class ProductCreateRequest
    {
        [Required(ErrorMessage = "Cần nhập giá gốc")]
        public decimal price { get; set; }
        public decimal salePrice { get; set; }
        public string detail { get; set; }
        [Required(ErrorMessage ="Cần nhập tên sản phẩm")]
        public string ProductName { get; set; }
        public string idSize { get; set; }
        public string idBrand { get; set; }
        public string idColor { get; set; }
        public string idType { get; set; }
        public int idCategory { get; set; } //
        public string LanguageId { set; get; }
        public IFormFile ThumbnailImage { get; set; }
    }
}
