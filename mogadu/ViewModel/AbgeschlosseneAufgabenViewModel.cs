using mogadu.Business.Interfaces;
using mogadu.Database.ExpandedEntities;
using Prism.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace mogadu.ViewModel
{
    public class AbgeschlosseneAufgabenViewModel
    {
        public AbgeschlosseneAufgabenViewModel(IDataRepository dataRepository, long auftragId)
        {
            Aufgaben = dataRepository.LoadAllAufgabenByAuftrag(auftragId).Where(a => a.Prozentualstatus == 100).ToList();
            NavigateToMitarbeiterCommand = new DelegateCommand<object>(NavigateToMitarbeiter);
            NavigateToAufgabeDetailCommand = new DelegateCommand<object>(NavigateToAufgabeDetail);
        }

        public List<ExpandedAufgabe> Aufgaben { get; set; }

        public ICommand NavigateToMitarbeiterCommand { get; set; }
        public ICommand NavigateToAufgabeDetailCommand { get; set; }

        private void NavigateToAufgabeDetail(object aufgabenId)
        {
            MainViewModel.Application.NavigateToAufgabenDetail((long)aufgabenId);
        }

        private void NavigateToMitarbeiter(object mitarbeiterId)
        {
            MainViewModel.Application.NavigateToMitarbeiterDetail((long)mitarbeiterId);
        }
    }
}
