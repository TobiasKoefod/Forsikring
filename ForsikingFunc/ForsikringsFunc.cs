using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text.RegularExpressions;
using System.Xml.Linq;
using Forsikring;
using ForsikringsClasses;
using NP_ForsikringsData;

namespace NP_ForsikringsFunc
{
    public class ForsikringsFunc : INotifyPropertyChanged
    {
        ForsikringsData ForsikringsData { get; set; } = new ForsikringsData();

        public event PropertyChangedEventHandler? PropertyChanged;

        private void RaisePropertyChanged(string propName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propName));
            }
        }
        // -----------------------------------

        public ObservableCollection<Kunde> KundeListe
        {
            get
            {
                return ForsikringsData.KundeListe;
            }
        } // Kunde Collection
        public ObservableCollection<Bilmodeller> BilListe // Bil Collection
        {
            get
            {
                return ForsikringsData.BilListe;
            }
        }
        public ObservableCollection<Forsikringer> Forsikring // Forsikring Collection
        {
            get
            {
                return ForsikringsData.Forsikring;
            }
        }
        public List<wInfo> extractWInfo(XElement baseElement, XDocument document)
        {
            return ForsikringsData.extractWInfo(baseElement, document);
        } // Vejr Info

        // -----------------------------------

        public Kunde OpretKunde(string fornavn, string efternavn, string adresse, int postnummer, int telefon)
        {
            Kunde kunde = new Kunde(fornavn, efternavn, adresse, postnummer, telefon);
            ForsikringsData.OpretKunde(kunde);
            RaisePropertyChanged(nameof(KundeListe));
            return kunde;
        } // Opret Kunde
        public Kunde FjernKunde(Kunde kunde)
        {
            ForsikringsData.FjernKunde(kunde);
            RaisePropertyChanged(nameof(KundeListe));
            return kunde;
        } // Fjern Kunde
        public Kunde ChangeKunde(Kunde selectedKunde, string fornavn, string efternavn, string adresse, int postnummer, int telefon)
        {
            Kunde kunde = new Kunde(fornavn, efternavn, adresse, postnummer, telefon);
            ForsikringsData.changeKunde(selectedKunde, kunde);

            RaisePropertyChanged(nameof(KundeListe));
            return kunde;
        } // Ændre Kunde

        // -----------------------------------
        public Bilmodeller OpretBilmdl(string mærke, string model, int startår, int slutår, decimal standartpris, decimal forsikringssum)
        {
            Bilmodeller bilmodeller = new Bilmodeller(mærke, model, startår, slutår, standartpris, forsikringssum);
            ForsikringsData.OpretBilmdl(bilmodeller);
            RaisePropertyChanged(nameof (BilListe));
            return bilmodeller;

        } // Opret Bil
        public Bilmodeller FjernBil(Bilmodeller bilmodeller)
        {
            ForsikringsData.FjernBil(bilmodeller);
            RaisePropertyChanged(nameof(BilListe));
            return bilmodeller;
        } // Fjern Bil
        public Bilmodeller changeBilmdl(Bilmodeller SelectedBilmodeller, string mærke, string model, int startår, int slutår, decimal standartpris, decimal forsikringssum)
        {
            Bilmodeller bilmodeller = new Bilmodeller(mærke, model, startår, slutår, standartpris, forsikringssum);
            ForsikringsData.changeBilmdl(SelectedBilmodeller, bilmodeller);

            RaisePropertyChanged(nameof (BilListe));
            return bilmodeller;
        } // Ændre bil

        // -----------------------------------
        public Forsikringer OpretForsikring(Kunde kunde, Bilmodeller bilmodeller, string regnr, decimal pris, decimal fssum, string requirements)
        {
            Forsikringer forsikringer = new Forsikringer();
            forsikringer.Kunde = kunde;
            forsikringer.Bilmodeller = bilmodeller;
            forsikringer.RegNr = regnr;
            forsikringer.FSsum = fssum;
            forsikringer.Pris = pris;
            forsikringer.Requirements = requirements;
            ForsikringsData.OpretForsikring(forsikringer);
            RaisePropertyChanged(nameof(Forsikring));
            return forsikringer;
        } // Opret Forsikring
        public Forsikringer FjernForsikring(Forsikringer forsikringer)
        {
            ForsikringsData.FjernForsikring(forsikringer);
            RaisePropertyChanged(nameof(Forsikring));
            return forsikringer;
        } // Fjern Forsikring
        public Forsikringer ChangeForsikring(Kunde kunde, Bilmodeller bilmodeller, string regnr, decimal pris, decimal fssum, string requirements)
        {
            Forsikringer forsikringer = new Forsikringer();
            forsikringer.Kunde = kunde;
            forsikringer.Bilmodeller = bilmodeller;
            forsikringer.RegNr = regnr;
            forsikringer.FSsum = fssum;
            forsikringer.Pris = pris;
            forsikringer.Requirements = requirements;
            ForsikringsData.UpdateForsikring(forsikringer);
            RaisePropertyChanged(nameof(Forsikring));

            return forsikringer;
        } // Ændre Forsikring

        // -----------------------------------
    }
}