using Newtonsoft.Json;
using System.Collections.Generic;

namespace SpecFlowProject.Entity
{
    public class Pet
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("category")]
        public Category Category { get; set; } = new Category();

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("photoUrls")]
        public List<string> PhotoUrls { get; set; } = new List<string>();

        [JsonProperty("tags")]
        public List<Category> Tags { get; set; } = new List<Category>();

        [JsonProperty("status")]
        public string Status { get; set; }
    }
}
