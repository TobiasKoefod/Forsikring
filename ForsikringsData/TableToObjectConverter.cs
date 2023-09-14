
using Forsikring;
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
        private Kunde GetKunde(DataRow row)
        {
            Kunde kunde = new Kunde((int)row["Id"], (string)row["Fornavn"], (string)row["Efternavn"], (string)row["Adresse"], (int)row["Postnummer"], (int)row["Telefon"]);

            return kunde;
        }             
    }
}
