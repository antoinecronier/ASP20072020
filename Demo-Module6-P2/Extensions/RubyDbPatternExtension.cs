using Demo_Module6_P2.Data;
using Demo_Module6_P2.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo_Module6_P2.Extensions
{
    public static class RubyDbPatternExtension
    {
        public static void Save(this object item)
        {
            if (item is DbItem)
            {
                using (var db = new DemoDbContext())
                {
                    db.Entry(item).State = System.Data.Entity.EntityState.Added;
                    db.SaveChanges();
                }
            }
            else
            {
                Console.WriteLine("Cannot save object of type " + item.GetType().FullName);
            }
        }
    }
}
