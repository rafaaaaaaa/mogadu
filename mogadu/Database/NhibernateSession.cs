using NHibernate;
using NHibernate.Cfg;
using System.IO;
using System.Web;
using System.Web.Hosting;

namespace mogadu.Database
{
    public class NhibernateSession
    {        public static ISession OpenSession()
        {
            var configuration = new Configuration();
            string exactPath = Path.GetFullPath("~/Database/hibernate.cfg.xml");
            exactPath = "C:\\Users\\vmadmin\\documents\\visual studio 2017\\Projects\\mogadu\\mogadu\\Database\\hibernate.cfg.xml";
            configuration.Configure(exactPath);
           // var assignmentconfigfile = HttpContext.Current.Server.MapPath(@"\Database\Mappings\Mitarbeiter.hbm.xml");
            var mitarbeiterconfigfile = "C:\\Users\\vmadmin\\documents\\visual studio 2017\\Projects\\mogadu\\mogadu\\Database\\Mappings\\Mitarbeiter.hbm.xml";
            var mitarbeiterloginconfigfile = "C:\\Users\\vmadmin\\documents\\visual studio 2017\\Projects\\mogadu\\mogadu\\Database\\Mappings\\Mitarbeiterlogin.hbm.xml";
            var positionconfigfile = "C:\\Users\\vmadmin\\documents\\visual studio 2017\\Projects\\mogadu\\mogadu\\Database\\Mappings\\Position.hbm.xml";
            var teamconfigfile = "C:\\Users\\vmadmin\\documents\\visual studio 2017\\Projects\\mogadu\\mogadu\\Database\\Mappings\\Team.hbm.xml";
            var auftragconfigfile = "C:\\Users\\vmadmin\\documents\\visual studio 2017\\Projects\\mogadu\\mogadu\\Database\\Mappings\\Auftrag.hbm.xml";
            var aufgabenconfigfile = "C:\\Users\\vmadmin\\documents\\visual studio 2017\\Projects\\mogadu\\mogadu\\Database\\Mappings\\Aufgabe.hbm.xml";
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
    }    
}
