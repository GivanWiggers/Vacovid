using System;
using System.ComponentModel.DataAnnotations;

namespace DAL
{
    public class CountryDTO
    {
        public CountryDTO()
        {
        }
        public CountryDTO(int id, string name, string capital, string currency, string language, int area, int population, string regime, string information, byte[] flag)
        {
            CountryID = id;
            CountryName = name;
            CountryCapital = capital;
            CountryCurrency = currency;
            CountryLanguage = language;
            CountryArea = area;
            CountryPopulation = population;
            CountryRegime = regime;
            CountryInformation = information;
            CountryFlag = flag;
        }

        public int CountryID { get; set; }
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
