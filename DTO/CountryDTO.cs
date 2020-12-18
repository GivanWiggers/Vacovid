using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DTO
{
    public class CountryDTO
    {
        public string CountryName { get; set; }
        public string CountryCapital { get; set; }
        public string CountryCurrency { get; set; }
        public string CountryLanguage { get; set; }
        public int CountryArea { get; set; }
        public int CountryPopulation { get; set; }
        public string CountryRegime { get; set; }
        public string CountryInformation { get; set; }
        public byte[] CountryFlag { get; set; }
    }
}
