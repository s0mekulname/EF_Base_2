using System;
using System.Collections.Generic;

namespace EF_Base_2.Models
{
    public partial class Group
    {
        public Group()
        {
            this.GroupItems = new List<GroupItem>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<GroupItem> GroupItems { get; set; }
    }
}
