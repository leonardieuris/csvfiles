using System.Collections.Generic;
using CsvHelper;
using System.IO;

namespace CSVHandler
{
    public class ReaderCSVFile
    {
        public IEnumerable<GeoCSV> Read (string pathFile)
        {
            using (var streamReader = new StreamReader(pathFile))
                using (var csvReader = new CsvReader(streamReader))
                {
                    foreach (var element in csvReader.GetRecords<GeoCSV>())
                    {
                        yield return element;
                    }
                }
        }
    }
}
