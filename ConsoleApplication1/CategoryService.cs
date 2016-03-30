using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration.Configuration;
using System.Linq;
using EF_Base_2.Models;

namespace ConsoleApplication1
{
    public class CategoryService
    {
        public IEnumerable<Category> BuildTree()
        {
            using (var context = new MITA_EF_Base_2Context())
            {
                context.Database.Log = Console.WriteLine;
                var all = context.Categories.ToArray();
                var roots = context.Categories.Where(c => c.ParentId == null)
                    .ToArray();

                foreach (var root in roots)
                {
                    root.ChildCategories = findChildren(root.Id, all);
                }

                return roots;
            }
        }

        private List<Category> findChildren(int parentId, IEnumerable<Category> all)
        {
            var children = all.Where(c => c.ParentId == parentId).ToList();
            foreach (var child in children)
            {
                child.ChildCategories = findChildren(child.Id, all);
            }
            return children;
        } 
    }
}
