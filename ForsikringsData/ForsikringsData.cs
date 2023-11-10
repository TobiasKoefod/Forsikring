using Forsikring;
using ForsikringsClasses;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Reflection.Metadata;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

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

        // -----------------------------------

        public ObservableCollection<Kunde> KundeListe
        {
            get
            {
                return converter.GetKundeListe(SqlAccess.ExecuteSql("Select * from Kunde"));
            }
            
        } // Kunde SQL
        public ObservableCollection<Bilmodeller> BilListe
        {
            get
            {
                return converter.GetBilModel(SqlAccess.ExecuteSql("Select * from Bilmodeller"));
            }
        } // Bil SQL
        public ObservableCollection<Forsikringer> Forsikring
        {
            get
            {
                return converter.GetForsikringer(SqlAccess.ExecuteSql("Select * from Forsikringer"));
            }
        } // Forsikring SQL
        public List<wInfo> extractWInfo(XElement baseElement, XDocument document)
        {
            List<wInfo> wInfoList = new List<wInfo>();

            foreach (XElement element in baseElement.Elements())
            {
                wInfoList.Add(new wInfo(element));
            }
            return wInfoList;
        } // Vejr Info

        // -----------------------------------

        public void OpretKunde(Kunde kunde)
        {
            SqlAccess.ExecuteSql($"Insert into Kunde (Fornavn, Efternavn, Adresse, Postnummer, Telefon) values ('{kunde.Fornavn}', '{kunde.Efternavn}' , '{kunde.Adresse}', {kunde.Postnummer}, {kunde.Telefon})");
        } // Opret Kunde
        public void FjernKunde(Kunde kunde)
        {
            SqlAccess.ExecuteSql($"Delete from Kunde where Id='{kunde.Id}'");
        } // Fjern Kunde
        public void changeKunde(Kunde selctedKunde, Kunde kunde)
        {
            SqlAccess.ExecuteSql($"Update Kunde set Fornavn='{kunde.Fornavn}', Efternavn='{kunde.Efternavn}', Adresse='{kunde.Adresse}', Postnummer={kunde.Postnummer}, Telefon={kunde.Telefon} where Id={selctedKunde.Id}");
        } // Ændre Kunde

        // -----------------------------------
        public void OpretBilmdl(Bilmodeller bilmodeller)
        {
            SqlAccess.ExecuteSql($"Insert into Bilmodeller (Mærke, Model, Startår, Slutår, Standartpris, Forsikringssum) values ('{bilmodeller.Mærke}', '{bilmodeller.Model}',{bilmodeller.Startår}, {bilmodeller.Slutår}, {bilmodeller.Standartpris.ToString(CultureInfo.InvariantCulture)}, {bilmodeller.Forsikringssum.ToString(CultureInfo.InvariantCulture)})");
        } // Opret Bil
        public void FjernBil(Bilmodeller bilmodeller)
        {
            SqlAccess.ExecuteSql($"Delete from Bilmodeller where Id='{bilmodeller.Id}'");
        } // Fjern Bil
        public void changeBilmdl(Bilmodeller SelectedBilmodeller, Bilmodeller bilmodeller)
        {
            SqlAccess.ExecuteSql($"Update Bilmodeller set Mærke='{bilmodeller.Mærke}', Model='{bilmodeller.Model}', Startår={bilmodeller.Startår}, Slutår={bilmodeller.Slutår}, Standartpris={bilmodeller.Standartpris.ToString(CultureInfo.InvariantCulture)}, Forsikringssum={bilmodeller.Forsikringssum.ToString(CultureInfo.InvariantCulture)} where Id={SelectedBilmodeller.Id}");
        } // Ændre Bil

        // -----------------------------------

        public void OpretForsikring(Forsikringer forsikringer)
        {
            SqlAccess.ExecuteSql($"Insert into Forsikringer (KundeId, BilmodellerId, RegNr, Pris, FSsum, Requirements) values ('{forsikringer.Kunde.Id}', '{forsikringer.Bilmodeller.Id}', '{forsikringer.RegNr}', {forsikringer.Pris.ToString(CultureInfo.InvariantCulture)} ,{forsikringer.FSsum.ToString(CultureInfo.InvariantCulture)}, '{forsikringer.Requirements}')");
        } // Opret Forsikring
        public void FjernForsikring(Forsikringer forsikringer)
        {
            SqlAccess.ExecuteSql($"Delete from Forsikringer where Id='{forsikringer.Id}'");
        } // Fjern Forsikring
        public void UpdateForsikring(Forsikringer forsikringer)
        {
            SqlAccess.ExecuteSql($"Update Forsikringer set KundeId='{forsikringer.Kunde.Id}', BilmodellerId='{forsikringer.Bilmodeller.Id}', RegNr='{forsikringer.RegNr}', Pris={forsikringer.Pris.ToString(CultureInfo.InvariantCulture)}, FSsum={forsikringer.FSsum.ToString(CultureInfo.InvariantCulture)}, Requirements='{forsikringer.Requirements}' where Id={forsikringer.Id}");
        } // Ændre Forsikring

        // -----------------------------------
    }
}
