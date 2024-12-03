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
using TuinCentrumUI.OfferteAanmaken;

namespace TuinCentrumUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        private void Button_Click_DataUploaden(object sender, RoutedEventArgs e)
        {
            // Open het DataUpload scherm
            DataUpload dataWindow = new DataUpload();
            dataWindow.Show();

            // Sluit dit venster
            this.Close();
        }

        private void Button_Click_KlantenOpzoeken(object sender, RoutedEventArgs e)
        {
            string optie = Microsoft.VisualBasic.Interaction.InputBox("Geef in hoe je de Klant wilt opzoeken:\n1. KlantNummer\n2. Naam van klant", "Klant Opzoeken");
            int optieGetal = int.Parse(optie);

            // Controleer of de gebruiker een optie heeft geselecteerd
            if (!string.IsNullOrEmpty(optie))
            {
                if (optieGetal == 1)
                {
                    // Doorgaan naar het andere scherm en de geselecteerde optie doorgeven
                    KlantenOpzoeken klantenZoeken = new KlantenOpzoeken();
                    klantenZoeken.Show();

                    this.Close();
                }
                if (optieGetal == 2)
                {
                    // Doorgaan naar het andere scherm en de geselecteerde optie doorgeven
                    KlantenZoekenViaNaam klantZoeken = new KlantenZoekenViaNaam();
                    klantZoeken.Show();

                    this.Close();
                }

            }
            else
            {
                MessageBox.Show("Selecteer een methode hoe je de offertes wilt opzoeken");
            }

            
        }
        private void Button_Click_OfferteOpvragen(object sender, RoutedEventArgs e)
        {
            // Toon de inputbox en vraag de gebruiker om een optie te selecteren
            string optie  = Microsoft.VisualBasic.Interaction.InputBox("Geef in hoe je de offertes wilt opzoeken:\n1. OfferteNummer\n2. Naam van klant\n3. Datum van offerte", "Offerte Zoeken");
            int optieGetal = int.Parse(optie);

            // Controleer of de gebruiker een optie heeft geselecteerd
            if (!string.IsNullOrEmpty(optie))
            {
                if (optieGetal == 2)
                {
                    bool offerteZoeken = true;
                    KlantenZoekenViaNaam klantenZoeken = new KlantenZoekenViaNaam(offerteZoeken);
                    klantenZoeken.Show();
                    this.Close();
                }
                else
                {
                    // Doorgaan naar het andere scherm en de geselecteerde optie doorgeven
                    OfferteOpzoeken offerteZoeken = new OfferteOpzoeken(optieGetal);
                    offerteZoeken.Show();

                    this.Close();
                }
                
            }
            else
            {
                MessageBox.Show("Selecteer een methode hoe je de offertes wilt opzoeken");
            }

            
        }
        private void Button_ClickOfferteAanmaken(object sender, RoutedEventArgs e)
        {
            ProductenSelecteren productenSelecteren = new ProductenSelecteren();
            productenSelecteren.Show();

            this.Close();
        }
    }
}
