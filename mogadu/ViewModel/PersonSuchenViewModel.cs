using mogadu.Business.Interfaces;
using mogadu.Database.Entities;
using mogadu.Database.ExpandedEntities;
using mogadu.ViewModel.Interfaces;
using System.Collections.Generic;

namespace mogadu.ViewModel
{
    public class PersonSuchenViewModel 
    {
        public PersonSuchenViewModel(IDataRepository datarepository, long mitarbeiterId)
        {
            Teams = datarepository.AlleTeams;
        }

        public List<ExpandedTeam> Teams { get; set; }
    } 
}
