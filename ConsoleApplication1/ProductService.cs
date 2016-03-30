using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations.Model;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using EF_Base_2.Models;
using Group = EF_Base_2.Models.Group;

namespace ConsoleApplication1
{
    public class ProductService
    {
        public List<Group> GetAll()
        {
            return null;
        }

        public Product GetById(int id)
        {
            using (var context = new MITA_EF_Base_2Context())
            {
                context.Database.Log = Console.WriteLine;
                var product1 = context.Products.Find(id);
                // select * from products where id = {id}

                var product2 = context.Products.First(p => p.Id == id);

                return product1;
            }
        }

        public IEnumerable<Product> GetAllProducts()
        {
            using (var context = new MITA_EF_Base_2Context())
            {
                context.Database.Log = Console.WriteLine;
                var products = context.Products.ToArray();
                // select * from products 


                return products;
            }
        }

        public void Save(Product product)
        {
            if (product.Id > 0)
            {
                Update(product);
            }
            else
            {
                Insert(product);
            }
        }

        private void Insert(Product product)
        {
            using (var context = new MITA_EF_Base_2Context())
            {
                context.Database.Log = Console.WriteLine;
                context.Products.Add(product);

                context.SaveChanges();
                // insert  into products () values ()

            }

        }

        private void Update(Product product)
        {
            using (var context = new MITA_EF_Base_2Context())
            {
                context.Database.Log = Console.WriteLine;
                context.Entry(product).State = EntityState.Modified;
                

                context.SaveChanges();
                // update products set ... where id = {id}

            }
        }

        public void Delete(int id)
        {
            using (var context = new MITA_EF_Base_2Context())
            {
 


                context.Entry(new Product {Id = id}).State = EntityState.Deleted;
                context.SaveChanges();
                // update products set ... where id = {id}

            }
        }
    }
}
