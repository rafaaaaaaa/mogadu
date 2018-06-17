using mogadu.Business.Interfaces;
using mogadu.Database.ExpandedEntities;
using mogadu.ViewModel.Interfaces;
using mogadu.Views.Aufgaben;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mogadu.ViewModel
{
    public class AuftragDetailViewModel : IWindow
    {
        public AuftragDetailViewModel(IDataRepository dataRepository, long auftragId)
        {
            OffeneAufgabeUserControl = new OffeneAufgabenUserControl(dataRepository, auftragId);
            AbgeschlosseneAufgabenUserControl = new AbgeschlosseneAufgabenUserControl(dataRepository, auftragId);
            Auftrag = dataRepository.LoadAuftragByAuftragId(auftragId);
        }

        public ExpandedAuftrag Auftrag { get; set; }

        public string Windowname => "Auftrag: " + Auftrag.Auftragname;

        public OffeneAufgabenUserControl OffeneAufgabeUserControl { get; set; }

        public AbgeschlosseneAufgabenUserControl AbgeschlosseneAufgabenUserControl { get; set; }
    }
}
