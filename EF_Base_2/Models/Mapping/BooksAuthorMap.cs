using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace EF_Base_2.Models.Mapping
{
    public class BooksAuthorMap : EntityTypeConfiguration<BooksAuthor>
    {
        public BooksAuthorMap()
        {
            // Primary Key
            this.HasKey(t => new { t.BookId, t.AuthorId });

            // Properties
            this.Property(t => t.BookId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.AuthorId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            // Table & Column Mappings
            this.ToTable("BooksAuthors");
            this.Property(t => t.BookId).HasColumnName("BookId");
            this.Property(t => t.AuthorId).HasColumnName("AuthorId");
            this.Property(t => t.OrderNumber).HasColumnName("OrderNumber");

            // Relationships
            //this.HasRequired(t => t.Author)
            //    .WithMany(t => t.BooksAuthors)
            //    .HasForeignKey(d => d.AuthorId);
            //this.HasRequired(t => t.Book)
            //    .WithMany(t => t.BooksAuthors)
            //    .HasForeignKey(d => d.BookId);

        }
    }
}
