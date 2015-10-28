using MongoRepository;
using Newtonsoft.Json;
using System;

namespace ScribemaniaAPI.Models
{
    [JsonObject(MemberSerialization.OptOut)]
    public class Paragraph : Entity
    {
        public Paragraph()
        {
            CreatedDate = DateTime.UtcNow;
        }

        public string Text { get; set; }
        public string AuthorId { get; set; }
        public string AuthorName { get; set; }
        public string StoryId { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}