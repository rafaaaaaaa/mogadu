using mogadu.Business.Interfaces;
using mogadu.Database.ExpandedEntities;
using mogadu.ViewModel.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mogadu.ViewModel
{
    public class MitarbeiterDetailViewModel : IWindow
    {
        public MitarbeiterDetailViewModel(IDataRepository dataRepository, long mitarbeiterId)
        {
            Mitarbeiter = dataRepository.LoadMitarbeiterById(mitarbeiterId);
        }

        public ExpandedMitarbeiter Mitarbeiter { get; set; }

        public string Windowname => "Mitarbeiter: " + Mitarbeiter.FullName;
    }
}
