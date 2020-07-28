using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo_Module6_P2.Entities
{
    public class Voiture : DbItem
    {
        private long id;

        [Column("car_name")]
        public string Name { get; set; }
        [Column("car_kilo")]
        public int Kilometers { get; set; }
        [Column("car_driver")]
        public virtual Conducteur Driver { get; set; }
        public virtual List<Trajet> Rides { get; set; }
        public virtual List<Trajet> CommonRides { get; set; }
        public long Id { get => this.id; set => this.id = value; }
    }
}
