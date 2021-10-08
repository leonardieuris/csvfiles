using System.Collections.Generic;

namespace GeoLibrary
{
    public class Provincia : Entity
    {
        public string Targa { get; set; }
        public IList<Comune> Comuni {get;set;}
    }
}
