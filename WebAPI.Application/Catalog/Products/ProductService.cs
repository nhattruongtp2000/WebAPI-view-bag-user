using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WebAPI.Data.EF;
using WebAPI.Data.Entities;
using WebAPI.Utilities.Exceptions;
using WebAPI.ViewModels.Catalog.Products;
using WebAPI.ViewModels.Common;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using WebAPI.Application.Common;
using Microsoft.AspNetCore.Http;
using System.Net.Http.Headers;
using System.IO;
using WebAPI.ViewModels.Catalog.ProductImages;

namespace WebAPI.Application.Catalog.Products
{
    public class ProductService : IProductService
    {
        private readonly WebApiDbContext _context;
        private readonly IStorageService _storageService;
        public ProductService(WebApiDbContext context, IStorageService storageService)
        {
            _context = context;
            _storageService = storageService;
        }

      

        public async Task<int> AddImage(int idProduct, ProductImageCreateRequest request)
        {
            var ProductPhoto = new productPhotos()
            {
                Caption = request.Caption,
                uploadedTime = DateTime.Now,
                IsDefault = request.IsDefault,
                idProduct = idProduct,
                SortOrder = request.SortOrder,
                         
            };

            if (request.ImageFile != null)
            {
                ProductPhoto.ImagePath = await this.SaveFile(request.ImageFile);
                ProductPhoto.FileSize = request.ImageFile.Length;
            }
            _context.productPhotos.Add(ProductPhoto);
            await _context.SaveChangesAsync();
            return ProductPhoto.Id;
        }

        public async Task AddViewcount(int idProduct)
        {
            var product = await _context.products.FindAsync(idProduct);
            product.ViewCount += 1;
            await _context.SaveChangesAsync();
        }


        public async Task<int> Create(ProductCreateRequest request)
        {
            var product = new products()
            {              
                idSize = request.idSize,
                idBrand = request.idBrand,
                idColor = request.idColor,
                idType = request.idType,
                ViewCount = 0,
                productDetails = new List<productDetail>()
                {
                     new productDetail()
                     {
                         ProductName=request.ProductName,
                         price=request.price,
                         salePrice=request.salePrice,
                         detail=request.detail,
                         dateAdded=DateTime.Now,
                         LanguageId = request.LanguageId
                     }
                
            },
                productInCategories = new List<ProductInCategory>()
                {
                    new ProductInCategory()
                    {
                        idCategory=request.idCategory,
                        
                    }
                }
            };

            //Save image
            if (request.ThumbnailImage != null)
            {
                product.productPhotos = new List<productPhotos>()
                {
                    new productPhotos()
                    {
                        Caption = "Thumbnail image",
                        uploadedTime = DateTime.Now,
                        FileSize = request.ThumbnailImage.Length,
                        ImagePath = await this.SaveFile(request.ThumbnailImage),
                        IsDefault = true,
                        SortOrder = 1
                    }
                };
            }
            _context.products.Add(product);
            await _context.SaveChangesAsync();
            return product.ProductId;
        }

        public async Task<int> Delete(int idProduct)
        {
            var product = await _context.products.FindAsync(idProduct);
            if (product == null) throw new WebAPIException($"Cannot find a product: {idProduct}");

            var images = _context.productPhotos.Where(i => i.idProduct == idProduct);
            foreach (var image in images)
            {
                await _storageService.DeleteFileAsync(image.ImagePath);
            }


            _context.products.Remove(product);
            return await _context.SaveChangesAsync();
        }

      

        

