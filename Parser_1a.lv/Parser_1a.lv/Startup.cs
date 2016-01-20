using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Parser_1a.lv.Startup))]
namespace Parser_1a.lv
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
