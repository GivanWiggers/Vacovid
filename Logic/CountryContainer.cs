using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Logic
{
    class CountryContainer
    {
        /// <summary>
        /// Convert a single CountryDTO to a Country object
        /// </summary>
        /// <param name="countryDTO"></param>
        /// <returns></returns>
        public Country CountryDTOtoCountry(CountryDTO countryDTO)
        {
            Country country = new Country(
                countryDTO.CountryID,
                countryDTO.CountryName,
                countryDTO.CountryCapital,
                countryDTO.CountryCurrency,
                countryDTO.CountryLanguage,
                countryDTO.CountryArea,
                countryDTO.CountryPopulation,
                countryDTO.CountryRegime,
                countryDTO.CountryInformation,
                countryDTO.CountryFlag
            );

            return country;
        }

        /// <summary>
        /// Convert a list of CountryDTO's to a list of Country objects
        /// </summary>
        /// <param name="countryDTOList"></param>
        /// <returns></returns>
        public List<Country> CountryDTOListToCountryList(List<CountryDTO> countryDTOList)
        {
            List<Country> countryList = new List<Country>();

            foreach (CountryDTO countryDTO in countryDTOList)
            {
                countryList.Add(
                    new Country(
                        countryDTO.CountryID,
                        countryDTO.CountryName,
                        countryDTO.CountryCapital,
                        countryDTO.CountryCurrency,
                        countryDTO.CountryLanguage,
                        countryDTO.CountryArea,
                        countryDTO.CountryPopulation,
                        countryDTO.CountryRegime,
                        countryDTO.CountryInformation,
                        countryDTO.CountryFlag
                    )
                );
            }

            return countryList;
        }

        //public bool AddCountry(Country country)
        //{
        //    return true;
        //}

        //public bool RemoveCountry(Country country)
        //{
        //    return true;
        //}
    }
}
