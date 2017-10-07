using CouchesAccèsBD;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoucheMetier
{
    class Joueur
    {
        public int num_joueur { get; set; }
        public string nom_joueur { get; set; }
        public string prenom_joueur { get; set; }
        public string classement { get; set; }

       
       


        public Joueur()
        {
        }

        public Joueur(Joueur joueur)
        {
            num_joueur = joueur.num_joueur;
            nom_joueur = joueur.nom_joueur;
            prenom_joueur = joueur.prenom_joueur;
            classement = joueur.classement;
     
        }

        public Joueur(int Num_joueur, string Nom_joueur, string Prenom_joueur, string Classement)
        {
            num_joueur = Num_joueur;
            nom_joueur = Nom_joueur;
            prenom_joueur = Prenom_joueur;
            classement = Classement;
      
        }

    }
}
