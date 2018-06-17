using mogadu.Business.Interfaces;
using mogadu.Database.Entities;
using mogadu.Database.ExpandedEntities;
using mogadu.ViewModel.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mogadu.ViewModel
{
    public class AuftraegeViewModel : IWindow
    {
        private string _teamBezeichnung;
        public AuftraegeViewModel(IDataRepository datarepository, long mitarbeiterId)
        {
            _teamBezeichnung = datarepository.LoadTeamByMitarbeiterId(mitarbeiterId).Teambezeichnung;
            Auftraege = new List<ExpandedAuftrag>();
            Auftraege = datarepository.LoadAuftrageByMitarbeiterId(mitarbeiterId);
        }

        public string Title { get { return "Aufträge vom Team " + _teamBezeichnung; } }
        public List<ExpandedAuftrag> Auftraege { get; set; }
        public string Windowname { get { return "Aufträge"; } }
    }
}
