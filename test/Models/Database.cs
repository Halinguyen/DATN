using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace test.Models
{
    public partial class Database : DbContext
    {
        public Database()
            : base("name=Database")
        {
        }

        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }
        public virtual DbSet<tbl_Calam> tbl_Calam { get; set; }
        public virtual DbSet<tbl_Calam_Nhanvien> tbl_Calam_Nhanvien { get; set; }
        public virtual DbSet<tbl_CT_Hoadon> tbl_CT_Hoadon { get; set; }
        public virtual DbSet<tbl_Giave> tbl_Giave { get; set; }
        public virtual DbSet<tbl_Hoadon> tbl_Hoadon { get; set; }
        public virtual DbSet<tbl_Khachhang> tbl_Khachhang { get; set; }
        public virtual DbSet<tbl_Khudexe> tbl_Khudexe { get; set; }
        public virtual DbSet<tbl_Khunggio> tbl_Khunggio { get; set; }
        public virtual DbSet<tbl_Loaive> tbl_Loaive { get; set; }
        public virtual DbSet<tbl_Loaixe> tbl_Loaixe { get; set; }
        public virtual DbSet<tbl_Nhanvien> tbl_Nhanvien { get; set; }
        public virtual DbSet<tbl_Phanquyen> tbl_Phanquyen { get; set; }
        public virtual DbSet<tbl_Quyen> tbl_Quyen { get; set; }
        public virtual DbSet<tbl_Taikhoan> tbl_Taikhoan { get; set; }
        public virtual DbSet<tbl_Ve> tbl_Ve { get; set; }
        public virtual DbSet<tbl_Xe> tbl_Xe { get; set; }
        public virtual DbSet<tbl_Xeravao> tbl_Xeravao { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<tbl_Calam>()
                .HasMany(e => e.tbl_Calam_Nhanvien)
                .WithRequired(e => e.tbl_Calam)
                .HasForeignKey(e => e.FK_iCalamID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<tbl_CT_Hoadon>()
                .Property(e => e.mDongia)
                .HasPrecision(18, 0);

            modelBuilder.Entity<tbl_Giave>()
                .Property(e => e.mGia)
                .HasPrecision(18, 0);

            modelBuilder.Entity<tbl_Hoadon>()
                .HasMany(e => e.tbl_CT_Hoadon)
                .WithRequired(e => e.tbl_Hoadon)
                .HasForeignKey(e => e.FK_iHoadonID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<tbl_Khachhang>()
                .Property(e => e.sSodienthoai)
                .IsUnicode(false);

            modelBuilder.Entity<tbl_Khachhang>()
                .Property(e => e.sSoCMND)
                .IsUnicode(false);

            modelBuilder.Entity<tbl_Khachhang>()
                .HasMany(e => e.tbl_Hoadon)
                .WithRequired(e => e.tbl_Khachhang)
                .HasForeignKey(e => e.FK_iKhachhangID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<tbl_Khunggio>()
                .HasMany(e => e.tbl_Giave)
                .WithRequired(e => e.tbl_Khunggio)
                .HasForeignKey(e => e.FK_iKhunggioID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<tbl_Loaive>()
                .HasMany(e => e.tbl_Giave)
                .WithRequired(e => e.tbl_Loaive)
                .HasForeignKey(e => e.FK_iLoaiveID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<tbl_Loaixe>()
                .HasMany(e => e.tbl_Giave)
                .WithRequired(e => e.tbl_Loaixe)
                .HasForeignKey(e => e.FK_iLoaixeID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<tbl_Loaixe>()
                .HasMany(e => e.tbl_Khudexe)
                .WithRequired(e => e.tbl_Loaixe)
                .HasForeignKey(e => e.FK_iLoaixeID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<tbl_Loaixe>()
                .HasMany(e => e.tbl_Xe)
                .WithRequired(e => e.tbl_Loaixe)
                .HasForeignKey(e => e.FK_iLoaixeID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<tbl_Nhanvien>()
                .Property(e => e.sSodienthoai)
                .IsUnicode(false);

            modelBuilder.Entity<tbl_Nhanvien>()
                .Property(e => e.sSoCMND)
                .IsUnicode(false);

            modelBuilder.Entity<tbl_Nhanvien>()
                .HasMany(e => e.tbl_Calam_Nhanvien)
                .WithRequired(e => e.tbl_Nhanvien)
                .HasForeignKey(e => e.FK_iNhanvienID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<tbl_Nhanvien>()
                .HasMany(e => e.tbl_Hoadon)
                .WithRequired(e => e.tbl_Nhanvien)
                .HasForeignKey(e => e.FK_iNhanvienID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<tbl_Nhanvien>()
                .HasMany(e => e.tbl_Xeravao)
                .WithRequired(e => e.tbl_Nhanvien)
                .HasForeignKey(e => e.FK_iNhanvienID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<tbl_Quyen>()
                .HasMany(e => e.tbl_Phanquyen)
                .WithRequired(e => e.tbl_Quyen)
                .HasForeignKey(e => e.FK_iQuyenID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<tbl_Taikhoan>()
                .Property(e => e.sMatkhau)
                .IsUnicode(false);

            modelBuilder.Entity<tbl_Taikhoan>()
                .HasMany(e => e.tbl_Khachhang)
                .WithRequired(e => e.tbl_Taikhoan)
                .HasForeignKey(e => e.FK_iTaikhoanID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<tbl_Taikhoan>()
                .HasMany(e => e.tbl_Nhanvien)
                .WithRequired(e => e.tbl_Taikhoan)
                .HasForeignKey(e => e.FK_iTaikhoanID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<tbl_Taikhoan>()
                .HasMany(e => e.tbl_Phanquyen)
                .WithOptional(e => e.tbl_Taikhoan)
                .HasForeignKey(e => e.FK_iTaikhoanID);

            modelBuilder.Entity<tbl_Ve>()
                .HasMany(e => e.tbl_CT_Hoadon)
                .WithRequired(e => e.tbl_Ve)
                .HasForeignKey(e => e.FK_iVexeID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<tbl_Ve>()
                .HasMany(e => e.tbl_Xeravao)
                .WithRequired(e => e.tbl_Ve)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<tbl_Xe>()
                .Property(e => e.sBiensoxe)
                .IsUnicode(false);

            modelBuilder.Entity<tbl_Xe>()
                .HasMany(e => e.tbl_Xeravao)
                .WithRequired(e => e.tbl_Xe)
                .HasForeignKey(e => e.FK_iXeID)
                .WillCascadeOnDelete(false);
        }
    }
}
