using System;
using System.Collections.Generic;

#nullable disable

namespace Bilbixen_API.EF
{
    public partial class OrdreLinje
    {
        public int OrdreLinjeId { get; set; }
        public int Antal { get; set; }
        public int OrdreId { get; set; }
        public int ProduktId { get; set; }
        public double Price { get; set; }

        public virtual Ordre Ordre { get; set; }
        public virtual Produkter Produkt { get; set; }
    }
}
