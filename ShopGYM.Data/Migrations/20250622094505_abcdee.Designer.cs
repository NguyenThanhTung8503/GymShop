﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ShopGYM.Data.EF;

#nullable disable

namespace ShopGYM.Data.Migrations
{
    [DbContext(typeof(ShopGYMDbContext))]
    [Migration("20250622094505_abcdee")]
    partial class abcdee
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<System.Guid>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("RoleId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.ToTable("AppRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<System.Guid>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.ToTable("AppUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<System.Guid>", b =>
                {
                    b.Property<Guid>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("LoginProvider")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ProviderKey")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId");

                    b.ToTable("AppUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<System.Guid>", b =>
                {
                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("RoleId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("UserId", "RoleId");

                    b.ToTable("AppUserRoles", (string)null);

                    b.HasData(
                        new
                        {
                            UserId = new Guid("90b411be-a570-4839-8f59-492edcc9520d"),
                            RoleId = new Guid("8e15262e-8583-4c49-86be-cef2bf4345d1")
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<System.Guid>", b =>
                {
                    b.Property<Guid>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("LoginProvider")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId");

                    b.ToTable("AppUserTokens", (string)null);
                });

            modelBuilder.Entity("ShopGYM.Data.Entities.AppRole", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("ConcurrencyStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MoTa")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NormalizedName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("AppRoles", (string)null);

                    b.HasData(
                        new
                        {
                            Id = new Guid("8e15262e-8583-4c49-86be-cef2bf4345d1"),
                            MoTa = "Quan Tri",
                            Name = "admin",
                            NormalizedName = "admin"
                        });
                });

            modelBuilder.Entity("ShopGYM.Data.Entities.AppUser", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Dob")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

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

                    b.HasKey("Id");

                    b.ToTable("AppUsers", (string)null);

                    b.HasData(
                        new
                        {
                            Id = new Guid("90b411be-a570-4839-8f59-492edcc9520d"),
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "1f2b3c4d-5e6f-7a8b-9c0d-1e2f3a4b5c6d",
                            Dob = new DateTime(2003, 5, 8, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = "Nguyenthanhutung0168I@gmail.com",
                            EmailConfirmed = true,
                            FirstName = "Nguyen",
                            LastName = "Tung",
                            LockoutEnabled = false,
                            NormalizedEmail = "Nguyenthanhutung0168I@gmail.com",
                            NormalizedUserName = "admin",
                            PasswordHash = "AQAAAAIAAYagAAAAEM46oTWgZoplJc03cruZtbZl0U+oFphoPy/WIUKRg7ddeIhiiLck/8cFrJw6UnM+MQ==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "",
                            TwoFactorEnabled = false,
                            UserName = "admin"
                        });
                });

            modelBuilder.Entity("ShopGYM.Data.Entities.ChiTietDonHang", b =>
                {
                    b.Property<int>("MaDonHang")
                        .HasColumnType("int");

                    b.Property<int>("MaSanPham")
                        .HasColumnType("int");

                    b.Property<decimal>("Gia")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("SoLuong")
                        .HasColumnType("int");

                    b.HasKey("MaDonHang", "MaSanPham");

                    b.HasIndex("MaSanPham");

                    b.ToTable("ChiTietDonHang", (string)null);
                });

            modelBuilder.Entity("ShopGYM.Data.Entities.DanhGia", b =>
                {
                    b.Property<int>("MaDanhGia")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MaDanhGia"));

                    b.Property<Guid>("MaNguoiDung")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("MaSanPham")
                        .HasColumnType("int");

                    b.Property<DateTime>("NgayDanhGia")
                        .HasColumnType("datetime2");

                    b.Property<string>("NoiDung")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("MaDanhGia");

                    b.HasIndex("MaNguoiDung");

                    b.HasIndex("MaSanPham");

                    b.ToTable("DanhGia", (string)null);
                });

            modelBuilder.Entity("ShopGYM.Data.Entities.DanhMuc", b =>
                {
                    b.Property<int>("MaDanhMuc")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MaDanhMuc"));

                    b.Property<string>("MoTa")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("TenDanhMuc")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("MaDanhMuc");

                    b.ToTable("DanhMuc", (string)null);

                    b.HasData(
                        new
                        {
                            MaDanhMuc = 1,
                            MoTa = "Quần các loại",
                            TenDanhMuc = "Quan"
                        },
                        new
                        {
                            MaDanhMuc = 2,
                            MoTa = "Áo thời trang",
                            TenDanhMuc = "Ao"
                        },
                        new
                        {
                            MaDanhMuc = 3,
                            MoTa = "Giày thể thao và thời trang",
                            TenDanhMuc = "Giay"
                        },
                        new
                        {
                            MaDanhMuc = 4,
                            MoTa = "Phụ kiện thời trang",
                            TenDanhMuc = "PhuKien"
                        });
                });

            modelBuilder.Entity("ShopGYM.Data.Entities.DonHang", b =>
                {
                    b.Property<int>("MaDonHang")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MaDonHang"));

                    b.Property<string>("DiaChiGiaoHang")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("MaNguoiDung")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("NgayDatHang")
                        .HasColumnType("datetime2");

                    b.Property<string>("PhuongThucThanhToan")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SDT")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TenNguoiNhan")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TrangThai")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("MaDonHang");

                    b.HasIndex("MaNguoiDung");

                    b.ToTable("DonHang", (string)null);
                });

            modelBuilder.Entity("ShopGYM.Data.Entities.GioHang", b =>
                {
                    b.Property<int>("MaGioHang")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MaGioHang"));

                    b.Property<decimal>("Gia")
                        .HasColumnType("decimal(18,2)");

                    b.Property<Guid>("MaNguoiDung")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("MaSanPham")
                        .HasColumnType("int");

                    b.Property<int>("SoLuong")
                        .HasColumnType("int");

                    b.HasKey("MaGioHang");

                    b.HasIndex("MaNguoiDung");

                    b.HasIndex("MaSanPham");

                    b.ToTable("GioHang", (string)null);
                });

            modelBuilder.Entity("ShopGYM.Data.Entities.HinhAnh", b =>
                {
                    b.Property<int>("MaHinhAnh")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MaHinhAnh"));

                    b.Property<string>("DuongDan")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<bool>("IsDefault")
                        .HasColumnType("bit");

                    b.Property<int?>("MaDanhGia")
                        .HasColumnType("int");

                    b.Property<int>("MaSanPham")
                        .HasColumnType("int");

                    b.Property<string>("Mota")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasColumnType("nvarchar(max)")
                        .HasDefaultValue("0");

                    b.Property<DateTime>("NgayTao")
                        .HasColumnType("datetime2");

                    b.HasKey("MaHinhAnh");

                    b.HasIndex("MaDanhGia");

                    b.HasIndex("MaSanPham");

                    b.ToTable("HinhAnh", (string)null);

                    b.HasData(
                        new
                        {
                            MaHinhAnh = 1,
                            DuongDan = "/images/jeans.jpg",
                            IsDefault = true,
                            MaSanPham = 1,
                            Mota = "Hình quần jeans nam",
                            NgayTao = new DateTime(2025, 3, 26, 8, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            MaHinhAnh = 2,
                            DuongDan = "/images/kaki.jpg",
                            IsDefault = true,
                            MaSanPham = 2,
                            Mota = "Hình quần kaki nữ",
                            NgayTao = new DateTime(2025, 3, 26, 8, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            MaHinhAnh = 3,
                            DuongDan = "/images/tshirt.jpg",
                            IsDefault = true,
                            MaSanPham = 3,
                            Mota = "Hình áo thun nam",
                            NgayTao = new DateTime(2025, 3, 26, 8, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            MaHinhAnh = 4,
                            DuongDan = "/images/shirt.jpg",
                            IsDefault = true,
                            MaSanPham = 4,
                            Mota = "Hình áo sơ mi nữ",
                            NgayTao = new DateTime(2025, 3, 26, 8, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            MaHinhAnh = 5,
                            DuongDan = "/images/sneaker.jpg",
                            IsDefault = true,
                            MaSanPham = 5,
                            Mota = "Hình giày sneaker nam",
                            NgayTao = new DateTime(2025, 3, 26, 8, 0, 0, 0, DateTimeKind.Unspecified)
                        });
                });

            modelBuilder.Entity("ShopGYM.Data.Entities.ProductInCategory", b =>
                {
                    b.Property<int>("MaDanhMuc")
                        .HasColumnType("int");

                    b.Property<int>("MaSanPham")
                        .HasColumnType("int");

                    b.HasKey("MaDanhMuc", "MaSanPham");

                    b.HasIndex("MaSanPham");

                    b.ToTable("ProductInCategory", (string)null);

                    b.HasData(
                        new
                        {
                            MaDanhMuc = 1,
                            MaSanPham = 1
                        },
                        new
                        {
                            MaDanhMuc = 1,
                            MaSanPham = 2
                        },
                        new
                        {
                            MaDanhMuc = 2,
                            MaSanPham = 3
                        },
                        new
                        {
                            MaDanhMuc = 2,
                            MaSanPham = 4
                        },
                        new
                        {
                            MaDanhMuc = 3,
                            MaSanPham = 5
                        });
                });

            modelBuilder.Entity("ShopGYM.Data.Entities.SanPham", b =>
                {
                    b.Property<int>("MaSanPham")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MaSanPham"));

                    b.Property<decimal>("Gia")
                        .HasColumnType("DECIMAL(18,2)");

                    b.Property<string>("KichThuoc")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("MauSac")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("MoTa")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("NgayTao")
                        .HasColumnType("datetime2");

                    b.Property<bool>("NoiBat")
                        .HasColumnType("bit");

                    b.Property<int>("SoLuongTon")
                        .HasColumnType("int");

                    b.Property<string>("TenSanPham")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("MaSanPham");

                    b.ToTable("SanPham", (string)null);

                    b.HasData(
                        new
                        {
                            MaSanPham = 1,
                            Gia = 350000m,
                            KichThuoc = "M",
                            MauSac = "Xanh đậm",
                            MoTa = "Quần jeans nam phong cách",
                            NgayTao = new DateTime(2025, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            NoiBat = false,
                            SoLuongTon = 50,
                            TenSanPham = "Quần Jeans Nam"
                        },
                        new
                        {
                            MaSanPham = 2,
                            Gia = 280000m,
                            KichThuoc = "S",
                            MauSac = "Beige",
                            MoTa = "Quần kaki nữ thời trang",
                            NgayTao = new DateTime(2025, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            NoiBat = false,
                            SoLuongTon = 40,
                            TenSanPham = "Quần Kaki Nữ"
                        },
                        new
                        {
                            MaSanPham = 3,
                            Gia = 150000m,
                            KichThuoc = "L",
                            MauSac = "Trắng",
                            MoTa = "Áo thun nam cotton",
                            NgayTao = new DateTime(2025, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            NoiBat = false,
                            SoLuongTon = 100,
                            TenSanPham = "Áo Thun Nam"
                        },
                        new
                        {
                            MaSanPham = 4,
                            Gia = 250000m,
                            KichThuoc = "M",
                            MauSac = "Xanh nhạt",
                            MoTa = "Áo sơ mi nữ công sở",
                            NgayTao = new DateTime(2025, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            NoiBat = false,
                            SoLuongTon = 30,
                            TenSanPham = "Áo Sơ Mi Nữ"
                        },
                        new
                        {
                            MaSanPham = 5,
                            Gia = 650000m,
                            KichThuoc = "L",
                            MauSac = "Đen",
                            MoTa = "Giày sneaker nam thời trang",
                            NgayTao = new DateTime(2025, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            NoiBat = false,
                            SoLuongTon = 25,
                            TenSanPham = "Giày Sneaker Nam"
                        });
                });

            modelBuilder.Entity("ShopGYM.Data.Entities.ChiTietDonHang", b =>
                {
                    b.HasOne("ShopGYM.Data.Entities.DonHang", "DonHang")
                        .WithMany("ChiTietDonHangs")
                        .HasForeignKey("MaDonHang")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ShopGYM.Data.Entities.SanPham", "SanPham")
                        .WithMany("ChiTietDonHangs")
                        .HasForeignKey("MaSanPham")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("DonHang");

                    b.Navigation("SanPham");
                });

            modelBuilder.Entity("ShopGYM.Data.Entities.DanhGia", b =>
                {
                    b.HasOne("ShopGYM.Data.Entities.AppUser", "AppUser")
                        .WithMany("DanhGias")
                        .HasForeignKey("MaNguoiDung")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ShopGYM.Data.Entities.SanPham", "SanPham")
                        .WithMany("DanhGias")
                        .HasForeignKey("MaSanPham")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("AppUser");

                    b.Navigation("SanPham");
                });

            modelBuilder.Entity("ShopGYM.Data.Entities.DonHang", b =>
                {
                    b.HasOne("ShopGYM.Data.Entities.AppUser", "AppUser")
                        .WithMany("DonHangs")
                        .HasForeignKey("MaNguoiDung")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("AppUser");
                });

            modelBuilder.Entity("ShopGYM.Data.Entities.GioHang", b =>
                {
                    b.HasOne("ShopGYM.Data.Entities.AppUser", "AppUser")
                        .WithMany("GioHangs")
                        .HasForeignKey("MaNguoiDung")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ShopGYM.Data.Entities.SanPham", "SanPham")
                        .WithMany("GioHangs")
                        .HasForeignKey("MaSanPham")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("AppUser");

                    b.Navigation("SanPham");
                });

            modelBuilder.Entity("ShopGYM.Data.Entities.HinhAnh", b =>
                {
                    b.HasOne("ShopGYM.Data.Entities.DanhGia", "DanhGia")
                        .WithMany("HinhAnhs")
                        .HasForeignKey("MaDanhGia")
                        .OnDelete(DeleteBehavior.NoAction);

                    b.HasOne("ShopGYM.Data.Entities.SanPham", "SanPham")
                        .WithMany("HinhAnhs")
                        .HasForeignKey("MaSanPham")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("DanhGia");

                    b.Navigation("SanPham");
                });

            modelBuilder.Entity("ShopGYM.Data.Entities.ProductInCategory", b =>
                {
                    b.HasOne("ShopGYM.Data.Entities.DanhMuc", "DanhMuc")
                        .WithMany("ProductInCategories")
                        .HasForeignKey("MaDanhMuc")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ShopGYM.Data.Entities.SanPham", "SanPham")
                        .WithMany("ProductInCategories")
                        .HasForeignKey("MaSanPham")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("DanhMuc");

                    b.Navigation("SanPham");
                });

            modelBuilder.Entity("ShopGYM.Data.Entities.AppUser", b =>
                {
                    b.Navigation("DanhGias");

                    b.Navigation("DonHangs");

                    b.Navigation("GioHangs");
                });

            modelBuilder.Entity("ShopGYM.Data.Entities.DanhGia", b =>
                {
                    b.Navigation("HinhAnhs");
                });

            modelBuilder.Entity("ShopGYM.Data.Entities.DanhMuc", b =>
                {
                    b.Navigation("ProductInCategories");
                });

            modelBuilder.Entity("ShopGYM.Data.Entities.DonHang", b =>
                {
                    b.Navigation("ChiTietDonHangs");
                });

            modelBuilder.Entity("ShopGYM.Data.Entities.SanPham", b =>
                {
                    b.Navigation("ChiTietDonHangs");

                    b.Navigation("DanhGias");

                    b.Navigation("GioHangs");

                    b.Navigation("HinhAnhs");

                    b.Navigation("ProductInCategories");
                });
#pragma warning restore 612, 618
        }
    }
}
