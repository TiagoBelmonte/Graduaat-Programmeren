using System;
using System.Collections.Generic;
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

namespace TuinCentrumUI.Aanpassen
{
    /// <summary>
    /// Interaction logic for OfferteAanpassen.xaml
    /// </summary>
    public partial class OfferteAanpassen : Window
    {
        Dictionary<Product, int> Winkelkar = new Dictionary<Product, int>();
        Dictionary<Product, int> VerwijderdProducten = new Dictionary<Product, int>();
        Dictionary<Product, int> NieuweProducten = new Dictionary<Product, int>();
        TuincentrumManager vm;
        IFileProcessor processor;
        List<String> productenLijst = new List<string>();
        Offerte offerte = new Offerte();
        double TotalePrijs = 0;
        bool leveren = false;
        bool aanlegen = false;
        double prijsNieuweProducten = 0;


        ITuincentrumRepository tuincentrumRepository;
        string connectionString = @"Data Source=LAPTOP-I33SVT0O\SQLEXPRESS;Initial Catalog=Tuincentrum;Integrated Security=True;Encrypt=True;Trust Server Certificate=True";
        public OfferteAanpassen(Offerte offerte1)
        {
            InitializeComponent();
            processor = new FileProcessor();
            tuincentrumRepository = new TuincentrumRepository(connectionString);
            vm = new TuincentrumManager(processor, tuincentrumRepository);
            offerte = offerte1;

            Winkelkar = tuincentrumRepository.GeefProductenViaID(offerte.ID);


            if (!CheckLeveren.IsChecked.Value)
            {
                CheckAanleg.Visibility = Visibility.Hidden;
            }

            foreach (Product product1 in Winkelkar.Keys)
            {
                productenLijst.Add($"Naam: {product1.WetenschappelijkeNaam}, Prijs: {product1.Prijs}, Aantal: {Winkelkar[product1]}");
            }
            ListProducten.ItemsSource = productenLijst;

            LabelOfferteIDInvull.Content = offerte.ID;
            TextDatum.Text = offerte.Datum.ToString();
            TextKlantnummer.Text = offerte.klantnummer.ToString();
            LabelPrijsAanvul.Content = offerte.Prijs;
            CheckLeveren.IsChecked = !offerte.afhaal;
            CheckAanleg.IsChecked = offerte.aanleg;



        }

