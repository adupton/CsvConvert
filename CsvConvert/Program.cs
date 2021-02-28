using System;
using CsvConvert.Converters.Factory;

namespace CsvConvert
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length == 0)
            {
                DisplayHelp();
            }
            else if (args[0].ToLower() == "/?")
            {
                DisplayHelp();
            }
            else
            {
                var dataSource = args[0];
                var converterType = args[1];

                var converter = new ConverterFactory().GetConverter(converterType);
                var result = converter.Convert(dataSource);
            }
        }

        private static void DisplayHelp()
        {
            Console.WriteLine("Usage: csvConvert <dataSource> <converterType>");
            Console.WriteLine("");
            Console.WriteLine("where:");
            Console.WriteLine("<datasource> is a valid file path.");
            Console.WriteLine("<converterType> is either csvToJson, csvToXml, jsonToCsv, jsonToXml, xmlToJson, xmlToCsv");
        }
    }
}
