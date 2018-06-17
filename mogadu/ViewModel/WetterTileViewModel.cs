using mogadu.Business.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mogadu.ViewModel
{
    public class WetterTileViewModel
    {
        public WetterTileViewModel(IWetterErmittler wetterErmittler)
        {
            Wetterstatus = wetterErmittler.ErmittleWetter();           
        }

        public int Wetterstatus { get; set; }
    }
}
