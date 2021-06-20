using System;
using System.Collections.Generic;

#nullable disable

namespace Bilbixen_API.EF
{
    public partial class PostNr
    {
        public PostNr()
        {
            Brugers = new HashSet<Bruger>();
        }

        public int PostNr1 { get; set; }
        public string PostBy { get; set; }

        public virtual ICollection<Bruger> Brugers { get; set; }
    }
}
