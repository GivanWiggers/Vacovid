using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace DAL
{
    public class CountryHandler
    {
        //public bool UpdateCountry()
        //{
        //    return true;
        //}

        //public bool AddCountry(DAL.CountryDTO country)
        //{
        //    return true;
        //}

        //public bool RemoveCountry(DAL.CountryDTO country)
        //{
        //    return true;
        //}

        public DAL.CountryDTO GetCountry(int countryid)
        {
            using var connection = Connection.GetConnection();
            {
                connection.OpenAsync();
                using var command = connection.CreateCommand();
                command.CommandText = "SELECT * FROM `country` WHERE CountryID = @countryid";
                command.Parameters.AddWithValue("@countryid", countryid);
                var reader = command.ExecuteReader();
                if (!reader.Read()) return null;
                var countryobj = new CountryDTO()

                {
                    CountryName = reader.GetString("Name"),
                    CountryCapital = reader.GetString("Capital"),
                    CountryCurrency = reader.GetString("Currency"),
                    CountryLanguage = reader.GetString("Language"),
                    CountryArea = reader.GetInt32("Area"),
                    CountryPopulation = reader.GetInt32("Population"),
                    CountryRegime = reader.GetString("Regime"),
                    CountryInformation = reader.GetString("Information"),
                    CountryFlag = reader.GetFieldValue<byte[]>("Flag")
                };
                return countryobj;
            }
        }

        public List<CountryDTO> GetAllCountries()
        {
            List<CountryDTO> CountryDTOList = new List<CountryDTO>();
            using var connection = Connection.GetConnection();
            {
                connection.OpenAsync();
                using var command = connection.CreateCommand();
                command.CommandText = "SELECT * FROM `country` ORDER BY `country`.`Name` ASC";
                using (MySqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        CountryDTOList.Add(
                                new CountryDTO(
                                    reader.GetInt32("CountryID"),
                                    reader.GetString("Name"),
                                    reader.GetString("Capital"),
                                    reader.GetString("Currency"),
                                    reader.GetString("Language"),
                                    reader.GetInt32("Area"),
                                    reader.GetInt32("Population"),
                                    reader.GetString("Regime"),
                                    reader.GetString("Information"),
                                    reader.GetFieldValue<byte[]>("Flag")
                                )
                            );
                        
                    }
                }
                //Console.WriteLine(CountryDTOList.Count);
                return CountryDTOList;
            }
        }
    }
}
