using Forsikring;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace NP_ForsikringsData
{
    public class ForsikringsData : INotifyPropertyChanged
    {
        SqlAccess SqlAccess { get; set; } = new SqlAccess();

        TableToObjectConverter converter = new TableToObjectConverter();

        public event PropertyChangedEventHandler? PropertyChanged;

        public ForsikringsData()
        {

        }
        public ObservableCollection<Kunde> KundeListe
        {
            get;
        } = new ObservableCollection<Kunde>();
        public void FjernKunde(Kunde kunde)
        {
            SqlAccess.ExecuteSql($"Delete row from Kunde where Id='{kunde.Id}'");
        }
        public void changeKunde(Kunde selctedKunde, Kunde kunde)
        {
            SqlAccess.ExecuteSql($"Update Kunde set  where Id={selctedKunde.Id}");
        }
        public void OpretKunde(Kunde kunde)
        {
            SqlAccess.ExecuteSql($"Insert into Kunde (Fornavn, Efternavn, Adresse, Postnummer, Telefon) values ('{kunde.Fornavn}', '{kunde.Efternavn}' , '{kunde.Adresse}', {kunde.Postnummer}, {kunde.Telefon})");
        }
        //public void OpretKunde(Kunde kunde)
        //{
        //}
    }
}
