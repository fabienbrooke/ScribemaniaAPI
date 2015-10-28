using Owin;
using System.Web.Http;

namespace ScribemaniaAPI
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            HttpConfiguration config = new HttpConfiguration();

            WebApiConfig.Register(config);

            Indexes.Register();

            app.UseWebApi(config);
        }
    }
}
