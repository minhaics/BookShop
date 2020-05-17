namespace BookStore.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Chinhanh")]
    public partial class Chinhanh
    {
        [Key]
        public int Macn { get; set; }

        [StringLength(100)]
        public string Tencn { get; set; }

        [StringLength(100)]
        public string Diachi { get; set; }

        [StringLength(20)]
        public string Sdt { get; set; }

        [StringLength(100)]
        public string Email { get; set; }

        [StringLength(200)]
        public string Hinh { get; set; }
    }
}
