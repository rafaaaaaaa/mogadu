using mogadu.Business.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using mogadu.Database.Entities;

namespace mogadu.Business
{
    public class AuslastungCalculator : IAuslastungCalculator
    {
        private IDataRepository _dataRepository;
        public AuslastungCalculator(IDataRepository dataRepository)
        {
           // _dataRepository = dataRepository;
        }

        public int Calculate(Team team)
        {
            // var aufgaben = _dataRepository.LoadAufgabenByMitarbeiterId(team.TeamleiterId);

            // int? aufgabenprozentual = 0;

            // foreach(var aufgabe in aufgaben)
            //  {
            //    aufgabenprozentual += aufgabe.Prozentualstatus;
            //  }
            //  aufgabenprozentual /= aufgaben.Count();

            //  return 100 - aufgabenprozentual.Value;
            return 10;
        }
    }
}
