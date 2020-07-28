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
    }
}
