namespace Demo_Module6_P2.Entities
{
    public class Trajet : DbItem
    {
        private long id;

        public string Name { get; set; }
        public long Id { get => this.id; set => this.id = value; }
    }
}