using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(LogisticSolutions.Startup))]
namespace LogisticSolutions
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
