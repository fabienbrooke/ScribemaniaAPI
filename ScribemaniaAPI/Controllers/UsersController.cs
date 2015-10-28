using MongoRepository;
using ScribemaniaAPI.Filters;
using ScribemaniaAPI.Models;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Web.Http;

namespace ScribemaniaAPI.Controllers
{
    public class UsersController : ApiController
    {
        private IRepository<User> users;


        public UsersController()
        {
            users = new MongoRepository<User>();
        }

        public UsersController(IRepository<User> repository)
        {
            users = repository;
        }


        [HttpGet]
        public IEnumerable<User> SearchUsersByName(string partialName)
        {
            return users.Where(user => user.DisplayName.Contains(partialName));
        }

        [NullNotFound]
        public User Get(string id)
        {
            try
            {
                new MailAddress(id);
                return users.FirstOrDefault(user => user.Email == id);
            }
            catch
            {
                var user = users.GetById(id);
                return user;
            }
        }

        public IHttpActionResult Post(User user)
        {
            user = users.Add(user);
            return CreatedAtRoute<User>("DefaultApi", new { controller = "users", id = user.Id }, user);
        }
    }
}
