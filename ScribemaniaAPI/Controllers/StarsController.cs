using MongoRepository;
using ScribemaniaAPI.Models;
using ScribemaniaAPI.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Http;
using ScribemaniaAPI.Filters;

namespace ScribemaniaAPI.Controllers
{
    public class StarsController : ApiController
    {
        private IRepository<Story> stories;
        private IUsers users;


        public StarsController()
        {
            stories = new MongoRepository<Story>();
            users = new Users();
        }

        public StarsController(IRepository<Story> storiesRepository, IUsers usersRepository)
        {
            stories = storiesRepository;
            users = usersRepository;
        }


        [Route("users/{userId}/starred")]
        public IEnumerable<Story> GetStoriesStarredByUser(string userId)
        {
            return stories.Where(story => story.StarredBy.Contains(userId));
        }

        [NullNotFound]
        [Route("stories/{storyId}/stars/{userId}")]
        public IHttpActionResult PutStar(string storyId, string userId)
        {
            var story = users.FavoriteStory(userId, storyId);

            if (story == null)
            {
                return null;
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        [Route("stories/{storyId}/stars/{userId}")]
        public IHttpActionResult DeleteStar(string storyId, string userId)
        {
            users.UnfavoriteStory(userId, storyId);
            return StatusCode(HttpStatusCode.NoContent);
        }
    }
}
