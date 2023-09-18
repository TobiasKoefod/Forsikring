using Forsikring;
using ForsikringsClasses;
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
        public ObservableCollection<Bilmodeller> BilListe
        {
            get
            {
                return converter.GetBilModel(SqlAccess.ExecuteSql("Select * from Bilmodeller"));
            }
        }
        public ObservableCollection<Kunde> KundeListe
        {
            get
            {
                return converter.GetKundeListe(SqlAccess.ExecuteSql("Select * from Kunde"));
            }
            
        }
        public void FjernKunde(Kunde kunde)
        {
            SqlAccess.ExecuteSql($"Delete from Kunde where Id='{kunde.Id}'");
        }
        public void changeKunde(Kunde selctedKunde, Kunde kunde)
        {
            SqlAccess.ExecuteSql($"Update Kunde set Fornavn='{kunde.Fornavn}', Efternavn='{kunde.Efternavn}', Adresse='{kunde.Adresse}', Postnummer={kunde.Postnummer}, Telefon={kunde.Telefon} where Id={selctedKunde.Id}");
        }
        public void OpretKunde(Kunde kunde)
        {
            SqlAccess.ExecuteSql($"Insert into Kunde (Fornavn, Efternavn, Adresse, Postnummer, Telefon) values ('{kunde.Fornavn}', '{kunde.Efternavn}' , '{kunde.Adresse}', {kunde.Postnummer}, {kunde.Telefon})");
        }
        public void OpretBilmdl(Bilmodeller bilmodeller)
        {
            SqlAccess.ExecuteSql($"Insert into Bilmodeller (Mærke, Model, Startår, Slutår, Standartpris, Forsikringssum) values ('{bilmodeller.Mærke}', '{bilmodeller.Model}',{bilmodeller.Starår}, {bilmodeller.Slutår}, {bilmodeller.Standartpris}, {bilmodeller.Forsikringssum})");
        }
    }
}
