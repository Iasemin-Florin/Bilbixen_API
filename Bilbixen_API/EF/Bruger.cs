using System;
using System.Collections.Generic;

#nullable disable

namespace Bilbixen_API.EF
{
    public partial class Bruger
    {
        public int BrugerId { get; set; }
        public string FNavn { get; set; }
        public string ENavn { get; set; }
        public string TlfNr { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Adresse { get; set; }
        public int PostNr { get; set; }
        public bool Admin { get; set; }

        public virtual PostNr PostNrNavigation { get; set; }
    }
}
