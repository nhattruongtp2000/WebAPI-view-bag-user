﻿using System;
using System.Collections.Generic;
using System.Text;

namespace WebAPI.ViewModels.Catalog.Products
{
    public class ProductVm
    {
        public int Id { get; set; }
        public decimal price { get; set; }
        public string ProductName { get; set; }
        public decimal salePrice { get; set; }

        public bool isSaling { get; set; }
        public string detail { get; set; }
        public int ViewCount { get; set; }

        public string LanguageId { set; get; }
        public DateTime dateAdded { get; set; }


    }
}