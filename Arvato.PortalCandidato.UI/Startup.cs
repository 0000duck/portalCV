using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Arvato.PortalCandidato.UI.Startup))]
namespace Arvato.PortalCandidato.UI
{
    public partial class Startup
    {

        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }

}
