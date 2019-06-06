using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(AutoTest.Startup))]
namespace AutoTest
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
