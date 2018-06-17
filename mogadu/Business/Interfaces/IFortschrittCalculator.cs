using mogadu.Database.ExpandedEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mogadu.Business.Interfaces
{
    public interface IFortschrittCalculator
    {
        int Calculate(ExpandedAuftrag auftrag);
    }
}
