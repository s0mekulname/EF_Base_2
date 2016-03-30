using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace EF_Base_2.Models.Mapping
{
    public class GroupItemMap : EntityTypeConfiguration<GroupItem>
    {
        public GroupItemMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.Name)
                .IsRequired()
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("GroupItems");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.Name).HasColumnName("Name");
            this.Property(t => t.GroupId).HasColumnName("GroupId");

            // Relationships
            this.HasRequired(t => t.Group)
                .WithMany(t => t.GroupItems)
                .HasForeignKey(d => d.GroupId);

        }
    }
}
