using System;
using System.Collections.Generic;

#nullable disable

namespace Bilbixen_API.EF
{
    public partial class Ordre
    {
        public Ordre()
        {
            OrdreLinjes = new HashSet<OrdreLinje>();
        }

        public int OrdreId { get; set; }
        public int BrugerId { get; set; }
        public DateTime OrdreDato { get; set; }
        public DateTime LejeDato { get; set; }
        public double TotalPris { get; set; }

        public virtual ICollection<OrdreLinje> OrdreLinjes { get; set; }
    }
}
