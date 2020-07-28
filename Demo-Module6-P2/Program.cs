using Demo_Module6_P2.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace Demo_Module6_P2
{
    public class Program
    {
        public static void Main(string[] args)
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


            Console.ReadKey();
        }
    }
}
