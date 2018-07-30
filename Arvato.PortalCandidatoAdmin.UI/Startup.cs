using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Arvato.PortalCandidatoAdmin.UI.Startup))]
namespace Arvato.PortalCandidatoAdmin.UI
{
    public partial class Startup
    {

        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }

}
