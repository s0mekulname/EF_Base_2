using System;
using System.Collections.Generic;

namespace EF_Base_2.Models
{
    public partial class Book
    {
        public Book()
        {
            this.Authors = new List<Author>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Author> Authors { get; set; }
    }
}
