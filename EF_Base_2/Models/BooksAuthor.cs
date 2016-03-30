using System;
using System.Collections.Generic;

namespace EF_Base_2.Models
{
    public partial class BooksAuthor
    {
        public int BookId { get; set; }
        public int AuthorId { get; set; }
        public int OrderNumber { get; set; }
        public virtual Author Author { get; set; }
        public virtual Book Book { get; set; }
    }
}
