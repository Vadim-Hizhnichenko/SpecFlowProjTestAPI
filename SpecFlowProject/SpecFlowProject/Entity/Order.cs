using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace SpecFlowProject.Entity
{
    public class Order
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("petId")]
        public long PetId { get; set; }

        [JsonProperty("quantity")]
        public long Quantity { get; set; }

        [JsonProperty("shipDate")]
        public DateTime ShipDate { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("complete")]
        public bool Complete { get; set; }
    }
}
