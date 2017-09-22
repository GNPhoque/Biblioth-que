using Bibliothèque.ViewModel;
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

namespace Bibliothèque.Views
{
    /// <summary>
    /// Logique d'interaction pour MFilm.xaml
    /// </summary>
    public partial class MFilm : UserControl
    {
        public MFilm()
        {
            InitializeComponent();
            //AccesClients dao = new AccesClients();
            //lvFilms.ItemsSource = dao.readTxtFilms();     //uncomment this to reas from txtfile
        }
        
    }
}
