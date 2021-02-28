using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading;

namespace CsvConvert
{
    public class CsvToJson
    {
        public void Convert()
        {
            var file = System.IO.File.ReadAllLines("csvData.csv");

            var headers = file[0].Split(',')
                .Select(x => x.Trim('\"'))
                .ToArray();

            var rows = file
                .Skip(1)
                .Select(line => line.Split(','))
                .ToList();

            var root = new List<Dictionary<string, object>>();

            for (int rowIndex = 0; rowIndex < rows.Count; rowIndex++)
            {
                var element = new Dictionary<string, object>();

                for (int headerIndex = 0; headerIndex < headers.Length; headerIndex++)
                {
                    if (!headers[headerIndex].Contains("_"))
                    {
                        element.Add(headers[headerIndex], rows[rowIndex][headerIndex]);
                    }
                    else
                    {
                        element.Add(headers[headerIndex], "parent");
                    }
                    
                }

                root.Add(element);
            }

            var result = JsonSerializer.Serialize(root);

        }
    }


}
