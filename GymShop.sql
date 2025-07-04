CREATE DATABASE GymShop
USE [GymShop]
GO
/****** Object:  User [Tung]    Script Date: 7/3/2025 4:51:13 PM ******/
CREATE USER [Tung] FOR LOGIN [Tung] WITH DEFAULT_SCHEMA=[dbo]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 7/3/2025 4:51:13 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[__EFMigrationsHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AppRoleClaims]    Script Date: 7/3/2025 4:51:13 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AppRoleClaims](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[RoleId] [uniqueidentifier] NOT NULL,
	[ClaimType] [nvarchar](max) NULL,
	[ClaimValue] [nvarchar](max) NULL,
 CONSTRAINT [PK_AppRoleClaims] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AppRoles]    Script Date: 7/3/2025 4:51:13 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AppRoles](
	[Id] [uniqueidentifier] NOT NULL,
	[MoTa] [nvarchar](200) NOT NULL,
	[Name] [nvarchar](max) NULL,
	[NormalizedName] [nvarchar](max) NULL,
	[ConcurrencyStamp] [nvarchar](max) NULL,
 CONSTRAINT [PK_AppRoles] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AppUserClaims]    Script Date: 7/3/2025 4:51:13 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AppUserClaims](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [uniqueidentifier] NOT NULL,
	[ClaimType] [nvarchar](max) NULL,
	[ClaimValue] [nvarchar](max) NULL,
 CONSTRAINT [PK_AppUserClaims] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AppUserLogins]    Script Date: 7/3/2025 4:51:13 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AppUserLogins](
	[UserId] [uniqueidentifier] NOT NULL,
	[LoginProvider] [nvarchar](max) NOT NULL,
	[ProviderKey] [nvarchar](max) NOT NULL,
	[ProviderDisplayName] [nvarchar](max) NULL,
 CONSTRAINT [PK_AppUserLogins] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AppUserRoles]    Script Date: 7/3/2025 4:51:13 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AppUserRoles](
	[UserId] [uniqueidentifier] NOT NULL,
	[RoleId] [uniqueidentifier] NOT NULL,
 CONSTRAINT [PK_AppUserRoles] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC,
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AppUsers]    Script Date: 7/3/2025 4:51:13 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AppUsers](
	[Id] [uniqueidentifier] NOT NULL,
	[FirstName] [nvarchar](200) NOT NULL,
	[LastName] [nvarchar](200) NOT NULL,
	[Dob] [datetime2](7) NOT NULL,
	[UserName] [nvarchar](max) NULL,
	[NormalizedUserName] [nvarchar](max) NULL,
	[Email] [nvarchar](max) NULL,
	[NormalizedEmail] [nvarchar](max) NULL,
	[EmailConfirmed] [bit] NOT NULL,
	[PasswordHash] [nvarchar](max) NULL,
	[SecurityStamp] [nvarchar](max) NULL,
	[ConcurrencyStamp] [nvarchar](max) NULL,
	[PhoneNumber] [nvarchar](max) NULL,
	[PhoneNumberConfirmed] [bit] NOT NULL,
	[TwoFactorEnabled] [bit] NOT NULL,
	[LockoutEnd] [datetimeoffset](7) NULL,
	[LockoutEnabled] [bit] NOT NULL,
	[AccessFailedCount] [int] NOT NULL,
 CONSTRAINT [PK_AppUsers] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AppUserTokens]    Script Date: 7/3/2025 4:51:13 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AppUserTokens](
	[UserId] [uniqueidentifier] NOT NULL,
	[LoginProvider] [nvarchar](max) NOT NULL,
	[Name] [nvarchar](max) NOT NULL,
	[Value] [nvarchar](max) NULL,
 CONSTRAINT [PK_AppUserTokens] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ChiTietDonHang]    Script Date: 7/3/2025 4:51:13 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ChiTietDonHang](
	[MaDonHang] [int] NOT NULL,
	[MaSanPham] [int] NOT NULL,
	[SoLuong] [int] NOT NULL,
	[Gia] [decimal](18, 2) NOT NULL,
 CONSTRAINT [PK_ChiTietDonHang] PRIMARY KEY CLUSTERED 
(
	[MaDonHang] ASC,
	[MaSanPham] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DanhGia]    Script Date: 7/3/2025 4:51:13 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DanhGia](
	[MaDanhGia] [int] IDENTITY(1,1) NOT NULL,
	[MaSanPham] [int] NOT NULL,
	[MaNguoiDung] [uniqueidentifier] NOT NULL,
	[NoiDung] [nvarchar](max) NOT NULL,
	[NgayDanhGia] [datetime2](7) NOT NULL,
 CONSTRAINT [PK_DanhGia] PRIMARY KEY CLUSTERED 
(
	[MaDanhGia] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DanhMuc]    Script Date: 7/3/2025 4:51:13 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DanhMuc](
	[MaDanhMuc] [int] IDENTITY(1,1) NOT NULL,
	[TenDanhMuc] [nvarchar](100) NOT NULL,
	[MoTa] [nvarchar](255) NOT NULL,
 CONSTRAINT [PK_DanhMuc] PRIMARY KEY CLUSTERED 
(
	[MaDanhMuc] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DonHang]    Script Date: 7/3/2025 4:51:13 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DonHang](
	[MaDonHang] [int] IDENTITY(1,1) NOT NULL,
	[MaNguoiDung] [uniqueidentifier] NOT NULL,
	[NgayDatHang] [datetime2](7) NOT NULL,
	[DiaChiGiaoHang] [nvarchar](max) NULL,
	[SDT] [nvarchar](max) NULL,
	[TenNguoiNhan] [nvarchar](max) NULL,
	[PhuongThucThanhToan] [nvarchar](max) NULL,
	[TrangThai] [nvarchar](max) NULL,
 CONSTRAINT [PK_DonHang] PRIMARY KEY CLUSTERED 
(
	[MaDonHang] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[GioHang]    Script Date: 7/3/2025 4:51:13 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[GioHang](
	[MaGioHang] [int] IDENTITY(1,1) NOT NULL,
	[MaNguoiDung] [uniqueidentifier] NOT NULL,
	[MaSanPham] [int] NOT NULL,
	[SoLuong] [int] NOT NULL,
	[Gia] [decimal](18, 2) NOT NULL,
 CONSTRAINT [PK_GioHang] PRIMARY KEY CLUSTERED 
(
	[MaGioHang] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[HinhAnh]    Script Date: 7/3/2025 4:51:13 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[HinhAnh](
	[MaHinhAnh] [int] IDENTITY(1,1) NOT NULL,
	[DuongDan] [nvarchar](255) NOT NULL,
	[MaSanPham] [int] NOT NULL,
	[Mota] [nvarchar](max) NOT NULL,
	[NgayTao] [datetime2](7) NOT NULL,
	[MaDanhGia] [int] NULL,
	[IsDefault] [bit] NOT NULL,
 CONSTRAINT [PK_HinhAnh] PRIMARY KEY CLUSTERED 
(
	[MaHinhAnh] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ProductInCategory]    Script Date: 7/3/2025 4:51:13 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProductInCategory](
	[MaSanPham] [int] NOT NULL,
	[MaDanhMuc] [int] NOT NULL,
 CONSTRAINT [PK_ProductInCategory] PRIMARY KEY CLUSTERED 
(
	[MaDanhMuc] ASC,
	[MaSanPham] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SanPham]    Script Date: 7/3/2025 4:51:13 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SanPham](
	[MaSanPham] [int] IDENTITY(1,1) NOT NULL,
	[TenSanPham] [nvarchar](100) NOT NULL,
	[Gia] [decimal](18, 2) NOT NULL,
	[MoTa] [nvarchar](max) NULL,
	[KichThuoc] [nvarchar](50) NOT NULL,
	[MauSac] [nvarchar](50) NOT NULL,
	[SoLuongTon] [int] NOT NULL,
	[NgayTao] [datetime2](7) NOT NULL,
	[NoiBat] [bit] NOT NULL,
 CONSTRAINT [PK_SanPham] PRIMARY KEY CLUSTERED 
(
	[MaSanPham] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20250510161843_Initial', N'9.0.4')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20250511154231_updatedatabase', N'9.0.4')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20250511154658_updatedatabase1', N'9.0.4')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20250513043414_update', N'9.0.4')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20250516072227_updateabd', N'9.0.4')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20250517110944_dltTable', N'9.0.4')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20250517115502_updtable', N'9.0.4')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20250517122456_updateOd', N'9.0.4')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20250612081435_abc', N'9.0.4')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20250622094505_abcdee', N'9.0.4')
GO
INSERT [dbo].[AppRoles] ([Id], [MoTa], [Name], [NormalizedName], [ConcurrencyStamp]) VALUES (N'b4a61976-a013-4c49-af27-3eff86cb4a25', N'Nhân viên', N'NhanVien', N'NhanVien', NULL)
INSERT [dbo].[AppRoles] ([Id], [MoTa], [Name], [NormalizedName], [ConcurrencyStamp]) VALUES (N'5bc70ed5-b04d-4b8f-9fc0-588f0e6c1962', N'Khách hàng', N'KhachHang', N'KhachHang', NULL)
INSERT [dbo].[AppRoles] ([Id], [MoTa], [Name], [NormalizedName], [ConcurrencyStamp]) VALUES (N'8e15262e-8583-4c49-86be-cef2bf4345d1', N'Quan Tri', N'Admin', N'admin', NULL)
GO
INSERT [dbo].[AppUserRoles] ([UserId], [RoleId]) VALUES (N'47cafa38-48eb-4eff-0ac5-08dd955ceca4', N'5bc70ed5-b04d-4b8f-9fc0-588f0e6c1962')
INSERT [dbo].[AppUserRoles] ([UserId], [RoleId]) VALUES (N'bb100ea3-aa44-42da-f858-08ddb2449214', N'b4a61976-a013-4c49-af27-3eff86cb4a25')
INSERT [dbo].[AppUserRoles] ([UserId], [RoleId]) VALUES (N'90b411be-a570-4839-8f59-492edcc9520d', N'8e15262e-8583-4c49-86be-cef2bf4345d1')
GO
INSERT [dbo].[AppUsers] ([Id], [FirstName], [LastName], [Dob], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount]) VALUES (N'47cafa38-48eb-4eff-0ac5-08dd955ceca4', N'Tung', N'test1', CAST(N'2025-05-08T00:00:00.0000000' AS DateTime2), N'Tung1', N'TUNG1', N'iuytutgyu@gmail.com', N'IUYTUTGYU@GMAIL.COM', 0, N'AQAAAAIAAYagAAAAECstnv1pwi32bsYGqUrk8Ty+qp9tERfUmi7TkUPoBbcDAMlqaNz8m+PMb6Kd6cs+DA==', N'PQG4BV4ZOAADMF42KJCZYXOWJY56WETU', N'f518d7a4-a59e-40f7-8076-a42d549cea2b', N'877845832', 0, 0, NULL, 1, 0)
INSERT [dbo].[AppUsers] ([Id], [FirstName], [LastName], [Dob], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount]) VALUES (N'bb100ea3-aa44-42da-f858-08ddb2449214', N'Nguyen', N'Nam', CAST(N'2025-06-21T00:00:00.0000000' AS DateTime2), N'Nam', N'NAM', N'iuytutgyusaduw@gmail.com', N'IUYTUTGYUSADUW@GMAIL.COM', 0, N'AQAAAAIAAYagAAAAEKsZaSL4UT2Ktcmm8MP58qEHdMOkoK/fhkWY3yXAm93y3reJc1xjGEOP+W+un8P5TA==', N'I4A55LKLPNEJTJZ4VHFC5AHXYYQU55WM', N'6bc86b57-7eed-4cfe-8fde-087c544822b6', N'03858445213', 0, 0, NULL, 1, 0)
INSERT [dbo].[AppUsers] ([Id], [FirstName], [LastName], [Dob], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount]) VALUES (N'90b411be-a570-4839-8f59-492edcc9520d', N'Nguyen', N'Thanh Tung', CAST(N'2003-05-08T00:00:00.0000000' AS DateTime2), N'admin', N'ADMIN', N'Nguyenthanhutung0168I@gmail.com', N'NGUYENTHANHUTUNG0168I@GMAIL.COM', 1, N'AQAAAAIAAYagAAAAEM46oTWgZoplJc03cruZtbZl0U+oFphoPy/WIUKRg7ddeIhiiLck/8cFrJw6UnM+MQ==', N'', N'578401e0-da12-431f-89c0-bc8e44c0d119', N'0385844597', 0, 0, NULL, 0, 0)
GO
INSERT [dbo].[ChiTietDonHang] ([MaDonHang], [MaSanPham], [SoLuong], [Gia]) VALUES (48, 2, 2, CAST(350000.00 AS Decimal(18, 2)))
INSERT [dbo].[ChiTietDonHang] ([MaDonHang], [MaSanPham], [SoLuong], [Gia]) VALUES (48, 3, 1, CAST(150000.00 AS Decimal(18, 2)))
INSERT [dbo].[ChiTietDonHang] ([MaDonHang], [MaSanPham], [SoLuong], [Gia]) VALUES (49, 1, 1, CAST(150000.00 AS Decimal(18, 2)))
INSERT [dbo].[ChiTietDonHang] ([MaDonHang], [MaSanPham], [SoLuong], [Gia]) VALUES (50, 14, 1, CAST(200000.00 AS Decimal(18, 2)))
INSERT [dbo].[ChiTietDonHang] ([MaDonHang], [MaSanPham], [SoLuong], [Gia]) VALUES (51, 2, 1, CAST(175000.00 AS Decimal(18, 2)))
INSERT [dbo].[ChiTietDonHang] ([MaDonHang], [MaSanPham], [SoLuong], [Gia]) VALUES (52, 2, 1, CAST(175000.00 AS Decimal(18, 2)))
INSERT [dbo].[ChiTietDonHang] ([MaDonHang], [MaSanPham], [SoLuong], [Gia]) VALUES (52, 8, 1, CAST(1200000.00 AS Decimal(18, 2)))
GO
SET IDENTITY_INSERT [dbo].[DanhGia] ON 

