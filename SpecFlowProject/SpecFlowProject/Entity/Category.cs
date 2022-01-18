using Newtonsoft.Json;

namespace SpecFlowProject.Entity
{
    public class Category
    {
        [JsonProperty("id")]
        public long Id { get; set; } = 2;

        [JsonProperty("name")]
        public string Name { get; set; } = "First";
    }
}
