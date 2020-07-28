using Demo_Module6_P2.Data;
using Demo_Module6_P2.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo_Module6_P2.GenericTest
{
    public class GenericDbManipulation<T> where T : DbItem
    {
        public void Do(T item)
        {
            using (var db = new DemoDbContext())
            {
                db.Entry(item).State = System.Data.Entity.EntityState.Added;
                db.SaveChanges();
            }
        }
    }
}
