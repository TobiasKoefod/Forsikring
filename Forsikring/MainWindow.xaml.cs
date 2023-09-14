﻿using System.ComponentModel;
using System.Windows;
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
        private void Tilføj_Click(object sender, RoutedEventArgs e)
        {
            ForsikringsFunc.OpretKunde(tbFornavn.Text, tbEfternavn.Text, tbAdresse.Text, int.Parse(tbPostnummer.Text), int.Parse(tbTelefon.Text));
        }

        private void SletBTN_Click(object sender, RoutedEventArgs e)
        {
            ForsikringsFunc.FjernKunde(dgKunder.SelectedItem as Kunde);
        }

        private void RedigerBTN_Click(object sender, RoutedEventArgs e)
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

        private void GemBTN_Click(object sender, RoutedEventArgs e)
        {
            ForsikringsFunc.ChangeKunde(dgKunder.SelectedItem as Kunde, tbFornavn.Text, tbEfternavn.Text, tbAdresse.Text, int.Parse(tbPostnummer.Text), int.Parse(tbTelefon.Text));
        }
    }
}

