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
        public int Startår { get; set; }
        public int Slutår { get; set; }
        public decimal Standartpris { get; set; }
        public decimal Forsikringssum { get; set; }
        public string KombineretBilinfo
        {
            get
            {
                return $"{Mærke}{Model}({Startår}-{Slutår})";
            }
        }
        public Bilmodeller(int id, string mærke, string model, int startår, int slutår, decimal standartpris, decimal forsikringssum)
        {
            if (mærke == "")
            {
                throw new ArgumentException();
            }
            Id = id;
            Mærke = mærke;
            Model = model;
            Startår = startår;
            Slutår = slutår;
            Standartpris = standartpris;
            Forsikringssum = forsikringssum;
        }
        public Bilmodeller(string mærke, string model, int startår, int slutår, decimal standartpris, decimal forsikringssum)
        {
            if (mærke == "")
            {
                throw new ArgumentException();
            }
            
            Id = -1;
            Mærke = mærke;
            Model = model;
            Startår = startår;
            Slutår = slutår;
            Standartpris = standartpris;
            Forsikringssum = forsikringssum;
        }
    }
}
