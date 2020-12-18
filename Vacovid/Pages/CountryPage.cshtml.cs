using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DAL;
using Logic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Vacovid.Pages
{
    public class CountryPageModel : PageModel
    {
        public List<Attraction> attractionList = new List<Attraction>();
        public Country country = new Country();
        public COVID covid = new COVID();
        public IActionResult OnGet(int id)
        {
            Attraction attraction = new Attraction();
            COVID cvd = new COVID();
            Country cnty = new Country();

            attractionList = attraction.GetAllAttractions(Convert.ToInt32(id));
            country = cnty.GetCountry(Convert.ToInt32(id));
            covid = cvd.GetCOVID(Convert.ToInt32(id));

            return Page();

        }
    }
}