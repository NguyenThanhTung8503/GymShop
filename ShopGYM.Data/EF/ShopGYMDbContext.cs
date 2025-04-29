
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ShopGYM.Data.Configuration;
using ShopGYM.Data.Entities;
using ShopGYM.Data.Extensions;

namespace ShopGYM.Data.EF
{
    public class ShopGYMDbContext : IdentityDbContext<AppUser, AppRole, Guid>
    {
        public ShopGYMDbContext(DbContextOptions options) : base(options)
        {
        }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new DanhMucConfiguration());
            modelBuilder.ApplyConfiguration(new SanPhamConfiguration());
            modelBuilder.ApplyConfiguration(new DonHangConfiguration());
            modelBuilder.ApplyConfiguration(new ChiTietDonHangConfiguration());
            modelBuilder.ApplyConfiguration(new GioHangConfiguration());
            modelBuilder.ApplyConfiguration(new DanhGiaConfiguration());
            modelBuilder.ApplyConfiguration(new GiaoDichConfiguration());
            modelBuilder.ApplyConfiguration(new NhaCungCapConfiguration());
            modelBuilder.ApplyConfiguration(new NhapHangConfiguration());
            modelBuilder.ApplyConfiguration(new ChiTietNhapHangConfiguration());
            modelBuilder.ApplyConfiguration(new HinhAnhConfiguration());
            modelBuilder.ApplyConfiguration(new AppUserConfiguration());
            modelBuilder.ApplyConfiguration(new AppRoleConfiguration());

            modelBuilder.Entity<IdentityUserClaim<Guid>>().ToTable("AppUserClaims");
            modelBuilder.Entity<IdentityUserRole<Guid>>().ToTable("AppUserRoles").HasKey(x => new { x.UserId, x.RoleId });
            modelBuilder.Entity<IdentityUserLogin<Guid>>().ToTable("AppUserLogins").HasKey(x => x.UserId);

            modelBuilder.Entity<IdentityRoleClaim<Guid>>().ToTable("AppRoleClaims");
            modelBuilder.Entity<IdentityUserToken<Guid>>().ToTable("AppUserTokens").HasKey(x => x.UserId);

            //Seeding data
           modelBuilder.Seed();

        }
        public DbSet<DanhMuc> DanhMucs { get; set; }
        public DbSet<SanPham> SanPhams { get; set; }
        public DbSet<DonHang> DonHangs { get; set; }
        public DbSet<ChiTietDonHang> ChiTietDonHangs { get; set; }
        public DbSet<GioHang> GioHangs { get; set; }
        public DbSet<DanhGia> DanhGias { get; set; }
        public DbSet<GiaoDich> GiaoDichs { get; set; }
        public DbSet<NhaCungCap> NhaCungCaps { get; set; }
        public DbSet<NhapHang> NhapHangs { get; set; }
        public DbSet<ChiTietNhapHang> ChiTietNhapHangs { get; set; }
        public DbSet<HinhAnh> HinhAnhs { get; set; }

    }
}
