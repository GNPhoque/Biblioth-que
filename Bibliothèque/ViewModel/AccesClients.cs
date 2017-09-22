using Bibliothèque.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bibliothèque.ViewModel
{
    class AccesClients
    {
        public List<Clients> listeClients { get; set; }
        public List<Films> listeFilms { get; set; }
        public List<Livres> listeLivres { get; set; }

        public AccesClients()
        {
            BibliothèqueEntities cx = new BibliothèqueEntities();
            List<Clients> lClients = new List<Clients>();
            foreach (var item in cx.Clients)
            {
                lClients.Add(item);
            }
            List<Films> lFilms = new List<Films>();
            foreach (var item in cx.Films)
            {
                lFilms.Add(item);
            }
            List<Livres> lLivres = new List<Livres>();
            foreach (var item in cx.Livres)
            {
                lLivres.Add(item);
            }
            listeClients = lClients;
            listeFilms = lFilms;
            listeLivres = lLivres;
        }

        public void RefreshListeClients()
        {
            BibliothèqueEntities cx = new BibliothèqueEntities();
            List<Clients> lClients = new List<Clients>();
            foreach (var item in cx.Clients)
            {
                lClients.Add(item);
            }
            listeClients = lClients;
        }

        public List<Films> readTxtFilms()
        {
            List<Films> lFilms = new List<Films>();
            string[] s = File.ReadAllLines(@".\..\..\Resources\films.txt");
            foreach (var item in s)
            {
                string[] split = item.Split('|');
                Films f = new Films() { id_film = int.Parse(split[0]), titre = split[1], id_genre = int.Parse(split[2]), acteur_p=split[3]};
                lFilms.Add(f);
            }
            listeFilms = lFilms;
            return listeFilms;
        }
    }
}
