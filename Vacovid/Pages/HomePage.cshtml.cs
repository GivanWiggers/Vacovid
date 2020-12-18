using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using DAL;
using Google.Protobuf.WellKnownTypes;
using Logic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Vacovid.Pages
{
    public class HomePageModel : PageModel
    {
        //allcountries
        public List<Country> countries = new List<Country>();
        //lists for filtering
        public List<string> currencyList = new List<string>();
        public List<string> languageList = new List<string>();
        public List<string> covidList = new List<string>();
        //apiList
        public List<APIObjects> apiList = new List<APIObjects>();

        private Country cty = new Country();
        private COVID covid = new COVID();

        public void OnGet()
        {

            countries = cty.GetAllCountries()/*.OrderBy(x => x.CountryPopulation).ToList()*/;

            LoadAllLists(countries);
            apiList = GetAPIList(countries);

        }
        public void OnPost()
        {
            string filter = Request.Form["filter"];
            string search = Request.Form["Search"];
            Console.WriteLine(filter);
            Console.WriteLine(search);

            Attraction attraction = new Attraction();
            List<Country> countriesNoFilter = new List<Country>();
            countriesNoFilter = cty.GetAllCountries();

            LoadAllLists(countriesNoFilter);
            

            if (languageList.Contains(filter))
            {
                foreach (var c in countriesNoFilter)
                {
                    if (c.CountryLanguage.Contains(filter))
                    {
                        if (!countries.Contains(c))
                        {
                            countries.Add(c);
                            apiList.Add(new APIObjects(c.CountryName, covid.GetCOVID(c.CountryID).CovidCode));

                        }
                    }
                }
            }
            if (currencyList.Contains(filter))
            {
                foreach (var c in countriesNoFilter)
                {
                    if (c.CountryCurrency.Contains(filter))
                    {
                        if (!countries.Contains(c))
                        {
                            countries.Add(c);
                            apiList.Add(new APIObjects(c.CountryName, covid.GetCOVID(c.CountryID).CovidCode));
                        }
                    }
                }
            }
            if (covidList.Contains(filter))
            {

                foreach (var c in countriesNoFilter)
                {
                    if (covid.GetCOVID(c.CountryID).CovidCode == filter)
                    {
                        if (!countries.Contains(c))
                        {
                            countries.Add(c);
                            apiList.Add(new APIObjects(c.CountryName, covid.GetCOVID(c.CountryID).CovidCode));
                        }
                    }
                }
            }
            Console.WriteLine(search);
            if (search != null && filter == null)
            {
                foreach (var c in countriesNoFilter)
                {
                    if (c.CountryName.Contains(search, StringComparison.OrdinalIgnoreCase) ||
                        c.CountryCapital.Contains(search, StringComparison.OrdinalIgnoreCase) ||
                        c.CountryCurrency.Contains(search, StringComparison.OrdinalIgnoreCase) ||
                        c.CountryLanguage.Contains(search, StringComparison.OrdinalIgnoreCase) ||
                        c.CountryRegime.Contains(search, StringComparison.OrdinalIgnoreCase) ||
                        /*c.CountryInformation.Contains(search, StringComparison.OrdinalIgnoreCase) ||*/
                        covid.GetCOVID(c.CountryID).CovidCode.Contains(search, StringComparison.OrdinalIgnoreCase)
                        )
                    {
                        if (!countries.Contains(c))
                        {
                            countries.Add(c);
                            apiList.Add(new APIObjects(c.CountryName, covid.GetCOVID(c.CountryID).CovidCode));
                        }
                    }
                }
            }
        }

        private List<string> Currencies(List<Country> list)
        {
            //Completely reads all currencies and add's them to the dropdown/filter list
            var groupbycurrencyList = list.GroupBy(x => x.CountryCurrency).Select(y => y.First()).OrderBy(x => x.CountryCurrency).ToList();
            foreach (var item in groupbycurrencyList)
            {
                currencyList.Add(item.CountryCurrency);
            }
            return currencyList;
        }

        private List<string> Languages(List<Country> list)
        {
            //Completely reads all languages and add's them to the dropdown/filter list including separating all the countries with multiple languages
            string[] splitter = null;
            List<string> splitLanguagesList = new List<string>();
            var groupbylanguageList = list.GroupBy(x => x.CountryLanguage).Select(y => y.First()).OrderBy(x => x.CountryLanguage).ToList();
            foreach (var item in groupbylanguageList)
            {
                //Console.WriteLine(item.CountryLanguage); //test
                splitter = item.CountryLanguage.Split(", ", StringSplitOptions.None);
                foreach (var substr in splitter)
                {
                    splitLanguagesList.Add(substr);
                }
            }
            //Removes duplactations
            foreach (string item in splitLanguagesList.Distinct())
            {
                //Console.WriteLine(item); //test
                languageList.Add(item);
            }
            return languageList;
        }
        private List<string> Covidstatusses(List<Country> list)
        {
            //Completely reads all covid-statussus and add's them to the dropdown/filter list
            List<string> covidListNotDistinct = new List<string>();
            foreach (var item in list)
            {
                covidListNotDistinct.Add(covid.GetCOVID(item.CountryID).CovidCode.ToString());
            }
            //Removes duplactations
            foreach (string code in covidListNotDistinct.Distinct())
            {
                covidList.Add(code);
            }
            return covidList;
        }

        private List<APIObjects> GetAPIList(List<Country> list)
        {
            //creates the list for our api information
            foreach (var country in list)
            {
                apiList.Add(new APIObjects(country.CountryName, covid.GetCOVID(country.CountryID).CovidCode));

            }
            return apiList;
        }

        private void LoadAllLists(List<Country> list)
        {
            currencyList = Currencies(list);
            languageList = Languages(list);
            covidList = Covidstatusses(list);
            
        }
    }
}