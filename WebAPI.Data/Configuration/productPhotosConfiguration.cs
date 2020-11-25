using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using WebAPI.Data.Entities;

namespace WebAPI.Data.Configuration
{
    public class productPhotosConfiguration : IEntityTypeConfiguration<productPhotos>
    {
       
        public void Configure(EntityTypeBuilder<productPhotos> builder)
        {
            builder.ToTable("productPhotos");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id).UseIdentityColumn();

            builder.Property(x => x.ImagePath).HasMaxLength(200).IsRequired(true);
            builder.Property(x => x.Caption).HasMaxLength(200);

            builder.HasOne(x => x.Product).WithMany(x => x.productPhotos).HasForeignKey(x => x.idProduct);
        }
    }
}
