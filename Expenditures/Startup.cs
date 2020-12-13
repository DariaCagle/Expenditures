using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Expenditures.Startup))]
namespace Expenditures
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
