using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EF_Base_2.Models;

namespace ConsoleApplication1
{
    public class GroupsService
    {

        public Group GetById(int id)
        {
            using (var context = new MITA_EF_Base_2Context())
            {
                context.Configuration.ProxyCreationEnabled = false;
                context.Database.Log = Console.WriteLine;

                var group1 = context.Groups.Find(id);

                context.Entry(group1).Collection(g => g.GroupItems).Load();

                return group1;
            }
        }

        public List<Group> GetAll()
        {
            using (var context = new MITA_EF_Base_2Context())
            {
                context.Database.Log = Console.WriteLine;
                var groups = context.Groups.ToList();
                // select * from products 


                return groups;
            }
        }

        public void Save(Group group, IEnumerable<int> deleteItems = null)
        {
            if (group.Id > 0)
            {
                Update(group, deleteItems);
            }
            else
            {
                Insert(group);
            }
        }

        private void Insert(Group group)
        {
            using (var context = new MITA_EF_Base_2Context())
            {              
                context.Database.Log = Console.WriteLine;
                context.Groups.Add(group);
                context.SaveChanges();
            }
        }

        private void Update(Group group, IEnumerable<int> deleteItems = null)
        {
            using (var context = new MITA_EF_Base_2Context())
            {
                context.Database.Log = Console.WriteLine;
                context.Entry(group).State = EntityState.Modified;
                foreach (var deletedId in deleteItems)
                {
                    context.Entry(new GroupItem {Id = deletedId}).State = EntityState.Deleted;
                }
                foreach (var gi in group.GroupItems)
                {
                    context.Entry(gi).State = gi.Id > 0 ? EntityState.Modified : EntityState.Added;
                }

                context.SaveChanges();
            }
        }

        public void Delete(int id)
        {
            using (var context = new MITA_EF_Base_2Context())
            {
                context.Database.Log = Console.WriteLine;

                var items = context.GroupItems.Where(gi => gi.GroupId == id).ToList();
                context.GroupItems.RemoveRange(items);

                context.Entry(new Group { Id = id}).State = EntityState.Deleted;
                context.SaveChanges();
            }
        }

    }
}
