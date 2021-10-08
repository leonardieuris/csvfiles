using CSVHandler;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace GeoLibrary
{
    public class Stato
    {
        private readonly IEnumerable<GeoCSV> ALlData;

        public Stato(IEnumerable<GeoCSV> Data)
        {
            ALlData = Data;
        }

        public IList<Regione> GetStato()
        {
            var regioni = ALlData.Select(x => x.Regione).Distinct().ToList();
            var lista = new List<Regione>();

            foreach (var reg in regioni)
            {
                var province = ALlData.Select(x => new { x.Provincia, x.Regione, x.Targa }).Distinct();
                var comuni = ALlData.Select(x => new { x.Provincia, x.Comune, popolazione = x.Popolazione }).Distinct();
                lista.Add(
                    new Regione
                    {
                        Nome = reg,
                        Province = province
                            .Where(x => x.Regione.Equals(reg))
                            .Select(x => new Provincia()
                            {
                                Nome = x.Provincia,
                                Targa = x.Targa,
                                Comuni = comuni.Where(z => z.Provincia.Equals(x.Provincia))
                                    .Select(n => new Comune { Nome = n.Comune, Popolazione = int.Parse(n.popolazione.Replace(".", "")) })
                                    .Distinct().ToList()
                            }).Distinct().ToList(),

                    });
            }

            return lista;
        }
    }
}
