using Forsikring;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForsikringsClasses
{
    public class Forsikringer
    {
        public int Id { get; set; }
        public int KundeId { get; set; }
        public int BilmodellerId { get; set; }
        public string RegNr { get; set; }
        public decimal FSsum { get; set; }
        public decimal Pris { get; set; }
        public string Requirements { get; set; }
        public Bilmodeller Bilmodeller { get; set; }
        public Kunde Kunde { get; set; }
    }
}
