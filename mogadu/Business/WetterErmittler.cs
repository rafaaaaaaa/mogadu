using mogadu.Business.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mogadu.Business
{
    public class WetterErmittler : IWetterErmittler
    {
        public int ErmittleWetter()
        {
            Random rnd = new Random();
            int randomZahl = rnd.Next(0, 2);
            return randomZahl;
        }
    }
}
