using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using mogadu.Database.ExpandedEntities;

namespace mogadu.Business
{
    public class Lohnberechner
    {
        internal static double Berechnen(ExpandedMitarbeiter expandedMitarbeiter)
        {
            return 4000 + (AnzahlGeschäftsTage(expandedMitarbeiter.Eintrittsdatum) * expandedMitarbeiter.Position.Lohnkoeffizient);
        }

        internal static int AnzahlGeschäftsTage(DateTime eintrittsdatum)
        {
           return ((DateTime.Today - eintrittsdatum).Days);
        }
    }
}
