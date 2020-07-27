using Demo_Module6_P1.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Demo_Module6_P1.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<Class1> Class1s { get; set; }
        public DbSet<Class2> Class2s { get; set; }

        public AppDbContext()
        {
            if (this.Database.CreateIfNotExists())
            {
                List<Class1> class1s = new List<Class1>();

                List<Class2> class2s = new List<Class2>()
                {
                    new Class2(){ Name = "c2I1" },
                    new Class2(){ Name = "c2I2" },
                    new Class2(){ Name = "c2I3" },
                };

                this.Class2s.AddRange(class2s);
                this.SaveChanges();

                for (int i = 0; i < 20; i++)
                {
                    class1s.Add(new Class1()
                    {
                        Firstname = "F" + i,
                        Lastname = "L" + i,
                        Age = 10 * i,
                        DayOfBirth = DateTime.Now,
                        IsActive = i % 2 == 0,
                        DistanceInSpace = 286d * i,
                        Money = new Decimal(10.69 * i),
                        Size = (uint)Math.Abs(10 * i),
                        Weight = 20 * i,
                        Hobbies = new List<string>()
                        {
                            "hobbies 1",
                            "hobbies 2",
                            "hobbies 3",
                        },
                        Class2s = new List<Class2>()
                        {
                            this.Class2s.FirstOrDefault(x => x.Id == (i % 3 + 1))
                        },
                    });
                }
                this.Class1s.AddRange(class1s);
                this.SaveChanges();
            }
        }
    }
}