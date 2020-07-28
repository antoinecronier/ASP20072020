using System.ComponentModel.DataAnnotations.Schema;

namespace Demo_Module6_P2.Entities
{
    public class Conducteur : DbItem
    {
        private long id;

        [Column("driver_firstname")]
        public string Firstname { get; set; }
        [Column("driver_lastname")]
        public string Lastname { get; set; }
        [Column("driver_car")]
        public virtual Voiture Car { get; set; }
        public long Id { get => this.id; set => this.id = value; }
    }
}