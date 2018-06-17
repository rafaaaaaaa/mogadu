namespace mogadu.Database.Entities
{
    public class Team
    {
        public virtual long TeamId { get; set; }
        public virtual long TeamleiterId { get; set; }
        public virtual string Teambezeichnung { get; set; }
    }
}
