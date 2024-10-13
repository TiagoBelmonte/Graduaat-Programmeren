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
        ObservableCollection<Haven> AlleHavens;
        ObservableCollection<Haven> GeselecteerdeHavens;
        ObservableCollection<int> AlleJaren;
        ObservableCollection<int> GeselecteerdeJaren;
        ObservableCollection<string> AlleMaanden;
        ObservableCollection<string> GeselecteerdeMaanden;



        public MainWindow()
        {
            InitializeComponent();
            processor = new FileProcessor();
            visStatsRepository = new VisStatsRepository(connectionString);
            visStatsManager = new VisStatsManager(processor, visStatsRepository);
            VissoortComboBox.ItemsSource = visStatsManager.GeefVissoorten();
            VissoortComboBox.SelectedIndex = 0;

            AlleHavens = new ObservableCollection<Haven>(visStatsManager.GeefHavens());
            AlleHavensListBox.ItemsSource = AlleHavens;

            GeselecteerdeHavens = new ObservableCollection<Haven>();
            GeselecteerdeHavensListBox.ItemsSource = GeselecteerdeHavens;

            AlleJaren = new ObservableCollection<int>(visStatsManager.geefJaartallen());
            AllejarenListBox.ItemsSource = AlleJaren;

            GeselecteerdeJaren = new ObservableCollection<int>();
            GeselecteerdejarenListBox.ItemsSource = GeselecteerdeJaren;

            AlleMaanden = new ObservableCollection<string>(new List<string>() { "Januari", "Februari", "Maart", "April", "Mei", "Juni", "Juli", "Augustus", "September", "Oktober", "November", "December" });
            AlleMaandenListBox.ItemsSource = AlleMaanden;

            GeselecteerdeMaanden = new ObservableCollection<string>();
            GeselecteerdeMaandenListBox.ItemsSource = GeselecteerdeMaanden;

        }

        private void ToonStatistiekenButton_Click(object sender, RoutedEventArgs e)
        {

            Eenheid eenheid;
            List<MaandVangst> lijstMaandVangsten = new List<MaandVangst>();
            if ((bool)kgRadioButton.IsChecked) eenheid = Eenheid.kg;
            else eenheid = Eenheid.euro;

            foreach (int jaar in GeselecteerdeJaren)
            {
                foreach (string maand in GeselecteerdeMaanden)
                {
                    switch(maand)
                    {
                        case "Januari":

                            int indexMaand = 1;
                            MaandVangst mv = visStatsManager.GeefVangstMaand(jaar, GeselecteerdeHavens.ToList(), eenheid, indexMaand, (Vissoort)VissoortComboBox.SelectedItem);
                            lijstMaandVangsten.Add(mv);
                            break;
                        case "Februari":
                            indexMaand = 2;
                            mv = visStatsManager.GeefVangstMaand(jaar, GeselecteerdeHavens.ToList(), eenheid, indexMaand, (Vissoort)VissoortComboBox.SelectedItem);
                            lijstMaandVangsten.Add(mv);
                            break;
                        case "Maart":
                            indexMaand = 3;
                            mv = visStatsManager.GeefVangstMaand(jaar, GeselecteerdeHavens.ToList(), eenheid, indexMaand, (Vissoort)VissoortComboBox.SelectedItem);
                            lijstMaandVangsten.Add(mv);
                            break;
                        case "April":
                            indexMaand = 4;
                            mv = visStatsManager.GeefVangstMaand(jaar, GeselecteerdeHavens.ToList(), eenheid, indexMaand, (Vissoort)VissoortComboBox.SelectedItem);
                            lijstMaandVangsten.Add(mv);
                            break;
                        case "Mei":
                            indexMaand = 5;
                            mv = visStatsManager.GeefVangstMaand(jaar, GeselecteerdeHavens.ToList(), eenheid, indexMaand, (Vissoort)VissoortComboBox.SelectedItem);
                            lijstMaandVangsten.Add(mv);
                            break;
                        case "Juni":
                            indexMaand = 6;
                            mv = visStatsManager.GeefVangstMaand(jaar, GeselecteerdeHavens.ToList(), eenheid, indexMaand, (Vissoort)VissoortComboBox.SelectedItem);
                            lijstMaandVangsten.Add(mv);
                            break;
                        case "Juli":
                            indexMaand = 7;
                            mv = visStatsManager.GeefVangstMaand(jaar, GeselecteerdeHavens.ToList(), eenheid, indexMaand, (Vissoort)VissoortComboBox.SelectedItem);
                            lijstMaandVangsten.Add(mv);
                            break;
                        case "Augustus":
                            indexMaand = 8;
                            mv = visStatsManager.GeefVangstMaand(jaar, GeselecteerdeHavens.ToList(), eenheid, indexMaand, (Vissoort)VissoortComboBox.SelectedItem);
                            lijstMaandVangsten.Add(mv);
                            break;
                        case "September":
                            indexMaand = 9;
                            mv = visStatsManager.GeefVangstMaand(jaar, GeselecteerdeHavens.ToList(), eenheid, indexMaand, (Vissoort)VissoortComboBox.SelectedItem);
                            lijstMaandVangsten.Add(mv);
                            break;
                        case "Oktober":
                            indexMaand = 10;
                            mv = visStatsManager.GeefVangstMaand(jaar, GeselecteerdeHavens.ToList(), eenheid, indexMaand, (Vissoort)VissoortComboBox.SelectedItem);
                            lijstMaandVangsten.Add(mv);
                            break;
                        case "November":
                            indexMaand = 11;
                            mv = visStatsManager.GeefVangstMaand(jaar, GeselecteerdeHavens.ToList(), eenheid, indexMaand, (Vissoort)VissoortComboBox.SelectedItem);
                            lijstMaandVangsten.Add(mv);
                            break;
                        case "December":
                            indexMaand = 12;
                            mv = visStatsManager.GeefVangstMaand(jaar, GeselecteerdeHavens.ToList(), eenheid, indexMaand, (Vissoort)VissoortComboBox.SelectedItem);
                            lijstMaandVangsten.Add(mv);
                            break;
                    }
                }
            }

            StatistiekenWindow w = new StatistiekenWindow(GeselecteerdeHavens.ToList(),lijstMaandVangsten,eenheid, (Vissoort)VissoortComboBox.SelectedItem);
            w.ShowDialog();
        }

        private void VoegHavenToeButton_Click(object sender, RoutedEventArgs e)
        {
            List<Haven> havens = new List<Haven>();
            foreach (Haven h in AlleHavensListBox.SelectedItems)
            {
                havens.Add(h);
            }

            foreach (Haven h in havens)
            {
                GeselecteerdeHavens.Add(h);
                AlleHavens.Remove(h);
            }
        }
        

         private void VoegAlleHavensToeButton_Click(object sender, RoutedEventArgs e)
        {
            foreach (Haven haven in AlleHavens)
            {
                GeselecteerdeHavens.Add(haven);
            }
            AlleHavens.Clear();
        }

        private void VerwijderAlleHavensButton_Click(object sender, RoutedEventArgs e)
        {
            foreach (Haven haven in GeselecteerdeHavens)
            {
                AlleHavens.Add(haven);
            }
            GeselecteerdeHavens.Clear();
        }

        private void VerwijderHavenButton_Click(object sender, RoutedEventArgs e)
        {
            List<Haven> havens = new List<Haven>();
            foreach (Haven h in GeselecteerdeHavensListBox.SelectedItems)
            {
                havens.Add(h);
            }

            foreach (Haven h in havens)
            {
                GeselecteerdeHavens.Remove(h);
                AlleHavens.Add(h);
            }
        }

        private void VoegJaarToeButton_Click(object sender, RoutedEventArgs e)
        {
            List<int> jaren = new List<int>();
            foreach (int i in AllejarenListBox.SelectedItems)
            {
                jaren.Add(i);
            }

            foreach (int i in jaren)
            {
                GeselecteerdeJaren.Add(i);
                AlleJaren.Remove(i);
            }
        }

        private void VoegAllejarenToeButton_Click(object sender, RoutedEventArgs e)
        {
            foreach (int jaar in AlleJaren)
            {
                GeselecteerdeJaren.Add(jaar);
            }
            AlleJaren.Clear();
        }

        private void VerwijderJaarButton_Click(object sender, RoutedEventArgs e)
        {
            List<int> jaren = new List<int>();
            foreach (int j in GeselecteerdejarenListBox.SelectedItems)
            {
                jaren.Add(j);
            }

            foreach (int jaar in jaren)
            {
                GeselecteerdeJaren.Remove(jaar);
                AlleJaren.Add(jaar);
            }
        }

        private void VerwijderAllejarenButton_Click(object sender, RoutedEventArgs e)
        {
            foreach (int jaar in GeselecteerdeJaren)
            {
                AlleJaren.Add(jaar);
            }
            GeselecteerdeJaren.Clear();
        }

        private void VoegMaandToeButton_Click(object sender, RoutedEventArgs e)
        {
            List<string> maanden = new List<string>();
            foreach (string s in AlleMaandenListBox.SelectedItems)
            {
                maanden.Add(s);
            }

            foreach (string s in maanden)
            {
                GeselecteerdeMaanden.Add(s);
                AlleMaanden.Remove(s);
            }
        }

        private void VoegAlleMaandenToeButton_Click(object sender, RoutedEventArgs e)
        {
            foreach (string maand in AlleMaanden)
            {
                GeselecteerdeMaanden.Add(maand);
            }
            AlleMaanden.Clear();
        }

        private void VerwijderMaandButton_Click(object sender, RoutedEventArgs e)
        {
            List<string> maanden = new List<string>();
            foreach (string s in GeselecteerdeMaandenListBox.SelectedItems)
            {
                maanden.Add(s);
            }

            foreach (string maand in maanden)
            {
                GeselecteerdeMaanden.Remove(maand);
                AlleMaanden.Add(maand);
            }
        }

        private void VerwijderAlleMaandenButton_Click(object sender, RoutedEventArgs e)
        {
            foreach (string maand in GeselecteerdeMaanden)
            {
                AlleMaanden.Add(maand);
            }
            GeselecteerdeMaanden.Clear();
        }
    }
}