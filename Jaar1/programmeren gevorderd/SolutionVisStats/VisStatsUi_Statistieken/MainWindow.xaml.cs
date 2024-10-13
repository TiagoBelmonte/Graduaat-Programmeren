using System.Collections.ObjectModel;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using VisStatsBL.Interfaces;
using VisStatsBL.Managers;
using VisStatsBL.Model;
using VisStatsDL_File;
using VisStatsDL_SQL;

namespace VisStatsUi_Statistieken
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        string connectionString = @"Data Source=LAPTOP-I33SVT0O\SQLEXPRESS;Initial Catalog=VisStats;Integrated Security=True;Encrypt=True;Trust Server Certificate=True";
        IFileProcessor processor;
        IVisStatsRepository visStatsRepository;
        VisStatsManager visStatsManager;
        ObservableCollection<Vissoort> AlleVissoorten;
        ObservableCollection<Vissoort> GeselecteerdeVissoorten;

        public MainWindow()
        {
            InitializeComponent();
            processor = new FileProcessor();
            visStatsRepository = new VisStatsRepository(connectionString);
            visStatsManager = new VisStatsManager(processor, visStatsRepository);
            HavensComboBox.ItemsSource = visStatsManager.GeefHavens();
            HavensComboBox.SelectedIndex = 0;

            JaarComboBox.ItemsSource = visStatsManager.geefJaartallen();
            JaarComboBox.SelectedIndex = 0;
            AlleVissoorten = new ObservableCollection<Vissoort>(visStatsManager.GeefVissoorten());
            AlleSoortenListBox.ItemsSource = AlleVissoorten;

            GeselecteerdeVissoorten = new ObservableCollection<Vissoort>();
            GeselecteerdeSoortenListBox.ItemsSource= GeselecteerdeVissoorten;

        }

        private void ToonStatistiekenButton_Click(object sender, RoutedEventArgs e)
        {
            Eenheid eenheid;
            if ((bool)kgRadioButton.IsChecked) eenheid = Eenheid.kg; else eenheid = Eenheid.euro;
            List<JaarVangst> vangst = visStatsManager.GeefVangst((int)JaarComboBox.SelectedItem, (Haven)
                HavensComboBox.SelectedItem, GeselecteerdeVissoorten.ToList(), eenheid);
            StatistiekenWindow w = new StatistiekenWindow((Haven)HavensComboBox.SelectedItem, (int)
                JaarComboBox.SelectedItem, eenheid, vangst);
            w.ShowDialog();
        }

        private void VoegSoortenToeButton_Click(object sender, RoutedEventArgs e)
        {
            List<Vissoort> soorten = new List<Vissoort>();
            foreach (Vissoort v in AlleSoortenListBox.SelectedItems)
            {
                soorten.Add(v);
            }

            foreach(Vissoort v in soorten)
            { 
                GeselecteerdeVissoorten.Add(v);
                AlleVissoorten.Remove(v);
            }
        }
        

         private void VoegAlleSoortenToeButton_Click(object sender, RoutedEventArgs e)
        {
            foreach (Vissoort vis in AlleVissoorten)
            {
                GeselecteerdeVissoorten.Add(vis);
            }
            AlleVissoorten.Clear();
        }

        private void VerwijderAlleSoortenButton_Click(object sender, RoutedEventArgs e)
        {
            foreach (Vissoort vis in GeselecteerdeVissoorten)
            {
                AlleVissoorten.Add(vis);
            }
            GeselecteerdeVissoorten.Clear();
        }

        private void VerwijderSoortenButton_Click(object sender, RoutedEventArgs e)
        {
            List<Vissoort> soorten = new List<Vissoort>();
            foreach (Vissoort v in GeselecteerdeSoortenListBox.SelectedItems)
            {
                soorten.Add(v);
            }

            foreach (Vissoort v in soorten)
            {
                GeselecteerdeVissoorten.Remove(v);
                AlleVissoorten.Add(v);
            }
        }
    }
}