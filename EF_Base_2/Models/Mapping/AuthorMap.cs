using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace EF_Base_2.Models.Mapping
{
    public class AuthorMap : EntityTypeConfiguration<Author>
    {
        public AuthorMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.Name)
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("Authors");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.Name).HasColumnName("Name");

            // Relationships
            this.HasMany(t => t.Books)
                .WithMany(t => t.Authors)
                .Map(m =>
                    {
                        m.ToTable("BookAuthors");
                        m.MapLeftKey("AuthorId");
                        m.MapRightKey("BookId");
                    });


        }
    }
}