        public OfferteAanpassen(Dictionary<Product, int> winkelkar, Dictionary<Product, int> nieuweProducten, Offerte offerte1)
        {
            InitializeComponent();
            processor = new FileProcessor();
            tuincentrumRepository = new TuincentrumRepository(connectionString);
            vm = new TuincentrumManager(processor, tuincentrumRepository);
            offerte = offerte1;
            Winkelkar = winkelkar;
            NieuweProducten = nieuweProducten;


            if (!CheckLeveren.IsChecked.Value)
            {
                CheckAanleg.Visibility = Visibility.Hidden;
            }

            foreach (Product product1 in Winkelkar.Keys)
            {
                productenLijst.Add($"Naam: {product1.WetenschappelijkeNaam}, Prijs: {product1.Prijs}, Aantal: {Winkelkar[product1]}");
            }
            foreach (Product product1 in NieuweProducten.Keys)
            {
                productenLijst.Add($"Naam: {product1.WetenschappelijkeNaam}, Prijs: {product1.Prijs}, Aantal: {NieuweProducten[product1]}");
            }
            ListProducten.ItemsSource = productenLijst;

            LabelOfferteIDInvull.Content = offerte.ID;
            TextDatum.Text = offerte.Datum.ToString();
            TextKlantnummer.Text = offerte.klantnummer.ToString();
            LabelPrijsAanvul.Content = offerte.Prijs;
            CheckLeveren.IsChecked = !offerte.afhaal;
            CheckAanleg.IsChecked = offerte.aanleg;

        }
        private void Afhalen_Checked(object sender, RoutedEventArgs e)
        {
            //Dit nog beter maken
            bool leveren = CheckLeveren.IsChecked.Value;
            bool aanlegen = CheckAanleg.IsChecked.Value;
            prijsNieuweProducten = 0;
            if (NieuweProducten.Count > 0)
            {
                prijsNieuweProducten = vm.BerekenPrijs(NieuweProducten, false, false, 0);
            }
            LabelPrijsAanvul.Content = vm.BerekenPrijs(Winkelkar, leveren, aanlegen, TotalePrijs) + prijsNieuweProducten;
            CheckAanleg.Visibility = Visibility.Visible;

        }
        private void Aanleggen_Checked(object sender, RoutedEventArgs e)
        {
            leveren = CheckLeveren.IsChecked.Value;
            aanlegen = CheckAanleg.IsChecked.Value;
            prijsNieuweProducten = 0;
            if (NieuweProducten.Count > 0)
            {
                prijsNieuweProducten = vm.BerekenPrijs(NieuweProducten, false, false, 0);
            }
            LabelPrijsAanvul.Content = vm.BerekenPrijs(Winkelkar, leveren, aanlegen, TotalePrijs) + prijsNieuweProducten;


        }
        private void Afhalen_UnChecked(object sender, RoutedEventArgs e)
        {
            //Dit nog beter maken
            leveren = CheckLeveren.IsChecked.Value;
            aanlegen = CheckAanleg.IsChecked.Value;
            prijsNieuweProducten = 0;
            if (NieuweProducten.Count > 0)
            {
                prijsNieuweProducten = vm.BerekenPrijs(NieuweProducten, false, false, 0);
            }
            LabelPrijsAanvul.Content = vm.BerekenPrijs(Winkelkar, leveren, aanlegen, TotalePrijs) + prijsNieuweProducten;
        }
        private void Aanleggen_UnChecked(object sender, RoutedEventArgs e)
        {

            leveren = CheckLeveren.IsChecked.Value;
            aanlegen = CheckAanleg.IsChecked.Value;
            prijsNieuweProducten = 0;
            if (NieuweProducten.Count > 0)
            {
                prijsNieuweProducten = vm.BerekenPrijs(NieuweProducten, false, false, 0);
            }
            LabelPrijsAanvul.Content = vm.BerekenPrijs(Winkelkar, leveren, aanlegen, TotalePrijs) + prijsNieuweProducten;
        }
        private void ButtonAantalAanpassen_Click(object sender, RoutedEventArgs e)
        {
            if (ListProducten.SelectedItem != null)
            {
                int selectedIndex = ListProducten.SelectedIndex;
                Product product = new Product();
                if (selectedIndex < Winkelkar.Keys.Count)
                {
                    product = Winkelkar.Keys.ElementAt(selectedIndex);
                }
                else
                { 
                    product = NieuweProducten.Keys.ElementAt(selectedIndex - Winkelkar.Count);
                }
                string input = Microsoft.VisualBasic.Interaction.InputBox($"Hoe veel {product.WetenschappelijkeNaam} wil je kopen?", "Aantal", "0");
                int aantal;
                if (int.TryParse(input, out aantal) && aantal > 0)
                {
                    if (Winkelkar.ContainsKey(product))
                    {
                        Winkelkar[product] = aantal;
                    }
                    else
                    {
                        NieuweProducten[product] = aantal;
                    }
                        

                    // Maak een nieuwe lijst voor de bijgewerkte items
                    List<string> bijgewerkteProductenLijst = new List<string>();

                    foreach (Product product1 in Winkelkar.Keys)
                    {
                        bijgewerkteProductenLijst.Add($"Naam: {product1.WetenschappelijkeNaam}, Prijs: {product1.Prijs}, Aantal: {Winkelkar[product1]}");
                    }
                    foreach (Product product1 in NieuweProducten.Keys)
                    {
                        bijgewerkteProductenLijst.Add($"Naam: {product1.WetenschappelijkeNaam}, Prijs: {product1.Prijs}, Aantal: {NieuweProducten[product1]}");
                    }
                    // Wijs de nieuwe lijst opnieuw toe aan de ItemsSource van ListProducten
                    ListProducten.ItemsSource = bijgewerkteProductenLijst;

                    // Update de prijs
                    bool leveren = CheckLeveren.IsChecked.Value;
                    bool aanlegen = CheckAanleg.IsChecked.Value;
                    TotalePrijs = 0;
                    prijsNieuweProducten = 0;
                    if (NieuweProducten.Count > 0)
                    {
                        prijsNieuweProducten = vm.BerekenPrijs(NieuweProducten, false, false, 0);
                    }
                    LabelPrijsAanvul.Content = vm.BerekenPrijs(Winkelkar, leveren, aanlegen, TotalePrijs) + prijsNieuweProducten;
                }
                else
                {
                    MessageBox.Show("Fout, geef een getal groter dan 0 weer");
                }
            }
            else
            {
                MessageBox.Show("Selecteer een product uit de lijst.");
            }
        }
        private void ButtonProductVerwijderen_Click(object sender, RoutedEventArgs e)
        {
            if (ListProducten.Items.Count>0)
            {
                if (ListProducten.SelectedItem != null)
                {
                    int selectedIndex = ListProducten.SelectedIndex;
                    Product product = new Product();
                    if (selectedIndex < Winkelkar.Keys.Count)
                    {
                        product = Winkelkar.Keys.ElementAt(selectedIndex);
                        //Voeg het product toe aan nieuwe dictionary
                        VerwijderdProducten.Add(product, Winkelkar[product]);
                        //Verwijder het product
                        Winkelkar.Remove(product);
                    }
                    else
                    {
                        product = NieuweProducten.Keys.ElementAt(selectedIndex-Winkelkar.Count);
                        //Voeg het product toe aan nieuwe dictionary
                        VerwijderdProducten.Add(product, NieuweProducten[product]);
                        //Verwijder het product
                        NieuweProducten.Remove(product);
                    }
                    

                    // Maak een nieuwe lijst voor de bijgewerkte items
                    List<string> bijgewerkteProductenLijst = new List<string>();

                    foreach (Product product1 in Winkelkar.Keys)
                    {
                        bijgewerkteProductenLijst.Add($"Naam: {product1.WetenschappelijkeNaam}, Prijs: {product1.Prijs}, Aantal: {Winkelkar[product1]}");
                    }
                    foreach (Product product1 in NieuweProducten.Keys)
                    {
                        bijgewerkteProductenLijst.Add($"Naam: {product1.WetenschappelijkeNaam}, Prijs: {product1.Prijs}, Aantal: {NieuweProducten[product1]}");
                    }
                    // Wijs de nieuwe lijst opnieuw toe aan de ItemsSource van ListProducten
                    ListProducten.ItemsSource = bijgewerkteProductenLijst;

                    // Update de prijs
                    bool leveren = CheckLeveren.IsChecked.Value;
                    bool aanlegen = CheckAanleg.IsChecked.Value;
                    TotalePrijs = 0;
                    prijsNieuweProducten = 0;
                    if (NieuweProducten.Count > 0)
                    {
                        prijsNieuweProducten = vm.BerekenPrijs(NieuweProducten, false, false, 0);
                    }
                    LabelPrijsAanvul.Content = vm.BerekenPrijs(Winkelkar, leveren, aanlegen, TotalePrijs) + prijsNieuweProducten;
                }

                else
                {
                    MessageBox.Show("Selecteer een product uit de lijst.");
                }
            }
            else
            {
                MessageBox.Show("Je Moet minstens 1 product in je offerte over hebben");
            }
        }
        private void ButtonProductenToevoegen_Click(object sender, RoutedEventArgs e)
        {
            ProductenToevoegen productenToevoegen = new ProductenToevoegen(Winkelkar, offerte);
            productenToevoegen.Show();
            this.Close();
        }
        private void ButtonOfferteAanpassen_Click(object sender, RoutedEventArgs e)
        {
            Dictionary<int,int>NieuweProductenInt = new Dictionary<int,int>();
            foreach (Product product in NieuweProducten.Keys)
            {
                NieuweProductenInt.Add((int)product.ID, NieuweProducten[product]);
            }

            Dictionary<int, int> VerwijderdProductenInt = new Dictionary<int, int>();
            foreach (Product product in VerwijderdProducten.Keys)
            {
                VerwijderdProductenInt.Add((int)product.ID, VerwijderdProducten[product]);
            }
            offerte.Producten.Clear();
            foreach (Product product in Winkelkar.Keys)
            {
                offerte.Producten.Add((int)product.ID, Winkelkar[product]);
            }

            offerte.Aantal = offerte.Producten.Count + NieuweProducten.Count;
            offerte.klantnummer = int.Parse(TextKlantnummer.Text);
            prijsNieuweProducten = 0;
            if (NieuweProducten.Count > 0)
            {
                prijsNieuweProducten = vm.BerekenPrijs(NieuweProducten, false, false, 0);
            }
            offerte.Prijs = vm.BerekenPrijs(Winkelkar, leveren, aanlegen, TotalePrijs) + prijsNieuweProducten;
            offerte.Datum = DateTime.Parse(TextDatum.Text);
            offerte.afhaal = !CheckLeveren.IsChecked.Value;
            offerte.aanleg = CheckAanleg.IsChecked.Value;

            vm.UpdateOfferte(offerte, NieuweProductenInt, VerwijderdProductenInt);
            MessageBox.Show("Offerte Geupdate in je databank");
            this.Close();
        }
    }
}

