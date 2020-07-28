using Demo_Module6_P2.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using Demo_Module6_P2.Entities;
using Demo_Module6_P2.GenericTest;
using Demo_Module6_P2.Extensions;

namespace Demo_Module6_P2
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //ItemAccess();
            //ItemManipulation();
            ItemManipulation2();

            Console.ReadKey();
        }

        private static void ItemManipulation2()
        {
            using (var db = new DemoDbContext())
            {
                try
                {
                    (string, string) item = ("test", "prop2");
                    db.Entry(item).State = EntityState.Added;
                    db.SaveChanges();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }

            Conducteur conducteur = new Conducteur() { Firstname = "std", Lastname = "std" }; ;
            //GenericDbManipulation<Conducteur> dbM = new GenericDbManipulation<Conducteur>();
            //dbM.Do(conducteur);

            //GenericDbManipulation<DbItem> dbM1 = new GenericDbManipulation<DbItem>();
            //dbM1.Do(conducteur);
            //dbM1.Do(new Voiture());

            //GenericDbManipulation2 dbm2 = new GenericDbManipulation2();
            //dbm2.Do(conducteur);
            //(string, string) item2 = ("test", "prop2");
            //dbm2.Do(item2);

            conducteur.Save();
        }

        private static void ItemManipulation()
        {
            Conducteur conducteurStd = null;
            Conducteur conducteurEntityState = null;

            using (var db = new DemoDbContext())
            {
                conducteurStd = new Conducteur() { Firstname = "conducteur", Lastname = "standard" };
                db.Conducteurs.Add(conducteurStd);
                db.SaveChanges();
            }

            using (var db = new DemoDbContext())
            {
                conducteurEntityState = new Conducteur() { Firstname = "conducteur", Lastname = "entityState" };
                db.Entry(conducteurEntityState).State = EntityState.Added;
                db.SaveChanges();
            }

            // Call from physical db
            using (var db = new DemoDbContext())
            {
                var dbItem = db.Conducteurs.FirstOrDefault(x => x.Id == conducteurEntityState.Id);
                if (dbItem != null)
                {
                    Console.WriteLine("Item firstname = " + dbItem.Firstname);
                }
            }

            // Using only memory db
            using (var db = new DemoDbContext())
            {
                conducteurEntityState.Firstname = "test";
                db.Entry(conducteurEntityState).State = EntityState.Modified;
                //db.SaveChanges();
                var dbItem = db.Conducteurs.FirstOrDefault(x => x.Id == conducteurEntityState.Id);
                if (dbItem != null)
                {
                    Console.WriteLine("Item firstname = " + dbItem.Firstname);
                }
            }

            using (var db = new DemoDbContext())
            {
                var dbItem = db.Conducteurs.FirstOrDefault(x => x.Id == conducteurEntityState.Id);
                dbItem.Firstname = "test";
                db.SaveChanges();
                var dbItemCheck = db.Conducteurs.FirstOrDefault(x => x.Id == conducteurEntityState.Id);
                if (dbItemCheck != null)
                {
                    Console.WriteLine("Item firstname = " + dbItemCheck.Firstname);
                }
            }

            using (var db = new DemoDbContext())
            {
                db.Conducteurs.Attach(conducteurStd);
                db.Conducteurs.Remove(conducteurStd);
                db.SaveChanges();
                if (db.Conducteurs.FirstOrDefault(x => x.Id == conducteurStd.Id) == null)
                {
                    Console.WriteLine("Conducteur std deleted");
                }
            }

            using (var db = new DemoDbContext())
            {
                db.Entry(conducteurEntityState).State = EntityState.Deleted;
                db.SaveChanges();
                if (db.Conducteurs.FirstOrDefault(x => x.Id == conducteurEntityState.Id) == null)
                {
                    Console.WriteLine("Conducteur entity state deleted");
                }
            }
        }

        private static void ItemAccess()
        {
            Console.WriteLine("Lazy loading");
            //using (var db = new DemoDbContext())
            //{
            //    Console.WriteLine("Car driver lastname");
            //    foreach (var item in db.Voitures)
            //    {
            //        Console.WriteLine(item.Driver.Lastname);
            //    }
            //}

            Console.WriteLine("Eager loading");
            using (var db = new DemoDbContext())
            {
                Console.WriteLine("Car driver lastname");
                foreach (var item in db.Voitures.Include(x => x.Driver).ToList())
                {
                    Console.WriteLine(item.Driver.Lastname);
                }

                Console.WriteLine("Car driver driver car name v1");
                foreach (var item in db.Voitures.Include(x => x.Driver).ToList())
                {
                    Console.WriteLine(item.Driver.Car.Name);
                }

                Console.WriteLine("Car driver driver car name v2");
                foreach (var item in db.Voitures.Include(x => x.Driver.Car).ToList())
                {
                    Console.WriteLine(item.Driver.Car.Name);
                }
            }

            Console.WriteLine("Reference loading");
            using (var db = new DemoDbContext())
            {
                Console.WriteLine("Car driver lastname");
                var voiture = db.Voitures.Find(1);
                Console.WriteLine("Voiture driver " + voiture.Driver);
                db.Entry(voiture).Reference(x => x.Driver).Load();
                Console.WriteLine("Voiture driver " + voiture.Driver);
                Console.WriteLine("Voiture driver lastname " + voiture.Driver.Lastname);
            }
        }
    }
}
