using System;
using System.Collections.Generic;
using System.Text;

namespace DAL
{
    public class AttractionDTO
    {
        public int AttractionID { get; set; }
        public string AttractionName { get; set; }
        public string AttractionInformation { get; set; }
        public byte[] AttractionImage { get; set; }

        public AttractionDTO()
        {

        }
        public AttractionDTO(int id,string name, string info, byte[] image)
        {
            AttractionID = id;
            AttractionName = name;
            AttractionInformation = info;
            AttractionImage = image;
        }
    }
}