        public async Task<PagedResult<ProductVm>> GetAllPaging(GetManageProductPagingRequest request)
        {
            //1. Select join
            var query = from p in _context.products
                        join pt in _context.productDetails on p.ProductId equals pt.ProductId
                        join pic in _context.ProductInCategories on p.ProductId equals pic.ProductId into ppic
                        from pic in ppic.DefaultIfEmpty()
                        join c in _context.Categories on pic.idCategory equals c.idCategory into picc
                        from c in picc.DefaultIfEmpty()
                        where pt.LanguageId == request.LanguageId
                        select new { p, pt, pic};
            //2. filter
            if (!string.IsNullOrEmpty(request.Keyword))
                query = query.Where(x => x.pt.ProductName.Contains(request.Keyword));

            if (request.CategoryId != null && request.CategoryId != 0)
            {
                query = query.Where(p => p.pic.idCategory == request.CategoryId);
            }

            //3. Paging
            int totalRow = await query.CountAsync();

            var data = await query.Skip((request.PageIndex - 1) * request.PageSize)
                .Take(request.PageSize)
                .Select(x => new ProductVm()
                {
                    Id = x.p.ProductId,
                    ProductName = x.pt.ProductName,
                    price = x.pt.price,
                    salePrice = x.pt.salePrice,
                    ViewCount = x.p.ViewCount,
                    detail = x.pt.detail,
                    LanguageId = x.pt.LanguageId,
                }).ToListAsync();

            //4. Select and projection
            var pagedResult = new PagedResult<ProductVm>()
            {
                TotalRecords = totalRow,
                PageSize = request.PageSize,
                PageIndex = request.PageIndex,
                Items = data
            };
            return pagedResult;
        }


        
        public async Task<ProductVm> GetById(int productId, string languageId)
        {
            var product = await _context.products.FindAsync(productId);
            var productTranslation = await _context.productDetails.FirstOrDefaultAsync(x => x.ProductId == productId && x.LanguageId == languageId);

            var categories = await (from c in _context.Categories
                                    join ct in _context.CategoryTranslations on c.idCategory equals ct.CategoryId
                                    join pic in _context.ProductInCategories on c.idCategory equals pic.idCategory
                                    where pic.ProductId == productId && ct.LanguageId == languageId
                                    select ct.Name).ToListAsync();
            var productViewModel = new ProductVm()
            {
                Id = product.ProductId,
                ProductName = productTranslation != null ? productTranslation.ProductName : null,
                price = productTranslation.price,
                salePrice = productTranslation.salePrice,
                ViewCount = product.ViewCount,
                detail = productTranslation.detail,
                dateAdded = productTranslation.dateAdded, 
                LanguageId = productTranslation.LanguageId,
                Categories=categories
            };
            return productViewModel;
        }


        public async Task<ProductImageViewModel> GetImageById(int imageId)
        {
            var image = await _context.productPhotos.FindAsync(imageId);
            if (image == null)
                throw new WebAPIException($"Cannot find an image with id {imageId}");

            var viewModel = new ProductImageViewModel()
            {
                Caption = image.Caption,
                uploadedTime = image.uploadedTime,
                FileSize = image.FileSize,
                Id = image.Id,
                ImagePath = image.ImagePath,
                IsDefault = image.IsDefault,
                IdProduct = image.idProduct,
                SortOrder = image.SortOrder
            };
            return viewModel;
        }

        public async  Task<List<ProductImageViewModel>> GetListImages(int idProduct)
        {
            return await _context.productPhotos.Where(x => x.idProduct == idProduct)
               .Select(i => new ProductImageViewModel()
               {
                   Caption = i.Caption,
                   uploadedTime = i.uploadedTime,
                   FileSize = i.FileSize,
                   Id = i.Id,
                   ImagePath = i.ImagePath,
                   IsDefault = i.IsDefault,
                   IdProduct = i.idProduct,
                   SortOrder = i.SortOrder
               }).ToListAsync();
        }

        public async Task<int> RemoveImage(int imageId)
        {
            var productImage = await _context.productPhotos.FindAsync(imageId);
            if (productImage == null)
                throw new WebAPIException($"Cannot find an image with id {imageId}");
            _context.productPhotos.Remove(productImage);
            return await _context.SaveChangesAsync();
        }

