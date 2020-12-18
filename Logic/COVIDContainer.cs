using DAL;
using System;
using System.Collections.Generic;
using System.Text;

namespace Logic
{
    class COVIDContainer
    {
        public COVID COVIDDTOtoCOVID(COVIDDTO covidDTO)
        {

            COVID covid = new COVID(
                covidDTO.CovidID,
                covidDTO.CovidCode
            );

            return covid;
        }
    }
}
