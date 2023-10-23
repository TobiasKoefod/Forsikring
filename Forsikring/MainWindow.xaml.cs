using System;
using System.ComponentModel;
using System.Windows;
using ForsikringsClasses;
using NP_ForsikringsFunc;
namespace Forsikring
{
    public partial class MainWindow : Window, INotifyPropertyChanged
    {

        public ForsikringsFunc ForsikringsFunc { get; set; } = new ForsikringsFunc();

        public event PropertyChangedEventHandler? PropertyChanged;
        
        private Kunde SelectedKunde;
        public Kunde ValgteKunde
        {
            get
            {
                return SelectedKunde;
            }
            set 
            { 
                SelectedKunde = value;
                {
                    PropertyChanged(this,
                    new PropertyChangedEventArgs(nameof(SelectedKunde)));
                }           
            }
        }
        public MainWindow()
        {
            InitializeComponent();
            DataContext = this;
        }
        private void Tilføj_Click(object sender, RoutedEventArgs e) // Tilføj Kunde
        {
            try
            {
                ForsikringsFunc.OpretKunde(tbFornavn.Text, tbEfternavn.Text, tbAdresse.Text, int.Parse(tbPostnummer.Text), int.Parse(tbTelefon.Text));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Fejl");
            }
        }

        private void SletBTN_Click(object sender, RoutedEventArgs e) // Slet kunde
        {
            try
            {
                ForsikringsFunc.FjernKunde(dgKunder.SelectedItem as Kunde);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Vælg en kunde og tryk slet");
            }
        }

        private void RedigerBTN_Click(object sender, RoutedEventArgs e) //Rediger Kunde
        {
            Kunde SelectedKunde = dgKunder.SelectedItem as Kunde;

            if (SelectedKunde != null)
            {
                tbFornavn.Text = SelectedKunde.Fornavn;
                tbEfternavn.Text = SelectedKunde.Efternavn;
                tbAdresse.Text = SelectedKunde.Adresse;
                tbPostnummer.Text = SelectedKunde.Postnummer.ToString();
                tbTelefon.Text = SelectedKunde.Telefon.ToString();
            }
        }

        private void GemBTN_Click(object sender, RoutedEventArgs e) //Dette er gem til Kunder
        {
            try
            {
                ForsikringsFunc.ChangeKunde(dgKunder.SelectedItem as Kunde, tbFornavn.Text, tbEfternavn.Text, tbAdresse.Text, int.Parse(tbPostnummer.Text), int.Parse(tbTelefon.Text));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Fejl");
            }
        }

        private void btnGem_Click(object sender, RoutedEventArgs e) //Dette er Gem til Bilmodeller
        {
            try
            {
                ForsikringsFunc.changeBilmdl(dgBiler.SelectedItem as Bilmodeller, tbMærke.Text, tbModel.Text, int.Parse(tbStartår.Text), int.Parse(tbSlutår.Text), decimal.Parse(tbStandartpris.Text), decimal.Parse(tbForsikringssum.Text));
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Fejl");
            }
        }

        private void btnTilføj_Click(object sender, RoutedEventArgs e) // Biler tilføj
        {
            try
            {
                ForsikringsFunc.OpretBilmdl(tbMærke.Text, tbModel.Text, int.Parse(tbStartår.Text), int.Parse(tbSlutår.Text), decimal.Parse(tbStandartpris.Text), decimal.Parse(tbForsikringssum.Text));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Fejl");
            }
        }

        private void Rediger_Click(object sender, RoutedEventArgs e) // Rediger for biler
        {
            Bilmodeller SelectedBilmodeller = dgBiler.SelectedItem as Bilmodeller;

            if (SelectedBilmodeller != null)
            {
                tbMærke.Text = SelectedBilmodeller.Mærke;
                tbModel.Text = SelectedBilmodeller.Model;
                tbStartår.Text = SelectedBilmodeller.Startår.ToString();
                tbSlutår.Text = SelectedBilmodeller.Slutår.ToString();
                tbStandartpris.Text = SelectedBilmodeller.Standartpris.ToString();
                tbForsikringssum.Text = SelectedBilmodeller.Forsikringssum.ToString();
            }
        }

        private void BilSlet_Click(object sender, RoutedEventArgs e) // Sletter Biler
        {
            try
            {
                ForsikringsFunc.FjernBil(dgBiler.SelectedItem as Bilmodeller);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Vælg en bil og prøv igen");
            }
        }

        private void UpdateForsikring_Click(object sender, RoutedEventArgs e) // Updater Forsikring
        {
            try
            {
                ForsikringsFunc.ChangeForsikring(cbxKunder.SelectedItem as Kunde, cbxBiler.SelectedItem as Bilmodeller, tbReg.Text, int.Parse(tbPris.Text), int.Parse(tbFssum.Text), tbRequirements.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Fejl");
            }
        }

        private void SletForsikring_Click(object sender, RoutedEventArgs e)
        {
            try
            {
            ForsikringsFunc.FjernForsikring(dgForsikring.SelectedItem as Forsikringer);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Vælg en Forsikring og prøv igen");
            }
        }

        private void RedigerForsikring_Click(object sender, RoutedEventArgs e)
        {
            Forsikringer SelectedForsikringer = dgForsikring.SelectedItem as Forsikringer;
            if (SelectedForsikringer != null)
            {
                cbxKunder.Text = SelectedForsikringer.Kunde.ToString();
                cbxBiler.Text = SelectedForsikringer.Bilmodeller.ToString();
                tbReg.Text = SelectedForsikringer.RegNr.ToString();
                tbPris.Text = SelectedForsikringer.Pris.ToString();
                tbFssum.Text = SelectedForsikringer.FSsum.ToString();
                tbRequirements.Text = SelectedForsikringer.Requirements.ToString();
            }
        }

        private void TilføjForsikring_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                ForsikringsFunc.OpretForsikring(cbxKunder.SelectedItem as Kunde, cbxBiler.SelectedItem as Bilmodeller, tbReg.Text, decimal.Parse(tbPris.Text), decimal.Parse(tbFssum.Text), tbRequirements.Text);
                if (cbxKunder.SelectedItem == null)
                {
                    throw new Exception("Vælg en kunde");
                }
                if (cbxBiler.SelectedItem == null) 
                {
                    throw new Exception("Vælg en bil");                   
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Fejl");
            }

        }
    }
}

