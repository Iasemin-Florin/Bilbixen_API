using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bilbixen_API.Models
{
    public class BrugerModel
    {
        [JsonProperty("brugerID")]
        public int BrugerID { get; set; }

        [JsonProperty("fNavn")]
        public string Fnavn { get; set; }

        [JsonProperty("eEavn")]
        public string Enavn { get; set; }

        [JsonProperty("tlfNr")]
        public string TlfNR { get; set; }

        [JsonProperty("email")]
        public string Email { get; set; }

        [JsonProperty("password")]
        public string Password { get; set; }

        [JsonProperty("adresse")]
        public string Adresse { get; set; }

        [JsonProperty("postNr")]
        public int PostNR { get; set; }

        [JsonProperty("admin")]
        public bool Admin { get; set; }
    }
}
