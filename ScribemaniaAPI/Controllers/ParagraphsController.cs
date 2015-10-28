using ScribemaniaAPI.Filters;
using ScribemaniaAPI.Models;
using ScribemaniaAPI.Collections;
using System.Linq;
using System.Net;
using System.Web.Http;

namespace ScribemaniaAPI.Controllers
{
    public class ParagraphsController : ApiController
    {
        private IStories stories;


        public ParagraphsController()
        {
            stories = new Stories();
        }

        public ParagraphsController(IStories repository)
        {
            stories = repository;
        }


        [NullNotFound]
        [Route("stories/{storyId}/paragraphs/{paragraphId}")]
        public Paragraph Get(string storyId, string paragraphId)
        {
            return stories.GetById(storyId).Paragraphs.FirstOrDefault(p => p.Id == paragraphId);
        }

        [NullNotFound]
        [Route("stories/{storyId}/paragraphs")]
        public IHttpActionResult Post(Paragraph paragraph)
        {
            var story = stories.AddParagraph(paragraph.StoryId, paragraph);

            if (story == null)
            {
                return null;
            }

            return StatusCode(HttpStatusCode.NoContent);
        }
    }
}
