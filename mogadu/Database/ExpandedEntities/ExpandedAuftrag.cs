using mogadu.Database.Entities;
using System.Collections.Generic;

namespace mogadu.Database.ExpandedEntities
{
    public class ExpandedAuftrag : Auftrag
    {
        public Team Team { get; set; }

        public List<Aufgabe> Aufgaben { get; set; }
    }
}
