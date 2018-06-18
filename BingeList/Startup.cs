using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(BingeList.Startup))]
namespace BingeList
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
