using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CarVehicle.Startup))]
namespace CarVehicle
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
