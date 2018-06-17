using mogadu.Business.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using mogadu.Database.ExpandedEntities;

namespace mogadu.Business
{
    public class FortschrittCalculator : IFortschrittCalculator
    {
        public int Calculate(ExpandedAuftrag auftrag)
        {
            var anzahLAufgaben = auftrag.Aufgaben.Count();
            int? prozentualGesamt = 0;
            foreach (var item in auftrag.Aufgaben)
            {
                prozentualGesamt += item.Prozentualstatus.Value;
            }

            var fortschritt =  (prozentualGesamt.Value / anzahLAufgaben);
            return fortschritt;
        }
    }
}
