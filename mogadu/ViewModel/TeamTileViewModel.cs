using mogadu.Business;
using mogadu.Business.Interfaces;
using mogadu.Database.Entities;
using mogadu.Database.ExpandedEntities;
using mogadu.ViewModel.Interfaces;
using Prism.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace mogadu.ViewModel
{
    public class TeamTileViewModel : IWindow
    {
        
        public TeamTileViewModel(IDataRepository dataRepository, long mitarbeiterId)
        {
            Teams = new List<TeamItem>();
            var teams = dataRepository.AlleTeams;
            foreach (var team in teams)
            {
                Teams.Add(new TeamItem(team));
            }
        }
        public ICommand GoToDetailsCommand { get; set; }
        public List<TeamItem> Teams { get; set; }
        public string Windowname { get { return "Team"; } }

        private void GoToDetails(object teamId)
        {

        }
    }
}
