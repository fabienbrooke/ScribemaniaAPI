using MongoRepository;
using ScribemaniaAPI.Models;
using ScribemaniaAPI.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace ScribemaniaAPI.Controllers
{
    public class GenresController : ApiController
    {
        private const int DEFAULT_RESULT_LIMIT = 50;

        private IRepository<Story> stories;


        public GenresController()
        {
            stories = new Stories();
        }

        public GenresController(IRepository<Story> repository)
        {
            stories = repository;
        }


        public IEnumerable<string> GetTopGenres()
        {
            return stories
                .GroupBy(story => story.Genre, (key, group) => new { Genre = key, Count = group.Count() })
                .OrderByDescending(group => group.Count)
                .Take(DEFAULT_RESULT_LIMIT)
                .Select(group => group.Genre);
        }

        [Route("genres/{genre}/stories")]
        public IEnumerable<Story> GetStoriesByGenre(string genre)
        {
            return stories.Where(story => story.Genre == genre);
        }
    }
}
