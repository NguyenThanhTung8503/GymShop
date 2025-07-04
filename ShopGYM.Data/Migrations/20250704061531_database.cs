using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ShopGYM.Data.Migrations
{
    /// <inheritdoc />
    public partial class database : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AppRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppRoleClaims", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AppRoles",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MoTa = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AppUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppUserClaims", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AppUserLogins",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppUserLogins", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "AppUserRoles",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RoleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppUserRoles", x => new { x.UserId, x.RoleId });
                });

            migrationBuilder.CreateTable(
                name: "AppUsers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Dob = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AppUserTokens",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppUserTokens", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "DanhMuc",
                columns: table => new
                {
                    MaDanhMuc = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenDanhMuc = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    MoTa = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DanhMuc", x => x.MaDanhMuc);
                });

            migrationBuilder.CreateTable(
                name: "SanPham",
                columns: table => new
                {
                    MaSanPham = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenSanPham = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Gia = table.Column<decimal>(type: "DECIMAL(18,2)", nullable: false),
                    MoTa = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    KichThuoc = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    MauSac = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    SoLuongTon = table.Column<int>(type: "int", nullable: false),
                    NgayTao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NoiBat = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SanPham", x => x.MaSanPham);
                });

            migrationBuilder.CreateTable(
                name: "DonHang",
                columns: table => new
                {
                    MaDonHang = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MaNguoiDung = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NgayDatHang = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TenNguoiNhan = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DiaChiGiaoHang = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SDT = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhuongThucThanhToan = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TrangThai = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DonHang", x => x.MaDonHang);
                    table.ForeignKey(
                        name: "FK_DonHang_AppUsers_MaNguoiDung",
                        column: x => x.MaNguoiDung,
                        principalTable: "AppUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DanhGia",
                columns: table => new
                {
                    MaDanhGia = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MaSanPham = table.Column<int>(type: "int", nullable: false),
                    MaNguoiDung = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NoiDung = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NgayDanhGia = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DanhGia", x => x.MaDanhGia);
                    table.ForeignKey(
                        name: "FK_DanhGia_AppUsers_MaNguoiDung",
                        column: x => x.MaNguoiDung,
                        principalTable: "AppUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DanhGia_SanPham_MaSanPham",
                        column: x => x.MaSanPham,
                        principalTable: "SanPham",
                        principalColumn: "MaSanPham",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GioHang",
                columns: table => new
                {
                    MaGioHang = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MaNguoiDung = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MaSanPham = table.Column<int>(type: "int", nullable: false),
                    SoLuong = table.Column<int>(type: "int", nullable: false),
                    Gia = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GioHang", x => x.MaGioHang);
                    table.ForeignKey(
                        name: "FK_GioHang_AppUsers_MaNguoiDung",
                        column: x => x.MaNguoiDung,
                        principalTable: "AppUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GioHang_SanPham_MaSanPham",
                        column: x => x.MaSanPham,
                        principalTable: "SanPham",
                        principalColumn: "MaSanPham",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductInCategory",
                columns: table => new
                {
                    MaSanPham = table.Column<int>(type: "int", nullable: false),
                    MaDanhMuc = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductInCategory", x => new { x.MaDanhMuc, x.MaSanPham });
                    table.ForeignKey(
                        name: "FK_ProductInCategory_DanhMuc_MaDanhMuc",
                        column: x => x.MaDanhMuc,
                        principalTable: "DanhMuc",
                        principalColumn: "MaDanhMuc",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductInCategory_SanPham_MaSanPham",
                        column: x => x.MaSanPham,
                        principalTable: "SanPham",
                        principalColumn: "MaSanPham",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ChiTietDonHang",
                columns: table => new
                {
                    MaDonHang = table.Column<int>(type: "int", nullable: false),
                    MaSanPham = table.Column<int>(type: "int", nullable: false),
                    SoLuong = table.Column<int>(type: "int", nullable: false),
                    Gia = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChiTietDonHang", x => new { x.MaDonHang, x.MaSanPham });
                    table.ForeignKey(
                        name: "FK_ChiTietDonHang_DonHang_MaDonHang",
                        column: x => x.MaDonHang,
                        principalTable: "DonHang",
                        principalColumn: "MaDonHang",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ChiTietDonHang_SanPham_MaSanPham",
                        column: x => x.MaSanPham,
                        principalTable: "SanPham",
                        principalColumn: "MaSanPham");
                });

            migrationBuilder.CreateTable(
                name: "HinhAnh",
                columns: table => new
                {
                    MaHinhAnh = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DuongDan = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    MaSanPham = table.Column<int>(type: "int", nullable: false),
                    Mota = table.Column<string>(type: "nvarchar(max)", nullable: false, defaultValue: "0"),
                    NgayTao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    MaDanhGia = table.Column<int>(type: "int", nullable: true),
                    IsDefault = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HinhAnh", x => x.MaHinhAnh);
                    table.ForeignKey(
                        name: "FK_HinhAnh_DanhGia_MaDanhGia",
                        column: x => x.MaDanhGia,
                        principalTable: "DanhGia",
                        principalColumn: "MaDanhGia");
                    table.ForeignKey(
                        name: "FK_HinhAnh_SanPham_MaSanPham",
                        column: x => x.MaSanPham,
                        principalTable: "SanPham",
                        principalColumn: "MaSanPham");
                });

            migrationBuilder.InsertData(
                table: "AppRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "MoTa", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { new Guid("5bc70ed5-b04d-4b8f-9fc0-588f0e6c1962"), null, "Khách hàng", "KhachHang", "KhachHang" },
                    { new Guid("8e15262e-8583-4c49-86be-cef2bf4345d1"), null, "Quan Tri", "Admin", "admin" },
                    { new Guid("b4a61976-a013-4c49-af27-3eff86cb4a25"), null, "Nhân viên", "NhanVien", "NhanVien" }
                });

            migrationBuilder.InsertData(
                table: "AppUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { new Guid("5bc70ed5-b04d-4b8f-9fc0-588f0e6c1962"), new Guid("47cafa38-48eb-4eff-0ac5-08dd955ceca4") },
                    { new Guid("8e15262e-8583-4c49-86be-cef2bf4345d1"), new Guid("90b411be-a570-4839-8f59-492edcc9520d") },
                    { new Guid("b4a61976-a013-4c49-af27-3eff86cb4a25"), new Guid("bb100ea3-aa44-42da-f858-08ddb2449214") }
                });

            migrationBuilder.InsertData(
                table: "AppUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Dob", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { new Guid("47cafa38-48eb-4eff-0ac5-08dd955ceca4"), 0, "f518d7a4-a59e-40f7-8076-a42d549cea2b", new DateTime(2025, 5, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "iuytutgyu@gmail.com", false, "Tung", "test1", true, null, "IUYTUTGYU@GMAIL.COM", "TUNG1", "AQAAAAIAAYagAAAAECstnv1pwi32bsYGqUrk8Ty+qp9tERfUmi7TkUPoBbcDAMlqaNz8m+PMb6Kd6cs+DA==", "877845832", false, "PQG4BV4ZOAADMF42KJCZYXOWJY56WETU", false, "Tung1" },
                    { new Guid("90b411be-a570-4839-8f59-492edcc9520d"), 0, "578401e0-da12-431f-89c0-bc8e44c0d119", new DateTime(2003, 5, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "Nguyenthanhutung0168I@gmail.com", true, "Nguyen", "Thanh Tung", false, null, "NGUYENTHANHUTUNG0168I@GMAIL.COM", "ADMIN", "AQAAAAIAAYagAAAAEM46oTWgZoplJc03cruZtbZl0U+oFphoPy/WIUKRg7ddeIhiiLck/8cFrJw6UnM+MQ==", "0385844597", false, "", false, "admin" },
                    { new Guid("bb100ea3-aa44-42da-f858-08ddb2449214"), 0, "6bc86b57-7eed-4cfe-8fde-087c544822b6", new DateTime(2025, 6, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "iuytutgyusaduw@gmail.com", false, "Nguyen", "Nam", true, null, "IUYTUTGYUSADUW@GMAIL.COM", "NAM", "AQAAAAIAAYagAAAAEKsZaSL4UT2Ktcmm8MP58qEHdMOkoK/fhkWY3yXAm93y3reJc1xjGEOP+W+un8P5TA==", "03858445213", false, "I4A55LKLPNEJTJZ4VHFC5AHXYYQU55WM", false, "Nam" }
                });

            migrationBuilder.InsertData(
                table: "DanhMuc",
                columns: new[] { "MaDanhMuc", "MoTa", "TenDanhMuc" },
                values: new object[,]
                {
                    { 1, "Quần các loại", "Quan" },
                    { 2, "Áo thời trang", "Ao" },
                    { 3, "Giày thể thao và thời trang", "Giay" },
                    { 4, "Phụ kiện thời trang", "PhuKien" }
                });

            migrationBuilder.InsertData(
                table: "SanPham",
                columns: new[] { "MaSanPham", "Gia", "KichThuoc", "MauSac", "MoTa", "NgayTao", "NoiBat", "SoLuongTon", "TenSanPham" },
                values: new object[,]
                {
                    { 1, 150000.00m, "L", "Đen", "ĐẶC ĐIỂM NỔI BẬT\n– Quần chạy bộ siêu nhẹ chỉ từ 80g\n– Quần đùi nam tập thể thao Gymlab được thiết kế với công nghệ vải co giãn tốt. Cực kỳ nhẹ, tạo cảm giác mặc vô cùng thoải mái.\n– Chất vải luôn đem lại cảm giác vô cùng mềm và nhẹ. Nhờ đặc tính kết hợp tuyệt vời của vải, chiếc quần của Gymlab cực kỳ nhanh thoát mồ hôi và loại trừ hầu hết mùi cơ thể.\n– Cảm giác vải cực kỳ nhẹ và mềm, công nghệ thoát ẩm 1 chiều giúp cho chiếc quần cực kỳ nhanh khô.\n– Quần có thiết kế form 5 inch ngắn trên gối, xẻ 2 bên phù hợp tập luyện.\n– Thiết kế 2 đáy, tránh đường may dấu cộng (+) ở dưới đáy quần, đảm bảo được độ bền chắc qua tất cả các bài tập chân khó nhất.\n– Quần có màu xám in họa tiết chữ Gymlab giúp tạo điểm nhấn nổi bật.\n– Quần form ôm fit, phong cách năng động thích hợp mặc đi tập gym, chạy bộ, cardio, daily wear.\n– Sản phẩm được đảm bảo với quy trình sản xuất chất lượng với đường may chắc chắn, tỉ mỉ từng chi tiết.", new DateTime(2025, 5, 1, 0, 0, 0, 0, DateTimeKind.Utc), true, 150, "Quần đùi chạy bộ nam tập thể thao " },
                    { 2, 175000.00m, "L", "Xám", "Thông tin cơ bản:\n\n– Người mẫu cao 1m68, nặng 65kg mặc size M vừa đẹp.\n– Chiếc áo mang đến cảm giác rộng thoải mái và cực kỳ thoáng mát khi tập.\n– Thiết kế theo dạng áo Tank sát nách, tôn dáng vai rất tốt. Tạo cảm giác vai to hơn khi mặc, giúp tăng vẻ mạnh mẽ và nam tính.\n– Cảm giác vải cực kỳ mềm mượt, công nghệ thoát ẩm 1 chiều giúp cho chiếc áo cực kỳ nhanh khô.\n– Logo được in màu bạc phản quang nhẹ vô cùng tinh tế.\n\nĐược thiết kế phù hợp với:\n\n– Tập Gym, Chạy bộ, Cardio, Daily Wear.\n– Tập luyện trong nhà và ngoài trời.\n– Phù hợp với nhiệt độ thời tiết từ 20-40 độ C.", new DateTime(2025, 5, 1, 0, 0, 0, 0, DateTimeKind.Utc), true, 2498, "ÁO TANK SÁT NÁCH NAM – ĐEN – SILVER LOGO" },
                    { 3, 150000.00m, "L", "Xanh Navi", "Đặc điểm nổi bật của áo công nghệ vải Activ-cool\n\n \n\nLần đầu tiên có 1 local brand đem đến Công nghệ vải đến từ Hàn Quốc với các tính năng vượt trội.\nÁo tập có tính năng: Co giãn, mềm mịn, mát mẻ, khử mùi, thoát mồ hôi cực nhanh, chống tia UV.\nĐảm bảo đem lại cảm giác mặc vô cùng thoải mái trong tất cả hoạt động hàng ngày, đặc biệt là trong hoạt động thể thao.\n \n\nThiết kế áo tập có tay co giãn của Gymlab\n\n \n\nĐội ngũ của Gymlab đã gửi rất nhiều tâm huyết vào dòng sản phẩm này, với tiêu chí thiết kế sản phẩm thoải mái khi tập luyện cũng như vượt trội về mặt thẩm mỹ.\n\n \n\nChiếc áo được may với thiết kế Raglan, tạo độ thẩm mỹ rất tốt cho người mặc, tạo cảm giác phần cầu vai và thân trên rộng hơn. Góp phần lớn vào việc tăng vẻ nam tính cho người mặc.\nChất liệu áo co giãn 4 chiều, mềm mỏng tạo cảm giác thoải mái không chỉ khi tập luyện, mà còn có thể mặc trong sinh hoạt hằng ngày. Đảm bảo khả năng khử mùi trong 48 giờ, bất chấp mọi thời tiết.\nHình in phản quang nhẹ giúp tăng tính thẩm mỹ của áo, lớp phản quang nhẹ không quá sáng, khiến cho người mặc giữ được sự lịch lãm đơn giản, không quá chói lóa.", new DateTime(2025, 5, 1, 0, 0, 0, 0, DateTimeKind.Utc), false, 100, "ÁO TẬP CÓ TAY NAM – XANH ĐEN – SILVER LOGO" },
                    { 4, 250000.00m, "M", "Xanh nhạt", "ĐẶC ĐIỂM NỔI BẬT\n– Áo thể thao tập gym nam Gymlab được thiết kế với công nghệ vải Activ-cool đến từ Hàn Quốc. Vải được tăng tỉ lệ Spandex giúp tăng khả năng co giãn vượt trội.\n– Chất vải luôn đem lại cảm giác vô cùng mềm và nhẹ. Nhờ đặc tính kết hợp tuyệt vời của vải, chiếc áo của Gymlab cực kỳ nhanh thoát mồ hôi và loại trừ hầu hết mùi cơ thể.\n– Áo form ôm fit, mang đến cảm giác vừa vặn và cực kỳ thoáng mát thích hợp mặc đi tập gym, thể thao.\n– Áo thiết kế tay ngắn đường may raglan (rắc lăng) tạo độ ôm tốt vào cầu vai. Giúp người mặc có cảm giác vai to và rộng hơn, tăng vẻ mạnh mẽ và nam tính của đàn ông.\n– Logo được in màu xám phản quang nhẹ vô cùng tinh tế.\n– Sản phẩm được đảm bảo với quy trình sản xuất chất lượng với đường may chắc chắn, tỉ mỉ từng chi tiết.\n***Lưu ý: Màu sản phẩm có thể sẽ chênh lệch thực tế một phần nhỏ, do ảnh hưởng về độ lệch màu của ánh sáng nhưng vẫn đảm bảo chất lượng.", new DateTime(2025, 5, 1, 0, 0, 0, 0, DateTimeKind.Utc), false, 30, "Áo Tập Gym Thể Thao Cho Nam – Xám – Silver Logo" },
                    { 5, 175000.00m, "L", "Đen", "ĐẶC ĐIỂM NỔI BẬT\n– Áo thể thao tập gym nam Gymlab được thiết kế với công nghệ vải Activ-cool đến từ Hàn Quốc. Vải được tăng tỉ lệ Spandex giúp tăng khả năng co giãn vượt trội.\n– Chất vải luôn đem lại cảm giác vô cùng mềm và nhẹ. Nhờ đặc tính kết hợp tuyệt vời của vải, chiếc áo của Gymlab cực kỳ nhanh thoát mồ hôi và loại trừ hầu hết mùi cơ thể.\n– Áo form ôm fit, mang đến cảm giác vừa vặn và cực kỳ thoáng mát thích hợp mặc đi tập gym, thể thao.\n– Áo thiết kế tay ngắn đường may raglan (rắc lăng) tạo độ ôm tốt vào cầu vai. Giúp người mặc có cảm giác vai to và rộng hơn, tăng vẻ mạnh mẽ và nam tính của đàn ông.\n– Logo được in màu xám phản quang nhẹ vô cùng tinh tế.\n– Sản phẩm được đảm bảo với quy trình sản xuất chất lượng với đường may chắc chắn, tỉ mỉ từng chi tiết.\n***Lưu ý: Màu sản phẩm có thể sẽ chênh lệch thực tế một phần nhỏ, do ảnh hưởng về độ lệch màu của ánh sáng nhưng vẫn đảm bảo chất lượng.\n\nHƯỚNG DẪN BẢO QUẢN\n– Không giặt rửa sản phẩm trực tiếp với chất tẩy rửa mạnh, sẽ gây phai màu và hư hại chất vải của sản phẩm.\n– Khi phơi nên lộn mặt trong của quần áo ra ngoài.\n– Tránh phơi đồ trực tiếp dưới nắng vì sẽ làm phai màu vải nhanh hơn.", new DateTime(2025, 5, 1, 0, 0, 0, 0, DateTimeKind.Utc), false, 250, "Áo Thể Thao Nam GYMLAB Raglan Tay Ngắn Phối Màu Tay Áo" },
                    { 6, 75000.00m, "L", "Đen", "ngon bổ rẻ", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), true, 34, "Bình Nước Tập Gym , Bình Lắc Thể Thao Có Con Lắc Lò Xo Tiện Lợi Myprotein 700ml" },
                    { 7, 750000.00m, "43", "Trắng", "Ngon rẻ bổ", new DateTime(2025, 5, 12, 18, 10, 30, 817, DateTimeKind.Utc).AddTicks(801), false, 50, "Giày Nike Zoom Vapor Pro 2 HC ‘White’ DR6191-101" },
                    { 8, 1200000.00m, "42", "Đỏ", "Rẻ bổ ngon", new DateTime(2025, 5, 12, 18, 20, 27, 620, DateTimeKind.Utc).AddTicks(550), false, 22, "Giày Tennis Asics Court FF Novak ‘Cranberry White’ 1041A089-605" },
                    { 10, 50000.00m, "30x50", "Đen", "ngon bổ re", new DateTime(2025, 5, 13, 14, 51, 32, 15, DateTimeKind.Utc).AddTicks(8239), false, 150, "Khăn bông cotton" },
                    { 13, 175000.00m, "L", "Đen", "ĐẶC ĐIỂM NỔI BẬT\n– Trẻ trung, năng động với kiểu dáng Jogger thời thượng, quần Jogger nam lưng thun dây rút của Gymlab chắc chắn sẽ là must-have-item cho các tín đồ thời trang yêu thích phong cách đa ứng dụng.\n– Quần có thiết kế đơn giản nhưng hiện đại, kế với công nghệ vải Activ-cool đến từ Hàn Quốc. Vải được tăng tỉ lệ Spandex giúp tăng khả năng co giãn vượt trội.\n– Quần có nhiều màu sắc và kích cỡ để bạn lựa chọn, phù hợp với mọi phong cách và dáng người.\n– Thiết kế lưng thun phối dây rút cùng chi tiết bo ống, logo được in màu bạc phản quang nhẹ vô cùng tinh tế.\n– Quần jogger tập gym nam không chỉ giúp bạn thoải mái khi tập luyện, mà còn tôn lên vẻ đẹp nam tính và khỏe khoắn của bạn.\n– Quần cũng rất dễ phối đồ bạn có thể kết hợp với áo thun, áo sơ mi hay áo khoác… Để tạo nên những bộ trang phục năng động và cá tính.\n– Sản phẩm được đảm bảo với quy trình sản xuất chất lượng với đường may chắc chắn, tỉ mỉ từng chi tiết.\n***Lưu ý: Màu sản phẩm có thể sẽ chênh lệch thực tế một phần nhỏ, do ảnh hưởng về độ lệch màu của ánh sáng nhưng vẫn đảm bảo chất lượng.\n\nHƯỚNG DẪN BẢO QUẢN\n– Không giặt rửa sản phẩm trực tiếp với chất tẩy rửa mạnh, sẽ gây phai màu và hư hại chất vải của sản phẩm.\n– Khi phơi nên lộn mặt trong của quần áo ra ngoài.\n– Tránh phơi đồ trực tiếp dưới nắng vì sẽ làm phai màu vải nhanh hơn.", new DateTime(2025, 5, 23, 14, 25, 41, 920, DateTimeKind.Utc).AddTicks(6926), false, 332, "Quần Jogger Túi Hộp Thể Thao Unisex " },
                    { 14, 200000.00m, "L", "Đen", "ĐẶC ĐIỂM NỔI BẬT\n– Quần short tập gym nam 2 lớp là một sản phẩm thời trang dành cho những người yêu thích thể hình và sức khỏe.\n– Quần có thiết kế đơn giản nhưng hiện đại, với 2 lớp vải chất lượng cao, thoáng mát và co giãn tốt.\n– Quần có nhiều màu sắc và kích cỡ để bạn lựa chọn, phù hợp với mọi phong cách và dáng người.\n– Quần short tập gym nam 2 lớp không chỉ giúp bạn thoải mái khi tập luyện, mà còn tôn lên vẻ đẹp nam tính và khỏe khoắn của bạn.\n– Quần cũng rất dễ phối đồ bạn có thể kết hợp với áo thun, áo sơ mi hay áo khoác… Để tạo nên những bộ trang phục năng động và cá tính.\n– Sản phẩm được đảm bảo với quy trình sản xuất chất lượng với đường may chắc chắn, tỉ mỉ từng chi tiết.\n***Lưu ý: Màu sản phẩm có thể sẽ chênh lệch thực tế một phần nhỏ, do ảnh hưởng về độ lệch màu của ánh sáng nhưng vẫn đảm bảo chất lượng.\n\nHƯỚNG DẪN BẢO QUẢN\n– Không giặt rửa sản phẩm trực tiếp với chất tẩy rửa mạnh, sẽ gây phai màu và hư hại chất vải của sản phẩm.\n– Khi phơi nên lộn mặt trong của quần áo ra ngoài.\n– Tránh phơi đồ trực tiếp dưới nắng vì sẽ làm phai màu vải nhanh hơn.", new DateTime(2025, 5, 25, 13, 53, 33, 552, DateTimeKind.Utc).AddTicks(7552), false, 123, "Quần short tập gym nam 2 lớp " },
                    { 15, 250000.00m, "m", "Đen", "ĐẶC ĐIỂM NỔI BẬT\n– Quần short tập gym nam 2 lớp là một sản phẩm thời trang dành cho những người yêu thích thể hình và sức khỏe.\n– Quần có thiết kế đơn giản nhưng hiện đại, với 2 lớp vải chất lượng cao, thoáng mát và co giãn tốt.\n– Quần có nhiều màu sắc và kích cỡ để bạn lựa chọn, phù hợp với mọi phong cách và dáng người.\n– Quần short tập gym nam 2 lớp không chỉ giúp bạn thoải mái khi tập luyện, mà còn tôn lên vẻ đẹp nam tính và khỏe khoắn của bạn.\n– Quần cũng rất dễ phối đồ bạn có thể kết hợp với áo thun, áo sơ mi hay áo khoác… Để tạo nên những bộ trang phục năng động và cá tính.\n– Sản phẩm được đảm bảo với quy trình sản xuất chất lượng với đường may chắc chắn, tỉ mỉ từng chi tiết.\n***Lưu ý: Màu sản phẩm có thể sẽ chênh lệch thực tế một phần nhỏ, do ảnh hưởng về độ lệch màu của ánh sáng nhưng vẫn đảm bảo chất lượng.\n\nHƯỚNG DẪN BẢO QUẢN\n– Không giặt rửa sản phẩm trực tiếp với chất tẩy rửa mạnh, sẽ gây phai màu và hư hại chất vải của sản phẩm.\n– Khi phơi nên lộn mặt trong của quần áo ra ngoài.\n– Tránh phơi đồ trực tiếp dưới nắng vì sẽ làm phai màu vải nhanh hơn.", new DateTime(2025, 5, 25, 15, 32, 41, 18, DateTimeKind.Utc).AddTicks(6589), false, 31, "Quần short tập gym nam 2 lớp" }
                });

            migrationBuilder.InsertData(
                table: "DanhGia",
                columns: new[] { "MaDanhGia", "MaNguoiDung", "MaSanPham", "NgayDanhGia", "NoiDung" },
                values: new object[,]
                {
                    { 2, new Guid("47cafa38-48eb-4eff-0ac5-08dd955ceca4"), 2, new DateTime(2025, 5, 28, 21, 49, 29, 771, DateTimeKind.Utc).AddTicks(5274), "ngon bổ đấy" },
                    { 4, new Guid("90b411be-a570-4839-8f59-492edcc9520d"), 2, new DateTime(2025, 5, 29, 15, 1, 46, 590, DateTimeKind.Utc).AddTicks(1833), "hehehehe" },
                    { 5, new Guid("90b411be-a570-4839-8f59-492edcc9520d"), 2, new DateTime(2025, 5, 29, 15, 2, 0, 409, DateTimeKind.Utc).AddTicks(6741), "hihihih" }
                });

            migrationBuilder.InsertData(
                table: "DonHang",
                columns: new[] { "MaDonHang", "DiaChiGiaoHang", "MaNguoiDung", "NgayDatHang", "PhuongThucThanhToan", "SDT", "TenNguoiNhan", "TrangThai" },
                values: new object[,]
                {
                    { 47, "ểw", new Guid("47cafa38-48eb-4eff-0ac5-08dd955ceca4"), new DateTime(2025, 5, 28, 20, 12, 46, 579, DateTimeKind.Utc).AddTicks(7613), "Momo", "0385844589", "tung", "Đang giao" },
                    { 48, "ninh bình", new Guid("90b411be-a570-4839-8f59-492edcc9520d"), new DateTime(2025, 6, 11, 10, 1, 53, 978, DateTimeKind.Utc).AddTicks(1287), "Momo", "0385844556", "tung", "Đã giao" },
                    { 49, "ninh bình", new Guid("47cafa38-48eb-4eff-0ac5-08dd955ceca4"), new DateTime(2025, 6, 12, 15, 45, 54, 17, DateTimeKind.Utc).AddTicks(9282), "COD", "0385844556", "tung", "Đã giao" },
                    { 50, "ninh bình", new Guid("47cafa38-48eb-4eff-0ac5-08dd955ceca4"), new DateTime(2025, 6, 12, 16, 9, 27, 631, DateTimeKind.Utc).AddTicks(5490), "Momo", "0385844556", "tung", "Đang giao" },
                    { 51, "ểw", new Guid("47cafa38-48eb-4eff-0ac5-08dd955ceca4"), new DateTime(2025, 6, 22, 15, 30, 13, 795, DateTimeKind.Utc).AddTicks(4134), "COD", "0385844389", "tung", "Đang xử lý" },
                    { 52, "ninh bình", new Guid("47cafa38-48eb-4eff-0ac5-08dd955ceca4"), new DateTime(2025, 7, 3, 16, 46, 50, 769, DateTimeKind.Utc).AddTicks(2810), "COD", "0385844592", "tung", "Đang xử lý" }
                });

            migrationBuilder.InsertData(
                table: "HinhAnh",
                columns: new[] { "MaHinhAnh", "DuongDan", "IsDefault", "MaDanhGia", "MaSanPham", "Mota", "NgayTao" },
                values: new object[,]
                {
                    { 1, "/user-content/9d87f6cd-d4cb-4fe4-b3ad-3a835ec5963b.png", true, null, 1, "Hình quần jeans nam đẹp", new DateTime(2025, 5, 14, 12, 53, 34, 82, DateTimeKind.Utc).AddTicks(1737) },
                    { 2, "/user-content/7b3698fa-690b-4b2d-b403-dbad0bd39ba1.png", true, null, 2, "Hình quần kaki nữ", new DateTime(2025, 3, 26, 8, 0, 0, 0, DateTimeKind.Utc) },
                    { 3, "/user-content/5a960552-f331-450b-85bf-3922c6167f3e.png", true, null, 3, "Hình áo thun nam", new DateTime(2025, 3, 26, 8, 0, 0, 0, DateTimeKind.Utc) },
                    { 4, "/user-content/44ca264f-7b2c-47a5-aca9-eafdc79684f8.png", true, null, 4, "Hình áo sơ mi nữ", new DateTime(2025, 3, 26, 8, 0, 0, 0, DateTimeKind.Utc) },
                    { 5, "/user-content/94f71cd2-508a-4ef2-b000-8355bbd7a45e.png", true, null, 5, "Hình giày sneaker nam", new DateTime(2025, 3, 26, 8, 0, 0, 0, DateTimeKind.Utc) },
                    { 6, "/user-content/bd8574b2-3ddb-4f5a-a90f-5a1033b8b965.webp", false, null, 6, "Thumbnail Images", new DateTime(2025, 5, 11, 8, 15, 13, 727, DateTimeKind.Utc).AddTicks(6523) },
                    { 7, "/user-content/d3b2f6c7-ff0f-4e88-9cf4-ecd5fd2b0c51.png", true, null, 7, "Thumbnail Images", new DateTime(2025, 5, 12, 18, 10, 30, 817, DateTimeKind.Utc).AddTicks(913) },
                    { 12, "/user-content/f3012e83-c8ed-4824-8cd4-f9a339daf8f2.webp", true, null, 10, "Thumbnail Images", new DateTime(2025, 5, 13, 14, 51, 32, 15, DateTimeKind.Utc).AddTicks(8324) },
                    { 18, "/user-content/35cc0df5-31ec-4738-b24d-7a2daf7627cb.png", false, null, 13, "Thumbnail Images", new DateTime(2025, 5, 23, 14, 25, 41, 921, DateTimeKind.Utc).AddTicks(388) },
                    { 19, "/user-content/36ceb809-f557-4bdd-bb39-1ae13e9f1e51.png", false, null, 14, "Thumbnail Images", new DateTime(2025, 5, 25, 13, 53, 33, 552, DateTimeKind.Utc).AddTicks(8252) },
                    { 20, "/user-content/e87db1f5-d929-4415-9428-a1a08dddec10.png", false, null, 1, "rẻ đẹp", new DateTime(2025, 5, 25, 14, 49, 39, 140, DateTimeKind.Utc).AddTicks(5037) },
                    { 21, "/user-content/9e9ee8ab-390c-4ef0-b019-c2eac1ac955a.png", false, null, 1, "rẻ đẹp", new DateTime(2025, 5, 25, 14, 49, 49, 149, DateTimeKind.Utc).AddTicks(5966) },
                    { 22, "/user-content/fb475d98-73f8-4f1b-8583-e6042b8d2622.png", false, null, 1, "test", new DateTime(2025, 5, 25, 14, 49, 59, 834, DateTimeKind.Utc).AddTicks(412) },
                    { 23, "/user-content/12536c9c-8fdd-4bfb-bf1e-dc31ea195022.png", false, null, 1, "test", new DateTime(2025, 5, 25, 14, 50, 10, 177, DateTimeKind.Utc).AddTicks(366) },
                    { 24, "/user-content/05eef3de-d0fb-493f-8019-ad5b6bc3bb5e.png", false, null, 2, "test", new DateTime(2025, 5, 25, 14, 52, 43, 848, DateTimeKind.Utc).AddTicks(1474) },
                    { 25, "/user-content/5aeae558-cd6a-4665-a87a-69f84c73b225.png", false, null, 2, "rẻ đẹp", new DateTime(2025, 5, 25, 14, 52, 55, 629, DateTimeKind.Utc).AddTicks(7785) },
                    { 26, "/user-content/cb8cfdd2-f5c9-41fd-b497-c2ac18bc747d.png", false, null, 2, "test", new DateTime(2025, 5, 25, 14, 53, 5, 139, DateTimeKind.Utc).AddTicks(8127) },
                    { 27, "/user-content/7df6e485-fddc-48fc-b383-3776cb04e487.jpg", false, null, 2, "rẻ đẹp", new DateTime(2025, 5, 25, 14, 53, 13, 685, DateTimeKind.Utc).AddTicks(5409) },
                    { 28, "/user-content/1f524bf7-d054-476d-893e-de25db4cb9a1.png", false, null, 3, "rẻ đẹp", new DateTime(2025, 5, 25, 14, 55, 3, 739, DateTimeKind.Utc).AddTicks(9717) },
                    { 29, "/user-content/70361097-bc35-4b0c-b125-ac11c8db49d2.png", false, null, 3, "s", new DateTime(2025, 5, 25, 14, 55, 22, 498, DateTimeKind.Utc).AddTicks(6399) },
                    { 30, "/user-content/bcfd0e3b-772c-4788-89e7-9b0d1d1fb882.png", false, null, 3, "test", new DateTime(2025, 5, 25, 14, 55, 41, 630, DateTimeKind.Utc).AddTicks(2513) },
                    { 31, "/user-content/20fd60d1-282d-4560-95de-48c9cdcde892.png", false, null, 4, "s", new DateTime(2025, 5, 25, 14, 57, 15, 376, DateTimeKind.Utc).AddTicks(1171) },
                    { 32, "/user-content/0480112b-2729-43aa-b6cd-262e00bfdf12.png", false, null, 4, "s", new DateTime(2025, 5, 25, 14, 57, 32, 742, DateTimeKind.Utc).AddTicks(1256) },
                    { 33, "/user-content/a1dd908b-517c-4e23-b802-863e6960dc14.jpg", false, null, 4, "s", new DateTime(2025, 5, 25, 14, 57, 43, 193, DateTimeKind.Utc).AddTicks(3090) },
                    { 34, "/user-content/fdd9b59d-3a23-44e9-9e1c-15060e5ca5f4.jpg", false, null, 4, "s", new DateTime(2025, 5, 25, 14, 57, 51, 181, DateTimeKind.Utc).AddTicks(7814) },
                    { 35, "/user-content/7114c9fb-0473-403f-a164-ff27fe9fd86b.png", false, null, 5, "s", new DateTime(2025, 5, 25, 14, 59, 49, 263, DateTimeKind.Utc).AddTicks(1807) },
                    { 36, "/user-content/8802f344-f99d-4a51-92e2-fd939b2930e4.png", false, null, 5, "s", new DateTime(2025, 5, 25, 15, 0, 14, 239, DateTimeKind.Utc).AddTicks(4353) },
                    { 37, "/user-content/2de91d87-c82e-4db1-81e7-a7576f137422.png", false, null, 5, "s", new DateTime(2025, 5, 25, 15, 0, 30, 219, DateTimeKind.Utc).AddTicks(4082) },
                    { 38, "/user-content/75bf5150-2758-4bda-baf7-cf2897135616.png", false, null, 5, "s", new DateTime(2025, 5, 25, 15, 0, 40, 305, DateTimeKind.Utc).AddTicks(3305) },
                    { 39, "/user-content/20401a19-080b-4983-9ccd-0799a15d8474.webp", false, null, 6, "s", new DateTime(2025, 5, 25, 15, 3, 39, 697, DateTimeKind.Utc).AddTicks(2322) },
                    { 40, "/user-content/cedcdac7-562a-438f-b3fe-a1e431b293f4.webp", false, null, 6, "a", new DateTime(2025, 5, 25, 15, 4, 4, 895, DateTimeKind.Utc).AddTicks(8437) },
                    { 41, "/user-content/b587f7d9-8de0-4d9e-8213-4de24055b44a.webp", true, null, 6, "a", new DateTime(2025, 5, 25, 15, 4, 17, 33, DateTimeKind.Utc).AddTicks(9597) },
                    { 42, "/user-content/44fa3c5a-b5f5-4305-8b23-7383fd6fb58d.webp", false, null, 6, "a", new DateTime(2025, 5, 25, 15, 4, 32, 599, DateTimeKind.Utc).AddTicks(3383) },
                    { 43, "/user-content/227a8e30-60b5-4525-a3f7-efdb992698a1.png", false, null, 7, "s", new DateTime(2025, 5, 25, 15, 6, 17, 950, DateTimeKind.Utc).AddTicks(9735) },
                    { 44, "/user-content/9ec0ce09-845c-4a5a-af69-ef0d816c757b.png", false, null, 7, "a", new DateTime(2025, 5, 25, 15, 6, 25, 59, DateTimeKind.Utc).AddTicks(381) },
                    { 45, "/user-content/28cb01e5-d934-454a-a105-1ed02dedfa36.png", false, null, 7, "a", new DateTime(2025, 5, 25, 15, 6, 33, 76, DateTimeKind.Utc).AddTicks(7742) },
                    { 46, "/user-content/74155430-c217-4ea8-a79a-cf5557a1d245.png", false, null, 7, "a", new DateTime(2025, 5, 25, 15, 6, 46, 588, DateTimeKind.Utc).AddTicks(7042) },
                    { 47, "/user-content/bc22666f-b6d2-4680-a449-354aebe6a431.png", false, null, 7, "a", new DateTime(2025, 5, 25, 15, 7, 6, 31, DateTimeKind.Utc).AddTicks(9322) },
                    { 48, "/user-content/8d2f638d-2e8b-4456-9155-9ffb45b3eaf8.png", false, null, 8, "a", new DateTime(2025, 5, 25, 15, 8, 14, 762, DateTimeKind.Utc).AddTicks(1710) },
                    { 49, "/user-content/a284f159-a24a-4bfa-a1a8-ea96db900d61.png", false, null, 8, "a", new DateTime(2025, 5, 25, 15, 8, 31, 632, DateTimeKind.Utc).AddTicks(9623) },
                    { 50, "/user-content/88244490-1b9b-4147-a9a8-cc5dfbb9b581.png", false, null, 8, "a", new DateTime(2025, 5, 25, 15, 8, 50, 75, DateTimeKind.Utc).AddTicks(4347) },
                    { 51, "/user-content/8e407540-b743-4ff1-95df-286736471de7.png", false, null, 8, "a", new DateTime(2025, 5, 25, 15, 9, 0, 111, DateTimeKind.Utc).AddTicks(1204) },
                    { 52, "/user-content/3d27fb88-b296-4e2c-9c2a-eba908eafc76.webp", false, null, 10, "a", new DateTime(2025, 5, 25, 15, 21, 27, 805, DateTimeKind.Utc).AddTicks(1149) },
                    { 54, "/user-content/a5960094-acad-4ea6-9c7c-80cb0d6e3afe.webp", false, null, 10, "a", new DateTime(2025, 5, 25, 15, 23, 57, 107, DateTimeKind.Utc).AddTicks(7261) },
                    { 56, "/user-content/dd5a0800-f3e6-48d1-99a1-5f96bae82591.webp", false, null, 10, "a", new DateTime(2025, 5, 25, 15, 24, 38, 790, DateTimeKind.Utc).AddTicks(5409) },
                    { 57, "/user-content/7dbf715b-f811-46df-be9c-ec466c4df33e.png", false, null, 13, "a", new DateTime(2025, 5, 25, 15, 27, 20, 52, DateTimeKind.Utc).AddTicks(9913) },
                    { 58, "/user-content/5efd88f8-50db-4681-9e8e-7d31b4f85119.png", false, null, 13, "a", new DateTime(2025, 5, 25, 15, 27, 28, 961, DateTimeKind.Utc).AddTicks(4938) },
                    { 59, "/user-content/8cc9c68b-86dd-48c6-a926-3bac4fed84ad.png", false, null, 13, "a", new DateTime(2025, 5, 25, 15, 27, 42, 692, DateTimeKind.Utc).AddTicks(9113) },
                    { 60, "/user-content/0534e4e4-a1ef-4961-a137-bd825270cfb2.png", false, null, 13, "a", new DateTime(2025, 5, 25, 15, 27, 58, 203, DateTimeKind.Utc).AddTicks(2257) },
                    { 61, "/user-content/84fc2b08-da8e-4d19-9f65-7920a3b47a04.png", false, null, 13, "a", new DateTime(2025, 5, 25, 15, 28, 9, 213, DateTimeKind.Utc).AddTicks(8202) },
                    { 62, "/user-content/e9bd5ff4-c7c0-4c43-8a75-5f2a9eb0da16.png", false, null, 14, "a", new DateTime(2025, 5, 25, 15, 29, 48, 114, DateTimeKind.Utc).AddTicks(9785) },
                    { 63, "/user-content/5fa677cd-e90c-4d0d-a33e-44ff34360895.png", true, null, 14, "a", new DateTime(2025, 5, 25, 15, 29, 56, 719, DateTimeKind.Utc).AddTicks(2050) },
                    { 64, "/user-content/53f59bde-a338-431a-912a-e87fdc8b2e06.png", false, null, 14, "a", new DateTime(2025, 5, 25, 15, 30, 8, 116, DateTimeKind.Utc).AddTicks(3458) },
                    { 65, "/user-content/6abb0d85-3e2d-4e14-806e-1a5bcb6b21d7.png", false, null, 14, "a", new DateTime(2025, 5, 25, 15, 30, 19, 716, DateTimeKind.Utc).AddTicks(5824) },
                    { 66, "/user-content/5b931c1b-6850-4cc0-91e4-79b3ba882bbe.png", false, null, 15, "Thumbnail Images", new DateTime(2025, 5, 25, 15, 32, 41, 18, DateTimeKind.Utc).AddTicks(7380) },
                    { 67, "/user-content/5e3de4f1-48b4-44bc-b6b5-4a1dfa03b377.png", false, null, 15, "q", new DateTime(2025, 5, 25, 15, 32, 48, 998, DateTimeKind.Utc).AddTicks(2490) },
                    { 68, "/user-content/2689bfce-ebab-4e56-bbee-ec7ff84fbef9.png", false, null, 15, "q", new DateTime(2025, 5, 25, 15, 33, 3, 277, DateTimeKind.Utc).AddTicks(5455) },
                    { 69, "/user-content/9185d88a-e602-40c7-85b1-5e4c4134f9d2.png", false, null, 15, "a", new DateTime(2025, 5, 25, 15, 33, 20, 155, DateTimeKind.Utc).AddTicks(5206) },
                    { 70, "/user-content/8567fa7e-8e6f-41c5-8ca1-6c2a1fae9ce7.png", true, null, 8, "k", new DateTime(2025, 5, 25, 21, 8, 31, 907, DateTimeKind.Utc).AddTicks(4647) }
                });

            migrationBuilder.InsertData(
                table: "ProductInCategory",
                columns: new[] { "MaDanhMuc", "MaSanPham" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 1, 13 },
                    { 1, 14 },
                    { 1, 15 },
                    { 2, 2 },
                    { 2, 3 },
                    { 2, 4 },
                    { 2, 5 },
                    { 3, 7 },
                    { 3, 8 },
                    { 4, 6 },
                    { 4, 10 }
                });

            migrationBuilder.InsertData(
                table: "ChiTietDonHang",
                columns: new[] { "MaDonHang", "MaSanPham", "Gia", "SoLuong" },
                values: new object[,]
                {
                    { 48, 2, 350000.00m, 2 },
                    { 48, 3, 150000.00m, 1 },
                    { 49, 1, 150000.00m, 1 },
                    { 50, 14, 200000.00m, 1 },
                    { 51, 2, 175000.00m, 1 },
                    { 52, 2, 175000.00m, 1 },
                    { 52, 8, 1200000.00m, 1 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_ChiTietDonHang_MaSanPham",
                table: "ChiTietDonHang",
                column: "MaSanPham");

            migrationBuilder.CreateIndex(
                name: "IX_DanhGia_MaNguoiDung",
                table: "DanhGia",
                column: "MaNguoiDung");

            migrationBuilder.CreateIndex(
                name: "IX_DanhGia_MaSanPham",
                table: "DanhGia",
                column: "MaSanPham");

            migrationBuilder.CreateIndex(
                name: "IX_DonHang_MaNguoiDung",
                table: "DonHang",
                column: "MaNguoiDung");

            migrationBuilder.CreateIndex(
                name: "IX_GioHang_MaNguoiDung",
                table: "GioHang",
                column: "MaNguoiDung");

            migrationBuilder.CreateIndex(
                name: "IX_GioHang_MaSanPham",
                table: "GioHang",
                column: "MaSanPham");

            migrationBuilder.CreateIndex(
                name: "IX_HinhAnh_MaDanhGia",
                table: "HinhAnh",
                column: "MaDanhGia");

            migrationBuilder.CreateIndex(
                name: "IX_HinhAnh_MaSanPham",
                table: "HinhAnh",
                column: "MaSanPham");

            migrationBuilder.CreateIndex(
                name: "IX_ProductInCategory_MaSanPham",
                table: "ProductInCategory",
                column: "MaSanPham");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AppRoleClaims");

            migrationBuilder.DropTable(
                name: "AppRoles");

            migrationBuilder.DropTable(
                name: "AppUserClaims");

            migrationBuilder.DropTable(
                name: "AppUserLogins");

            migrationBuilder.DropTable(
                name: "AppUserRoles");

            migrationBuilder.DropTable(
                name: "AppUserTokens");

            migrationBuilder.DropTable(
                name: "ChiTietDonHang");

            migrationBuilder.DropTable(
                name: "GioHang");

            migrationBuilder.DropTable(
                name: "HinhAnh");

            migrationBuilder.DropTable(
                name: "ProductInCategory");

            migrationBuilder.DropTable(
                name: "DonHang");

            migrationBuilder.DropTable(
                name: "DanhGia");

            migrationBuilder.DropTable(
                name: "DanhMuc");

            migrationBuilder.DropTable(
                name: "AppUsers");

            migrationBuilder.DropTable(
                name: "SanPham");
        }
    }
}
