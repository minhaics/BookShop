namespace BookStore.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ChiTietGioHang")]
    public partial class ChiTietGioHang
    {
        public int ChitietgiohangID { get; set; }

        public int? GiohangkhID { get; set; }

        public int? Masach { get; set; }

        public int? Soluong { get; set; }

        public decimal? Thanhtien { get; set; }

        public virtual Giohangkh Giohangkh { get; set; }

        public virtual Sach Sach { get; set; }
    }
}
