namespace mogadu.Database.Entities
{
    public class Aufgabe
    {
        public virtual long AufgabenId { get; set; }
        public virtual long AuftragId { get; set; }
        public virtual string Aufgabenname { get; set; }
        public virtual string Aufgabenbeschreibung { get; set; }
        public virtual long? MitarbeiterId { get; set; }
        public virtual int? Prozentualstatus { get; set; }
    }
}
