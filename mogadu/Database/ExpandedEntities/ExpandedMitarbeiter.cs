using mogadu.Business;
using mogadu.Database.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mogadu.Database.ExpandedEntities
{
    public class ExpandedMitarbeiter : Mitarbeiter
    {
        public Position Position { get; set; }

        public Team Team { get; set; }

        public string Lohn
        {
            get
            {
                return Math.Round(Lohnberechner.Berechnen(this)).ToString() + " CHF";
            }
        }

        public string FullName
        {
            get { return (Vorname + " " + Name); }
        } 
        
    }
}
