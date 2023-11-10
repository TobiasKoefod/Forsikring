using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net;
using System.Reflection.Metadata;
using System.Windows;
using System.Xml.Linq;
using ForsikringsClasses;
using NP_ForsikringsFunc;
namespace Forsikring
{
    public partial class MainWindow : Window, INotifyPropertyChanged
    {

        public ForsikringsFunc ForsikringsFunc { get; set; } = new ForsikringsFunc();

        public event PropertyChangedEventHandler? PropertyChanged;


        private Kunde SelectedKunde;
        public MainWindow()
        {
            InitializeComponent();
            DataContext = this;
        }

        // -----------------------------------

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

        // -----------------------------------

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

        // -----------------------------------

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
        } // Tilføj Forsikring
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
        } // Sletter Forsikring
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
        } // rediger Forsikring

        // -----------------------------------

        private void weatherBTNcheck_Click(object sender, RoutedEventArgs e) // Vejr Tjekker
        {
            try
            {
                string location = LocationTextBox.Text;
                string xmlContent = GetWeather(location);
                XDocument document = XDocument.Parse(xmlContent);
                XElement temperatureElement = document.Descendants("temperature").FirstOrDefault();
                XElement windElementElement = document.Descendants("wind").FirstOrDefault();
                // vind values
                if (windElementElement != null)
                {
                    string windSpeed = windElementElement.Element("speed").Attribute("value").Value;
                    string windBehavior = windElementElement.Element("speed").Attribute("name").Value;
                    speed.Text = (windSpeed + "m/s");
                    opførsel.Text = windBehavior;
                }
                // temperature values
                if (temperatureElement != null)
                {
                    string temperatureValue = temperatureElement.Attribute("value").Value;
                    string temperatureMin = temperatureElement.Attribute("min").Value;
                    string temperatureMax = temperatureElement.Attribute("max").Value;
                    gnst.Text = temperatureValue;
                    min.Text = temperatureMin;
                    max.Text = temperatureMax;
                }
                else
                {
                    MessageBox.Show("Fejl.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Husk at skrive navet på en by!");
            }
        }
        private string GetWeather(string location) // Vejr API KEY + xmlContent
        {
            string APIKEY = "b90eb4e2357c87f8821b0c865c88abff";
            string ApiUrl = $"http://api.openweathermap.org/data/2.5/weather?q={location}&mode=xml&units=metric&APPID={APIKEY}";
            using (WebClient client = new WebClient())
            {
                string xmlContent = client.DownloadString(ApiUrl);
                return xmlContent;
            }
        }

        // -----------------------------------
    }
}

