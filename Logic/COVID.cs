using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Logic
{
    public class COVID
    {
        public int CovidID { get; set; }
        public string CovidCode { get; set; }
        public COVID()
        {

        }
        public COVID(int covidid, string code)
        {
            CovidID = covidid;
            CovidCode = code;
        }
        public COVID GetCOVID(int id)
        {
            COVIDHandler covidHandler = new COVIDHandler();
            COVIDDTO covidDTO = covidHandler.GetCOVID(id);
            
            COVID covid = new COVIDContainer().COVIDDTOtoCOVID(covidDTO);
            
            return covid;
        }
    }
}