INSERT [dbo].[DanhGia] ([MaDanhGia], [MaSanPham], [MaNguoiDung], [NoiDung], [NgayDanhGia]) VALUES (2, 2, N'47cafa38-48eb-4eff-0ac5-08dd955ceca4', N'ngon bổ đấy', CAST(N'2025-05-28T21:49:29.7715274' AS DateTime2))
INSERT [dbo].[DanhGia] ([MaDanhGia], [MaSanPham], [MaNguoiDung], [NoiDung], [NgayDanhGia]) VALUES (4, 2, N'90b411be-a570-4839-8f59-492edcc9520d', N'hehehehe', CAST(N'2025-05-29T15:01:46.5901833' AS DateTime2))
INSERT [dbo].[DanhGia] ([MaDanhGia], [MaSanPham], [MaNguoiDung], [NoiDung], [NgayDanhGia]) VALUES (5, 2, N'90b411be-a570-4839-8f59-492edcc9520d', N'hihihih
', CAST(N'2025-05-29T15:02:00.4096741' AS DateTime2))
SET IDENTITY_INSERT [dbo].[DanhGia] OFF
GO
SET IDENTITY_INSERT [dbo].[DanhMuc] ON 

INSERT [dbo].[DanhMuc] ([MaDanhMuc], [TenDanhMuc], [MoTa]) VALUES (1, N'Quan', N'Quần các loại')
INSERT [dbo].[DanhMuc] ([MaDanhMuc], [TenDanhMuc], [MoTa]) VALUES (2, N'Ao', N'Áo thời trang')
INSERT [dbo].[DanhMuc] ([MaDanhMuc], [TenDanhMuc], [MoTa]) VALUES (3, N'Giay', N'Giày thể thao và thời trang')
INSERT [dbo].[DanhMuc] ([MaDanhMuc], [TenDanhMuc], [MoTa]) VALUES (4, N'PhuKien', N'Phụ kiện thời trang')
SET IDENTITY_INSERT [dbo].[DanhMuc] OFF
GO
SET IDENTITY_INSERT [dbo].[DonHang] ON 

INSERT [dbo].[DonHang] ([MaDonHang], [MaNguoiDung], [NgayDatHang], [DiaChiGiaoHang], [SDT], [TenNguoiNhan], [PhuongThucThanhToan], [TrangThai]) VALUES (47, N'47cafa38-48eb-4eff-0ac5-08dd955ceca4', CAST(N'2025-05-28T20:12:46.5797613' AS DateTime2), N'ểw', N'0385844589', N'tung', N'Momo', N'Đang giao')
INSERT [dbo].[DonHang] ([MaDonHang], [MaNguoiDung], [NgayDatHang], [DiaChiGiaoHang], [SDT], [TenNguoiNhan], [PhuongThucThanhToan], [TrangThai]) VALUES (48, N'90b411be-a570-4839-8f59-492edcc9520d', CAST(N'2025-06-11T10:01:53.9781287' AS DateTime2), N'ninh bình', N'0385844556', N'tung', N'Momo', N'Đã giao')
INSERT [dbo].[DonHang] ([MaDonHang], [MaNguoiDung], [NgayDatHang], [DiaChiGiaoHang], [SDT], [TenNguoiNhan], [PhuongThucThanhToan], [TrangThai]) VALUES (49, N'47cafa38-48eb-4eff-0ac5-08dd955ceca4', CAST(N'2025-06-12T15:45:54.0179282' AS DateTime2), N'ninh bình', N'0385844556', N'tung', N'COD', N'Đã giao')
INSERT [dbo].[DonHang] ([MaDonHang], [MaNguoiDung], [NgayDatHang], [DiaChiGiaoHang], [SDT], [TenNguoiNhan], [PhuongThucThanhToan], [TrangThai]) VALUES (50, N'47cafa38-48eb-4eff-0ac5-08dd955ceca4', CAST(N'2025-06-12T16:09:27.6315490' AS DateTime2), N'ninh bình', N'0385844556', N'tung', N'Momo', N'Đang giao')
INSERT [dbo].[DonHang] ([MaDonHang], [MaNguoiDung], [NgayDatHang], [DiaChiGiaoHang], [SDT], [TenNguoiNhan], [PhuongThucThanhToan], [TrangThai]) VALUES (51, N'47cafa38-48eb-4eff-0ac5-08dd955ceca4', CAST(N'2025-06-22T15:30:13.7954134' AS DateTime2), N'ểw', N'0385844389', N'tung', N'COD', N'Đang xử lý')
INSERT [dbo].[DonHang] ([MaDonHang], [MaNguoiDung], [NgayDatHang], [DiaChiGiaoHang], [SDT], [TenNguoiNhan], [PhuongThucThanhToan], [TrangThai]) VALUES (52, N'47cafa38-48eb-4eff-0ac5-08dd955ceca4', CAST(N'2025-07-03T16:46:50.7692810' AS DateTime2), N'ninh bình', N'0385844592', N'tung', N'COD', N'Đang xử lý')
SET IDENTITY_INSERT [dbo].[DonHang] OFF
GO
SET IDENTITY_INSERT [dbo].[HinhAnh] ON 

INSERT [dbo].[HinhAnh] ([MaHinhAnh], [DuongDan], [MaSanPham], [Mota], [NgayTao], [MaDanhGia], [IsDefault]) VALUES (1, N'/user-content/9d87f6cd-d4cb-4fe4-b3ad-3a835ec5963b.png', 1, N'Hình quần jeans nam đẹp', CAST(N'2025-05-14T12:53:34.0821737' AS DateTime2), NULL, 1)
INSERT [dbo].[HinhAnh] ([MaHinhAnh], [DuongDan], [MaSanPham], [Mota], [NgayTao], [MaDanhGia], [IsDefault]) VALUES (2, N'/user-content/7b3698fa-690b-4b2d-b403-dbad0bd39ba1.png', 2, N'Hình quần kaki nữ', CAST(N'2025-03-26T08:00:00.0000000' AS DateTime2), NULL, 1)
INSERT [dbo].[HinhAnh] ([MaHinhAnh], [DuongDan], [MaSanPham], [Mota], [NgayTao], [MaDanhGia], [IsDefault]) VALUES (3, N'/user-content/5a960552-f331-450b-85bf-3922c6167f3e.png', 3, N'Hình áo thun nam', CAST(N'2025-03-26T08:00:00.0000000' AS DateTime2), NULL, 1)
INSERT [dbo].[HinhAnh] ([MaHinhAnh], [DuongDan], [MaSanPham], [Mota], [NgayTao], [MaDanhGia], [IsDefault]) VALUES (4, N'/user-content/44ca264f-7b2c-47a5-aca9-eafdc79684f8.png', 4, N'Hình áo sơ mi nữ', CAST(N'2025-03-26T08:00:00.0000000' AS DateTime2), NULL, 1)
INSERT [dbo].[HinhAnh] ([MaHinhAnh], [DuongDan], [MaSanPham], [Mota], [NgayTao], [MaDanhGia], [IsDefault]) VALUES (5, N'/user-content/94f71cd2-508a-4ef2-b000-8355bbd7a45e.png', 5, N'Hình giày sneaker nam', CAST(N'2025-03-26T08:00:00.0000000' AS DateTime2), NULL, 1)
INSERT [dbo].[HinhAnh] ([MaHinhAnh], [DuongDan], [MaSanPham], [Mota], [NgayTao], [MaDanhGia], [IsDefault]) VALUES (6, N'/user-content/bd8574b2-3ddb-4f5a-a90f-5a1033b8b965.webp', 6, N'Thumbnail Images', CAST(N'2025-05-11T08:15:13.7276523' AS DateTime2), NULL, 0)
INSERT [dbo].[HinhAnh] ([MaHinhAnh], [DuongDan], [MaSanPham], [Mota], [NgayTao], [MaDanhGia], [IsDefault]) VALUES (7, N'/user-content/d3b2f6c7-ff0f-4e88-9cf4-ecd5fd2b0c51.png', 7, N'Thumbnail Images', CAST(N'2025-05-12T18:10:30.8170913' AS DateTime2), NULL, 1)
INSERT [dbo].[HinhAnh] ([MaHinhAnh], [DuongDan], [MaSanPham], [Mota], [NgayTao], [MaDanhGia], [IsDefault]) VALUES (12, N'/user-content/f3012e83-c8ed-4824-8cd4-f9a339daf8f2.webp', 10, N'Thumbnail Images', CAST(N'2025-05-13T14:51:32.0158324' AS DateTime2), NULL, 1)
INSERT [dbo].[HinhAnh] ([MaHinhAnh], [DuongDan], [MaSanPham], [Mota], [NgayTao], [MaDanhGia], [IsDefault]) VALUES (18, N'/user-content/35cc0df5-31ec-4738-b24d-7a2daf7627cb.png', 13, N'Thumbnail Images', CAST(N'2025-05-23T14:25:41.9210388' AS DateTime2), NULL, 0)
INSERT [dbo].[HinhAnh] ([MaHinhAnh], [DuongDan], [MaSanPham], [Mota], [NgayTao], [MaDanhGia], [IsDefault]) VALUES (19, N'/user-content/36ceb809-f557-4bdd-bb39-1ae13e9f1e51.png', 14, N'Thumbnail Images', CAST(N'2025-05-25T13:53:33.5528252' AS DateTime2), NULL, 0)
INSERT [dbo].[HinhAnh] ([MaHinhAnh], [DuongDan], [MaSanPham], [Mota], [NgayTao], [MaDanhGia], [IsDefault]) VALUES (20, N'/user-content/e87db1f5-d929-4415-9428-a1a08dddec10.png', 1, N'rẻ đẹp', CAST(N'2025-05-25T14:49:39.1405037' AS DateTime2), NULL, 0)
INSERT [dbo].[HinhAnh] ([MaHinhAnh], [DuongDan], [MaSanPham], [Mota], [NgayTao], [MaDanhGia], [IsDefault]) VALUES (21, N'/user-content/9e9ee8ab-390c-4ef0-b019-c2eac1ac955a.png', 1, N'rẻ đẹp', CAST(N'2025-05-25T14:49:49.1495966' AS DateTime2), NULL, 0)
INSERT [dbo].[HinhAnh] ([MaHinhAnh], [DuongDan], [MaSanPham], [Mota], [NgayTao], [MaDanhGia], [IsDefault]) VALUES (22, N'/user-content/fb475d98-73f8-4f1b-8583-e6042b8d2622.png', 1, N'test', CAST(N'2025-05-25T14:49:59.8340412' AS DateTime2), NULL, 0)
INSERT [dbo].[HinhAnh] ([MaHinhAnh], [DuongDan], [MaSanPham], [Mota], [NgayTao], [MaDanhGia], [IsDefault]) VALUES (23, N'/user-content/12536c9c-8fdd-4bfb-bf1e-dc31ea195022.png', 1, N'test', CAST(N'2025-05-25T14:50:10.1770366' AS DateTime2), NULL, 0)
INSERT [dbo].[HinhAnh] ([MaHinhAnh], [DuongDan], [MaSanPham], [Mota], [NgayTao], [MaDanhGia], [IsDefault]) VALUES (24, N'/user-content/05eef3de-d0fb-493f-8019-ad5b6bc3bb5e.png', 2, N'test', CAST(N'2025-05-25T14:52:43.8481474' AS DateTime2), NULL, 0)
INSERT [dbo].[HinhAnh] ([MaHinhAnh], [DuongDan], [MaSanPham], [Mota], [NgayTao], [MaDanhGia], [IsDefault]) VALUES (25, N'/user-content/5aeae558-cd6a-4665-a87a-69f84c73b225.png', 2, N'rẻ đẹp', CAST(N'2025-05-25T14:52:55.6297785' AS DateTime2), NULL, 0)
INSERT [dbo].[HinhAnh] ([MaHinhAnh], [DuongDan], [MaSanPham], [Mota], [NgayTao], [MaDanhGia], [IsDefault]) VALUES (26, N'/user-content/cb8cfdd2-f5c9-41fd-b497-c2ac18bc747d.png', 2, N'test', CAST(N'2025-05-25T14:53:05.1398127' AS DateTime2), NULL, 0)
INSERT [dbo].[HinhAnh] ([MaHinhAnh], [DuongDan], [MaSanPham], [Mota], [NgayTao], [MaDanhGia], [IsDefault]) VALUES (27, N'/user-content/7df6e485-fddc-48fc-b383-3776cb04e487.jpg', 2, N'rẻ đẹp', CAST(N'2025-05-25T14:53:13.6855409' AS DateTime2), NULL, 0)
INSERT [dbo].[HinhAnh] ([MaHinhAnh], [DuongDan], [MaSanPham], [Mota], [NgayTao], [MaDanhGia], [IsDefault]) VALUES (28, N'/user-content/1f524bf7-d054-476d-893e-de25db4cb9a1.png', 3, N'rẻ đẹp', CAST(N'2025-05-25T14:55:03.7399717' AS DateTime2), NULL, 0)
INSERT [dbo].[HinhAnh] ([MaHinhAnh], [DuongDan], [MaSanPham], [Mota], [NgayTao], [MaDanhGia], [IsDefault]) VALUES (29, N'/user-content/70361097-bc35-4b0c-b125-ac11c8db49d2.png', 3, N's', CAST(N'2025-05-25T14:55:22.4986399' AS DateTime2), NULL, 0)
INSERT [dbo].[HinhAnh] ([MaHinhAnh], [DuongDan], [MaSanPham], [Mota], [NgayTao], [MaDanhGia], [IsDefault]) VALUES (30, N'/user-content/bcfd0e3b-772c-4788-89e7-9b0d1d1fb882.png', 3, N'test', CAST(N'2025-05-25T14:55:41.6302513' AS DateTime2), NULL, 0)
INSERT [dbo].[HinhAnh] ([MaHinhAnh], [DuongDan], [MaSanPham], [Mota], [NgayTao], [MaDanhGia], [IsDefault]) VALUES (31, N'/user-content/20fd60d1-282d-4560-95de-48c9cdcde892.png', 4, N's', CAST(N'2025-05-25T14:57:15.3761171' AS DateTime2), NULL, 0)
INSERT [dbo].[HinhAnh] ([MaHinhAnh], [DuongDan], [MaSanPham], [Mota], [NgayTao], [MaDanhGia], [IsDefault]) VALUES (32, N'/user-content/0480112b-2729-43aa-b6cd-262e00bfdf12.png', 4, N's', CAST(N'2025-05-25T14:57:32.7421256' AS DateTime2), NULL, 0)
INSERT [dbo].[HinhAnh] ([MaHinhAnh], [DuongDan], [MaSanPham], [Mota], [NgayTao], [MaDanhGia], [IsDefault]) VALUES (33, N'/user-content/a1dd908b-517c-4e23-b802-863e6960dc14.jpg', 4, N's', CAST(N'2025-05-25T14:57:43.1933090' AS DateTime2), NULL, 0)
INSERT [dbo].[HinhAnh] ([MaHinhAnh], [DuongDan], [MaSanPham], [Mota], [NgayTao], [MaDanhGia], [IsDefault]) VALUES (34, N'/user-content/fdd9b59d-3a23-44e9-9e1c-15060e5ca5f4.jpg', 4, N's', CAST(N'2025-05-25T14:57:51.1817814' AS DateTime2), NULL, 0)
INSERT [dbo].[HinhAnh] ([MaHinhAnh], [DuongDan], [MaSanPham], [Mota], [NgayTao], [MaDanhGia], [IsDefault]) VALUES (35, N'/user-content/7114c9fb-0473-403f-a164-ff27fe9fd86b.png', 5, N's', CAST(N'2025-05-25T14:59:49.2631807' AS DateTime2), NULL, 0)
INSERT [dbo].[HinhAnh] ([MaHinhAnh], [DuongDan], [MaSanPham], [Mota], [NgayTao], [MaDanhGia], [IsDefault]) VALUES (36, N'/user-content/8802f344-f99d-4a51-92e2-fd939b2930e4.png', 5, N's', CAST(N'2025-05-25T15:00:14.2394353' AS DateTime2), NULL, 0)
INSERT [dbo].[HinhAnh] ([MaHinhAnh], [DuongDan], [MaSanPham], [Mota], [NgayTao], [MaDanhGia], [IsDefault]) VALUES (37, N'/user-content/2de91d87-c82e-4db1-81e7-a7576f137422.png', 5, N's', CAST(N'2025-05-25T15:00:30.2194082' AS DateTime2), NULL, 0)
INSERT [dbo].[HinhAnh] ([MaHinhAnh], [DuongDan], [MaSanPham], [Mota], [NgayTao], [MaDanhGia], [IsDefault]) VALUES (38, N'/user-content/75bf5150-2758-4bda-baf7-cf2897135616.png', 5, N's', CAST(N'2025-05-25T15:00:40.3053305' AS DateTime2), NULL, 0)
INSERT [dbo].[HinhAnh] ([MaHinhAnh], [DuongDan], [MaSanPham], [Mota], [NgayTao], [MaDanhGia], [IsDefault]) VALUES (39, N'/user-content/20401a19-080b-4983-9ccd-0799a15d8474.webp', 6, N's', CAST(N'2025-05-25T15:03:39.6972322' AS DateTime2), NULL, 0)
INSERT [dbo].[HinhAnh] ([MaHinhAnh], [DuongDan], [MaSanPham], [Mota], [NgayTao], [MaDanhGia], [IsDefault]) VALUES (40, N'/user-content/cedcdac7-562a-438f-b3fe-a1e431b293f4.webp', 6, N'a', CAST(N'2025-05-25T15:04:04.8958437' AS DateTime2), NULL, 0)
INSERT [dbo].[HinhAnh] ([MaHinhAnh], [DuongDan], [MaSanPham], [Mota], [NgayTao], [MaDanhGia], [IsDefault]) VALUES (41, N'/user-content/b587f7d9-8de0-4d9e-8213-4de24055b44a.webp', 6, N'a', CAST(N'2025-05-25T15:04:17.0339597' AS DateTime2), NULL, 1)
INSERT [dbo].[HinhAnh] ([MaHinhAnh], [DuongDan], [MaSanPham], [Mota], [NgayTao], [MaDanhGia], [IsDefault]) VALUES (42, N'/user-content/44fa3c5a-b5f5-4305-8b23-7383fd6fb58d.webp', 6, N'a', CAST(N'2025-05-25T15:04:32.5993383' AS DateTime2), NULL, 0)
INSERT [dbo].[HinhAnh] ([MaHinhAnh], [DuongDan], [MaSanPham], [Mota], [NgayTao], [MaDanhGia], [IsDefault]) VALUES (43, N'/user-content/227a8e30-60b5-4525-a3f7-efdb992698a1.png', 7, N's', CAST(N'2025-05-25T15:06:17.9509735' AS DateTime2), NULL, 0)
INSERT [dbo].[HinhAnh] ([MaHinhAnh], [DuongDan], [MaSanPham], [Mota], [NgayTao], [MaDanhGia], [IsDefault]) VALUES (44, N'/user-content/9ec0ce09-845c-4a5a-af69-ef0d816c757b.png', 7, N'a', CAST(N'2025-05-25T15:06:25.0590381' AS DateTime2), NULL, 0)
INSERT [dbo].[HinhAnh] ([MaHinhAnh], [DuongDan], [MaSanPham], [Mota], [NgayTao], [MaDanhGia], [IsDefault]) VALUES (45, N'/user-content/28cb01e5-d934-454a-a105-1ed02dedfa36.png', 7, N'a', CAST(N'2025-05-25T15:06:33.0767742' AS DateTime2), NULL, 0)
INSERT [dbo].[HinhAnh] ([MaHinhAnh], [DuongDan], [MaSanPham], [Mota], [NgayTao], [MaDanhGia], [IsDefault]) VALUES (46, N'/user-content/74155430-c217-4ea8-a79a-cf5557a1d245.png', 7, N'a', CAST(N'2025-05-25T15:06:46.5887042' AS DateTime2), NULL, 0)
INSERT [dbo].[HinhAnh] ([MaHinhAnh], [DuongDan], [MaSanPham], [Mota], [NgayTao], [MaDanhGia], [IsDefault]) VALUES (47, N'/user-content/bc22666f-b6d2-4680-a449-354aebe6a431.png', 7, N'a', CAST(N'2025-05-25T15:07:06.0319322' AS DateTime2), NULL, 0)
INSERT [dbo].[HinhAnh] ([MaHinhAnh], [DuongDan], [MaSanPham], [Mota], [NgayTao], [MaDanhGia], [IsDefault]) VALUES (48, N'/user-content/8d2f638d-2e8b-4456-9155-9ffb45b3eaf8.png', 8, N'a', CAST(N'2025-05-25T15:08:14.7621710' AS DateTime2), NULL, 0)
INSERT [dbo].[HinhAnh] ([MaHinhAnh], [DuongDan], [MaSanPham], [Mota], [NgayTao], [MaDanhGia], [IsDefault]) VALUES (49, N'/user-content/a284f159-a24a-4bfa-a1a8-ea96db900d61.png', 8, N'a', CAST(N'2025-05-25T15:08:31.6329623' AS DateTime2), NULL, 0)
INSERT [dbo].[HinhAnh] ([MaHinhAnh], [DuongDan], [MaSanPham], [Mota], [NgayTao], [MaDanhGia], [IsDefault]) VALUES (50, N'/user-content/88244490-1b9b-4147-a9a8-cc5dfbb9b581.png', 8, N'a', CAST(N'2025-05-25T15:08:50.0754347' AS DateTime2), NULL, 0)
INSERT [dbo].[HinhAnh] ([MaHinhAnh], [DuongDan], [MaSanPham], [Mota], [NgayTao], [MaDanhGia], [IsDefault]) VALUES (51, N'/user-content/8e407540-b743-4ff1-95df-286736471de7.png', 8, N'a', CAST(N'2025-05-25T15:09:00.1111204' AS DateTime2), NULL, 0)
INSERT [dbo].[HinhAnh] ([MaHinhAnh], [DuongDan], [MaSanPham], [Mota], [NgayTao], [MaDanhGia], [IsDefault]) VALUES (52, N'/user-content/3d27fb88-b296-4e2c-9c2a-eba908eafc76.webp', 10, N'a', CAST(N'2025-05-25T15:21:27.8051149' AS DateTime2), NULL, 0)
INSERT [dbo].[HinhAnh] ([MaHinhAnh], [DuongDan], [MaSanPham], [Mota], [NgayTao], [MaDanhGia], [IsDefault]) VALUES (54, N'/user-content/a5960094-acad-4ea6-9c7c-80cb0d6e3afe.webp', 10, N'a', CAST(N'2025-05-25T15:23:57.1077261' AS DateTime2), NULL, 0)
INSERT [dbo].[HinhAnh] ([MaHinhAnh], [DuongDan], [MaSanPham], [Mota], [NgayTao], [MaDanhGia], [IsDefault]) VALUES (56, N'/user-content/dd5a0800-f3e6-48d1-99a1-5f96bae82591.webp', 10, N'a', CAST(N'2025-05-25T15:24:38.7905409' AS DateTime2), NULL, 0)
INSERT [dbo].[HinhAnh] ([MaHinhAnh], [DuongDan], [MaSanPham], [Mota], [NgayTao], [MaDanhGia], [IsDefault]) VALUES (57, N'/user-content/7dbf715b-f811-46df-be9c-ec466c4df33e.png', 13, N'a', CAST(N'2025-05-25T15:27:20.0529913' AS DateTime2), NULL, 0)
INSERT [dbo].[HinhAnh] ([MaHinhAnh], [DuongDan], [MaSanPham], [Mota], [NgayTao], [MaDanhGia], [IsDefault]) VALUES (58, N'/user-content/5efd88f8-50db-4681-9e8e-7d31b4f85119.png', 13, N'a', CAST(N'2025-05-25T15:27:28.9614938' AS DateTime2), NULL, 0)
INSERT [dbo].[HinhAnh] ([MaHinhAnh], [DuongDan], [MaSanPham], [Mota], [NgayTao], [MaDanhGia], [IsDefault]) VALUES (59, N'/user-content/8cc9c68b-86dd-48c6-a926-3bac4fed84ad.png', 13, N'a', CAST(N'2025-05-25T15:27:42.6929113' AS DateTime2), NULL, 0)
INSERT [dbo].[HinhAnh] ([MaHinhAnh], [DuongDan], [MaSanPham], [Mota], [NgayTao], [MaDanhGia], [IsDefault]) VALUES (60, N'/user-content/0534e4e4-a1ef-4961-a137-bd825270cfb2.png', 13, N'a', CAST(N'2025-05-25T15:27:58.2032257' AS DateTime2), NULL, 0)
INSERT [dbo].[HinhAnh] ([MaHinhAnh], [DuongDan], [MaSanPham], [Mota], [NgayTao], [MaDanhGia], [IsDefault]) VALUES (61, N'/user-content/84fc2b08-da8e-4d19-9f65-7920a3b47a04.png', 13, N'a', CAST(N'2025-05-25T15:28:09.2138202' AS DateTime2), NULL, 0)
INSERT [dbo].[HinhAnh] ([MaHinhAnh], [DuongDan], [MaSanPham], [Mota], [NgayTao], [MaDanhGia], [IsDefault]) VALUES (62, N'/user-content/e9bd5ff4-c7c0-4c43-8a75-5f2a9eb0da16.png', 14, N'a', CAST(N'2025-05-25T15:29:48.1149785' AS DateTime2), NULL, 0)
INSERT [dbo].[HinhAnh] ([MaHinhAnh], [DuongDan], [MaSanPham], [Mota], [NgayTao], [MaDanhGia], [IsDefault]) VALUES (63, N'/user-content/5fa677cd-e90c-4d0d-a33e-44ff34360895.png', 14, N'a', CAST(N'2025-05-25T15:29:56.7192050' AS DateTime2), NULL, 1)
INSERT [dbo].[HinhAnh] ([MaHinhAnh], [DuongDan], [MaSanPham], [Mota], [NgayTao], [MaDanhGia], [IsDefault]) VALUES (64, N'/user-content/53f59bde-a338-431a-912a-e87fdc8b2e06.png', 14, N'a', CAST(N'2025-05-25T15:30:08.1163458' AS DateTime2), NULL, 0)
INSERT [dbo].[HinhAnh] ([MaHinhAnh], [DuongDan], [MaSanPham], [Mota], [NgayTao], [MaDanhGia], [IsDefault]) VALUES (65, N'/user-content/6abb0d85-3e2d-4e14-806e-1a5bcb6b21d7.png', 14, N'a', CAST(N'2025-05-25T15:30:19.7165824' AS DateTime2), NULL, 0)
INSERT [dbo].[HinhAnh] ([MaHinhAnh], [DuongDan], [MaSanPham], [Mota], [NgayTao], [MaDanhGia], [IsDefault]) VALUES (66, N'/user-content/5b931c1b-6850-4cc0-91e4-79b3ba882bbe.png', 15, N'Thumbnail Images', CAST(N'2025-05-25T15:32:41.0187380' AS DateTime2), NULL, 0)
INSERT [dbo].[HinhAnh] ([MaHinhAnh], [DuongDan], [MaSanPham], [Mota], [NgayTao], [MaDanhGia], [IsDefault]) VALUES (67, N'/user-content/5e3de4f1-48b4-44bc-b6b5-4a1dfa03b377.png', 15, N'q', CAST(N'2025-05-25T15:32:48.9982490' AS DateTime2), NULL, 0)
INSERT [dbo].[HinhAnh] ([MaHinhAnh], [DuongDan], [MaSanPham], [Mota], [NgayTao], [MaDanhGia], [IsDefault]) VALUES (68, N'/user-content/2689bfce-ebab-4e56-bbee-ec7ff84fbef9.png', 15, N'q', CAST(N'2025-05-25T15:33:03.2775455' AS DateTime2), NULL, 0)
INSERT [dbo].[HinhAnh] ([MaHinhAnh], [DuongDan], [MaSanPham], [Mota], [NgayTao], [MaDanhGia], [IsDefault]) VALUES (69, N'/user-content/9185d88a-e602-40c7-85b1-5e4c4134f9d2.png', 15, N'a', CAST(N'2025-05-25T15:33:20.1555206' AS DateTime2), NULL, 0)
INSERT [dbo].[HinhAnh] ([MaHinhAnh], [DuongDan], [MaSanPham], [Mota], [NgayTao], [MaDanhGia], [IsDefault]) VALUES (70, N'/user-content/8567fa7e-8e6f-41c5-8ca1-6c2a1fae9ce7.png', 8, N'k', CAST(N'2025-05-25T21:08:31.9074647' AS DateTime2), NULL, 1)
SET IDENTITY_INSERT [dbo].[HinhAnh] OFF
GO
INSERT [dbo].[ProductInCategory] ([MaSanPham], [MaDanhMuc]) VALUES (1, 1)
INSERT [dbo].[ProductInCategory] ([MaSanPham], [MaDanhMuc]) VALUES (2, 2)
INSERT [dbo].[ProductInCategory] ([MaSanPham], [MaDanhMuc]) VALUES (3, 2)
INSERT [dbo].[ProductInCategory] ([MaSanPham], [MaDanhMuc]) VALUES (4, 2)
INSERT [dbo].[ProductInCategory] ([MaSanPham], [MaDanhMuc]) VALUES (5, 2)
INSERT [dbo].[ProductInCategory] ([MaSanPham], [MaDanhMuc]) VALUES (6, 4)
INSERT [dbo].[ProductInCategory] ([MaSanPham], [MaDanhMuc]) VALUES (7, 3)
INSERT [dbo].[ProductInCategory] ([MaSanPham], [MaDanhMuc]) VALUES (8, 3)
INSERT [dbo].[ProductInCategory] ([MaSanPham], [MaDanhMuc]) VALUES (10, 4)
INSERT [dbo].[ProductInCategory] ([MaSanPham], [MaDanhMuc]) VALUES (13, 1)
INSERT [dbo].[ProductInCategory] ([MaSanPham], [MaDanhMuc]) VALUES (14, 1)
INSERT [dbo].[ProductInCategory] ([MaSanPham], [MaDanhMuc]) VALUES (15, 1)
GO
SET IDENTITY_INSERT [dbo].[SanPham] ON 

INSERT [dbo].[SanPham] ([MaSanPham], [TenSanPham], [Gia], [MoTa], [KichThuoc], [MauSac], [SoLuongTon], [NgayTao], [NoiBat]) VALUES (1, N'Quần đùi chạy bộ nam tập thể thao ', CAST(150000.00 AS Decimal(18, 2)), N'ĐẶC ĐIỂM NỔI BẬT
– Quần chạy bộ siêu nhẹ chỉ từ 80g
– Quần đùi nam tập thể thao Gymlab được thiết kế với công nghệ vải co giãn tốt. Cực kỳ nhẹ, tạo cảm giác mặc vô cùng thoải mái.
– Chất vải luôn đem lại cảm giác vô cùng mềm và nhẹ. Nhờ đặc tính kết hợp tuyệt vời của vải, chiếc quần của Gymlab cực kỳ nhanh thoát mồ hôi và loại trừ hầu hết mùi cơ thể.
– Cảm giác vải cực kỳ nhẹ và mềm, công nghệ thoát ẩm 1 chiều giúp cho chiếc quần cực kỳ nhanh khô.
– Quần có thiết kế form 5 inch ngắn trên gối, xẻ 2 bên phù hợp tập luyện.
– Thiết kế 2 đáy, tránh đường may dấu cộng (+) ở dưới đáy quần, đảm bảo được độ bền chắc qua tất cả các bài tập chân khó nhất.
– Quần có màu xám in họa tiết chữ Gymlab giúp tạo điểm nhấn nổi bật.
– Quần form ôm fit, phong cách năng động thích hợp mặc đi tập gym, chạy bộ, cardio, daily wear.
– Sản phẩm được đảm bảo với quy trình sản xuất chất lượng với đường may chắc chắn, tỉ mỉ từng chi tiết.', N'L', N'Đen', 150, CAST(N'2025-05-01T00:00:00.0000000' AS DateTime2), 1)
INSERT [dbo].[SanPham] ([MaSanPham], [TenSanPham], [Gia], [MoTa], [KichThuoc], [MauSac], [SoLuongTon], [NgayTao], [NoiBat]) VALUES (2, N'ÁO TANK SÁT NÁCH NAM – ĐEN – SILVER LOGO', CAST(175000.00 AS Decimal(18, 2)), N'Thông tin cơ bản:

– Người mẫu cao 1m68, nặng 65kg mặc size M vừa đẹp.
– Chiếc áo mang đến cảm giác rộng thoải mái và cực kỳ thoáng mát khi tập.
– Thiết kế theo dạng áo Tank sát nách, tôn dáng vai rất tốt. Tạo cảm giác vai to hơn khi mặc, giúp tăng vẻ mạnh mẽ và nam tính.
– Cảm giác vải cực kỳ mềm mượt, công nghệ thoát ẩm 1 chiều giúp cho chiếc áo cực kỳ nhanh khô.
– Logo được in màu bạc phản quang nhẹ vô cùng tinh tế.

Được thiết kế phù hợp với:

– Tập Gym, Chạy bộ, Cardio, Daily Wear.
– Tập luyện trong nhà và ngoài trời.
– Phù hợp với nhiệt độ thời tiết từ 20-40 độ C.', N'L', N'Xám', 2498, CAST(N'2025-05-01T00:00:00.0000000' AS DateTime2), 1)
INSERT [dbo].[SanPham] ([MaSanPham], [TenSanPham], [Gia], [MoTa], [KichThuoc], [MauSac], [SoLuongTon], [NgayTao], [NoiBat]) VALUES (3, N'ÁO TẬP CÓ TAY NAM – XANH ĐEN – SILVER LOGO', CAST(150000.00 AS Decimal(18, 2)), N'Đặc điểm nổi bật của áo công nghệ vải Activ-cool

 

Lần đầu tiên có 1 local brand đem đến Công nghệ vải đến từ Hàn Quốc với các tính năng vượt trội.
Áo tập có tính năng: Co giãn, mềm mịn, mát mẻ, khử mùi, thoát mồ hôi cực nhanh, chống tia UV.
Đảm bảo đem lại cảm giác mặc vô cùng thoải mái trong tất cả hoạt động hàng ngày, đặc biệt là trong hoạt động thể thao.
 

Thiết kế áo tập có tay co giãn của Gymlab

 

Đội ngũ của Gymlab đã gửi rất nhiều tâm huyết vào dòng sản phẩm này, với tiêu chí thiết kế sản phẩm thoải mái khi tập luyện cũng như vượt trội về mặt thẩm mỹ.

 

Chiếc áo được may với thiết kế Raglan, tạo độ thẩm mỹ rất tốt cho người mặc, tạo cảm giác phần cầu vai và thân trên rộng hơn. Góp phần lớn vào việc tăng vẻ nam tính cho người mặc.
Chất liệu áo co giãn 4 chiều, mềm mỏng tạo cảm giác thoải mái không chỉ khi tập luyện, mà còn có thể mặc trong sinh hoạt hằng ngày. Đảm bảo khả năng khử mùi trong 48 giờ, bất chấp mọi thời tiết.
Hình in phản quang nhẹ giúp tăng tính thẩm mỹ của áo, lớp phản quang nhẹ không quá sáng, khiến cho người mặc giữ được sự lịch lãm đơn giản, không quá chói lóa.', N'L', N'Xanh Navi', 100, CAST(N'2025-05-01T00:00:00.0000000' AS DateTime2), 0)
INSERT [dbo].[SanPham] ([MaSanPham], [TenSanPham], [Gia], [MoTa], [KichThuoc], [MauSac], [SoLuongTon], [NgayTao], [NoiBat]) VALUES (4, N'Áo Tập Gym Thể Thao Cho Nam – Xám – Silver Logo', CAST(250000.00 AS Decimal(18, 2)), N'ĐẶC ĐIỂM NỔI BẬT
– Áo thể thao tập gym nam Gymlab được thiết kế với công nghệ vải Activ-cool đến từ Hàn Quốc. Vải được tăng tỉ lệ Spandex giúp tăng khả năng co giãn vượt trội.
– Chất vải luôn đem lại cảm giác vô cùng mềm và nhẹ. Nhờ đặc tính kết hợp tuyệt vời của vải, chiếc áo của Gymlab cực kỳ nhanh thoát mồ hôi và loại trừ hầu hết mùi cơ thể.
– Áo form ôm fit, mang đến cảm giác vừa vặn và cực kỳ thoáng mát thích hợp mặc đi tập gym, thể thao.
– Áo thiết kế tay ngắn đường may raglan (rắc lăng) tạo độ ôm tốt vào cầu vai. Giúp người mặc có cảm giác vai to và rộng hơn, tăng vẻ mạnh mẽ và nam tính của đàn ông.
– Logo được in màu xám phản quang nhẹ vô cùng tinh tế.
– Sản phẩm được đảm bảo với quy trình sản xuất chất lượng với đường may chắc chắn, tỉ mỉ từng chi tiết.
***Lưu ý: Màu sản phẩm có thể sẽ chênh lệch thực tế một phần nhỏ, do ảnh hưởng về độ lệch màu của ánh sáng nhưng vẫn đảm bảo chất lượng.', N'M', N'Xanh nhạt', 30, CAST(N'2025-05-01T00:00:00.0000000' AS DateTime2), 0)
INSERT [dbo].[SanPham] ([MaSanPham], [TenSanPham], [Gia], [MoTa], [KichThuoc], [MauSac], [SoLuongTon], [NgayTao], [NoiBat]) VALUES (5, N'Áo Thể Thao Nam GYMLAB Raglan Tay Ngắn Phối Màu Tay Áo', CAST(175000.00 AS Decimal(18, 2)), N'ĐẶC ĐIỂM NỔI BẬT
– Áo thể thao tập gym nam Gymlab được thiết kế với công nghệ vải Activ-cool đến từ Hàn Quốc. Vải được tăng tỉ lệ Spandex giúp tăng khả năng co giãn vượt trội.
– Chất vải luôn đem lại cảm giác vô cùng mềm và nhẹ. Nhờ đặc tính kết hợp tuyệt vời của vải, chiếc áo của Gymlab cực kỳ nhanh thoát mồ hôi và loại trừ hầu hết mùi cơ thể.
– Áo form ôm fit, mang đến cảm giác vừa vặn và cực kỳ thoáng mát thích hợp mặc đi tập gym, thể thao.
– Áo thiết kế tay ngắn đường may raglan (rắc lăng) tạo độ ôm tốt vào cầu vai. Giúp người mặc có cảm giác vai to và rộng hơn, tăng vẻ mạnh mẽ và nam tính của đàn ông.
– Logo được in màu xám phản quang nhẹ vô cùng tinh tế.
– Sản phẩm được đảm bảo với quy trình sản xuất chất lượng với đường may chắc chắn, tỉ mỉ từng chi tiết.
***Lưu ý: Màu sản phẩm có thể sẽ chênh lệch thực tế một phần nhỏ, do ảnh hưởng về độ lệch màu của ánh sáng nhưng vẫn đảm bảo chất lượng.

HƯỚNG DẪN BẢO QUẢN
– Không giặt rửa sản phẩm trực tiếp với chất tẩy rửa mạnh, sẽ gây phai màu và hư hại chất vải của sản phẩm.
– Khi phơi nên lộn mặt trong của quần áo ra ngoài.
– Tránh phơi đồ trực tiếp dưới nắng vì sẽ làm phai màu vải nhanh hơn.', N'L', N'Đen', 250, CAST(N'2025-05-01T00:00:00.0000000' AS DateTime2), 0)
INSERT [dbo].[SanPham] ([MaSanPham], [TenSanPham], [Gia], [MoTa], [KichThuoc], [MauSac], [SoLuongTon], [NgayTao], [NoiBat]) VALUES (6, N'Bình Nước Tập Gym , Bình Lắc Thể Thao Có Con Lắc Lò Xo Tiện Lợi Myprotein 700ml', CAST(75000.00 AS Decimal(18, 2)), N'ngon bổ rẻ', N'L', N'Đen', 34, CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), 1)
INSERT [dbo].[SanPham] ([MaSanPham], [TenSanPham], [Gia], [MoTa], [KichThuoc], [MauSac], [SoLuongTon], [NgayTao], [NoiBat]) VALUES (7, N'Giày Nike Zoom Vapor Pro 2 HC ‘White’ DR6191-101', CAST(750000.00 AS Decimal(18, 2)), N'Ngon rẻ bổ', N'43', N'Trắng', 50, CAST(N'2025-05-12T18:10:30.8170801' AS DateTime2), 0)
INSERT [dbo].[SanPham] ([MaSanPham], [TenSanPham], [Gia], [MoTa], [KichThuoc], [MauSac], [SoLuongTon], [NgayTao], [NoiBat]) VALUES (8, N'Giày Tennis Asics Court FF Novak ‘Cranberry White’ 1041A089-605', CAST(1200000.00 AS Decimal(18, 2)), N'Rẻ bổ ngon', N'42', N'Đỏ', 22, CAST(N'2025-05-12T18:20:27.6200550' AS DateTime2), 0)
INSERT [dbo].[SanPham] ([MaSanPham], [TenSanPham], [Gia], [MoTa], [KichThuoc], [MauSac], [SoLuongTon], [NgayTao], [NoiBat]) VALUES (10, N'Khăn bông cotton', CAST(50000.00 AS Decimal(18, 2)), N'ngon bổ re', N'30x50', N'Đen', 150, CAST(N'2025-05-13T14:51:32.0158239' AS DateTime2), 0)
INSERT [dbo].[SanPham] ([MaSanPham], [TenSanPham], [Gia], [MoTa], [KichThuoc], [MauSac], [SoLuongTon], [NgayTao], [NoiBat]) VALUES (13, N'Quần Jogger Túi Hộp Thể Thao Unisex ', CAST(175000.00 AS Decimal(18, 2)), N'ĐẶC ĐIỂM NỔI BẬT
– Trẻ trung, năng động với kiểu dáng Jogger thời thượng, quần Jogger nam lưng thun dây rút của Gymlab chắc chắn sẽ là must-have-item cho các tín đồ thời trang yêu thích phong cách đa ứng dụng.
– Quần có thiết kế đơn giản nhưng hiện đại, kế với công nghệ vải Activ-cool đến từ Hàn Quốc. Vải được tăng tỉ lệ Spandex giúp tăng khả năng co giãn vượt trội.
– Quần có nhiều màu sắc và kích cỡ để bạn lựa chọn, phù hợp với mọi phong cách và dáng người.
– Thiết kế lưng thun phối dây rút cùng chi tiết bo ống, logo được in màu bạc phản quang nhẹ vô cùng tinh tế.
– Quần jogger tập gym nam không chỉ giúp bạn thoải mái khi tập luyện, mà còn tôn lên vẻ đẹp nam tính và khỏe khoắn của bạn.
– Quần cũng rất dễ phối đồ bạn có thể kết hợp với áo thun, áo sơ mi hay áo khoác… Để tạo nên những bộ trang phục năng động và cá tính.
– Sản phẩm được đảm bảo với quy trình sản xuất chất lượng với đường may chắc chắn, tỉ mỉ từng chi tiết.
***Lưu ý: Màu sản phẩm có thể sẽ chênh lệch thực tế một phần nhỏ, do ảnh hưởng về độ lệch màu của ánh sáng nhưng vẫn đảm bảo chất lượng.

HƯỚNG DẪN BẢO QUẢN
– Không giặt rửa sản phẩm trực tiếp với chất tẩy rửa mạnh, sẽ gây phai màu và hư hại chất vải của sản phẩm.
– Khi phơi nên lộn mặt trong của quần áo ra ngoài.
– Tránh phơi đồ trực tiếp dưới nắng vì sẽ làm phai màu vải nhanh hơn.', N'L', N'Đen', 332, CAST(N'2025-05-23T14:25:41.9206926' AS DateTime2), 0)
INSERT [dbo].[SanPham] ([MaSanPham], [TenSanPham], [Gia], [MoTa], [KichThuoc], [MauSac], [SoLuongTon], [NgayTao], [NoiBat]) VALUES (14, N'Quần short tập gym nam 2 lớp ', CAST(200000.00 AS Decimal(18, 2)), N'ĐẶC ĐIỂM NỔI BẬT
– Quần short tập gym nam 2 lớp là một sản phẩm thời trang dành cho những người yêu thích thể hình và sức khỏe.
– Quần có thiết kế đơn giản nhưng hiện đại, với 2 lớp vải chất lượng cao, thoáng mát và co giãn tốt.
– Quần có nhiều màu sắc và kích cỡ để bạn lựa chọn, phù hợp với mọi phong cách và dáng người.
– Quần short tập gym nam 2 lớp không chỉ giúp bạn thoải mái khi tập luyện, mà còn tôn lên vẻ đẹp nam tính và khỏe khoắn của bạn.
– Quần cũng rất dễ phối đồ bạn có thể kết hợp với áo thun, áo sơ mi hay áo khoác… Để tạo nên những bộ trang phục năng động và cá tính.
– Sản phẩm được đảm bảo với quy trình sản xuất chất lượng với đường may chắc chắn, tỉ mỉ từng chi tiết.
***Lưu ý: Màu sản phẩm có thể sẽ chênh lệch thực tế một phần nhỏ, do ảnh hưởng về độ lệch màu của ánh sáng nhưng vẫn đảm bảo chất lượng.

HƯỚNG DẪN BẢO QUẢN
– Không giặt rửa sản phẩm trực tiếp với chất tẩy rửa mạnh, sẽ gây phai màu và hư hại chất vải của sản phẩm.
– Khi phơi nên lộn mặt trong của quần áo ra ngoài.
– Tránh phơi đồ trực tiếp dưới nắng vì sẽ làm phai màu vải nhanh hơn.', N'L', N'Đen', 123, CAST(N'2025-05-25T13:53:33.5527552' AS DateTime2), 0)
INSERT [dbo].[SanPham] ([MaSanPham], [TenSanPham], [Gia], [MoTa], [KichThuoc], [MauSac], [SoLuongTon], [NgayTao], [NoiBat]) VALUES (15, N'Quần short tập gym nam 2 lớp', CAST(250000.00 AS Decimal(18, 2)), N'ĐẶC ĐIỂM NỔI BẬT
– Quần short tập gym nam 2 lớp là một sản phẩm thời trang dành cho những người yêu thích thể hình và sức khỏe.
– Quần có thiết kế đơn giản nhưng hiện đại, với 2 lớp vải chất lượng cao, thoáng mát và co giãn tốt.
– Quần có nhiều màu sắc và kích cỡ để bạn lựa chọn, phù hợp với mọi phong cách và dáng người.
– Quần short tập gym nam 2 lớp không chỉ giúp bạn thoải mái khi tập luyện, mà còn tôn lên vẻ đẹp nam tính và khỏe khoắn của bạn.
– Quần cũng rất dễ phối đồ bạn có thể kết hợp với áo thun, áo sơ mi hay áo khoác… Để tạo nên những bộ trang phục năng động và cá tính.
– Sản phẩm được đảm bảo với quy trình sản xuất chất lượng với đường may chắc chắn, tỉ mỉ từng chi tiết.
***Lưu ý: Màu sản phẩm có thể sẽ chênh lệch thực tế một phần nhỏ, do ảnh hưởng về độ lệch màu của ánh sáng nhưng vẫn đảm bảo chất lượng.

HƯỚNG DẪN BẢO QUẢN
– Không giặt rửa sản phẩm trực tiếp với chất tẩy rửa mạnh, sẽ gây phai màu và hư hại chất vải của sản phẩm.
– Khi phơi nên lộn mặt trong của quần áo ra ngoài.
– Tránh phơi đồ trực tiếp dưới nắng vì sẽ làm phai màu vải nhanh hơn.', N'm', N'Đen', 31, CAST(N'2025-05-25T15:32:41.0186589' AS DateTime2), 0)
SET IDENTITY_INSERT [dbo].[SanPham] OFF
GO
ALTER TABLE [dbo].[GioHang] ADD  DEFAULT ((0.0)) FOR [Gia]
GO
ALTER TABLE [dbo].[HinhAnh] ADD  DEFAULT (N'0') FOR [Mota]
GO
ALTER TABLE [dbo].[HinhAnh] ADD  DEFAULT (CONVERT([bit],(0))) FOR [IsDefault]
GO
ALTER TABLE [dbo].[SanPham] ADD  DEFAULT (N'') FOR [KichThuoc]
GO
ALTER TABLE [dbo].[SanPham] ADD  DEFAULT (N'') FOR [MauSac]
GO
ALTER TABLE [dbo].[SanPham] ADD  DEFAULT ('0001-01-01T00:00:00.0000000') FOR [NgayTao]
GO
ALTER TABLE [dbo].[SanPham] ADD  DEFAULT (CONVERT([bit],(0))) FOR [NoiBat]
GO
ALTER TABLE [dbo].[ChiTietDonHang]  WITH CHECK ADD  CONSTRAINT [FK_ChiTietDonHang_DonHang_MaDonHang] FOREIGN KEY([MaDonHang])
REFERENCES [dbo].[DonHang] ([MaDonHang])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[ChiTietDonHang] CHECK CONSTRAINT [FK_ChiTietDonHang_DonHang_MaDonHang]
GO
ALTER TABLE [dbo].[ChiTietDonHang]  WITH CHECK ADD  CONSTRAINT [FK_ChiTietDonHang_SanPham_MaSanPham] FOREIGN KEY([MaSanPham])
REFERENCES [dbo].[SanPham] ([MaSanPham])
GO
ALTER TABLE [dbo].[ChiTietDonHang] CHECK CONSTRAINT [FK_ChiTietDonHang_SanPham_MaSanPham]
GO
ALTER TABLE [dbo].[DanhGia]  WITH CHECK ADD  CONSTRAINT [FK_DanhGia_AppUsers_MaNguoiDung] FOREIGN KEY([MaNguoiDung])
REFERENCES [dbo].[AppUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[DanhGia] CHECK CONSTRAINT [FK_DanhGia_AppUsers_MaNguoiDung]
GO
ALTER TABLE [dbo].[DanhGia]  WITH CHECK ADD  CONSTRAINT [FK_DanhGia_SanPham_MaSanPham] FOREIGN KEY([MaSanPham])
REFERENCES [dbo].[SanPham] ([MaSanPham])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[DanhGia] CHECK CONSTRAINT [FK_DanhGia_SanPham_MaSanPham]
GO
ALTER TABLE [dbo].[DonHang]  WITH CHECK ADD  CONSTRAINT [FK_DonHang_AppUsers_MaNguoiDung] FOREIGN KEY([MaNguoiDung])
REFERENCES [dbo].[AppUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[DonHang] CHECK CONSTRAINT [FK_DonHang_AppUsers_MaNguoiDung]
GO
ALTER TABLE [dbo].[GioHang]  WITH CHECK ADD  CONSTRAINT [FK_GioHang_AppUsers_MaNguoiDung] FOREIGN KEY([MaNguoiDung])
REFERENCES [dbo].[AppUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[GioHang] CHECK CONSTRAINT [FK_GioHang_AppUsers_MaNguoiDung]
GO
ALTER TABLE [dbo].[GioHang]  WITH CHECK ADD  CONSTRAINT [FK_GioHang_SanPham_MaSanPham] FOREIGN KEY([MaSanPham])
REFERENCES [dbo].[SanPham] ([MaSanPham])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[GioHang] CHECK CONSTRAINT [FK_GioHang_SanPham_MaSanPham]
GO
ALTER TABLE [dbo].[HinhAnh]  WITH CHECK ADD  CONSTRAINT [FK_HinhAnh_DanhGia_MaDanhGia] FOREIGN KEY([MaDanhGia])
REFERENCES [dbo].[DanhGia] ([MaDanhGia])
GO
ALTER TABLE [dbo].[HinhAnh] CHECK CONSTRAINT [FK_HinhAnh_DanhGia_MaDanhGia]
GO
ALTER TABLE [dbo].[HinhAnh]  WITH CHECK ADD  CONSTRAINT [FK_HinhAnh_SanPham_MaSanPham] FOREIGN KEY([MaSanPham])
REFERENCES [dbo].[SanPham] ([MaSanPham])
GO
ALTER TABLE [dbo].[HinhAnh] CHECK CONSTRAINT [FK_HinhAnh_SanPham_MaSanPham]
GO
ALTER TABLE [dbo].[ProductInCategory]  WITH CHECK ADD  CONSTRAINT [FK_ProductInCategory_DanhMuc_MaDanhMuc] FOREIGN KEY([MaDanhMuc])
REFERENCES [dbo].[DanhMuc] ([MaDanhMuc])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[ProductInCategory] CHECK CONSTRAINT [FK_ProductInCategory_DanhMuc_MaDanhMuc]
GO
ALTER TABLE [dbo].[ProductInCategory]  WITH CHECK ADD  CONSTRAINT [FK_ProductInCategory_SanPham_MaSanPham] FOREIGN KEY([MaSanPham])
REFERENCES [dbo].[SanPham] ([MaSanPham])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[ProductInCategory] CHECK CONSTRAINT [FK_ProductInCategory_SanPham_MaSanPham]
GO
