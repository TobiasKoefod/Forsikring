using System.ComponentModel;
using System.Windows;
using NP_ForsikringsFunc;
namespace Forsikring
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
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
            dgKunder.Items.Refresh();
        }

        private void SletBTN_Click(object sender, RoutedEventArgs e)
        {
            ForsikringsFunc.FjernKunde(SelectedKunde);
        }
    }
}

