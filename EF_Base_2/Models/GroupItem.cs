using System;
using System.Collections.Generic;

namespace EF_Base_2.Models
{
    public partial class GroupItem
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int GroupId { get; set; }
        public virtual Group Group { get; set; }
    }
}
