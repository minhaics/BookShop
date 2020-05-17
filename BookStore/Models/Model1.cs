namespace BookStore.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class Model1 : DbContext
    {
        public Model1()
            : base("name=Model1")
        {
        }

        public virtual DbSet<Chinhanh> Chinhanhs { get; set; }
        public virtual DbSet<ChiTietGioHang> ChiTietGioHangs { get; set; }
        public virtual DbSet<Chude> Chudes { get; set; }
        public virtual DbSet<Giohangkh> Giohangkhs { get; set; }
        public virtual DbSet<Khachhang> Khachhangs { get; set; }
        public virtual DbSet<Nhaxuatban> Nhaxuatbans { get; set; }
        public virtual DbSet<Sach> Saches { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }
        public virtual DbSet<Tacgia> Tacgias { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Chinhanh>()
                .Property(e => e.Sdt)
                .IsUnicode(false);

            modelBuilder.Entity<ChiTietGioHang>()
                .Property(e => e.Thanhtien)
                .HasPrecision(18, 0);

            modelBuilder.Entity<Chude>()
                .Property(e => e.Key)
                .IsUnicode(false);

            modelBuilder.Entity<Giohangkh>()
                .Property(e => e.Tongtien)
                .HasPrecision(18, 0);

            modelBuilder.Entity<Khachhang>()
                .Property(e => e.Dienthoaikh)
                .IsUnicode(false);

            modelBuilder.Entity<Sach>()
                .Property(e => e.Dongia)
                .HasPrecision(18, 0);

            modelBuilder.Entity<Sach>()
                .Property(e => e.Giakm)
                .HasPrecision(18, 0);
        }
    }
}
