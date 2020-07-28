using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo_Module6_P2.Entities
{
    public class Voiture : DbItem
    {
        private long id;
        public string Name { get; set; }
        public int Kilometers { get; set; }
        public Conducteur Driver { get; set; }
        public List<Trajet> Rides { get; set; }
        public List<Trajet> CommonRides { get; set; }
        public long Id { get => this.id; set => this.id = value; }
    }
}
