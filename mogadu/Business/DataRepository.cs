using mogadu.Business.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using mogadu.Database.Entities;
using mogadu.Database;
using NHibernate;
using mogadu.Database.ExpandedEntities;
using NHibernate.SqlCommand;

namespace mogadu.Business
{
    public class DataRepository : IDataRepository
    {
        private IAuslastungCalculator _auslastungsCalculator { get; set; }
        private IFortschrittCalculator _fortschrittCalculator { get; set; }
        public List<ExpandedMitarbeiter> AlleMitarbeiter { get; set; }
        public List<ExpandedAuftrag> AlleAuftraege { get; set; }
        public List<ExpandedAufgabe> AlleAufgaben { get; set; }
        public List<ExpandedTeam> AlleTeams { get; set; }
        public List<Position> AllePositionen { get; set; }
        public List<Mitarbeiterlogin> AlleLogins { get; set; }

        public DataRepository()
        {
            _fortschrittCalculator = new FortschrittCalculator();
            _auslastungsCalculator = new AuslastungCalculator(this);
            RefreshData();
        }

        public void RefreshData()
        {
            AllePositionen = LoadAllPositions();
            AlleLogins = LoadAllMitarbeiterLogins();
            AlleMitarbeiter = LoadAllMitarbeiter();
            AlleAufgaben = LoadAllAufgaben();
            AlleAuftraege = LoadAllAuftraege();
            AlleTeams = LoadAllTeams();
            RefillTeams();
            RefillAuftrag(); 
        }

        //LOAD ALL
        public List<ExpandedMitarbeiter> LoadAllMitarbeiter()
        {
            List<Mitarbeiter> mitarbeiter = null;
            using (ISession session = NhibernateSession.OpenSession())
            {
                mitarbeiter = session.Query<Mitarbeiter>().ToList();
            }

            return mitarbeiter.Select(CreateExpandedMitarbeiter).ToList();
        }
        public List<ExpandedAuftrag> LoadAllAuftraege()
        {
            List<Auftrag> auftraege = null;
            using (ISession session = NhibernateSession.OpenSession())
            {
                auftraege = session.Query<Auftrag>().ToList();
            }

            return auftraege.Select(CreateExpandedAuftrag).ToList();
        }
        public List<ExpandedAufgabe> LoadAllAufgaben()
        {
            List<Aufgabe> aufgaben = null;
            using (ISession session = NhibernateSession.OpenSession())
            {
                aufgaben = session.Query<Aufgabe>().ToList();
            }

            return aufgaben.Select(CreateExpandedAufgabe).ToList();
        }
        public List<ExpandedTeam> LoadAllTeams()
        {
            List<Team> teams = null;
            using (ISession session = NhibernateSession.OpenSession())
            {
                teams = session.Query<Team>().ToList();
            }

            return teams.Select(CreateExpandedTeam).ToList(); 
        }
        public List<Position> LoadAllPositions()
        {
            List<Position> positions = null;
            using (ISession session = NhibernateSession.OpenSession())
            {
                positions = session.Query<Position>().ToList();
            }

            return positions;
        }
        public List<Mitarbeiterlogin> LoadAllMitarbeiterLogins()
        {
            List<Mitarbeiterlogin> mitarbeiterlogins = null;
            using (ISession session = NhibernateSession.OpenSession())
            {
                mitarbeiterlogins = session.Query<Mitarbeiterlogin>().ToList();
            }

            return mitarbeiterlogins;
        }

        //SERVICEFUNCTIONS
        public ExpandedMitarbeiter LoadMitarbeiterById(long id)
        {
            return AlleMitarbeiter.Where(m => m.MitarbeiterId == id).First();
        }
        public List<ExpandedAuftrag> LoadAuftrageByMitarbeiterId(long id)
        {
            var mitarbeiter = AlleMitarbeiter.Where(m => m.MitarbeiterId == id).First();
            var team = AlleTeams.Where(t => t.TeamId == mitarbeiter.TeamId).First();
            return AlleAuftraege.Where(a => a.TeamId == team.TeamId).ToList();
        }
        public ExpandedTeam LoadTeamByMitarbeiterId(long id)
        {
          var mitarbeiter = AlleMitarbeiter.Where(m => m.MitarbeiterId == id).First();
          return AlleTeams.Where(t => t.TeamId == mitarbeiter.TeamId).First();
        }
        public List<ExpandedMitarbeiter> LoadAllMitarbeiterOfTeamByMitarbeiterId(long id)
        {
            var mitarbeiter = AlleMitarbeiter.Where(m => m.MitarbeiterId == id).First();
            return AlleMitarbeiter.Where(m => m.Team == mitarbeiter.Team).ToList();;
        }
        public Position LoadPositionById(long id)
        {
            return AllePositionen.Where(p => p.PositionsId == id).First();
        }
        public List<Aufgabe> LoadAufgabenByMitarbeiterId(long id)
        {             
            var mitarbeiter = AlleMitarbeiter.Where(m => m.MitarbeiterId == id).First();
            if (AlleTeams != null)
            {
                var team = AlleTeams.Where(t => t.TeamId == mitarbeiter.TeamId).First();
                var auftraege = AlleAuftraege.Where(a => a.TeamId == team.TeamId);

                List<Aufgabe> aufgaben = new List<Aufgabe>();
                foreach (var auftrag in auftraege)
                {
                    aufgaben.AddRange(auftrag.Aufgaben);
                }

                return aufgaben;
            }
            return null;
        }
        public ExpandedMitarbeiter LoadMitarbeiterByTeamId(long id)
        {
            return AlleMitarbeiter.Where(m => m.TeamId == id).First();
        }
        public ExpandedAuftrag LoadAuftragByAuftragId(long id)
        {
            return AlleAuftraege.Where(a => a.AuftragId == id).First();
        }
        public List<ExpandedAufgabe> LoadAllAufgabenByAuftrag(long id)
        {
            return AlleAufgaben.Where(a => a.AuftragId == id).ToList();
        }

