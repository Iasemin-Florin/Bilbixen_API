using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bilbixen_API.Models
{
    public class OrdreLinjeModel
    {
        [JsonProperty("ordreLinjeId")]
        public int OrdreLinjeID { get; set; }

        [JsonProperty("produktId")]
        public int ProduktID { get; set; }

        [JsonProperty("antal")]
        public int Antal { get; set; }

        [JsonProperty("pris")]
        public double Pris { get; set; }

        [JsonProperty("ordreId")]
        public int OrdreID { get; set; }
    }
}
