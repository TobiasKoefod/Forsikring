using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace ForsikringsClasses
{
    public class Bilmodeller
    {
        public int Id { get; set; }
        public string Mærke { get; set; }
        public string Model { get; set; }
        public int Starår { get; set; }
        public int Slutår { get; set; }
        public int Standartpris { get; set; }
        public int Forsikringssum { get; set; }
        public Bilmodeller(int id, string mærke, string model, int starår, int slutår, int standartpris, int forsikringssum)
        {
            if (mærke == "")
            {
                throw new ArgumentException();
            }
            Id = id;
            Mærke = mærke;
            Model = model;
            Starår = starår;
            Slutår = slutår;
            Standartpris = standartpris;
            Forsikringssum = forsikringssum;
        }
        public Bilmodeller(string mærke, string model, int starår, int slutår, int standartpris, int forsikringssum)
        {
            if (mærke == "")
            {
                throw new ArgumentException();
            }
            
            Id = -1;
            Mærke = mærke;
            Model = model;
            Starår = starår;
            Slutår = slutår;
            Standartpris = standartpris;
            Forsikringssum = forsikringssum;
        }
    }
}
