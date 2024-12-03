using System;
using System.Collections.Generic;
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
    /// Interaction logic for OfferteOpzoeken.xaml
    /// </summary>
    public partial class OfferteOpzoeken : Window
    {
        string connectionString = @"Data Source=LAPTOP-I33SVT0O\SQLEXPRESS;Initial Catalog=Tuincentrum;Integrated Security=True;Encrypt=True;Trust Server Certificate=True";
        IFileProcessor processor;
        ITuincentrumRepository tuincentrumRepository;
        TuincentrumManager vm;
        Klant klant = new Klant();
        int optie = 0;
        public OfferteOpzoeken(int optieGetal)
        {
            InitializeComponent();
            optie = optieGetal;
            processor = new FileProcessor();
            tuincentrumRepository = new TuincentrumRepository(connectionString);
            vm = new TuincentrumManager(processor, tuincentrumRepository);
            if (optie == 1)
            {
                TextboxID.Visibility = Visibility.Visible;
                TextboxNaam.Visibility = Visibility.Hidden;
                DatumSelector.Visibility = Visibility.Hidden;
            }
            if (optie == 2)
            {
                TextboxID.Visibility = Visibility.Hidden;
                TextboxNaam.Visibility = Visibility.Visible;
                DatumSelector.Visibility = Visibility.Hidden;
            }
            if (optie == 3)
            {
                TextboxID.Visibility = Visibility.Hidden;
                TextboxNaam.Visibility = Visibility.Hidden;
                DatumSelector.Visibility = Visibility.Visible;
            }
        }

        public OfferteOpzoeken(Klant klant)
        {
            InitializeComponent();
            processor = new FileProcessor();
            tuincentrumRepository = new TuincentrumRepository(connectionString);
            vm = new TuincentrumManager(processor, tuincentrumRepository);

            TextboxNaam.Text = klant.Naam.ToString();
            TextboxNaam.IsReadOnly = true;
            DatumSelector.Visibility = Visibility.Hidden;
            TextboxID.Visibility = Visibility.Hidden;
            btnZoeken.Visibility = Visibility.Hidden;



            ListOffertes.ItemsSource = tuincentrumRepository.GeefOfferteViaKlantID(klant.ID);
        }
        private void Button_Click_Zoeken(object sender, RoutedEventArgs e)
        {

            if (optie == 1)
            {
                ListOffertes.ItemsSource = tuincentrumRepository.GeefOffertesViaID(Convert.ToInt32(TextboxID.Text));
            }
            else if (optie == 3)
            {
                ListOffertes.ItemsSource = tuincentrumRepository.GeefOffertesViaDatum(DatumSelector.SelectedDate.Value);
            }

        }
        private void Button_Click_MainMenu(object sender, RoutedEventArgs e)
        {
            // Open het startScherm opnieuw
            MainWindow start = new MainWindow();
            start.Show();

            // Sluit dit venster
            this.Close();
        }
        private void ListOffertes_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (ListOffertes.SelectedItem is Offerte selectedOfferte)
            {
                OfferteAanpassen offerteAanpassen = new OfferteAanpassen(selectedOfferte);
                offerteAanpassen.Show();
            }
        }
    }
}
