using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookStore.Models
{
    public class CartItem
    {
        public Sach Product { get; set; }
        public int Quantity { get; set; }
    }
}