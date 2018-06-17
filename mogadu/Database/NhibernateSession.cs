using NHibernate;
using NHibernate.Cfg;
using System.IO;
namespace mogadu.Database
{
    public class NhibernateSession
    {        public static ISession OpenSession()
        {
            var configuration = new Configuration();
            configuration.Configure(GetExactPath(@"Database/hibernate.cfg.xml"));
            
            var mitarbeiterconfigfile = GetExactPath(@"Database/Mappings/Mitarbeiter.hbm.xml");
            var mitarbeiterloginconfigfile = GetExactPath(@"Database/Mappings/Mitarbeiterlogin.hbm.xml");  
            var positionconfigfile = GetExactPath(@"Database/Mappings/Position.hbm.xml");
            var teamconfigfile = GetExactPath(@"Database/Mappings/Team.hbm.xml"); 
            var auftragconfigfile = GetExactPath(@"Database/Mappings/Auftrag.hbm.xml"); 
            var aufgabenconfigfile = GetExactPath(@"Database/Mappings/Aufgabe.hbm.xml");
            configuration
                .AddFile(mitarbeiterconfigfile)
                .AddFile(mitarbeiterloginconfigfile)
                .AddFile(positionconfigfile)
                .AddFile(teamconfigfile)
                .AddFile(auftragconfigfile)
                .AddFile(aufgabenconfigfile);

            ISessionFactory sessionFactory = configuration.BuildSessionFactory();
            return sessionFactory.OpenSession();
        }

        private static string GetExactPath(string relativePath)
        {
            string exactPath = Path.GetFullPath(relativePath);
            exactPath = exactPath.Replace("bin\\Debug\\", "");
            return exactPath;
        }
    }    
}
