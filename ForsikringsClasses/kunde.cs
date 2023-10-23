using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Forsikring
{
    public class Kunde
    {
        public int Id { get; set; }
        public string Fornavn { get; set; }
        public string Efternavn { get; set; }
        public string Adresse { get; set; }
        public int Postnummer { get; set; }
        public int Telefon { get; set; }

        public string KombineretNavn
        {
            get
            {
                return $"{Fornavn} {Efternavn}";
            }
        }
        public Kunde(int id, string fornavn, string efternavn, string adresse, int postnummer, int telefon)
        {
            if (fornavn == "")
            {
                throw new ArgumentException();
            }
            Id = id;
            Fornavn = fornavn;
            Efternavn = efternavn;
            Adresse = adresse;
            Postnummer = postnummer;
            Telefon = telefon;
        }
        public Kunde(string fornavn, string efternavn , string adresse, int postnummer, int telefon)
        {
            if (fornavn == "")
            {
                throw new ArgumentException();
            }
            Fornavn = fornavn;
            Efternavn = efternavn;
            Adresse = adresse;
            Postnummer = postnummer;
            Telefon = telefon;
            Id = -1;
        }
    }
}
