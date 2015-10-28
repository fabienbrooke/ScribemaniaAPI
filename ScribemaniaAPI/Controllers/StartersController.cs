using ScribemaniaAPI.Starters;
using System.Web.Http;

namespace ScribemaniaAPI.Controllers
{
    public class StartersController : ApiController
    {
        // id represents the language but only english is supported
        public string Get(string id)
        {
            return EnglishStarters.Generate();
        }
    }
}
