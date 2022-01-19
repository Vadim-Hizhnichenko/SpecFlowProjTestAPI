using Newtonsoft.Json;

namespace SpecFlowProject.Entity
{
    public class CodeType
    {
        [JsonProperty("code")]
        public long Code { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("message")]
        public string Message { get; set; }
    }
}
