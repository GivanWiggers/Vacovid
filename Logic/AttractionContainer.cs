using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Logic
{
    class AttractionContainer
    {
        /// <summary>
        /// Convert a single AttractionDTO to a Attraction object
        /// </summary>
        /// <param name="attractionDTO"></param>
        /// <returns></returns>
        public Attraction AttractionDTOtoAttraction(AttractionDTO attractionDTO)
        {
            Attraction attraction = new Attraction(
                attractionDTO.AttractionID,
                attractionDTO.AttractionName,
                attractionDTO.AttractionInformation,
                attractionDTO.AttractionImage
            );

            return attraction;
        }

        /// <summary>
        /// Convert a list of AttractionDTO's to a list of Attraction objects
        /// </summary>
        /// <param name="attractionDTOList"></param>
        /// <returns></returns>
        public List<Attraction> AttractionDTOListToAttractionList(List<AttractionDTO> attractionDTOList)
        {
            List<Attraction> attractionList = new List<Attraction>();

            foreach (AttractionDTO attractionDTO in attractionDTOList)
            {
                attractionList.Add(
                    new Attraction(
                attractionDTO.AttractionID,
                attractionDTO.AttractionName,
                attractionDTO.AttractionInformation,
                attractionDTO.AttractionImage
                    )
                );
            }

            return attractionList;
        }
    }
}
