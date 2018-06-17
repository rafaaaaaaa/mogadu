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
    public class TeamTileViewModel 
    {
        
        public TeamTileViewModel(IDataRepository dataRepository, long mitarbeiterId)
        {
            Team = dataRepository.LoadTeamByMitarbeiterId(mitarbeiterId);
        }
        public ICommand GoToDetailsCommand { get; set; }
        public Team Team { get; set; }
    }
}
