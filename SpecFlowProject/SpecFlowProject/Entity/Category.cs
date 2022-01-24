﻿using Newtonsoft.Json;

namespace SpecFlowProject.Entity
{
    public class Category
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; } 
    }
}
