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
    /// Logique d'interaction pour Reservation.xaml
    /// </summary>
    public partial class Reservation : UserControl
    {
        AccesClients dao = new AccesClients();
        public Reservation()
        {
            InitializeComponent();
            cbbClient.ItemsSource = dao.listeClients;
            cbbFilm.ItemsSource = dao.listeLivres;
            cbbLivres.ItemsSource = dao.listeLivres;
        }

        private void btnReserverFilm_Click(object sender, RoutedEventArgs e)
        {
            if (cbbClient.SelectedItem == null)
            {
                MessageBox.Show("Choisir un client");
            }
            else if (cbbLivres.SelectedItem == null)
            {
                MessageBox.Show("Choisir un Livre");
            }
            else
            {
                Clients cl = (Clients)cbbClient.SelectedValue;
                Films fl = (Films)cbbLivres.SelectedValue;
                DateTime date = DateTime.Today;
                DateTime date_r = date.AddDays(14);
                EmpruntsFilms em = new EmpruntsFilms() { id_client = cl.id_client, id_film = fl.id_film, date_emprunt_f = date, date_retour_f = date_r };
                BibliothèqueEntities cx = new BibliothèqueEntities();
                if (!cx.EmpruntsFilms.ToList().Exists(x=>x.id_client==em.id_client&&x.id_film==em.id_film&&x.date_emprunt_f==em.date_emprunt_f))
                {
                    try
                    {
                        cx.EmpruntsFilms.Add(em);
                        cx.SaveChanges();
                    }
                    catch (Exception)
                    {

                        MessageBox.Show("Erreur : " + e);
                    }
                    MessageBox.Show("Reservation confirmée");
                }
                else
                {
                    MessageBox.Show("Reservation existante");
                }
                
            }
        }

        private void btnReserverLivre_Click(object sender, RoutedEventArgs e)
        {
            if (cbbClient.SelectedItem == null)
            {
                MessageBox.Show("Choisir un client");
            }
            else if (cbbLivres.SelectedItem == null)
            {
                MessageBox.Show("Choisir un livre");
            }
            else
            {
                Clients cl = (Clients)cbbClient.SelectedValue;
                Livres fl = (Livres)cbbLivres.SelectedValue;
                DateTime date = DateTime.Today;
                DateTime date_r = date.AddDays(14);
                EmpruntsLivres em = new EmpruntsLivres() { id_client = cl.id_client, id_livre = fl.id_livre, date_emprunt_l = date, date_retour_l = date_r };
                BibliothèqueEntities cx = new BibliothèqueEntities();
                if (!cx.EmpruntsLivres.ToList().Exists(x => x.id_client == em.id_client && x.id_livre == em.id_livre && x.date_emprunt_l == em.date_emprunt_l))
                {
                    try
                    {
                        cx.EmpruntsLivres.Add(em);
                        cx.SaveChanges();
                    }
                    catch (Exception)
                    {

                        MessageBox.Show("Erreur : " + e);
                    }
                    MessageBox.Show("Reservation confirmée");
                }
                else
                {
                    MessageBox.Show("Reservation existante");
                }

            }
        }
    }
}
