using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace EF_Base_2.Models.Mapping
{
    public class ProductMap : EntityTypeConfiguration<Product>
    {
        public ProductMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.Name)
                .IsRequired()
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("Products");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.Name).HasColumnName("Name");
            this.Property(t => t.Created).HasColumnName("Created");
            this.Property(t => t.Price).HasColumnName("Price");
            this.Property(t => t.Active).HasColumnName("Active");
            this.Property(t => t.Count).HasColumnName("Count");
            this.Property(t => t.CategoryId).HasColumnName("CategoryId");
        }
    }
}
