using mogadu.Business.Interfaces;
using mogadu.Database.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mogadu.ViewModel
{
    public class AufgabenSuchenViewModel
    {
         public AufgabenSuchenViewModel(IDataRepository dataRepository, long mitarbeiterId)
        {
            Aufgaben = dataRepository.LoadAufgabenByMitarbeiterId(mitarbeiterId);      
        }
        public List<Aufgabe> Aufgaben { get; set; }
    }
}
