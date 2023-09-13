using System.Collections.ObjectModel;
using System.ComponentModel;
using Forsikring;
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
        public Kunde FjernKunde(Kunde kunde)
        {
            ForsikringsData.FjernKunde(kunde);
            return kunde;
        }
        public Kunde OpretKunde(string fornavn, string efternavn, string adresse, int postnummer, int telefon)
        {
            Kunde kunde = new Kunde(fornavn, efternavn, adresse, postnummer, telefon);
            ForsikringsData.OpretKunde(kunde);
            RaisePropertyChanged(nameof(KundeListe));
            return kunde;
        }
        // void OpretKunde(Kunde kunde)
        //{
        //    ForsikringsData.OpretKunde(kunde);
        //}

    }
}