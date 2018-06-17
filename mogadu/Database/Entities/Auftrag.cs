using System;

namespace mogadu.Database.Entities
{
    public class Auftrag
    {
        public virtual long AuftragId { get; set; }
        public virtual long TeamId { get; set; }
        public virtual string Auftragname { get; set; }
        public virtual int Priorität { get; set; }
        public virtual DateTime ErstellDatum { get; set; }
        public virtual DateTime? FinishDatum { get; set; }
    }
}
