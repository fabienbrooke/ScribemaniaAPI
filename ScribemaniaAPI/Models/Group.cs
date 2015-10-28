using MongoRepository;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace ScribemaniaAPI.Models
{
    [JsonObject(MemberSerialization.OptOut)]
    public class Group : Entity
    {
        public Group()
        {
            CreatedDate = DateTime.UtcNow;
        }

        public bool WritePrivate { get; set; }
        public string Name { get; set; }
        public string Slug { get; set; }
        public string Description { get; set; }
        public IEnumerable<string> MemberIds { get; set; }
        public DateTime CreatedDate { get; set; }
        public string CreatorId { get; set; }
        public IEnumerable<string> StoryIds { get; set; }
    }
}