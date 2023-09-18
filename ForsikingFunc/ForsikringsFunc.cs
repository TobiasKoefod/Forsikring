using System.Collections.ObjectModel;
using System.ComponentModel;
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
        public ObservableCollection<Kunde> KundeListe
        {
            get
            {
                return ForsikringsData.KundeListe;
            }
        }

        public ObservableCollection<Bilmodeller> BilListe
        {
            get
            {
                return ForsikringsData.BilListe;
            }
        }
        public Kunde FjernKunde(Kunde kunde)
        {
            ForsikringsData.FjernKunde(kunde);
            RaisePropertyChanged(nameof(KundeListe));
            return kunde;
        }
        public Kunde ChangeKunde(Kunde selectedKunde, string fornavn, string efternavn, string adresse, int postnummer, int telefon)
        {
            Kunde kunde = new Kunde(fornavn, efternavn, adresse, postnummer, telefon);
            ForsikringsData.changeKunde(selectedKunde, kunde);

            RaisePropertyChanged(nameof(KundeListe));
            return kunde;
        }
        public Kunde OpretKunde(string fornavn, string efternavn, string adresse, int postnummer, int telefon)
        {
            Kunde kunde = new Kunde(fornavn, efternavn, adresse, postnummer, telefon);
            ForsikringsData.OpretKunde(kunde);
            RaisePropertyChanged(nameof(KundeListe));
            return kunde;
        }
        public Bilmodeller OpretBilmdl(string mærke, string model, int startår, int slutår, int standartpris, int forsikringssum)
        {
            Bilmodeller bilmodeller = new Bilmodeller(mærke, model, startår, slutår, standartpris, forsikringssum);
            ForsikringsData.OpretBilmdl(bilmodeller);
            RaisePropertyChanged(nameof (Bilmodeller));
            return bilmodeller;
        }
    }
}