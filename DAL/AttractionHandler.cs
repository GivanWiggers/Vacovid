using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace DAL
{
    public class AttractionHandler
    {
        //private bool UpdateAttraction(int attractionId, string attractionName, string attractionInformation, byte[] attractionImage)
        //{
        //    using var connection = Connection.GetConnection();
        //    {
        //        connection.OpenAsync();
        //        using var command = connection.CreateCommand();
        //        command.CommandText = "UPDATE `attraction` SET Name=@name, Information=@info, Image=@image WHERE AttractionID=@attractionId";
        //        command.Parameters.AddWithValue("@attractionId", attractionId);
        //        command.Parameters.AddWithValue("@name", attractionName);
        //        command.Parameters.AddWithValue("@info", attractionInformation);
        //        command.Parameters.AddWithValue("@image", attractionImage);
        //        command.ExecuteNonQueryAsync();
        //        connection.CloseAsync();
        //        return true;
        //    }
        //}

        //private bool AddAttraction(AttractionDTO attraction)
        //{
        //    using var connection = Connection.GetConnection();
        //    {
        //        connection.OpenAsync();
        //        using var command = connection.CreateCommand();
        //        command.CommandText = "INSERT INTO attraction (Name, Information, Image) VALUES (@name, @info, @image);";
        //        command.Parameters.AddWithValue("@name", attraction.AttractionName);
        //        command.Parameters.AddWithValue("@info", attraction.AttractionInformation);
        //        command.Parameters.AddWithValue("@image", attraction.AttractionImage);
        //        command.ExecuteNonQueryAsync();
        //        connection.CloseAsync();
        //        return true;
        //    }
        //}
        //private bool RemoveAttraction(int countryid, int attractionid)
        //{
        //    using var connection = Connection.GetConnection();
        //    {
        //        connection.OpenAsync();
        //        using var command = connection.CreateCommand();
        //        command.CommandText = "DELETE * FROM `attraction` att WHERE AttractionID IN(SELECT AttractionID FROM `country-attraction` WHERE CountryID = @countryid) AND AttractionID = @attractionid";
        //        command.Parameters.AddWithValue("@countryid", countryid);
        //        command.Parameters.AddWithValue("@attractionid", attractionid);
        //        command.ExecuteNonQueryAsync();
        //        connection.CloseAsync();
        //        return true;
        //    }
        //}

        public DAL.AttractionDTO GetAttraction(int countryid)
        {
            using var connection = Connection.GetConnection();
            {
                connection.OpenAsync();
                using var command = connection.CreateCommand();
                command.CommandText = "SELECT * FROM attraction WHERE AttractionID IN (SELECT AttractionID FROM `country-attraction` WHERE CountryID = @countryid)";
                command.Parameters.AddWithValue("@countryid", countryid);
                var reader = command.ExecuteReader();
                if (!reader.Read()) return null;
                var attrobj = new AttractionDTO

                {
                    AttractionName = reader.GetString("Name"),
                    AttractionInformation = reader.GetString("Information"),
                    AttractionImage = reader.GetFieldValue<byte[]>("Image")
                };
                Console.WriteLine(attrobj.AttractionName);
                Console.WriteLine(attrobj.AttractionInformation);
                return attrobj;
            }
        }

        public List<AttractionDTO> GetAllAttractions(int countryid)
        {
            List<AttractionDTO> AttractionDTOList = new List<AttractionDTO>();
            using var connection = Connection.GetConnection();
            {
                connection.OpenAsync();
                using var command = connection.CreateCommand();
                command.CommandText = "SELECT * FROM attraction WHERE AttractionID IN (SELECT AttractionID FROM `country-attraction` WHERE CountryID = @countryid)";
                command.Parameters.AddWithValue("@countryid", countryid);
                using (MySqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        AttractionDTOList.Add(
                                new AttractionDTO(
                                    reader.GetInt32("AttractionID"),
                                    reader.GetString("Name"),
                                    reader.GetString("Information"),
                                    reader.GetFieldValue<byte[]>("Image")
                                )
                            );

                    }
                }
                Console.WriteLine(AttractionDTOList.Count);
                return AttractionDTOList;
            }
        }

    }
}
