using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using EF_Base_2.Models.Mapping;

namespace EF_Base_2.Models
{
    public partial class MITA_EF_Base_2Context : DbContext
    {
        static MITA_EF_Base_2Context()
        {
            Database.SetInitializer<MITA_EF_Base_2Context>(null);
        }

        public MITA_EF_Base_2Context()
            : base("Name=MITA_EF_Base_2Context")
        {
        }

        public DbSet<Author> Authors { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<GroupItem> GroupItems { get; set; }
        public DbSet<Group> Groups { get; set; }
        public DbSet<ProductDetail> ProductDetails { get; set; }
        public DbSet<Product> Products { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new AuthorMap());
            modelBuilder.Configurations.Add(new BookMap());
            modelBuilder.Configurations.Add(new CategoryMap());
            modelBuilder.Configurations.Add(new GroupItemMap());
            modelBuilder.Configurations.Add(new GroupMap());
            modelBuilder.Configurations.Add(new ProductDetailMap());
            modelBuilder.Configurations.Add(new ProductMap());

        }
    }
}