        public async Task<int> Update(ProductUpdateRequest request)
        {
            var product = await _context.products.FindAsync(request.Id);
            var productDetails = await _context.productDetails.FirstOrDefaultAsync(x => x.ProductId == request.Id && x.LanguageId == request.LanguageId);

            if (product == null || productDetails == null) throw new WebAPIException($"Cannot find a product with id: {request.Id}");

            productDetails.ProductName = request.ProductName;
            productDetails.price = request.price;
            productDetails.detail = request.detail;
            productDetails.salePrice = request.salePrice;

            //Save image
            if (request.ThumbnailImage != null)
            {
                var thumbnailImage = await _context.productPhotos.FirstOrDefaultAsync(i => i.IsDefault == true && i.idProduct == request.Id);
                if (thumbnailImage != null)
                {
                    thumbnailImage.FileSize = request.ThumbnailImage.Length;
                    thumbnailImage.ImagePath = await this.SaveFile(request.ThumbnailImage);
                    _context.productPhotos.Update(thumbnailImage);
                }
            }


            return await _context.SaveChangesAsync();
        }

        public async Task<int> UpdateImage(int imageId, ProductImageUpdateRequest request)
        {
            var productImage = await _context.productPhotos.FindAsync(imageId);
            if (productImage == null)
                throw new WebAPIException($"Cannot find an image with id {imageId}");

            if (request.ImageFile != null)
            {
                productImage.ImagePath = await this.SaveFile(request.ImageFile);
                productImage.FileSize = request.ImageFile.Length;
            }
            _context.productPhotos.Update(productImage);
            return await _context.SaveChangesAsync();

        }

        public async Task<bool> UpdatePrice(int idProduct, decimal newPrice)
        {
            var product = await _context.productDetails.FindAsync(idProduct);
            if (product == null) throw new WebAPIException($"Cannot find a product with id: {idProduct}");
            product.price = newPrice;
            return await _context.SaveChangesAsync() > 0;
        }

        private async Task<string> SaveFile(IFormFile file)
        {
            var originalFileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');
            var fileName = $"{Guid.NewGuid()}{Path.GetExtension(originalFileName)}";
            await _storageService.SaveFileAsync(file.OpenReadStream(), fileName);
            return fileName;
        }

        public async Task<PagedResult<ProductVm>> GetAllByCategoryId(string languageId,GetPublicProductPagingRequest request)
        {
            var query = from p in _context.products
                        join pt in _context.productDetails on p.ProductId equals pt.ProductId
                        join pic in _context.ProductInCategories on p.ProductId equals pic.ProductId
                        join c in _context.Categories on pic.idCategory equals c.idCategory
                        where pt.LanguageId == languageId
                        select new { p, pt, pic };
            //2. filter
            if (request.idCategory.HasValue && request.idCategory.Value > 0)
                query = query.Where(p => p.pic.idCategory == request.idCategory);

            //3. Paging
            int totalRow = await query.CountAsync();

            var data = await query.Skip((request.PageIndex - 1) * request.PageSize)
                .Take(request.PageSize)
                .Select(x => new ProductVm()
                {
                    Id = x.p.ProductId,
                    ProductName = x.pt.ProductName,
                    price = x.pt.price,
                    salePrice = x.pt.salePrice,
                    LanguageId = x.pt.LanguageId,
                    ViewCount = x.p.ViewCount,
                    detail = x.pt.detail,

                }).ToListAsync();

            //4. Select and projection
            var pagedResult = new PagedResult<ProductVm>()
            {
                TotalRecords = totalRow,
                PageIndex = request.PageIndex,
                PageSize = request.PageSize,
                Items = data
            };
            return pagedResult;
        }

        public async Task<ApiResult<bool>> CategoryAssign(int id, CategoryAssignRequest request)
        {
            var user = await _context.products.FindAsync(id);
            if (user == null)
            {
                return new ApiErrorResult<bool>($"Sản phẩm với id {id} không tồn tại");
            }
            foreach (var category in request.Categories)
            {
                var productInCategory = await _context.ProductInCategories
                    .FirstOrDefaultAsync(x => x.idCategory == int.Parse(category.Id)
                    && x.ProductId == id);
                if (productInCategory != null && category.Selected == false)
                {
                    _context.ProductInCategories.Remove(productInCategory);
                }
                else if (productInCategory == null && category.Selected)
                {
                    await _context.ProductInCategories.AddAsync(new ProductInCategory()
                    {
                        idCategory = int.Parse(category.Id),
                        ProductId = id
                    });
                }
            }
            await _context.SaveChangesAsync();
            return new ApiSuccessResult<bool>();
        }
    }
}
