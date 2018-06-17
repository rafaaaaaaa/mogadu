using mogadu.Business.Interfaces;
using mogadu.ViewModel.Interfaces;
using mogadu.Views.Suche;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI;

namespace mogadu.ViewModel
{
    public class SucheViewModel : IWindow
    {
        public SucheViewModel(IDataRepository dataRepository, long mitarbeiterId)
        {
            PersonenSucheUserControl = new PersonenSucheUserControl(dataRepository, mitarbeiterId);
            AuftragSucheUserControl = new AuftragSucheUserControl(dataRepository, mitarbeiterId);
            AufgabenSucheUserControl = new AufgabeSucheUserControl(dataRepository, mitarbeiterId);
        }
        public string Windowname { get { return "Suche"; } }

        public PersonenSucheUserControl PersonenSucheUserControl { get; set; }
        public AuftragSucheUserControl AuftragSucheUserControl { get; set; }
        public AufgabeSucheUserControl AufgabenSucheUserControl { get; set; }
    }
}
