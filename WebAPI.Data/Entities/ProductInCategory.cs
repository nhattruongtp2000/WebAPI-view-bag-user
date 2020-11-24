using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace WebAPI.Data.Entities
{
    
    public class ProductInCategory
    {
        
        public int  idProduct { get; set; }

        
        public virtual products Product { get; set; }
  
        public int idCategory { get; set; }

        
        public virtual productCategories Category { get; set; }

        
    }
}
