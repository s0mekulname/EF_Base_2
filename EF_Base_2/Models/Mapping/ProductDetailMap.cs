using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace EF_Base_2.Models.Mapping
{
    public class ProductDetailMap : EntityTypeConfiguration<ProductDetail>
    {
        public ProductDetailMap()
        {
            // Primary Key
            this.HasKey(t => t.ProductId);

            // Properties
            this.Property(t => t.ProductId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.Details)
                .IsRequired()
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("ProductDetails");
            this.Property(t => t.ProductId).HasColumnName("ProductId");
            this.Property(t => t.Details).HasColumnName("Details");

            // Relationships
            this.HasRequired(t => t.Product)
                .WithOptional(t => t.ProductDetail);

        }
    }
}
