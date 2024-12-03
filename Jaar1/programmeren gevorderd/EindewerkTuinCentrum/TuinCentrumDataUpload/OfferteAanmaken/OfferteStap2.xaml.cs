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

namespace TuinCentrumUI.OfferteAanmaken
{
   
    public partial class OfferteStap2 : Window
    {
        string connectionString = @"Data Source=LAPTOP-I33SVT0O\SQLEXPRESS;Initial Catalog=Tuincentrum;Integrated Security=True;Encrypt=True;Trust Server Certificate=True";
        IFileProcessor processor;
        ITuincentrumRepository tuincentrumRepository;
        TuincentrumManager vm;
        Klant klant = new Klant();
        Dictionary<Product, int> Winkelkar = new Dictionary<Product, int>();
        double TotalePrijs = 0;
        Offerte offerte = new Offerte();
        public OfferteStap2(Dictionary<Product,int> winkelkar, String naam)
        {

            InitializeComponent();

            if (!Leveren.IsChecked.Value)
            {
                Aanleggen.Visibility = Visibility.Hidden;
            }


            processor = new FileProcessor();
            tuincentrumRepository = new TuincentrumRepository(connectionString);
            vm = new TuincentrumManager(processor, tuincentrumRepository);
            Dictionary<Product, int> Winkelkar = winkelkar;
            List<String> productenLijst = new List<string>();

            foreach (Product product1 in Winkelkar.Keys)
            {
                productenLijst.Add($"Naam: {product1.WetenschappelijkeNaam}, Prijs: {product1.Prijs}, Aantal: {Winkelkar[product1]}");
            }
            DataProducten.ItemsSource = productenLijst;
            //labels toevoegen voor info klant en die oproepen via de string naam
            Klant klant = vm.HeeftInfoKlant(naam);

            LabelNaam.Content = $"Naam: {klant.Naam}";
            LabelID.Content = $"ID: {klant.ID}";
            LabelAdres.Content = $"Adres: {klant.Adres}";
            LabelDatum.Content = DateTime.Now.ToString();

            bool leveren = false;
            bool aanlegen = false;
            TotalePrijs = vm.BerekenPrijs(Winkelkar, leveren, aanlegen, TotalePrijs);
            LabelPrijs.Content = $"Totale prijs: {TotalePrijs}";

            //Label totale prijs nog aanpassen eenmaal je prijs kan berekenen


            DateTime datum = DateTime.Now;
            int klantnr = klant.ID;
            bool Afhaal = !Leveren.IsChecked.Value;
            bool Aanleg = Aanleggen.IsChecked.Value;
            int aantal = Winkelkar.Count;
            int ID = tuincentrumRepository.GeefOffertes().Count() + 1;

            Dictionary<int, int> producten = new Dictionary<int, int>();

            foreach (Product product in Winkelkar.Keys)
            {
                producten.Add((int)product.ID, Winkelkar[product]);
            }


            offerte = new Offerte(ID, datum, klantnr, Afhaal, Aanleg, aantal, TotalePrijs, producten);


        }
        private void Afhalen_Checked(object sender, RoutedEventArgs e)
        {
            //Dit nog beter maken
            bool leveren = Leveren.IsChecked.Value;
            bool aanlegen = Aanleggen.IsChecked.Value;
            Aanleggen.Visibility = Visibility.Visible;
            LabelPrijs.Content = $"Totale prijs: {vm.BerekenPrijs(Winkelkar, leveren, aanlegen, TotalePrijs)}";

        }
        private void Aanleggen_Checked(object sender, RoutedEventArgs e)
        {
            bool leveren = Leveren.IsChecked.Value;
            bool aanlegen = Aanleggen.IsChecked.Value;
            LabelPrijs.Content = $"Totale prijs: {vm.BerekenPrijs(Winkelkar, leveren, aanlegen, TotalePrijs)}";

        }
        private void Afhalen_UnChecked(object sender, RoutedEventArgs e)
        {
            bool leveren = Leveren.IsChecked.Value;
            bool aanlegen = Aanleggen.IsChecked.Value;
            LabelPrijs.Content = $"Totale prijs: {vm.BerekenPrijs(Winkelkar, leveren, aanlegen, TotalePrijs)}";

        }
        private void Aanleggen_UnChecked(object sender, RoutedEventArgs e)
        {
            bool leveren = Leveren.IsChecked.Value;
            bool aanlegen = Aanleggen.IsChecked.Value;
            LabelPrijs.Content = $"Totale prijs: {vm.BerekenPrijs(Winkelkar, leveren, aanlegen, TotalePrijs)}";

        }
        private void Button_Click_Anulleer(object sender, RoutedEventArgs e)
        {
            // Open het startScherm opnieuw
            MainWindow start = new MainWindow();
            start.Show();

            // Sluit dit venster
            this.Close();
        }
        private void Button_Click_OffertePlaatsen(object sender, RoutedEventArgs e)
        {
            offerte.aanleg = Aanleggen.IsChecked.Value;
            offerte.afhaal = !Leveren.IsChecked.Value;
            bool leveren = Leveren.IsChecked.Value;
            bool aanlegen = Aanleggen.IsChecked.Value;
            offerte.Prijs = vm.BerekenPrijs(Winkelkar, leveren, aanlegen, TotalePrijs);
            




            tuincentrumRepository.schrijfOfferte(offerte);

            MessageBox.Show("Offerte is aangemaakt", "Tuincentrum");

            

            MainWindow start = new MainWindow();
            start.Show();

            this.Close();
        }
    }
}
