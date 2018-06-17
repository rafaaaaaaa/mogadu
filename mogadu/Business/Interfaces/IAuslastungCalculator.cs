using mogadu.Database.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mogadu.Business.Interfaces
{
    public interface IAuslastungCalculator
    {
        int Calculate(Team team);
    }
}
