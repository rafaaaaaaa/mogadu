using mogadu.Business.Interfaces;
using mogadu.Database.Entities;
using mogadu.Database.ExpandedEntities;
using mogadu.ViewModel.Interfaces;
using mogadu.Views.Dashboard;
using mogadu.Views.Templates;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace mogadu.ViewModel
{
    public class UebersichtViewModel : IWindow
    {

        public UebersichtViewModel(IDataRepository dataRepository, long mitarbeiterId)
        {
            TeamTile = new TeamTileUserControl(dataRepository, mitarbeiterId);
            WetterTile = new WetterTileUserControl();

            //LOGIK NICHT IMPLEMENTIERT
            MitarbeiterDesMonates = dataRepository.AlleMitarbeiter.First().FullName;
            Tag = DateTime.Today.DayOfWeek.ToString();

            var auftrag = dataRepository.AlleAuftraege.Where(x => x.FinishDatum != null).OrderBy(x => x.FinishDatum).Last();
            Neuigkeit = "Der Auftrag '" + auftrag.Auftragname + "' wurde vor " + (auftrag.FinishDatum.Value.Date - DateTime.Today).Days + " Tagen erfolgreich abgeschlossen.";
            Monat = DateTime.Today.Month.ToString();
        }

        public string Monat { get; set; }
        public string Neuigkeit { get; set; }
        public string Tag { get; set; }
        public string MitarbeiterDesMonates { get; set; }
        public TeamTileUserControl TeamTile { get; set; }
        public WetterTileUserControl WetterTile { get; set; }


        public List<ExpandedAuftrag> Auftrage { get; set; }
        public string Windowname { get { return "Übersicht"; } }
    }
}
