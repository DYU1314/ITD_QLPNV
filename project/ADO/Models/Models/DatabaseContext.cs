using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace ADO.Models.Models
{
    public partial class DatabaseContext : DbContext
    {
        public DatabaseContext()
            : base("name=DatabaseContext")
        {
        }

        public virtual DbSet<ACCOUNT> ACCOUNTs { get; set; }
        public virtual DbSet<CHUC_VU> CHUC_VUs { get; set; }
        public virtual DbSet<CHUCVU_NHANVIEN> CHUCVU_NHANVIENs { get; set; }
        public virtual DbSet<DON_XIN_NGHI_PHEP> DON_XIN_NGHI_PHEPs { get; set; }
        public virtual DbSet<LEVEL_USER> LEVEL_USERs { get; set; }
        public virtual DbSet<NGHI_PHEP> NGHI_PHEPs { get; set; }
        public virtual DbSet<NHAN_VIEN> NHAN_VIENs { get; set; }
        public virtual DbSet<PHONG_BAN> PHONG_BANs { get; set; }
        public virtual DbSet<PHONGBAN_NHANVIEN> PHONGBAN_NHANVIENs { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CHUC_VU>()
                .HasMany(e => e.CHUCVU_NHANVIEN)
                .WithOptional(e => e.CHUC_VU)
                .HasForeignKey(e => e.ID_CHUCVU);

            modelBuilder.Entity<LEVEL_USER>()
                .HasMany(e => e.ACCOUNTs)
                .WithOptional(e => e.LEVEL_USER)
                .HasForeignKey(e => e.ID_QUYEN);

            modelBuilder.Entity<NHAN_VIEN>()
                .HasMany(e => e.ACCOUNTs)
                .WithOptional(e => e.NHAN_VIEN)
                .HasForeignKey(e => e.ID_NHANVIEN);

            modelBuilder.Entity<NHAN_VIEN>()
                .HasMany(e => e.CHUCVU_NHANVIEN)
                .WithOptional(e => e.NHAN_VIEN)
                .HasForeignKey(e => e.ID_NHANVIEN);

            modelBuilder.Entity<NHAN_VIEN>()
                .HasMany(e => e.DON_XIN_NGHI_PHEP)
                .WithOptional(e => e.NHAN_VIEN)
                .HasForeignKey(e => e.ID_NHANVIEN);

            modelBuilder.Entity<NHAN_VIEN>()
                .HasMany(e => e.NGHI_PHEP)
                .WithOptional(e => e.NHAN_VIEN)
                .HasForeignKey(e => e.ID_NHANVIEN);

            modelBuilder.Entity<NHAN_VIEN>()
                .HasMany(e => e.PHONGBAN_NHANVIEN)
                .WithOptional(e => e.NHAN_VIEN)
                .HasForeignKey(e => e.ID_NHANVIEN);

            modelBuilder.Entity<PHONG_BAN>()
                .HasMany(e => e.PHONGBAN_NHANVIEN)
                .WithOptional(e => e.PHONG_BAN)
                .HasForeignKey(e => e.ID_PHONGBAN);
        }
    }
}
