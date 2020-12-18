using System;
using System.Collections.Generic;
using System.Text;

namespace Logic
{
    public class APIObjects
    {
        public string APIName { get; set; }

        public string APICode { get; set; }

        public APIObjects(string name, string code)
        {
            APIName = name;
            APICode = code;
        }
    }
}
