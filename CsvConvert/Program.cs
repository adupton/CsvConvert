using System;

namespace CsvConvert
{
    class Program
    {
        static void Main(string[] args)
        {
            var csvToJson = new CsvToJson();
            var result = csvToJson.Convert("csvData.csv");
        }
    }
}
