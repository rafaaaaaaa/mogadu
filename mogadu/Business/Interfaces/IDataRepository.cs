using mogadu.Database.Entities;
using mogadu.Database.ExpandedEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mogadu.Business.Interfaces
{
    public interface IDataRepository
    {
        List<ExpandedMitarbeiter> AlleMitarbeiter { get; set; }
        List<ExpandedAuftrag> AlleAuftraege { get; set; }
        List<Aufgabe> AlleAufgaben { get; set; }
        List<ExpandedTeam> AlleTeams { get; set; }
        List<Position> AllePositionen { get; set; }
        List<Mitarbeiterlogin> AlleLogins { get; set; }

        void RefreshData();
        List<ExpandedMitarbeiter> LoadAllMitarbeiter();
        List<ExpandedAuftrag> LoadAllAuftraege();
        List<Aufgabe> LoadAllAufgaben();
        List<ExpandedTeam> LoadAllTeams();
        List<Position> LoadAllPositions();
        List<Mitarbeiterlogin> LoadAllMitarbeiterLogins();
        Mitarbeiter LoadMitarbeiterById(long id);
        List<ExpandedAuftrag> LoadAuftrageByMitarbeiterId(long id);
        ExpandedTeam LoadTeamByMitarbeiterId(long id);
        List<ExpandedMitarbeiter> LoadAllMitarbeiterOfTeamByMitarbeiterId(long id);
        Position LoadPositionById(long id);
        List<Aufgabe> LoadAufgabenByMitarbeiterId(long id);
    }
}
