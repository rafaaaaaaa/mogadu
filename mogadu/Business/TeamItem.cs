using mogadu.Database.Entities;
using mogadu.Database.ExpandedEntities;
using Prism.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace mogadu.Business
{
    public class TeamItem
    {
        public TeamItem(ExpandedTeam team) 
        {
            Team = team;
            GoToDetailsCommand = new DelegateCommand<object>(GoToDetails);

        }
       public ExpandedTeam Team { get; set; }
       public ICommand GoToDetailsCommand { get; set; }

        private void GoToDetails(object o)
        {

        }
    }
}
