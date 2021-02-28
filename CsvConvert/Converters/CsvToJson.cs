using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;

namespace CsvConvert.Converters
{
    /// <summary>
    /// CsvToJson converts a csv file to json
    /// </summary>
    public class CsvToJson : IConverter
    {
        /// <summary>
        /// Convert reads a csv file to transform data into json.
        /// </summary>
        /// <param name="dataSource"></param>
        /// <returns>A string of json data.</returns>
        public string Convert(string dataSource) 
        {
            if (string.IsNullOrEmpty(dataSource)) throw new ArgumentException("A valid data source is required");
            
            try
            {
                var file = System.IO.File.ReadAllLines(dataSource);

                if (file.Length < 2)
                    throw new ArgumentException(
                        $"{dataSource} must contain a header row and at least one row of data.");

                var headers = file[0].Split(',')
                    .Select(x => x.Trim('\"'))
                    .ToArray();

                var rows = file
                    .Skip(1)
                    .Select(line => line.Split(','))
                    .ToList();

                var root = new List<Dictionary<string, object>>();

                foreach (var row in rows)
                {
                    var element = new Dictionary<string, object>();

                    for (int headerIndex = 0; headerIndex < headers.Length; headerIndex++)
                    {
                        if (!headers[headerIndex].Contains("_"))
                        {
                            element.Add(headers[headerIndex], row[headerIndex]);
                        }
                        else
                        {
                            var headerGroup = headers[headerIndex].Split("_");
                            var subElement = new Dictionary<string, object>();

                            if (element.ContainsKey(headerGroup[0]))
                            {
                                element.TryGetValue(headerGroup[0], out var existingSubElement);
                                subElement = existingSubElement as Dictionary<string, object>;
                                subElement?.Add(headerGroup[1], row[headerIndex]);
                            }
                            else
                            {
                                subElement.Add(headerGroup[1], row[headerIndex]);
                                element.Add(headerGroup[0], subElement);
                            }
                        }
                    }

                    root.Add(element);
                }

                return JsonSerializer.Serialize(root, new JsonSerializerOptions
                {
                    WriteIndented = true
                });
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}
