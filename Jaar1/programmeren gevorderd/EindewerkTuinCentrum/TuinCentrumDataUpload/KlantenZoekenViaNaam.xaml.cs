using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using TuinCentrumBL.Interfaces;
using TuinCentrumBL.manager;
using TuinCentrumBL.Model;
using TuinCentrumDL_File;
using TuinCentrumDL_SQL;
using TuinCentrumUI.Aanpassen;

namespace TuinCentrumUI
{
    /// <summary>
    /// Interaction logic for KlantenZoekenViaNaam.xaml
    /// </summary>
    public partial class KlantenZoekenViaNaam : Window
    {
        string connectionString = @"Data Source=LAPTOP-I33SVT0O\SQLEXPRESS;Initial Catalog=Tuincentrum;Integrated Security=True;Encrypt=True;Trust Server Certificate=True";
        ObservableCollection<Klant> AlleKlanten;
        ObservableCollection<Klant> GefilterdeKlanten;
        TuincentrumManager TuinManager;
        IFileProcessor processor;
        ITuincentrumRepository TuinRepository;
        bool offerteZoeken = false;

        public KlantenZoekenViaNaam()
        {
            InitializeComponent();
            processor = new FileProcessor();
            TuinRepository = new TuincentrumRepository(connectionString);
            TuinManager = new TuincentrumManager(processor, TuinRepository);
            AlleKlanten = new ObservableCollection<Klant>(TuinManager.GeefKlanten());
            GefilterdeKlanten = new ObservableCollection<Klant>();
            ListBoxKlanten.ItemsSource = GefilterdeKlanten;
        }
        public KlantenZoekenViaNaam(bool OfferteZoeken)
        {
            InitializeComponent();
            processor = new FileProcessor();
            TuinRepository = new TuincentrumRepository(connectionString);
            TuinManager = new TuincentrumManager(processor, TuinRepository);
            AlleKlanten = new ObservableCollection<Klant>(TuinManager.GeefKlanten());
            GefilterdeKlanten = new ObservableCollection<Klant>();
            ListBoxKlanten.ItemsSource = GefilterdeKlanten;
            offerteZoeken = OfferteZoeken;

        }

        private void TextboxNaam_Changed(object sender, TextChangedEventArgs e)
        {
            string filter = TextBoxNaam.Text.ToLower();

            if (string.IsNullOrWhiteSpace(filter))
            {
                GefilterdeKlanten.Clear();
            }
            else
            {
                var gefilterde = AlleKlanten
                    .Where(klant => klant.Naam.ToLower().Contains(filter))
                    .OrderBy(klant => klant.Naam);

                GefilterdeKlanten.Clear();
                foreach (Klant klant in gefilterde)
                {
                    GefilterdeKlanten.Add(klant);
                }
            }
        }

        private void ButtonMainMenu_Click(object sender, RoutedEventArgs e)
        {
            // Open het startScherm opnieuw
            MainWindow start = new MainWindow();
            start.Show();

            // Sluit dit venster
            this.Close();
        }

        private void ListKlanten_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (offerteZoeken)
            {
                Klant klant = ListBoxKlanten.SelectedItem as Klant;
                OfferteOpzoeken offerteZoeken = new OfferteOpzoeken(klant);
                offerteZoeken.Show();

                this.Close();
            }
            else
            {
                Klant klant = ListBoxKlanten.SelectedItem as Klant;
                KlantenOpzoeken klantenOpzoeken = new KlantenOpzoeken(klant);
                klantenOpzoeken.Show();

                this.Close();
            }
            
        }
    }
}
