using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using WebAPI.Data.Entities;

namespace WebAPI.Data.Configuration
{
    class ProductDetailConfiguration : IEntityTypeConfiguration<productDetail>
    {
        public void Configure(EntityTypeBuilder<productDetail> builder)
        {
            builder.Property(x => x.idProductDetail).UseIdentityColumn();

            builder.HasOne(x => x.Language).WithMany(x => x.productDetails).HasForeignKey(x => x.LanguageId);

            builder.HasOne(x => x.Products).WithMany(x => x.productDetails).HasForeignKey(x => x.ProductId);
        }

    }
}
