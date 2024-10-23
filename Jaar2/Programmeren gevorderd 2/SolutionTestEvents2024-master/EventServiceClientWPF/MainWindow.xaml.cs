using EventServiceClientWPF.Model;
using EventServiceClientWPF.Services;
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

namespace EventServiceClientWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private EventService eventService;
        public MainWindow()
        {
            InitializeComponent();
            eventService = new EventService();
        }

        private async void EventButton_Click(object sender, RoutedEventArgs e)
        {
            string Name=EventNameTextBox.Text;
            Event ev=await eventService.GetEventAsync($"api/event/{Name}");
            SelectedEventTextBox.Text=ev.ToString();
        }
    }
}