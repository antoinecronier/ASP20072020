using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Demo_Module6_P2.Entities
{
    public class Trajet : DbItem
    {
        private long id;

        [Column("ride_name")]
        public string Name { get; set; }
        [Column("ride_common_car")]
        public virtual Voiture CommonCar { get; set; }
        public virtual List<Voiture> Cars { get; set; }
        public long Id { get => this.id; set => this.id = value; }
    }
}