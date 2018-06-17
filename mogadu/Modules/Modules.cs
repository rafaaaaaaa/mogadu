using Autofac;
using mogadu.Business;
using mogadu.Business.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mogadu.Modules
{
    public class Modules : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            base.Load(builder);
            var assembly = GetType().Assembly;

            builder.RegisterType<DataRepository>().As<IDataRepository>();
        }
    }    
}
