using MongoRepository;
using ScribemaniaAPI.Filters;
using ScribemaniaAPI.Models;
using ScribemaniaAPI.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace ScribeAPI.Controllers
{
    public class StoriesController : ApiController
    {
        private const int DEFAULT_RESULT_LIMIT = 50;

        private IRepository<Story> stories;

        public StoriesController()
        {
            stories = new Stories();
        }

        public StoriesController(IRepository<Story> repository)
        {
            stories = repository;
        }


        public IEnumerable<Story> Get()
        {
            return stories.OrderByDescending(x => x.CreatedDate).Take(DEFAULT_RESULT_LIMIT);
        }

        [NullNotFound]
        public Story Get(string id)
        {
            return stories.FirstOrDefault(x => x.Slug == id);
        }

        public IHttpActionResult Post(Story story)
        {
            story = stories.Add(story);
            return CreatedAtRoute<Story>("DefaultApi", new { controller = "stories", id = story.Id }, story);
        }

        public void Delete(string id)
        {
            stories.Delete(id);
        }

        [Route("users/{userId}/stories")]
        public IEnumerable<Story> GetStoriesByUser(string userId)
        {
            return stories.Where(story => story.CreatorId == userId).Take(DEFAULT_RESULT_LIMIT);
        }
    }
}
