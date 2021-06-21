using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bilbixen_API.Models
{
    public class ProduktModel
    {
        [JsonProperty("produktId")]
        public int produktID { get; set; }

        [JsonProperty("produktNavn")]
        public string ProduktNavn { get; set; }

        [JsonProperty("pris")]
        public double pris { get; set; }
    }
}
