using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bilbixen_API.Models
{
    public class OrdreModel
    {
        [JsonProperty("ordreId")]
        public int OrdreID { get; set; }

        [JsonProperty("brugerId")]
        public int BrugerID { get; set; }

        [JsonProperty("ordreDato")]
        public DateTime OrdreDato { get; set; }

        [JsonProperty("lejeDato")]
        public DateTime LejeDato { get; set; }

        [JsonProperty("totalPris")]
        public double TotalPris { get; set; }
    }
}
