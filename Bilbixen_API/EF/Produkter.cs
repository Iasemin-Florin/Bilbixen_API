using System;
using System.Collections.Generic;

#nullable disable

namespace Bilbixen_API.EF
{
    public partial class Produkter
    {
        public Produkter()
        {
            OrdreLinjes = new HashSet<OrdreLinje>();
        }

        public int ProduktId { get; set; }
        public string ProduktNavn { get; set; }
        public double Pris { get; set; }

        public virtual ICollection<OrdreLinje> OrdreLinjes { get; set; }
    }
}
