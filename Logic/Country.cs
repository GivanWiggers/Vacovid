using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;

namespace Logic
{
    public class Country
    {
        public int CountryID { get; set; }
        public string CountryName { get; set; }
        public string CountryCapital { get; set; }
        public string CountryCurrency { get; set; }
        public string CountryLanguage { get; set; }
        public int CountryArea { get; set; }
        public int CountryPopulation { get; set; }
        public string CountryRegime { get; set; }
        public byte[] CountryFlag { get; set; }
        public string CountryInformation { get; set; }
        //public Country(string name, string capital, string currency, string language, int area, int population, string regime, byte[] flag, string information)
        //{
        //    CountryName = name;
        //    CountryCapital = capital;
        //    CountryCurrency = currency;
        //    CountryLanguage = language;
        //    CountryArea = area;
        //    CountryPopulation = population;
        //    CountryRegime = regime;
        //    CountryFlag = flag;
        //    CountryInformation = information;
        //}
        public Country()
        {
        }
        public Country(int id, string name, string capital, string currency, string language, int area, int population, string regime, string information, byte[] flag)
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

        //public bool UpdateCountry()
        //{
        //    return true;
        //}

        public Country GetCountry(int id)
        {
            CountryHandler countryHandler = new CountryHandler();
            CountryDTO countryDTO = countryHandler.GetCountry(id);
            //Console.WriteLine(countryDTO.CountryName);
            Country country = new CountryContainer().CountryDTOtoCountry(countryDTO);
            //Console.WriteLine(country.CountryName);
            return country;
        }
        
        public List<Country> GetAllCountries()
        {
            CountryHandler countryHandler = new CountryHandler();
            List<CountryDTO> countryDTOList = countryHandler.GetAllCountries();

            // Convert the DTO object list to a logic object list
            List<Country> countryList = new CountryContainer().CountryDTOListToCountryList(countryDTOList);
            //foreach (Country country in countryList)
            //{
            //    Console.WriteLine(country.CountryName);
            //}
            return countryList;
            
        }
    }
}
