namespace mogadu.Database.Entities
{
    public class Position
    {
        public virtual long PositionsId { get; set; }
        public virtual string Positionsbezeichnung { get; set; }
        public virtual double Lohnkoeffizient { get; set; }
    }
}
