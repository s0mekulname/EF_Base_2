using System;
using System.Collections.Generic;

namespace EF_Base_2.Models
{
    public partial class Category
    {
        public Category()
        {
            this.ChildCategories = new List<Category>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int? ParentId { get; set; }
        public virtual ICollection<Category> ChildCategories { get; set; }
        public virtual Category ParentCategory { get; set; }
    }
}
