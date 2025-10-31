using System;
using Newtonsoft.Json;

namespace webapiLearn.Models
{
    public class Carrier
    {
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string CarrierCode { get; set; }
        public long BSSNetworkId { get; set; }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string Name { get; set; }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string VendorName { get; set; }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string URL { get; set; }
    }
}