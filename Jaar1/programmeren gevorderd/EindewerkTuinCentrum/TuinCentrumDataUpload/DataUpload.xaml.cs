using Microsoft.Win32;
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
using TuinCentrumDL_File;
using TuinCentrumDL_SQL;
using TuinCentrumBL.Model;
using TuinCentrumUI.OfferteAanmaken;

namespace TuinCentrumUI
{
    /// <summary>
    /// Interaction logic for DataUpload.xaml
    /// </summary>
    public partial class DataUpload : Window
    {
        OpenFileDialog openFileDialog = new OpenFileDialog();
        string connectionString = @"Data Source=LAPTOP-I33SVT0O\SQLEXPRESS;Initial Catalog=Tuincentrum;Integrated Security=True;Encrypt=True;Trust Server Certificate=True";
        IFileProcessor processor;
        ITuincentrumRepository tuincentrumRepository;
        TuincentrumManager vm;
        public DataUpload()
        {
            InitializeComponent();
            openFileDialog.DefaultExt = ".txt";
            openFileDialog.Filter = "Text documents (*.txt)|*.txt";
            openFileDialog.InitialDirectory = @"C:\Users\tbelm\Documenten\programmeren gevorderd\tuin";
            openFileDialog.Multiselect = true;
            processor = new FileProcessor();
            tuincentrumRepository = new TuincentrumRepository(connectionString);
            vm = new TuincentrumManager(processor, tuincentrumRepository);
        }
        private void Button_Click_Klanten(object sender, RoutedEventArgs e)
        {
            bool? result = openFileDialog.ShowDialog();
            if (result == true)
            {
                var fileNames = openFileDialog.FileNames;
                KlantenFileListBox.ItemsSource = fileNames;
                openFileDialog.FileName = null;
                processor = new FileProcessor();
            }
        }
        private void Button_Click_UploadKlanten(object sender, RoutedEventArgs e)
        {
            foreach (string fileName in KlantenFileListBox.ItemsSource)
            {
                vm.UploadKlanten(fileName);
            }
            MessageBox.Show("Upload Klaar", "Klanten");
        }
        private void Button_Click_Offertes(object sender, RoutedEventArgs e)
        {
            bool? result = openFileDialog.ShowDialog();
            if (result == true)
            {
                var filenames = openFileDialog.FileNames;
                OffertesFileListBox.ItemsSource = filenames;
                openFileDialog.FileName = null;
            }
            else OffertesFileListBox.ItemsSource = null;
        }
        private void Button_Click_UploadOffertes(object sender, RoutedEventArgs e)
        {
            //string filename1 = OffertesFileListBox.Items[1].ToString();
            //string filename2 = OffertesFileListBox.Items[0].ToString();

            //vm.uploadOfferte(filename1, filename2);

            //MessageBox.Show("Upload klaar", "VisStats");

            List<Offerte> offertes = tuincentrumRepository.GeefOffertes();
            

            foreach (Offerte offerte in offertes)
            {
                Dictionary<Product, int> winkelkar = new Dictionary<Product, int>();
                Dictionary<int, int> Producten = new Dictionary<int, int>();
                Producten = tuincentrumRepository.GeefInfoOfferte(offerte.ID);
                foreach (int productID in Producten.Keys)
                {
                    Product product = tuincentrumRepository.GeefProductViaID(productID);
                    winkelkar.Add(product, Producten[productID]);
                }
                offerte.Prijs = vm.BerekenPrijs(winkelkar, !offerte.afhaal, offerte.aanleg, 0);
                tuincentrumRepository.UpdateOfferteInDatabase(offerte);
            }

        }
        private void Button_Click_UploadProducten(object sender, RoutedEventArgs e)
        {
            foreach (string filename in ProductenFileListBox.ItemsSource)
            {
                vm.UploadProducten(filename);
            }
            MessageBox.Show("Upload klaar", "VisStats");
        }
        private void Button_Click_Producten(object sender, RoutedEventArgs e)
        {
            bool? result = openFileDialog.ShowDialog();
            if (result == true)
            {
                var filenames = openFileDialog.FileNames;
                ProductenFileListBox.ItemsSource = filenames;
                openFileDialog.FileName = null;
            }
            else ProductenFileListBox.ItemsSource = null;
        }
        private void Button_Click_Terugkeren(object sender, RoutedEventArgs e)
        {
            // Open het startScherm opnieuw
            MainWindow start = new MainWindow();
            start.Show();

            // Sluit dit venster
            this.Close();
        }
    }
}
