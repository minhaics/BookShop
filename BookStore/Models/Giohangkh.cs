namespace BookStore.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Giohangkh")]
    public partial class Giohangkh
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Giohangkh()
        {
            ChiTietGioHangs = new HashSet<ChiTietGioHang>();
        }

        public int GiohangkhID { get; set; }

        public int? Makh { get; set; }

        [Column(TypeName = "smalldatetime")]
        public DateTime? Ngaymua { get; set; }

        public decimal? Tongtien { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ChiTietGioHang> ChiTietGioHangs { get; set; }

        public virtual Khachhang Khachhang { get; set; }
    }
}
