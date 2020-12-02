using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using WebAPI.Data.Enums;

namespace WebAPI.Data.Entities
{
    [Table("productDetails")]
    public class productDetail
    {
        [Key]       
        public int idProductDetail           {get;set;}
        [Required]
        public int ProductId { get; set; }
        [Required]
        [Column(TypeName = "VARCHAR(200)")]
        public string ProductName { get; set; }
        [Required]
        [Column(TypeName = "VARCHAR(200)")]
        public decimal   price                     {get;set;}
        [Required]
        [Column(TypeName = "VARCHAR(200)")]
        public decimal salePrice                 {get;set;}

        public string LanguageId { set; get; }

        [Required]
        [Column(TypeName = "VARCHAR(2000)")]
        public string detail                    {get;set;}

        [DefaultValue(false)]
        public bool isSaling                     {get;set;}
        public DateTime expiredSalingDate       {get;set;}
   
        public DateTime dateAdded { get; set; }

        
        public  products Products { get; set; }

        public  Language Language { get; set; }


    }
}
