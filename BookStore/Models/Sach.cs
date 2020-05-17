namespace BookStore.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Sach")]
    public partial class Sach
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Sach()
        {
            ChiTietGioHangs = new HashSet<ChiTietGioHang>();
        }

        [Key]
        public int Masach { get; set; }

        [StringLength(200)]
        public string Tensach { get; set; }

        public decimal? Dongia { get; set; }

        [StringLength(10)]
        public string Donvitinh { get; set; }

        [Column(TypeName = "ntext")]
        public string Mota { get; set; }

        [StringLength(200)]
        public string Hinhminhhoa { get; set; }

        public int? Macd { get; set; }

        public int? Manxb { get; set; }

        [Column(TypeName = "smalldatetime")]
        public DateTime? Ngaycapnhat { get; set; }

        public int? Matacgia { get; set; }

        public int? Soluong { get; set; }

        public decimal? Giakm { get; set; }

        [Column(TypeName = "ntext")]
        public string Motangangon { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ChiTietGioHang> ChiTietGioHangs { get; set; }

        public virtual Chude Chude { get; set; }

        public virtual Nhaxuatban Nhaxuatban { get; set; }

        public virtual Tacgia Tacgia { get; set; }
    }
}
