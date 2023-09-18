
using Forsikring;
using ForsikringsClasses;
using NP_ForsikringsData;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NP_ForsikringsData
{
    public class TableToObjectConverter
    {
        private SqlAccess SqlAccess { get; set; }

        public TableToObjectConverter() 
        {
            SqlAccess = new SqlAccess();
        }
        public ObservableCollection<Kunde> GetKundeListe(DataTable table)
        {
            ObservableCollection<Kunde> liste = new ObservableCollection<Kunde>();
            foreach (DataRow row in table.Rows)
            {
                Kunde kunde = GetKunde(row);
                liste.Add(kunde);
            }
            return liste;
        }
        public ObservableCollection<Bilmodeller> GetBilModel(DataTable table)
        {
            ObservableCollection<Bilmodeller> liste = new ObservableCollection<Bilmodeller>();
            foreach (DataRow row in table.Rows)
            {
                Bilmodeller bilmodeller = GetBilModel(row);
                liste.Add(bilmodeller);
            }
            return liste;
        }
        private Bilmodeller GetBilModel(DataRow row)
        {
            Bilmodeller bilmodeller = new Bilmodeller((int)row["Id"], (string)row["Mærke"], (string)row["Model"], (int)row["Startår"], (int)row["Slutår"], (int)row["Standartpris"], (int)row["Forsikringssum"]);

            return bilmodeller;
        }
        private Kunde GetKunde(DataRow row)
        {
            Kunde kunde = new Kunde((int)row["Id"], (string)row["Fornavn"], (string)row["Efternavn"], (string)row["Adresse"], (int)row["Postnummer"], (int)row["Telefon"]);

            return kunde;
        }             
    }
}
