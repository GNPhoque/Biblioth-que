using Bibliothèque.Views;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Bibliothèque
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        
        private void btnReservation_Click(object sender, RoutedEventArgs e)
        {
            contentControl.Content = new Reservation();
        }

        private void btnClients_Click(object sender, RoutedEventArgs e)
        {
            contentControl.Content = new MClient();
        }

        private void btnLivres_Click(object sender, RoutedEventArgs e)
        {
            contentControl.Content = new MLivres();
        }

        private void btnFilms_Click(object sender, RoutedEventArgs e)
        {
            contentControl.Content = new MFilm();
        }
    }
}
