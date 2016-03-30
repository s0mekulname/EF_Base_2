using System;
using System.Collections.Generic;

namespace EF_Base_2.Models
{
    public partial class ProductDetail
    {
        public int ProductId { get; set; }
        public string Details { get; set; }
        public virtual Product Product { get; set; }
    }
}
