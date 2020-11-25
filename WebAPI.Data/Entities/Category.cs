using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace WebAPI.Data.Entities
{
    
    [Table("productCategories")]
    public class Category
    {
        [Key]
        [Required]
        public int idCategory { get; set; }
        [Required]
        [Column(TypeName = "VARCHAR(200)")]
        public string categoryName { get; set; }

        public string LanguageId { set; get; }

        [ForeignKey("idProduct")]
        public virtual products Products { get; set; }

        public List<ProductInCategory> productInCategories { get; set; }

        public List<productDetail> productDetails { get; set; }

        public List<CategoryTranslation> CategoryTranslations { get; set; }



    }
}
