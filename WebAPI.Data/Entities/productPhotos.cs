    using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace WebAPI.Data.Entities
{
    
    public class productPhotos
    {
        
        public int Id { get; set; }
        
        public int idProduct { get; set; }
        
        public string ImagePath { get; set; }
        public string Caption { get; set; }

        public bool IsDefault { get; set; }

        public int SortOrder { get; set; }

        public long FileSize { get; set; }

        
        public DateTime uploadedTime { get; set; }

        
        public  products Product { get; set; }
    }
}
