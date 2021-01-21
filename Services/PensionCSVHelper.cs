using CsvHelper;
using PensionsCalculator.DTOs.CSV;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;

namespace PensionsCalculator.Services
{
    public class PensionCSVHelper
    {
        public List<RetiredPensionDto> ReadRetiredPensions()
        {
            using TextReader textReader = new StreamReader("RetiredPensions.csv");
            using var csvReader = new CsvReader(textReader, CultureInfo.InvariantCulture);
            return csvReader.GetRecords<RetiredPensionDto>().ToList();
        }
        
        public List<DeceasedPensionDto> ReadDeceasedPensions()
        {
            using TextReader textReader = new StreamReader("DeceasedPensions.csv");
            using var csvReader = new CsvReader(textReader, CultureInfo.InvariantCulture);
            return csvReader.GetRecords<DeceasedPensionDto>().ToList();
        }
    }
}
