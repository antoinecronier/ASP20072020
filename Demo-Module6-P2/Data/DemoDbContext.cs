using Demo_Module6_P2.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo_Module6_P2.Data
{
    public class DemoDbContext : DbContext
    {
        public DbSet<Voiture> Voitures { get; set; }
        public DbSet<Trajet> Trajets { get; set; }
        public DbSet<Conducteur> Conducteurs { get; set; }

        public DemoDbContext()
        {
            this.Configuration.LazyLoadingEnabled = false;

            if (this.Database.CreateIfNotExists())
            {
                List<Conducteur> conducteurs = new List<Conducteur>();
                List<Trajet> trajets = new List<Trajet>();
                List<Voiture> voitures = new List<Voiture>();

                for (int i = 0; i < 5; i++)
                {
                    conducteurs.Add(new Conducteur() { Lastname = "l" + i, Firstname = "f" + i });
                }

                this.Conducteurs.AddRange(conducteurs);
                this.SaveChanges();

                for (int i = 0; i < 5; i++)
                {
                    trajets.Add(new Trajet() { Name = "trajet " + i });
                }

                this.Trajets.AddRange(trajets);
                this.SaveChanges();

                for (int i = 0; i < 5; i++)
                {
                    voitures.Add(new Voiture()
                    {
                        Kilometers = 10 * i,
                        Name = "voiture " + i,
                        Driver = conducteurs.ElementAt(i),
                        CommonRides = new List<Trajet>() { trajets.ElementAt(i) },
                        Rides = new List<Trajet>() { trajets.ElementAt(0) }
                    });
                }

                this.Voitures.AddRange(voitures);
                this.SaveChanges();
            }
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Voiture>().HasOptional(x => x.Driver).WithOptionalPrincipal(x => x.Car);
            modelBuilder.Entity<Voiture>().HasMany(x => x.CommonRides).WithOptional(x => x.CommonCar);
            modelBuilder.Entity<Voiture>().HasMany(x => x.Rides).WithMany(x => x.Cars);
            //modelBuilder.Entity<Trajet>().HasMany(x => x.Cars).WithMany(x => x.Rides);
        }
    }
}
