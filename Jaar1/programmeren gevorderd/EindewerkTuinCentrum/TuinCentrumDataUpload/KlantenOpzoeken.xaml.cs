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
    /// Interaction logic for KlantenOpzoeken.xaml
    /// </summary>
    public partial class KlantenOpzoeken : Window
    {
        string connectionString = @"Data Source=LAPTOP-I33SVT0O\SQLEXPRESS;Initial Catalog=Tuincentrum;Integrated Security=True;Encrypt=True;Trust Server Certificate=True";
        IFileProcessor processor;
        ITuincentrumRepository tuincentrumRepository;
        TuincentrumManager vm;
        public KlantenOpzoeken()
        {
            InitializeComponent();

            processor = new FileProcessor();
            tuincentrumRepository = new TuincentrumRepository(connectionString);
            vm = new TuincentrumManager(processor, tuincentrumRepository);
        }

        public KlantenOpzoeken(Klant klant)
        {
            InitializeComponent();

            processor = new FileProcessor();
            tuincentrumRepository = new TuincentrumRepository(connectionString);
            vm = new TuincentrumManager(processor, tuincentrumRepository);

            LabelNaam.Content = $"Naam: {klant.Naam}";
            LabelID.Content = $"KlantenNummer: {klant.ID}";
            LabelAdres.Content = $"Adres: {klant.Adres}";
            TextboxID.Text = "";
            ListBoxOffertes.ItemsSource = tuincentrumRepository.GeefOfferteViaKlantID(klant.ID);
            LabelAantalOffertes.Content = $"Aantal Offertes: {ListBoxOffertes.Items.Count}";
            TextboxID.Visibility = Visibility.Hidden;
            BtnZoekt.Visibility = Visibility.Hidden;
            LabelID.Margin = new Thickness(10, 20, 0, 0);
            LabelNaam.Margin = new Thickness(10, 50, 0, 0);
            LabelAdres.Margin = new Thickness(10, 90, 0, 0);
            this.Width = 300;
        }

        private void Button_Click_ZoekenID(object sender, RoutedEventArgs e)
        {
            if (tuincentrumRepository.HeeftKlantID(Convert.ToInt32(TextboxID.Text)))
            {

                Klant klant = vm.HeeftInfoKlantID(Convert.ToInt32(TextboxID.Text));
                LabelNaam.Content = $"Naam: {klant.Naam}";
                LabelID.Content = $"KlantenNummer: {klant.ID}";
                LabelAdres.Content = $"Adres: {klant.Adres}";
                TextboxID.Text = "";
                ListBoxOffertes.ItemsSource = tuincentrumRepository.GeefOfferteViaKlantID(klant.ID);
                LabelAantalOffertes.Content = $"Aantal Offertes: {ListBoxOffertes.Items.Count}";
            }
            else
            {
                MessageBox.Show("Klant met deze id zit niet in de databank");
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
       
    }
}
