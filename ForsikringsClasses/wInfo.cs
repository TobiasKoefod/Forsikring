using System;
using System.Xml.Linq;

namespace Forsikring
{
    public class wInfo
    {
        string name = "";
        string id = "";

        public wInfo(XElement elem)
        {
            foreach (var attr in elem.Attributes())
            {
                if (attr.Name == "name")
                {
                    name = attr.Value;
                }
                if (attr.Name == "id")
                {
                    id = attr.Value;
                }
            }
        }
    }
}

