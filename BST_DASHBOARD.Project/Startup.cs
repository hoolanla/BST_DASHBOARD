using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(BST_DASHBOARD.Project.Startup))]
namespace BST_DASHBOARD.Project
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
