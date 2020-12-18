using System;
using System.Data;
using MySql.Data.MySqlClient;
using System.Configuration;
using System.Linq;

namespace DAL
{
    public class COVIDHandler
    {

        //private readonly ICOVID = new COVIDFactory.GetInstance();

        //private bool UpdateCOVID(int covidid, string code)
        //{
        //    using var connection = Connection.GetConnection();
        //    {
        //        connection.OpenAsync();
        //        using var command = connection.CreateCommand();
        //        command.CommandText = "UPDATE covid19 SET Code=@code WHERE COVIDID=@covidid";
        //        command.Parameters.AddWithValue("@code", code);
        //        command.Parameters.AddWithValue("@covidid", covidid);
        //        command.ExecuteNonQueryAsync();
        //        connection.CloseAsync();
        //        return true;
        //    }
        //}

        public COVIDDTO GetCOVID(int countryid)
        {
            using var connection = Connection.GetConnection();
            {
                connection.OpenAsync();
                using var command = connection.CreateCommand();
                command.CommandText = "SELECT * FROM `covid19` WHERE COVIDID IN (SELECT COVIDID FROM `country-covid19` WHERE CountryID = @countryid)";
                command.Parameters.AddWithValue("@countryid", countryid);
                var reader = command.ExecuteReader();
                if (!reader.Read()) return new COVIDDTO {CovidCode = "none" };
                var covidobj = new COVIDDTO

                {
                    CovidID = reader.GetInt32("COVIDID"),
                    CovidCode = reader.GetString("Code")
                };
                return covidobj;
            }
        }
        //private bool AddCOVID(int covidid, string code)
        //{
        //    using var connection = Connection.GetConnection();
        //    {
        //        connection.OpenAsync();
        //        using var command = connection.CreateCommand();
        //        command.CommandText = "INSERT INTO covid19 (COVIDID, Code) VALUES (@covidid, @code);";
        //        command.Parameters.AddWithValue("@covidid", covidid);
        //        command.Parameters.AddWithValue("@code", code);
        //        command.ExecuteNonQueryAsync();
        //        connection.CloseAsync();
        //        return true;
        //    }
        //}
    }
}
