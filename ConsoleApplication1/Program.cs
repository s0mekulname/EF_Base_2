using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;
using EF_Base_2.Models;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            //var service = new ProductService();
            //var id = 4;
            //var product = service.GetById(id);
            //var products = service.GetAllProducts();
            //var newProduct = new Product
            //{
            //    Name = "new product",
            //    Created = DateTime.Today.AddDays(-1),
            //    Price = 123m,
            //    Count = 1000

            //};

            //service.Save(newProduct);

            //if (product != null)
            //{
            //    product.Name += " RENAME";
            //    service.Save(product);
            //}
            //service.Delete(id);

            var gs = new GroupsService();

            var group = new Group
            {
                Name = "Группа 11",
                GroupItems = new List<GroupItem>
                {
                    new GroupItem { Name = "Подгруппа 1" },
                    new GroupItem { Name = "Подгруппа 2" },
                    new GroupItem { Name = "Подгруппа 3" }
                }
            };
            gs.Save(group);
           // gs.Delete(group.Id);

            group.Name += " RENAME";
            group.GroupItems.ElementAt(1).Name += " Rename";
            group.GroupItems.Add(new GroupItem {Name = "Крайний сервер", GroupId = group.Id});
            var deleted = group.GroupItems.ElementAt(0);
            group.GroupItems.Remove(deleted);

            gs.Save(group, new [] {deleted.Id});


            Console.ReadKey();
        }

        private static void DeleteProduct()
        {
            int id = 5;
            using (var context = new MITA_EF_Base_2Context())
            {
                context.Database.Log = Console.WriteLine;

                context.Entry(new Product {Id = id}).State = EntityState.Deleted;

                context.SaveChanges();
            }
        }

        private static void UpdateConnectedProduct()
        {
            using (var context = new MITA_EF_Base_2Context())
            {
                context.Database.Log = Console.WriteLine;

                var product = context.Products.Find(5);

                product.Name += " RENAME";

                context.SaveChanges();
            }
        }

        private static void UpdateDisconnectedProfuct()
        {
            var product = new Product
            {
                Id = 8,
                Name = "Товар 8 UPDATE",
                Created = DateTime.Today.AddDays(-1),
                Price = 123m,
                Active = false
            };
            using (var context = new MITA_EF_Base_2Context())
            {
                context.Database.Log = Console.WriteLine;

                context.Entry(product).State = EntityState.Modified;
                context.SaveChanges();
            }
        }

        private static void FindId()
        {
            Product product = null;

            using (var context = new MITA_EF_Base_2Context())
            {
                context.Database.Log = Console.WriteLine;

                product = context.Products.Find(8);
                //products = q.ToList();
            }
        }

        private static void SelectProducts()
        {
            var products = new List<Product>();

            using (var context = new MITA_EF_Base_2Context())
            {
                context.Database.Log = Console.WriteLine;

              var q = context.Products.Where(p => p.Price > 10).OrderBy(p => p.Name);
              products = q.ToList();
            }
        }

        private static void AddNewProduct()
        {
            var product = new Product
            {
                Name = "Item 1",
                Created = DateTime.Today
            };
            using (var context = new MITA_EF_Base_2Context())
            {
                context.Database.Log = Console.WriteLine;
                context.Products.Add(product);
                context.SaveChanges();
            }
        }
    }
}
