
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
        public ObservableCollection<Kunde> GetVareListe(DataTable table)
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
        //public ObservableCollection<Bestilling> GetBestillingsListe(DataTable table)
        //{
        //    ObservableCollection<Bestilling> liste = new ObservableCollection<Bestilling>();
        //    foreach (DataRow row in table.Rows)
        //    {
        //        Bestilling bestilling = GetBestilling(row);
        //        liste.Add(bestilling);
        //    }
        //    return liste;
        //}
        //private bestilling getbestilling(datarow row)
        //{
        //    bestilling bestilling = new bestilling();
        //    bestilling.antal = (int)row["antal"];
        //    bestilling.id = (int)row["id"];
        //    bestilling.vare = getvare(getvaretable(row["vareid"].tostring()).rows[0]);
        //    return bestilling;
        //}

        private DataTable GetVareTable(string id)
        {
            DataTable table;

            table = SqlAccess.ExecuteSql($"select * from Kunde where Kunde.Id = {id}");

            return table;
        }
    }
}
