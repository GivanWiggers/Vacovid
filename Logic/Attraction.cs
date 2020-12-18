using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Logic
{
    public class Attraction
    {
        public int AttractionID { get; set; }
        public string AttractionName { get; set; }
        public string AttractionInformation { get; set; }
        public byte[] AttractionImage { get; set; }

        public Attraction()
        {

        }
        public Attraction(int id, string name, string info, byte[] image)
        {
            AttractionID = id;
            AttractionName = name;
            AttractionInformation = info;
            AttractionImage = image;
        }

        public Attraction GetAttraction(int id)
        {
            AttractionHandler attractionHandler = new AttractionHandler();
            AttractionDTO attractionDTO = attractionHandler.GetAttraction(id);
            Attraction attraction = new AttractionContainer().AttractionDTOtoAttraction(attractionDTO);
            return attraction;
        }

        public List<Attraction> GetAllAttractions(int id)
        {
            AttractionHandler attractionHandler = new AttractionHandler();
            List<AttractionDTO> attractionDTOList = attractionHandler.GetAllAttractions(id);

            List<Attraction> attractionList = new AttractionContainer().AttractionDTOListToAttractionList(attractionDTOList);
            return attractionList;

        }
    }
}
