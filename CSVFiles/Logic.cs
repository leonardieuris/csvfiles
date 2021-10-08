using CSVHandler;
using GeoLibrary;
using System;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace CSVFiles
{
    public static class Logic
    {
        public static void Execute(string path)
        {
            var cronometro = Stopwatch.StartNew();
            var reader = new ReaderCSVFile();
            var geo = reader.Read(path);
            var generatore = new Stato(geo);
            var italia = generatore.GetStato();
            var totaleRegioni = italia.Count();
            var totaleProvince = 0;
            var totaleComuni = 0;
            var totPopolazione = 0;

            foreach (var reg in italia)
            {
                var province = reg.Province.SelectMany(x => x.Comuni).ToList();
                var totComuni = province.Count();
                var popolazione = province.Sum(x => x.Popolazione);
                totPopolazione += popolazione;
                Console.WriteLine($"Regione {reg.Nome} -> Popolazione {popolazione} -> Province {reg.Province.Count()} -> Comuni {totComuni}");
                totaleComuni += totComuni;
                totaleProvince += province.Count();
            }

            Console.WriteLine($"Popolazione Italiana => {totPopolazione} => Regioni {totaleRegioni} => Province {totaleProvince} => Comuni {totaleComuni} ");
            Console.WriteLine($"Execution Time {cronometro.ElapsedMilliseconds}");
        }
    }
}