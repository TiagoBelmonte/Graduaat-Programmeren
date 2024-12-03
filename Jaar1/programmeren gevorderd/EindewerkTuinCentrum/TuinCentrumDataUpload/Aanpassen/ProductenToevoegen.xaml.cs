using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using TuinCentrumUI.OfferteAanmaken;

namespace TuinCentrumUI.Aanpassen
{
    /// <summary>
    /// Interaction logic for ProductenToevoegen.xaml
    /// </summary>
    public partial class ProductenToevoegen : Window
    {
        string connectionString = @"Data Source=LAPTOP-I33SVT0O\SQLEXPRESS;Initial Catalog=Tuincentrum;Integrated Security=True;Encrypt=True;Trust Server Certificate=True";
        IFileProcessor processor;
        ITuincentrumRepository TuinRepository;
        TuincentrumManager TuinManager;
        ObservableCollection<Product> AlleProducten;
        ObservableCollection<Product> GeselecteerdeProducten;
        ObservableCollection<Product> GefilterdeProducten;
        Dictionary<Product, int> Winkelkar = new Dictionary<Product, int>();
        Dictionary<Product, int> NieuweProducten = new Dictionary<Product, int>();
        Offerte offerte = new Offerte();
        public ProductenToevoegen(Dictionary<Product,int> Winkelkar1, Offerte offerte1)
        {
            InitializeComponent();
            processor = new FileProcessor();
            TuinRepository = new TuincentrumRepository(connectionString);
            TuinManager = new TuincentrumManager(processor, TuinRepository);

            Winkelkar = Winkelkar1;
            offerte = offerte1;

            // Sorteer de productenlijst alfabetisch op de wetenschappelijke naam
            AlleProducten = new ObservableCollection<Product>(TuinManager.GeefProducten());
            GefilterdeProducten = new ObservableCollection<Product>(AlleProducten);

            AlleProductenListBox.ItemsSource = GefilterdeProducten;

            GeselecteerdeProducten = new ObservableCollection<Product>();
            GeselecteerdeProductenListBox.ItemsSource = GeselecteerdeProducten;


            foreach (Product p in Winkelkar.Keys)
            {
                GeselecteerdeProducten.Add(p);
                AlleProducten.Remove(p);
            }



        }
        private void TextboxWetNaam_TextChanged(object sender, TextChangedEventArgs e)
        {

            string filter = TextboxWetNaam.Text.ToLower();

            var gefilterde = AlleProducten
                .Where(product => product.WetenschappelijkeNaam.ToLower().Contains(filter))
                .OrderBy(product => product.WetenschappelijkeNaam);

            GefilterdeProducten.Clear();
            foreach (var product in gefilterde)
            {
                GefilterdeProducten.Add(product);
            }
        }
        private void VoegAlleProductenToeButton_Click(object sender, RoutedEventArgs e)
        {
            foreach (Product p in AlleProducten)
            {
                GeselecteerdeProducten.Add(p);
            }
            GefilterdeProducten.Clear();
        }
        private void VoegProductToeButton_Click(object sender, RoutedEventArgs e)
        {
            List<Product> producten = new List<Product>();
            foreach (Product p in AlleProductenListBox.SelectedItems)
            {
                producten.Add(p);
            }

            foreach (Product p in producten)
            {
                GeselecteerdeProducten.Add(p);
                GefilterdeProducten.Remove(p);
            }
        }
        private void VerwijderAlleProductenButton_Click(object sender, RoutedEventArgs e)
        {
            foreach (Product p in GeselecteerdeProducten)
            {
                GefilterdeProducten.Add(p);
            }
            GeselecteerdeProducten.Clear();
        }
        private void VerwijderProduct_Click(object sender, RoutedEventArgs e)
        {
            List<Product> producten = new List<Product>();
            foreach (Product p in GeselecteerdeProductenListBox.SelectedItems)
            {
                producten.Add(p);
            }

            foreach (Product p in producten)
            {
                GeselecteerdeProducten.Remove(p);
                GefilterdeProducten.Add(p);
            }
        }
        private void VolgendeVensterButton_Click(object sender, RoutedEventArgs e)
        {

            foreach (Product product in GeselecteerdeProducten)
            {
                if (!Winkelkar.ContainsKey(product))
                {
                    string input = Microsoft.VisualBasic.Interaction.InputBox($"Hoe veel {product.WetenschappelijkeNaam} Wil je kopen?", "Aantal", "0");
                    int aantal;
                    if (int.TryParse(input, out aantal) && aantal > 0)
                    {
                        NieuweProducten.Add(product, aantal);
                        offerte.Producten.Add((int)product.ID, aantal);
                        offerte.Prijs = TuinManager.BerekenPrijs(Winkelkar, !offerte.aanleg, offerte.afhaal, 0) + TuinManager.BerekenPrijs(NieuweProducten, false, false, 0);
                    }
                    else
                    {
                        MessageBox.Show("Fout, geef een getal groter dan 0 weer");
                    }
                }
            }

            OfferteAanpassen offerteAanpassen = new OfferteAanpassen(Winkelkar,NieuweProducten,offerte);
            offerteAanpassen.Show();
            this.Close();
        }
    }
}

