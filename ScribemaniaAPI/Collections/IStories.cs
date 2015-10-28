using MongoRepository;
using ScribemaniaAPI.Models;

namespace ScribemaniaAPI.Collections
{
    public interface IStories : IRepository<Story>
    {
        Story AddParagraph(string id, Paragraph paragraph);

        Story AddFavorite(string storyId, string userId);

        Story RemoveFavorite(string storyId, string userId);
    }
}
