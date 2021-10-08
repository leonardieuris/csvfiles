using System;

namespace CSVFiles
{
    class Program
    {
        static void Main(string[] args)
        {
            var path = @"C:\sorgente\dati\Elenco-comuni-italiani.csv";
            Logic.Execute(path);
            Console.ReadKey();
        }
    }
}
