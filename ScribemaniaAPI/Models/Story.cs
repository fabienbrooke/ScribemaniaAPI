using MongoRepository;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ScribemaniaAPI.Models
{
    [JsonObject(MemberSerialization.OptOut)]
    public class Story : Entity
    {
        public Story()
        {
            CreatedDate = DateTime.UtcNow;
            StarredBy = Enumerable.Empty<string>();
            Paragraphs = Enumerable.Empty<Paragraph>();
        }

        public string Title { get; set; }
        public string Slug { get; set; }
        public IEnumerable<Paragraph> Paragraphs { get; set; }
        public IEnumerable<string> StarredBy { get; set; }
        public string GroupId { get; set; }
        public string Genre { get; set; }
        public DateTime CreatedDate { get; set; }
        public string CreatorId { get; set; }
        public string CreatorName { get; set; }
    }
}