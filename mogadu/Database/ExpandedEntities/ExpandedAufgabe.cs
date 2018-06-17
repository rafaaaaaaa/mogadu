using mogadu.Database.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mogadu.Database.ExpandedEntities
{
    public class ExpandedAufgabe : Aufgabe
    {
       public ExpandedMitarbeiter Mitarbeiter { get; set; }

       public ExpandedAuftrag Auftrag { get; set; }
    }
}
