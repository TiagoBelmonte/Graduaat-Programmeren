using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reflection.Emit;
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
    /// <summary>
    /// Interaction logic for ProductenSelecteren.xaml
    /// </summary>
    public partial class ProductenSelecteren : Window
    {
        string connectionString = @"Data Source=LAPTOP-I33SVT0O\SQLEXPRESS;Initial Catalog=Tuincentrum;Integrated Security=True;Encrypt=True;Trust Server Certificate=True";
        IFileProcessor processor;
        ITuincentrumRepository TuinRepository;
        TuincentrumManager TuinManager;
        ObservableCollection<Product> AlleProducten;
        ObservableCollection<Product> GeselecteerdeProducten;
        ObservableCollection<Product> GefilterdeProducten;

        public ProductenSelecteren()
        {
            InitializeComponent();
            processor = new FileProcessor();
            TuinRepository = new TuincentrumRepository(connectionString);
            TuinManager = new TuincentrumManager(processor, TuinRepository);

            // Sorteer de productenlijst alfabetisch op de wetenschappelijke naam
            AlleProducten = new ObservableCollection<Product>(TuinManager.GeefProducten());
            GefilterdeProducten = new ObservableCollection<Product>(AlleProducten);

            AlleProductenListBox.ItemsSource = GefilterdeProducten;

            GeselecteerdeProducten = new ObservableCollection<Product>();
            GeselecteerdeProductenListBox.ItemsSource = GeselecteerdeProducten;


        }
        private void TextboxWetNaam_TextChanged(object sender, TextChangedEventArgs e)
        {

            string filter = TextboxWetNaam.Text.ToLower();

            var gefilterde = AlleProducten
                .Where(product => product.WetenschappelijkeNaam.ToLower().Contains(filter))
                .OrderBy(product => product.WetenschappelijkeNaam);

            GefilterdeProducten.Clear();
            foreach (Product product in gefilterde)
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
            Dictionary<Product, int> winkelKar = new Dictionary<Product, int>();
            if (TuinRepository.HeeftKlant(TextBoxNaam.Text))
            {
                if (GeselecteerdeProducten.Count > 0)
                {


                    foreach (Product product in GeselecteerdeProducten)
                    {
                        string input = Microsoft.VisualBasic.Interaction.InputBox($"Hoe veel {product.WetenschappelijkeNaam} Wil je kopen?", "Aantal", "0");
                        int aantal;
                        if (int.TryParse(input, out aantal) && aantal > 0)
                        {
                            winkelKar.Add(product, aantal);
                        }
                        else
                        {
                            MessageBox.Show("Fout, geef een getal groter dan 0 weer");
                        }
                    }

                    OfferteStap2 stap2 = new OfferteStap2(winkelKar, TextBoxNaam.Text);
                    stap2.Show();

                    this.Close();
                }
                else
                {
                    MessageBox.Show("Je kan geen bestelling plaatsen zonder minstens 1 product te selecteren");
                }
                  
            }
            else
            {
                MessageBox.Show("Je kan geen bestelling plaatsen met deze Klant");
            }
            
        }
    }
}
