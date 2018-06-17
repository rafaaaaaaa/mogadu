using mogadu.Business.Interfaces;
using mogadu.Database.Entities;
using System.Collections.Generic;
using System.Linq;

namespace mogadu.Database.ExpandedEntities
{
    public class ExpandedAuftrag : Auftrag
    {
        private readonly IFortschrittCalculator _fortschrittCalculator;

        public ExpandedAuftrag(IFortschrittCalculator fortschrittCalculator)
        {
            _fortschrittCalculator = fortschrittCalculator;
        }

        public Team Team { get; set; }

        public List<ExpandedAufgabe> Aufgaben { get; set; }

        public bool Abgeschlossen { get { return FinishDatum.HasValue; } }

        public int ErledigteAufgaben
        {
            get { return Aufgaben.Where(x => x.Prozentualstatus == 100).Count(); }
        }
        public int OffeneAufgaben
        {
            get { return Aufgaben.Where(x => x.Prozentualstatus != 100).Count(); }
        }

        public int Fortschritt
        {
            get
            {
               return  _fortschrittCalculator.Calculate(this);
            }

            set
            {
                Fortschritt = value;
            }
        }

        public string ProzentualerFortschritt
        {
            get
            {
                return Fortschritt + "%";
            }
        }
    }
}
