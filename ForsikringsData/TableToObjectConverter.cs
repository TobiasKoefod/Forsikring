
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
        public ObservableCollection<Forsikringer> GetForsikringer(DataTable table)
        {
            ObservableCollection<Forsikringer> liste = new ObservableCollection<Forsikringer>();
            foreach (DataRow row in table.Rows)
            {
                Forsikringer forsikringer = GetForsikringer(row);
                liste.Add(forsikringer);
            }
            return liste;

        }
        public ObservableCollection<Bilmodeller> GetBilModel(DataTable table)
        {
            ObservableCollection<Bilmodeller> liste = new ObservableCollection<Bilmodeller>();
            foreach (DataRow row in table.Rows)
            {
                Bilmodeller bilmodeller = GetBilModeller(row);
                liste.Add(bilmodeller);
            }
            return liste;
        }
        private Forsikringer GetForsikringer(DataRow row)
        {
            Forsikringer forsikringer = new Forsikringer();
            forsikringer.Id = (int)row["Id"];
            forsikringer.Kunde = GetKunde(GetKundeTabel(row["KundeId"].ToString()).Rows[0]);
            forsikringer.Bilmodeller = GetBilModeller(GetBilTabel(row["BilmodellerId"].ToString()).Rows[0]);
            forsikringer.RegNr = (string)row["RegNr"];
            forsikringer.Pris = (decimal)row["Pris"];
            forsikringer.FSsum = (decimal)row["FSsum"];
            forsikringer.Requirements = (string)row["Requirements"];

            return forsikringer;
        }
        private Bilmodeller GetBilModeller(DataRow row)
        {
            Bilmodeller bilmodeller = new Bilmodeller((int)row["Id"], (string)row["Mærke"], (string)row["Model"], (int)row["Startår"], (int)row["Slutår"], (decimal)row["Standartpris"], (decimal)row["Forsikringssum"]);

            return bilmodeller;
        }
        private Kunde GetKunde(DataRow row)
        {
            Kunde kunde = new Kunde((int)row["Id"], (string)row["Fornavn"], (string)row["Efternavn"], (string)row["Adresse"], (int)row["Postnummer"], (int)row["Telefon"]);

            return kunde;
        }
        private DataTable GetKundeTabel(string id)
        {
            DataTable table;
            table = SqlAccess.ExecuteSql($"select * from Kunde where Kunde.Id = {id}");

            return table;
        }
        private DataTable GetBilTabel(string id)
        {
            DataTable table;
            table = SqlAccess.ExecuteSql($"select * from Bilmodeller where Bilmodeller.Id = {id}");

            return table;
        }
    }
}
