using System;

namespace CsvConvert.Converters.Factory
{
    /// <summary>
    /// ConverterFactory returns an object that implements IConverter to handle different formats.
    /// </summary>
    public class ConverterFactory
    {
        /// <summary>
        /// GetConverter takes a string parameter to return the desired converter
        /// </summary>
        /// <param name="converter"></param>
        /// <returns>An IConverter object.</returns>
        public IConverter GetConverter(string converter)
        {
            if (string.IsNullOrEmpty(converter)) throw new ArgumentException("A type of converter is required.");

            switch (converter.ToLower())
            {
                case "csvtojson":
                    return new CsvToJson();
                case "csvtoxml":
                    return new CsvToXml();
                case "jsontocsv":
                    return new JsonToCsv();
                case "jsontoxml":
                    return new JsonToXml();
                case "xmltossv":
                    return new XmlToCsv();
                case "xmltosson":
                    return new XmlToJson();
                default:
                    return null;
            }
        }
    }

    public class XmlToJson : IConverter
    {
        public string Convert(string dataSource)
        {
            return "Not implemented";
        }
    }

    public class XmlToCsv : IConverter
    {
        public string Convert(string dataSource)
        {
            return "Not implemented";
        }
    }

    public class JsonToXml : IConverter
    {
        public string Convert(string dataSource)
        {
            return "Not implemented";
        }
    }

    public class JsonToCsv : IConverter
    {
        public string Convert(string dataSource)
        {
            return "Not implemented";
        }
    }

    public class CsvToXml : IConverter
    {
        public string Convert(string dataSource)
        {
            return "Not implemented";
        }
    }
}
