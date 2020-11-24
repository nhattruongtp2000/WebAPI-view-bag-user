﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WebAPI.Data.EF;

namespace WebAPI.Data.Migrations
{
    [DbContext(typeof(WebApiDbContext))]
    partial class WebApiDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.0");

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<System.Guid>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("RoleId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.ToTable("RoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<System.Guid>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.ToTable("UserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<System.Guid>", b =>
                {
                    b.Property<Guid>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId");

                    b.ToTable("UserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<System.Guid>", b =>
                {
                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("RoleId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("UserId", "RoleId");

                    b.ToTable("UserRoles");

                    b.HasData(
                        new
                        {
                            UserId = new Guid("69bd714f-9576-45ba-b5b7-f00649be00de"),
                            RoleId = new Guid("8d04dce2-969a-435d-bba4-df3f325983dc")
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<System.Guid>", b =>
                {
                    b.Property<Guid>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId");

                    b.ToTable("UserTokens");
                });

            modelBuilder.Entity("WebAPI.Data.Entities.Language", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<bool>("IsDefault")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Languages");

                    b.HasData(
                        new
                        {
                            Id = "vi-VN",
                            IsDefault = true,
                            Name = "Tiếng Việt"
                        },
                        new
                        {
                            Id = "en-US",
                            IsDefault = false,
                            Name = "English"
                        });
                });

            modelBuilder.Entity("WebAPI.Data.Entities.ProductInCategory", b =>
                {
                    b.Property<int>("idCategory")
                        .HasColumnType("int");

                    b.Property<int>("idProduct")
                        .HasColumnType("int");

                    b.HasKey("idCategory", "idProduct");

                    b.HasIndex("idProduct");

                    b.ToTable("ProductInCategories");

                    b.HasData(
                        new
                        {
                            idCategory = 1,
                            idProduct = 1
                        });
                });

            modelBuilder.Entity("WebAPI.Data.Entities.ordersDetails", b =>
                {
                    b.Property<string>("idOrder")
                        .HasColumnType("VARCHAR(200)");

                    b.Property<DateTime>("date")
                        .HasColumnType("datetime2");

                    b.Property<string>("idVoucher")
                        .IsRequired()
                        .HasColumnType("VARCHAR(200)");

                    b.Property<string>("status")
                        .IsRequired()
                        .HasColumnType("VARCHAR(200)");

                    b.Property<int>("totalPrice")
                        .HasColumnType("int");

                    b.HasKey("idOrder");

                    b.ToTable("OrdersDetails");
                });

            modelBuilder.Entity("WebAPI.Data.Entities.ordersList", b =>
                {
                    b.Property<string>("idOrder")
                        .IsRequired()
                        .HasColumnType("VARCHAR(200)");

                    b.Property<int>("idProduct")
                        .HasColumnType("int");

                    b.Property<Guid>("idUser")
                        .HasColumnType("uniqueidentifier");

                    b.HasIndex("idOrder");

                    b.HasIndex("idProduct");

                    b.HasIndex("idUser");

                    b.ToTable("ordersLists");
                });

            modelBuilder.Entity("WebAPI.Data.Entities.productBrand", b =>
                {
                    b.Property<string>("idBrand")
                        .HasColumnType("VARCHAR(200)");

                    b.Property<string>("brandDetail")
                        .IsRequired()
                        .HasColumnType("VARCHAR(200)");

                    b.Property<string>("brandName")
                        .IsRequired()
                        .HasColumnType("VARCHAR(200)");

                    b.HasKey("idBrand");

                    b.ToTable("productBrands");

                    b.HasData(
                        new
                        {
                            idBrand = "1",
                            brandDetail = "Logo",
                            brandName = "Logo"
                        },
                        new
                        {
                            idBrand = "2",
                            brandDetail = "Company",
                            brandName = "Company"
                        });
                });

            modelBuilder.Entity("WebAPI.Data.Entities.productCategories", b =>
                {
                    b.Property<int>("idCategory")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("LanguageId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("categoryName")
                        .IsRequired()
                        .HasColumnType("VARCHAR(200)");

                    b.Property<int?>("idProduct")
                        .HasColumnType("int");

                    b.HasKey("idCategory");

                    b.HasIndex("LanguageId");

                    b.HasIndex("idProduct");

                    b.ToTable("productCategories");

                    b.HasData(
                        new
                        {
                            idCategory = 1,
                            categoryName = "Shoes"
                        },
                        new
                        {
                            idCategory = 2,
                            categoryName = "Shirt"
                        });
                });

            modelBuilder.Entity("WebAPI.Data.Entities.productColor", b =>
                {
                    b.Property<string>("idColor")
                        .HasColumnType("VARCHAR(200)");

                    b.Property<string>("colorName")
                        .IsRequired()
                        .HasColumnType("VARCHAR(200)");

                    b.HasKey("idColor");

                    b.ToTable("productColors");

                    b.HasData(
                        new
                        {
                            idColor = "ffffff",
                            colorName = "While"
                        },
                        new
                        {
                            idColor = "Red",
                            colorName = "Red"
                        });
                });

            modelBuilder.Entity("WebAPI.Data.Entities.productDetail", b =>
                {
                    b.Property<int>("idProductDetail")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("LanguageId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProductName")
                        .IsRequired()
                        .HasColumnType("VARCHAR(200)");

                    b.Property<DateTime>("dateAdded")
                        .HasColumnType("datetime2");

                    b.Property<string>("detail")
                        .IsRequired()
                        .HasColumnType("VARCHAR(2000)");

                    b.Property<DateTime>("expiredSalingDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("idProduct")
                        .HasColumnType("int");

                    b.Property<bool>("isSaling")
                        .HasColumnType("bit");

                    b.Property<string>("price")
                        .IsRequired()
                        .HasColumnType("VARCHAR(200)");

                    b.Property<int?>("productCategoriesidCategory")
                        .HasColumnType("int");

                    b.Property<string>("salePrice")
                        .IsRequired()
                        .HasColumnType("VARCHAR(200)");

                    b.HasKey("idProductDetail");

                    b.HasIndex("LanguageId");

                    b.HasIndex("idProduct");

                    b.HasIndex("productCategoriesidCategory");

                    b.ToTable("productDetails");

                    b.HasData(
                        new
                        {
                            idProductDetail = 1,
                            LanguageId = "vi-VN",
                            ProductName = "Shoe",
                            dateAdded = new DateTime(2019, 10, 21, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            detail = "goood product",
                            expiredSalingDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            idProduct = 1,
                            isSaling = false,
                            price = "1000000",
                            salePrice = "1000000"
                        },
                        new
                        {
                            idProductDetail = 2,
                            LanguageId = "vi-VN",
                            ProductName = "Pro",
                            dateAdded = new DateTime(2019, 10, 21, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            detail = "goood product",
                            expiredSalingDate = new DateTime(2020, 10, 12, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            idProduct = 2,
                            isSaling = false,
                            price = "2000000",
                            salePrice = "1000000"
                        });
                });

            modelBuilder.Entity("WebAPI.Data.Entities.productPhotos", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Caption")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("FileSize")
                        .HasColumnType("bigint");

                    b.Property<string>("ImagePath")
                        .IsRequired()
                        .HasColumnType("VARCHAR(200)");

                    b.Property<bool>("IsDefault")
                        .HasColumnType("bit");

                    b.Property<int>("SortOrder")
                        .HasColumnType("int");

                    b.Property<int>("idProduct")
                        .HasColumnType("int");

                    b.Property<int?>("productDetailidProductDetail")
                        .HasColumnType("int");

                    b.Property<DateTime>("uploadedTime")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("idProduct");

                    b.HasIndex("productDetailidProductDetail");

                    b.ToTable("productPhotos");
                });

            modelBuilder.Entity("WebAPI.Data.Entities.productSize", b =>
                {
                    b.Property<string>("idSize")
                        .HasColumnType("VARCHAR(200)");

                    b.Property<string>("sizeName")
                        .IsRequired()
                        .HasColumnType("VARCHAR(200)");

                    b.HasKey("idSize");

                    b.ToTable("productSizes");

                    b.HasData(
                        new
                        {
                            idSize = "1",
                            sizeName = "L"
                        },
                        new
                        {
                            idSize = "2",
                            sizeName = "M"
                        });
                });

            modelBuilder.Entity("WebAPI.Data.Entities.productTypes", b =>
                {
                    b.Property<string>("idType")
                        .HasColumnType("VARCHAR(200)");

                    b.Property<string>("typeName")
                        .IsRequired()
                        .HasColumnType("VARCHAR(200)");

                    b.HasKey("idType");

                    b.ToTable("productTypes");

                    b.HasData(
                        new
                        {
                            idType = "1",
                            typeName = "Cheap"
                        },
                        new
                        {
                            idType = "2",
                            typeName = "Expensive"
                        });
                });

            modelBuilder.Entity("WebAPI.Data.Entities.products", b =>
                {
                    b.Property<int>("idProduct")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int>("ViewCount")
                        .HasColumnType("int");

                    b.Property<string>("idBrand")
                        .IsRequired()
                        .HasColumnType("VARCHAR(200)");

                    b.Property<string>("idCategory")
                        .IsRequired()
                        .HasColumnType("VARCHAR(200)");

                    b.Property<string>("idColor")
                        .IsRequired()
                        .HasColumnType("VARCHAR(200)");

                    b.Property<string>("idSize")
                        .IsRequired()
                        .HasColumnType("VARCHAR(200)");

                    b.Property<string>("idType")
                        .IsRequired()
                        .HasColumnType("VARCHAR(200)");

                    b.Property<string>("ordersDetailsidOrder")
                        .HasColumnType("VARCHAR(200)");

                    b.HasKey("idProduct");

                    b.HasIndex("idBrand");

                    b.HasIndex("idColor");

                    b.HasIndex("idSize");

                    b.HasIndex("idType");

                    b.HasIndex("ordersDetailsidOrder");

                    b.ToTable("products");

                    b.HasData(
                        new
                        {
                            idProduct = 1,
                            ViewCount = 0,
                            idBrand = "1",
                            idCategory = "1",
                            idColor = "ffffff",
                            idSize = "1",
                            idType = "1"
                        },
                        new
                        {
                            idProduct = 2,
                            ViewCount = 0,
                            idBrand = "1",
                            idCategory = "1",
                            idColor = "ffffff",
                            idSize = "1",
                            idType = "1"
                        });
                });

            modelBuilder.Entity("WebAPI.Data.Entities.rating", b =>
                {
                    b.Property<string>("comment")
                        .IsRequired()
                        .HasColumnType("VARCHAR(200)");

                    b.Property<int>("idProduct")
                        .HasColumnType("int");

                    b.Property<Guid>("idUser")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("rate")
                        .HasColumnType("int");

                    b.Property<DateTime>("rateDate")
                        .HasColumnType("datetime2");

                    b.HasIndex("idProduct");

                    b.HasIndex("idUser");

                    b.ToTable("ratings");
                });

            modelBuilder.Entity("WebAPI.Data.Entities.role", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("ConcurrencyStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("VARCHAR(200)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NormalizedName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Roles");

                    b.HasData(
                        new
                        {
                            Id = new Guid("8d04dce2-969a-435d-bba4-df3f325983dc"),
                            ConcurrencyStamp = "7b1d8cd3-5e88-4002-8901-5b447a05248a",
                            Description = "Administrator role",
                            Name = "admin",
                            NormalizedName = "admin"
                        });
                });

            modelBuilder.Entity("WebAPI.Data.Entities.users", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NormalizedUserName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("birthday")
                        .IsRequired()
                        .HasColumnType("VARCHAR(200)");

                    b.Property<string>("firstName")
                        .IsRequired()
                        .HasColumnType("VARCHAR(200)");

                    b.Property<string>("interestedIn")
                        .HasColumnType("VARCHAR(200)");

                    b.Property<DateTime>("lastLogin")
                        .HasColumnType("datetime2");

                    b.Property<string>("lastName")
                        .IsRequired()
                        .HasColumnType("VARCHAR(200)");

                    b.Property<string>("note")
                        .HasColumnType("VARCHAR(200)");

                    b.Property<string>("province")
                        .HasColumnType("VARCHAR(200)");

                    b.HasKey("Id");

                    b.ToTable("users");

                    b.HasData(
                        new
                        {
                            Id = new Guid("69bd714f-9576-45ba-b5b7-f00649be00de"),
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "d06bd459-afbf-4348-82ce-d183a26ea693",
                            Email = "nhattruongtp2000@gmail.com",
                            EmailConfirmed = true,
                            LockoutEnabled = false,
                            NormalizedEmail = "nhattruongtp2000@gmail.com",
                            NormalizedUserName = "admin",
                            PasswordHash = "AQAAAAEAACcQAAAAEKbX5Uq0McqgZTiDF1j2G7bOtrhXKZVKfxEBekwLCWvnMXcm/EaLD4/wMg66dz1hVw==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "",
                            TwoFactorEnabled = false,
                            UserName = "admin",
                            birthday = "2020-10-12 00:00:00",
                            firstName = "Nguyen",
                            lastLogin = new DateTime(2020, 11, 13, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            lastName = "Truong"
                        });
                });

            modelBuilder.Entity("WebAPI.Data.Entities.vouchers", b =>
                {
                    b.Property<string>("idVoucher")
                        .HasColumnType("VARCHAR(200)");

                    b.Property<int>("isUse")
                        .HasColumnType("int");

                    b.Property<int>("price")
                        .HasColumnType("int");

                    b.HasKey("idVoucher");

                    b.ToTable("vouchers");
                });

            modelBuilder.Entity("WebAPI.Data.Entities.ProductInCategory", b =>
                {
                    b.HasOne("WebAPI.Data.Entities.productCategories", "Category")
                        .WithMany("productInCategories")
                        .HasForeignKey("idCategory")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WebAPI.Data.Entities.products", "Product")
                        .WithMany("productInCategories")
                        .HasForeignKey("idProduct")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("WebAPI.Data.Entities.ordersList", b =>
                {
                    b.HasOne("WebAPI.Data.Entities.ordersDetails", "OrdersDetails")
                        .WithMany()
                        .HasForeignKey("idOrder")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WebAPI.Data.Entities.products", "Products")
                        .WithMany()
                        .HasForeignKey("idProduct")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WebAPI.Data.Entities.users", "Users")
                        .WithMany()
                        .HasForeignKey("idUser")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("OrdersDetails");

                    b.Navigation("Products");

                    b.Navigation("Users");
                });

            modelBuilder.Entity("WebAPI.Data.Entities.productCategories", b =>
                {
                    b.HasOne("WebAPI.Data.Entities.Language", null)
                        .WithMany("CategoryTranslations")
                        .HasForeignKey("LanguageId");

                    b.HasOne("WebAPI.Data.Entities.products", "Products")
                        .WithMany()
                        .HasForeignKey("idProduct");

                    b.Navigation("Products");
                });

            modelBuilder.Entity("WebAPI.Data.Entities.productDetail", b =>
                {
                    b.HasOne("WebAPI.Data.Entities.Language", "Language")
                        .WithMany("ProductTranslations")
                        .HasForeignKey("LanguageId");

                    b.HasOne("WebAPI.Data.Entities.products", "Products")
                        .WithMany("productDetails")
                        .HasForeignKey("idProduct")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WebAPI.Data.Entities.productCategories", null)
                        .WithMany("productDetails")
                        .HasForeignKey("productCategoriesidCategory");

                    b.Navigation("Language");

                    b.Navigation("Products");
                });

            modelBuilder.Entity("WebAPI.Data.Entities.productPhotos", b =>
                {
                    b.HasOne("WebAPI.Data.Entities.products", "Products")
                        .WithMany("productPhotos")
                        .HasForeignKey("idProduct")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WebAPI.Data.Entities.productDetail", null)
                        .WithMany("productPhotos")
                        .HasForeignKey("productDetailidProductDetail");

                    b.Navigation("Products");
                });

            modelBuilder.Entity("WebAPI.Data.Entities.products", b =>
                {
                    b.HasOne("WebAPI.Data.Entities.productBrand", "ProductBrand")
                        .WithMany("Products")
                        .HasForeignKey("idBrand")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WebAPI.Data.Entities.productColor", "ProductColor")
                        .WithMany("Products")
                        .HasForeignKey("idColor")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WebAPI.Data.Entities.productSize", "ProductSize")
                        .WithMany("Products")
                        .HasForeignKey("idSize")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WebAPI.Data.Entities.productTypes", "ProductTypes")
                        .WithMany("Products")
                        .HasForeignKey("idType")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WebAPI.Data.Entities.ordersDetails", null)
                        .WithMany("products")
                        .HasForeignKey("ordersDetailsidOrder");

                    b.Navigation("ProductBrand");

                    b.Navigation("ProductColor");

                    b.Navigation("ProductSize");

                    b.Navigation("ProductTypes");
                });

            modelBuilder.Entity("WebAPI.Data.Entities.rating", b =>
                {
                    b.HasOne("WebAPI.Data.Entities.productDetail", "ProductDetail")
                        .WithMany()
                        .HasForeignKey("idProduct")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WebAPI.Data.Entities.users", "Users")
                        .WithMany()
                        .HasForeignKey("idUser")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ProductDetail");

                    b.Navigation("Users");
                });

            modelBuilder.Entity("WebAPI.Data.Entities.Language", b =>
                {
                    b.Navigation("CategoryTranslations");

                    b.Navigation("ProductTranslations");
                });

            modelBuilder.Entity("WebAPI.Data.Entities.ordersDetails", b =>
                {
                    b.Navigation("products");
                });

            modelBuilder.Entity("WebAPI.Data.Entities.productBrand", b =>
                {
                    b.Navigation("Products");
                });

            modelBuilder.Entity("WebAPI.Data.Entities.productCategories", b =>
                {
                    b.Navigation("productDetails");

                    b.Navigation("productInCategories");
                });

            modelBuilder.Entity("WebAPI.Data.Entities.productColor", b =>
                {
                    b.Navigation("Products");
                });

            modelBuilder.Entity("WebAPI.Data.Entities.productDetail", b =>
                {
                    b.Navigation("productPhotos");
                });

            modelBuilder.Entity("WebAPI.Data.Entities.productSize", b =>
                {
                    b.Navigation("Products");
                });

            modelBuilder.Entity("WebAPI.Data.Entities.productTypes", b =>
                {
                    b.Navigation("Products");
                });

            modelBuilder.Entity("WebAPI.Data.Entities.products", b =>
                {
                    b.Navigation("productDetails");

                    b.Navigation("productInCategories");

                    b.Navigation("productPhotos");
                });
#pragma warning restore 612, 618
        }
    }
}
