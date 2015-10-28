using MongoRepository;
using ScribemaniaAPI.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace ScribemaniaAPI.Controllers
{
    public class GroupsController : ApiController
    {
        private const int DEFAULT_RESULT_LIMIT = 50;

        private IRepository<Group> groups;

        public GroupsController()
        {
            groups = new MongoRepository<Group>();
        }

        public GroupsController(IRepository<Group> repository)
        {
            groups = repository;
        }

        public Group Get(string id)
        {
            return groups.GetById(id);
        }

        public IHttpActionResult Post(Group group)
        {
            group = groups.Add(group);
            return CreatedAtRoute<Group>("DefaultApi", new { controller = "groups", id = group.Id }, group);
        }

        [Route("users/{userId}/groups")]
        public IEnumerable<Group> GetGroupsByUser(string userId)
        {
            return groups.Where(group => group.MemberIds.Contains(userId)).Take(DEFAULT_RESULT_LIMIT);
        }
    }
}
