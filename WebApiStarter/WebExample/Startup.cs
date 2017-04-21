using System;
using System.Threading.Tasks;
using Microsoft.Owin;
using Owin;
using WebExample.App_Start;

[assembly: OwinStartup(typeof(WebExample.Startup))]

namespace WebExample
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            // For more information on how to configure your application, visit http://go.microsoft.com/fwlink/?LinkID=316888
            //DIServiceConfig.Register();
        }
    }
}
