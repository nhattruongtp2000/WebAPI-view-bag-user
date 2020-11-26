using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace WebAPI.Data.Entities
{ 
    public class Category
    {
        
        public int idCategory { get; set; }
        
        public int SortOrder { set; get; }
        public bool IsShowOnHome { set; get; }

   
        

        public List<ProductInCategory> productInCategories { get; set; }

        public List<productDetail> productDetails { get; set; }

        public List<CategoryTranslation> CategoryTranslations { get; set; }



    }
}
