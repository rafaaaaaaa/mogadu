using mogadu.Business.Interfaces;
using mogadu.Database.ExpandedEntities;
using mogadu.ViewModel.Interfaces;
using System.Collections.Generic;

namespace mogadu.ViewModel
{
    public class AuftragSuchenViewModel
    {
        public AuftragSuchenViewModel(IDataRepository datarepository, long mitarbeiterId)
        {
            Auftraege = new List<ExpandedAuftrag>();
            Auftraege = datarepository.LoadAuftrageByMitarbeiterId(mitarbeiterId);
        }

        public List<ExpandedAuftrag> Auftraege { get; set; }
    }
}
