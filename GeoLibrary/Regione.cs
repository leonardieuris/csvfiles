using System.Collections.Generic;

namespace GeoLibrary
{
    public class Regione : Entity
    {
        public IList<Provincia> Province { get; set; }
    }
}
