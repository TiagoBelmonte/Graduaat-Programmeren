using Microsoft.Win32;
using System.Reflection;
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
using VisStatsDL_File;
using VisStatsDL_SQL;

namespace VisStatsUI_DataUpload
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        OpenFileDialog openFileDialog = new OpenFileDialog();
        string connectionString = @"Data Source=LAPTOP-I33SVT0O\SQLEXPRESS;Initial Catalog=VisStats;Integrated Security=True;Encrypt=True;Trust Server Certificate=True";
        IFileProcessor processor;
        IVisStatsRepository visStatsRepository;
        VisStatsManager vm;
        public MainWindow()
        {
            InitializeComponent();
            openFileDialog.DefaultExt = ".txt";
            openFileDialog.Filter = "Text documents (*.txt)|*.txt";
            openFileDialog.InitialDirectory = @"C:\Users\tbelm\Downloads\Vis";
            openFileDialog.Multiselect = true;
            processor = new FileProcessor();
            visStatsRepository = new VisStatsRepository(connectionString);
            vm = new VisStatsManager(processor, visStatsRepository);
        }

      
        private void Button_Click_Vissoorten(object sender, RoutedEventArgs e)
        {
            bool? result = openFileDialog.ShowDialog();
            if (result == true)
            {
                var fileNames = openFileDialog.FileNames;
                VissoortenFileListBox.ItemsSource = fileNames;
                openFileDialog.FileName = null;
                processor = new FileProcessor();
            }
        }

        private void Button_Click_UploadVissoorten(object sender, RoutedEventArgs e)
        {
            foreach (string fileName in VissoortenFileListBox.ItemsSource) {
                vm.UploadVissoorten(fileName);
            }
            MessageBox.Show("Upload Klaar", "VisStats");
        }

        private void Button_Click_Statistieken(object sender, RoutedEventArgs e)
        {
            bool? result = openFileDialog.ShowDialog();
            if (result == true)
            {
                var filenames = openFileDialog.FileNames;
                StatistiekenFileListBox.ItemsSource = filenames;
                openFileDialog.FileName = null;
            }
            else StatistiekenFileListBox.ItemsSource = null;
        }

        private void Button_Click_UploadStatistieken(object sender, RoutedEventArgs e)
        {
            foreach (string filename in StatistiekenFileListBox.ItemsSource)
            {
                vm.UploadStatistieken(filename);
            }
            MessageBox.Show("Upload klaar", "VisStats");
        }

        private void Button_Click_UploadHaven(object sender, RoutedEventArgs e)
        {
            foreach (string filename in HavenFileListBox.ItemsSource)
            {
                vm.UploadHaven(filename);
            }
            MessageBox.Show("Upload klaar", "VisStats");
        }

        private void Button_Click_Haven(object sender, RoutedEventArgs e)
        {
            bool? result = openFileDialog.ShowDialog();
            if (result == true)
            {
                var filenames = openFileDialog.FileNames;
                HavenFileListBox.ItemsSource = filenames;
                openFileDialog.FileName = null;
            }
            else StatistiekenFileListBox.ItemsSource = null;
        }
    }
}
