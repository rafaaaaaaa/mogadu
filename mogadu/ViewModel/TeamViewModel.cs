using mogadu.Business;
using mogadu.Business.Interfaces;
using mogadu.Database.Entities;
using mogadu.Database.ExpandedEntities;
using mogadu.ViewModel.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace mogadu.ViewModel
{
    public class TeamViewModel : IWindow
    {
        public TeamViewModel(IDataRepository repository, long id)
        {
            Mitarbeiterliste = repository.LoadAllMitarbeiterOfTeamByMitarbeiterId(id);
            Team = repository.LoadTeamByMitarbeiterId(id);
        }
        public string Windowname { get { return "Team"; } }

        public List<ExpandedMitarbeiter> Mitarbeiterliste {get; set;}

        public ExpandedTeam Team { get; set; }
    }
}