        public void SafeAufgabe(ExpandedAufgabe aufgabe)
        {
            Aufgabe updatedAufgabe = new Aufgabe
            {
                Aufgabenbeschreibung = aufgabe.Aufgabenbeschreibung,
                AufgabenId = aufgabe.AufgabenId,
                Aufgabenname = aufgabe.Aufgabenname,
                AuftragId = aufgabe.AuftragId,
                MitarbeiterId = aufgabe.MitarbeiterId,
                Prozentualstatus = aufgabe.Prozentualstatus
            };  

            using (ISession session = NhibernateSession.OpenSession())
            {
                using (ITransaction transaction = session.BeginTransaction())
                {
                    session.Update(updatedAufgabe); 
                    transaction.Commit();
                }
            }
        }

        public void SafeAuftrag(ExpandedAuftrag auftrag)
        {
            Auftrag updatedAuftrag = new Auftrag
            {
                AuftragId = auftrag.AuftragId,
                Auftragname = auftrag.Auftragname,
                ErstellDatum = auftrag.ErstellDatum,
                FinishDatum = DateTime.Today,
                Priorität = auftrag.Priorität,
                TeamId = auftrag.TeamId   
            };

            using (ISession session = NhibernateSession.OpenSession())
            {
                using (ITransaction transaction = session.BeginTransaction())
                {
                    session.Update(updatedAuftrag); 
                    transaction.Commit();
                }
            }
        }


        public ExpandedAufgabe LoadAufgabeByAufgabenId(long id)
        {
            return AlleAufgaben.Where(a => a.AufgabenId == id).First();
        }

        //EXPANDED CREATORS
        private ExpandedMitarbeiter CreateExpandedMitarbeiter(Mitarbeiter mitarbeiter)
        {
            var position = LoadPositionById(mitarbeiter.PositionId);
            return new ExpandedMitarbeiter()
            {
                MitarbeiterId = mitarbeiter.MitarbeiterId,
                Vorname = mitarbeiter.Vorname,
                Name = mitarbeiter.Name,
                Eintrittsdatum = mitarbeiter.Eintrittsdatum,
                Position = position,
                IsMale = mitarbeiter.IsMale,
                PositionId = mitarbeiter.PositionId,                
                TeamId = mitarbeiter.TeamId                
            };
        }
        private ExpandedTeam CreateExpandedTeam(Team team)
        {
            var teammitglieder = LoadAllMitarbeiterOfTeamByMitarbeiterId(team.TeamleiterId);  
            var teamleiter = teammitglieder.Where(x => x.MitarbeiterId == team.TeamleiterId).First();

            return new ExpandedTeam(_auslastungsCalculator)
            {
                Teammitglieder = teammitglieder,
                AnzahlMitarbeiter = teammitglieder.Count,
                Teambezeichnung = team.Teambezeichnung,
                TeamId = team.TeamId,
                TeamleiterId = team.TeamleiterId,
                Teamleiter = CreateExpandedMitarbeiter(teamleiter)          
            };
        }
        private ExpandedAuftrag CreateExpandedAuftrag(Auftrag auftrag)
        {
            List<ExpandedAufgabe> aufgaben = null;
            List<ExpandedAuftrag> expandedAuftraege = new List<ExpandedAuftrag>();
            
             aufgaben = AlleAufgaben.Where(a => a.AuftragId == auftrag.AuftragId).ToList();
            

            return new ExpandedAuftrag(_fortschrittCalculator)
            {
                AuftragId = auftrag.AuftragId,
                Auftragname = auftrag.Auftragname,
                ErstellDatum = auftrag.ErstellDatum,
                FinishDatum = auftrag.FinishDatum ?? null,
                Priorität = auftrag.Priorität,
                TeamId = auftrag.TeamId,
                Aufgaben = aufgaben
            };
        }        
        private ExpandedAufgabe CreateExpandedAufgabe(Aufgabe aufgabe)
        {
            return new ExpandedAufgabe
            {
                Aufgabenbeschreibung = aufgabe.Aufgabenbeschreibung,
                AufgabenId = aufgabe.AufgabenId,
                Aufgabenname = aufgabe.Aufgabenname,
                AuftragId = aufgabe.AuftragId,
                Mitarbeiter = AlleMitarbeiter.Where(m => m.MitarbeiterId == aufgabe.MitarbeiterId).First(),
                MitarbeiterId = aufgabe.MitarbeiterId,
                Prozentualstatus = aufgabe.Prozentualstatus
            };
        }
        private void RefillTeams()
        {
            foreach(var mitarbeiter in AlleMitarbeiter)
            {
                mitarbeiter.Team = AlleTeams.Where(t => t.TeamId == mitarbeiter.TeamId).First();
            }

            foreach (var auftrag in AlleAuftraege)
            {
                auftrag.Team = AlleTeams.Where(x => x.TeamId == auftrag.TeamId).First();
            }  
        }

        private void RefillAuftrag()
        {
            foreach(var aufgabe in AlleAufgaben)
            {
                aufgabe.Auftrag = AlleAuftraege.Where(a => a.AuftragId == aufgabe.AuftragId).First();
            }
        }
    }

}
