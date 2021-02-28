namespace CsvConvert.Converters
{
    /// <summary>
    /// IConverter interface.
    /// </summary>
    public interface IConverter
    {
        /// <summary>
        /// Convert reads a file or database connection to transform data into the required format o either csv, xml or json.
        /// </summary>
        /// <param name="dataSource"></param>
        /// <returns>A string of data in the required format</returns>
        string Convert(string dataSource);
    }
}
