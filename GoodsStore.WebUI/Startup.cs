using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(GoodsStore.WebUI.Startup))]
namespace GoodsStore.WebUI
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
