using System;

namespace mogadu.Database.Entities
{
    public class Mitarbeiter
    {
        public virtual long MitarbeiterId { get; set; }
        public virtual string Name { get; set; }
        public virtual string Vorname { get; set; }
        public virtual DateTime Eintrittsdatum {get; set;}
        public virtual long TeamId { get; set; }
        public virtual long PositionId { get; set; }
        public virtual bool IsMale { get; set; }
    }
}
