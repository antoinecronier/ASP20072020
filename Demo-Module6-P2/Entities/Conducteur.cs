namespace Demo_Module6_P2.Entities
{
    public class Conducteur : DbItem
    {
        private long id;
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public long Id { get => this.id; set => this.id = value; }
    }
}