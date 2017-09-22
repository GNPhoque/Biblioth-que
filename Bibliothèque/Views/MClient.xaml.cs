using Bibliothèque.Model;
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
    /// Logique d'interaction pour MClient.xaml
    /// </summary>
    public partial class MClient : UserControl
    {
        AccesClients dao = new AccesClients();
        public MClient()
        {
            InitializeComponent();
        }

        private void btnAjouter_Click(object sender, RoutedEventArgs e)
        {
            Clients cl = new Clients() { nom=txtNom.Text,prenom=txtPrenom.Text,adresse=txtAdresse.Text,telephone=txtTel.Text};
            if (dao.listeClients.Exists(x=>x.nom==txtNom.Text && x.prenom==txtPrenom.Text && x.adresse==txtAdresse.Text))
            {
                MessageBox.Show("Client existant");
            }
            else
            {
                BibliothèqueEntities cx = new BibliothèqueEntities();
                try
                {
                    cx.Clients.Add(cl);
                    cx.SaveChanges();
                }
                catch (Exception)
                {

                    MessageBox.Show("Erreur insertion");
                }
                MessageBox.Show("Client ajouté");
                dao.RefreshListeClients();
                dgClients.ItemsSource = dao.listeClients;
            }
        }

        private void dgClients_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (dgClients.SelectedItem != null)
            {
                Clients cl = new Clients();
                cl = (Clients)dgClients.SelectedItem;
                lblIdSelec.Content = cl.id_client;
                txtNom.Text = cl.nom;
                txtPrenom.Text = cl.prenom;
                txtAdresse.Text = cl.adresse;
                txtTel.Text = cl.telephone;
            }
        }

        private void btnModifier_Click(object sender, RoutedEventArgs e)
        {
            BibliothèqueEntities cx = new BibliothèqueEntities();
            Clients cl = new Clients();
            var req = from x in cx.Clients where x.id_client == (int)lblIdSelec.Content select x;
            req.First().nom = txtNom.Text;
            req.First().prenom = txtPrenom.Text;
            req.First().adresse = txtAdresse.Text;
            req.First().telephone = txtTel.Text;
            cx.SaveChanges();
            dao.RefreshListeClients();
            dgClients.ItemsSource = dao.listeClients;
            MessageBox.Show("Modification confirmeée");
        }
    }
}
