using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(OrderEntry.Startup))]
namespace OrderEntry
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
