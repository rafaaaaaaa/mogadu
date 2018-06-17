using mogadu.Business.Interfaces;
using mogadu.Database.Entities;
using System.Collections.Generic;

namespace mogadu.Database.ExpandedEntities
{
    public class ExpandedTeam : Team
    {
        private IAuslastungCalculator _auslastungCalculator;
        public ExpandedTeam(IAuslastungCalculator auslastungCalculator)
        {
            _auslastungCalculator = auslastungCalculator;
        }
        public ExpandedMitarbeiter Teamleiter { get; set; }
        public string ProzentualeAuslastung { get { return Auslastung + " %"; } }
        public int Auslastung { get { return _auslastungCalculator.Calculate(this as Team); } set { Auslastung = value; } }
        public int AnzahlMitarbeiter { get; set; }

        public List<ExpandedMitarbeiter> Teammitglieder { get; set; }
    }
}
