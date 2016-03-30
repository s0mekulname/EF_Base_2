using System;
using System.Collections.Generic;

namespace EF_Base_2.Models
{
    public partial class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public System.DateTime Created { get; set; }
        public decimal Price { get; set; }
        public Nullable<bool> Active { get; set; }
        public int Count { get; set; }
        public Nullable<int> CategoryId { get; set; }
        public virtual ProductDetail ProductDetail { get; set; }
    }
}
